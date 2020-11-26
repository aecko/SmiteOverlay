using System;
using System.Collections.Generic;
using System.Linq;
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
using System.Text.RegularExpressions;
using System.Runtime.InteropServices;
using System.Windows.Interop;

namespace SmiteOverlay
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.Top = Utility.windowLocationY;
            this.Left = Utility.windowLocationX;
            ApiUtility.createSession();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            
            if (e.ChangedButton == MouseButton.Left && !Utility.overlayLocked)
                this.DragMove();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Utility.username = UserName_Textbox.Text;
            ApiUtility.Player player = ApiUtility.getPlayerInfo(Utility.username);
            if (UserName_Textbox.Text != "")
            {
                if (player != null)
                {
                    Utility.player = player;
                    string usernameFormatted = Regex.Replace(UserName_Textbox.Text, @"\s+", "");
                    if (usernameFormatted != "")
                    {
                        new ProfilePage(player).Show();
                        this.Close();
                    }
                }
            }
        }

        /*
        private void Window_Deactivated(object sender, EventArgs e)
        {
            this.Topmost = true;
            this.Activate();
        }
        */

        private void Window_Activated(object sender, EventArgs e)
        {
            if (!Utility.overlayLocked)
            {
                this.Top = Utility.windowLocationY;
                this.Left = Utility.windowLocationX;
                this.Topmost = true;
                UserName_Textbox.Text = "";
            }
        }

        private void Window_LocationChanged(object sender, EventArgs e)
        {
            Utility.windowLocationX = (int)this.Left;
            Utility.windowLocationY = (int)this.Top;
        }
    }
}
