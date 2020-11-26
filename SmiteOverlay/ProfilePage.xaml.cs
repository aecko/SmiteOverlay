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

namespace SmiteOverlay
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class ProfilePage : Window
    {
        public ProfilePage(ApiUtility.Player player)
        {
            InitializeComponent();
            this.Top = Utility.windowLocationY;
            this.Left = Utility.windowLocationX;
            displayStats(player);
        }

        private void displayStats(ApiUtility.Player player)
        {
            if (player != null)
            {
                Utility.usernameID = player.Id;
                UsernameValue_Label.Text = player.Name;
                UserMessageValue_Label.Text = player.Personal_Status_Message;
                TotalWinsValue_Label.Content = (player.Wins).ToString();
                TotalLossesValue_Label.Content = (player.Losses).ToString();
                HoursPlayedValue_Label.Content = (player.HoursPlayed).ToString();
                MasteryLevelsValue_Label.Content = (player.MasteryLevel).ToString();



                float winPercent = ((float)player.Wins / ((float)player.Wins + (float)player.Losses)) * 100;
                WinRatioValue_Label.Content = winPercent.ToString("#.##") + "%";

                /*
                if (player.Avatar_URL != "" || player.Avatar_URL != null)
                {
                    var imgUrl = new Uri(player.Avatar_URL);
                    var imageData = new WebClient().DownloadData(imgUrl);

                    // or you can download it Async won't block your UI
                    // var imageData = await new WebClient().DownloadDataTaskAsync(imgUrl);

                    var bitmapImage = new BitmapImage { CacheOption = BitmapCacheOption.OnLoad };
                    bitmapImage.BeginInit();
                    bitmapImage.StreamSource = new MemoryStream(imageData);
                    bitmapImage.EndInit();

                    Avatar_Img.Source = bitmapImage;
                }
                */
            }
            else
            {
                this.Close();
            }

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
            new MainWindow().Show();
            this.Close();
        }

        private void StartMatch_Button_Click(object sender, RoutedEventArgs e)
        {
            ApiUtility.PlayerStatus playerStatus = ApiUtility.getPlayerStatus()[0];
            if (playerStatus.status == 3)
            {
                Utility.playerStatus = playerStatus;
                new MatchInfo().Show();
                this.Hide();
            }
            else
            {
                InGameInfo_Label.Foreground = Brushes.Red;
                InGameInfo_Label.Content = "Game Not Found";
            }
        }
    }
}
