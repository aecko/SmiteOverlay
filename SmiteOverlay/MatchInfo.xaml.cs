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
using System.Windows.Shapes;

namespace SmiteOverlay
{
    /// <summary>
    /// Interaction logic for MatchInfo.xaml
    /// </summary>
    public partial class MatchInfo : Window
    {
        
        public MatchInfo()
        {
            InitializeComponent();
            this.Top = Utility.windowLocationY;
            this.Left = Utility.windowLocationX;
            displayMatchDetails();
        }
        private void displayMatchDetails()
        {
            Utility.matchPlayerDetails = ApiUtility.getLiveMatchDetails(Utility.playerStatus.Match);
            List<ApiUtility.MatchPlayerDetails> matchPlayerDetails = Utility.matchPlayerDetails;

            int team1Counter = 0;
            int team2Counter = 0;

            for (int i = 0; i < matchPlayerDetails.Count; i++)
            {
                if (matchPlayerDetails[i].playerName == Utility.username)
                {
                    Utility.currentGod = matchPlayerDetails[i].GodName;
                    Utility.currentTeam = matchPlayerDetails[i].taskForce;
                }
                if (matchPlayerDetails[i].taskForce == 1)
                {
                    team1Counter += 1;
                    var labelName = string.Format("Team1_Player{0}_Label", team1Counter);
                    var label = (Label)this.FindName(labelName);
                    label.IsEnabled = true;
                    label.Content = matchPlayerDetails[i].GodName;

                    var labelNameLevel = string.Format("Team1_Player{0}_Level_Label", team1Counter);
                    var labelLevel = (Label)this.FindName(labelNameLevel);
                    labelLevel.Content = matchPlayerDetails[i].Account_Level;
                    Utility.playerNamesTeam1.Add(matchPlayerDetails[i].playerName);

                }
                else
                {
                    team2Counter += 1;
                    var labelName = string.Format("Team2_Player{0}_Label", team2Counter);
                    var label = (Label)this.FindName(labelName);
                    label.IsEnabled = true;
                    label.Content = matchPlayerDetails[i].GodName;

                    var labelNameLevel = string.Format("Team2_Player{0}_Level_Label", team2Counter);
                    var labelLevel = (Label)this.FindName(labelNameLevel);
                    labelLevel.Content = matchPlayerDetails[i].Account_Level;
                    Utility.playerNamesTeam2.Add(matchPlayerDetails[i].playerName);
                }
            }
        }
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            new Items(Utility.currentGod, this).Show();
            this.Hide();
        }

        private void GoBack_Button_Click(object sender, RoutedEventArgs e)
        {
            new ProfilePage(Utility.player).Show();
            this.Close();
        }

        private void PlayerName_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ApiUtility.Player selectedPlayer = null;

            if ((String)((Label)sender).Content != "")

            {
                string nameOfLabel = ((Label)sender).Name;
                List<int> teamAndPlayer = new List<int>();
                for (int i = 0; i < nameOfLabel.Length; i++)
                {
                    if (Char.IsDigit(nameOfLabel[i]))
                    {
                        if (teamAndPlayer.Count == 0)
                        {
                            teamAndPlayer.Add(int.Parse(nameOfLabel[i].ToString()));
                        }
                        else
                        {
                            teamAndPlayer.Add(int.Parse(nameOfLabel[i].ToString()) - 1);
                        }
                    }
                }

                if (teamAndPlayer[0] == 1)
                {
                    selectedPlayer = ApiUtility.getPlayerInfo(Utility.playerNamesTeam1[teamAndPlayer[1]]);
                }
                if (teamAndPlayer[0] == 2)
                {
                    selectedPlayer = ApiUtility.getPlayerInfo(Utility.playerNamesTeam2[teamAndPlayer[1]]);
                }

                if (selectedPlayer != null)
                {
                    new SelectedPlayerProfile(selectedPlayer, this).Show();
                    this.Hide();
                }
            }
        }
    }
}
