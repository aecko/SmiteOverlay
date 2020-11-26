using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using HtmlAgilityPack;

namespace SmiteOverlay
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Items : Window
    {
        MatchInfo matchInfo = null;
        public Items(string currentGod, MatchInfo itemsWindow)
        {
            InitializeComponent();
            this.Top = Utility.windowLocationY;
            this.Left = Utility.windowLocationX;
            matchInfo = itemsWindow;
            SetItemImages(currentGod);
        }

        private void SetItemImages(string currentGod)
        {
            List<SmiteGuruItem> items = GetMostPopularConquestItemImageLinks(currentGod);

            for(int i = 0; i < items.Count; i++)
            {
                var imageName = string.Format("Item{0}_Image", i + 1);
                var image = (Image)this.FindName(imageName);

                var imgUrl = new Uri(items[i].src);
                var imageData = new WebClient().DownloadData(imgUrl);

                // or you can download it Async won't block your UI
                // var imageData = await new WebClient().DownloadDataTaskAsync(imgUrl);

                var bitmapImage = new BitmapImage { CacheOption = BitmapCacheOption.OnLoad };
                bitmapImage.BeginInit();
                bitmapImage.StreamSource = new MemoryStream(imageData);
                bitmapImage.EndInit();

                image.Source = bitmapImage;
                image.ToolTip = new ToolTip { Content = items[i].altText };

            }
        }
        private List<SmiteGuruItem> GetMostPopularConquestItemImageLinks(string GodName)
        {
            if (GodName.Contains(" "))
                GodName = GodName.Replace(" ", "-");

            List<SmiteGuruItem> LinkList = new List<SmiteGuruItem>();

            WebClient webClient = new WebClient();
            string page = webClient.DownloadString("http://smite.guru/builds/" + GodName);

            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(page);

            HtmlNode node = doc.DocumentNode.SelectSingleNode("//div[@class='columns']");

            foreach (HtmlNode node2 in node.SelectNodes(".//div[@class='column col-sm-3 alt-items']"))
            {
                foreach (HtmlNode node3 in node2.SelectNodes(".//div[@class='primary-item']"))
                {
                    foreach (HtmlNode node4 in node3.SelectNodes(".//div[@class='item primary-item__img']"))
                    {
                        foreach (HtmlNode node5 in node4.SelectNodes(".//img[@src]"))
                        {
                            SmiteGuruItem item = new SmiteGuruItem();
                            item.altText = node5.Attributes["alt"].Value.Replace("//", "");
                            item.src = node5.Attributes["src"].Value;
                            HtmlAttribute altText = node5.Attributes["alt"];

                            string innertext = node5.Attributes["alt"].Value.Replace("//", "");

                            /*
                            // Check for ' code and replace it
                            if (innertext.Contains("&#039;"))
                                innertext = node3.InnerText.Replace("&#039;", "'");
                            */
                            //LinkList.Add("http://" + innertext);
                            LinkList.Add(item);
                        }
                    }
                }
            }
            

            // return the completed god list
            return LinkList;
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
        private void Window_Deactivated(object sender, EventArgs e)
        {
            this.Topmost = true;
            this.Activate();
        }

        private void Window_Activated(object sender, EventArgs e)
        {
            this.Top = Utility.windowLocationY;
            this.Left = Utility.windowLocationX;
            this.Topmost = true;
        }

        private void Window_LocationChanged(object sender, EventArgs e)
        {
            Utility.windowLocationX = (int)this.Left;
            Utility.windowLocationY = (int)this.Top;
        }

        private void BackToMain_Button_Click(object sender, RoutedEventArgs e)
        {
            matchInfo.Show();
            this.Close();
        }

        public class SmiteGuruItem
        {
            public string src { get; set; }
            public string altText { get; set; }
        }

    }
}
