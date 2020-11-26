using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmiteOverlay
{
    class Utility
    {
        public static int windowLocationX, windowLocationY = 300;
        public static string username = "";
        public static int? usernameID;

        public static ApiUtility.Player player;
        public static ApiUtility.PlayerStatus playerStatus;

        public static string currentGod = "";
        public static int currentTeam = 0;

        public static List<ApiUtility.MatchPlayerDetails> matchPlayerDetails = new List<ApiUtility.MatchPlayerDetails>();

        public static List<string> playerNamesTeam1 = new List<string>();
        public static List<string> playerNamesTeam2 = new List<string>();

        public static List<ApiUtility.Player> Team1Players = new List<ApiUtility.Player>();
        public static List<ApiUtility.Player> Team2Players = new List<ApiUtility.Player>();

        public static bool overlayLocked = false;


    }
}
