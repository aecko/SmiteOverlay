using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Security.Cryptography;
using System.Net;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Web.Script.Serialization;
using System.IO;
using System.Timers;


namespace SmiteOverlay
{
    public class ApiUtility
    {
        static string devKey = ApiConfig.DevId;
        static string authKey = ApiConfig.AuthKey;
        static string timestamp = DateTime.UtcNow.ToString("yyyyMMddHHmmss");
        static string urlPrefix = "http://api.smitegame.com/smiteapi.svc/";


        private static string signature = "";
        private static string session = "";

        private static System.Timers.Timer aTimer;



        private static string GetMD5Hash(string input)
        {
            var md5 = new MD5CryptoServiceProvider();
            var bytes = Encoding.UTF8.GetBytes(input);
            bytes = md5.ComputeHash(bytes);
            var sb = new StringBuilder();
            foreach (byte b in bytes)
            {
                sb.Append(b.ToString("x2").ToLower());
            }
            return sb.ToString();
        }

        private static string generateSignature(string methodName)
        {
            return (GetMD5Hash(devKey + methodName + authKey + timestamp));
        }

        private static string httpRequest(string url)
        {
            // Call the "createsession" API method & wait for synchronous response
            //
            try
            {
                WebRequest request = WebRequest.Create(url);
                WebResponse response = request.GetResponse();

                Stream dataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream);

                string responseFromServer = reader.ReadToEnd();


                reader.Close();
                response.Close();
                return responseFromServer;
            }
            catch (Exception)
            {
                MessageBox.Show("404 Error Recieved. Please check DevID and AuthKey.");
                Environment.Exit(0);
                return null;
            }
        }

        public static void createSession()
        {
            signature = generateSignature("createsession");
            string requestURL = urlPrefix + "createsessionjson/" + devKey + "/" + signature + "/" + timestamp;

            string responseFromServer = httpRequest(requestURL);

            // Parse returned JSON into "session" data
            //
            using (var web = new WebClient())
            {
                web.Encoding = System.Text.Encoding.UTF8;
                var jsonString = responseFromServer;
                var jss = new JavaScriptSerializer();
                var g = jss.Deserialize<SessionInfo>(jsonString);

                session = g.session_id;
                SetTimer();

            }
        }

        private static void SetTimer()
        {
            aTimer = new System.Timers.Timer(840000);
            // Hook up the Elapsed event for the timer. 
            aTimer.Elapsed += OnTimedEvent;
            aTimer.AutoReset = false;
            aTimer.Enabled = true;
            aTimer.Start();
        }

        private static void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            createSession();
        }


        public static string getGods()
        {
            string godList = "";
            // Get Signature that is specific to "getgods"
            //
            signature = GetMD5Hash(devKey + "getgods" + authKey + timestamp);

            // Call the "getgods" API method & wait for synchronous response
            //
            string languageCode = "1";
            string requestURL = urlPrefix + "getgodsjson/" + devKey + "/" + signature + "/" + session + "/" + timestamp + "/" + languageCode;
            string responseFromServer = httpRequest(requestURL);


            // Parse returned JSON into "gods" data
            //
            using (var web = new WebClient())
            {
                web.Encoding = System.Text.Encoding.UTF8;
                var jsonString = responseFromServer;
                var jss = new JavaScriptSerializer();
                var GodsList = jss.Deserialize<List<Gods>>(jsonString);

                foreach (Gods x in GodsList)
                    godList = godList + ", " + x.Name;

            }
            return godList;
        }

        public static Player getPlayerInfo(string playerName)
        {
            // Get Signature that is specific to "getplayer"
            signature = GetMD5Hash(devKey + "getplayer" + authKey + timestamp);

            // Call the "getplayer" API method & wait for synchronous response
            string requestURL = urlPrefix + "getplayerjson/" + devKey + "/" + signature + "/" + session + "/" + timestamp + "/" + playerName;
            string responseFromServer = httpRequest(requestURL);


            // Parse returned JSON into "player" data
            using (var web = new WebClient())
            {
                web.Encoding = System.Text.Encoding.UTF8;
                var jsonString = responseFromServer;
                var jss = new JavaScriptSerializer();
                var PlayerInfo = jss.Deserialize<List<Player>>(jsonString);

                if (PlayerInfo.Count == 0)
                {
                    return null;
                }
                else
                {
                    return PlayerInfo[0];
                }
            }

        }

        public static List<PlayerStatus> getPlayerStatus()
        {
            // Get Signature that is specific to "getplayer"
            signature = GetMD5Hash(devKey + "getplayerstatus" + authKey + timestamp);

            // Call the "getplayer" API method & wait for synchronous response
            string requestURL = urlPrefix + "getplayerstatusjson/" + devKey + "/" + signature + "/" + session + "/" + timestamp + "/" + Utility.usernameID;
            string responseFromServer = httpRequest(requestURL);

            // Parse returned JSON into "player" data
            using (var web = new WebClient())
            {
                web.Encoding = System.Text.Encoding.UTF8;
                var jsonString = responseFromServer;
                var jss = new JavaScriptSerializer();
                var PlayerStatus = jss.Deserialize<List<PlayerStatus>>(jsonString);

                return PlayerStatus;
            }
        }
        
        public static List<MatchPlayerDetails> getLiveMatchDetails(string matchID) {
            // Get Signature that is specific to "getplayer"
            signature = GetMD5Hash(devKey + "getmatchplayerdetails" + authKey + timestamp);

            // Call the "getplayer" API method & wait for synchronous response
            string requestURL = urlPrefix + "getmatchplayerdetailsjson/" + devKey + "/" + signature + "/" + session + "/" + timestamp + "/" + matchID;
            string responseFromServer = httpRequest(requestURL);

            // Parse returned JSON into "player" data
            using (var web = new WebClient())
            {
                web.Encoding = System.Text.Encoding.UTF8;
                var jsonString = responseFromServer;
                var jss = new JavaScriptSerializer();
                var MatchPlayerDetails = jss.Deserialize<List<MatchPlayerDetails>>(jsonString);

                return MatchPlayerDetails;
            }
        }

        public class PlayerStatus
        {
            public string Match { get; set; }
            public string match_queue_id { get; set; }
            public string personal_status_message { get; set; }
            public string ret_msg { get; set; }
            public int status { get; set; }
            public string status_string { get; set; }
        }

        public class MatchPlayerDetails
        {
            public int Account_Gods_Played { get; set; }
            public int Account_Level { get; set; }
            public int GodId { get; set; }
            public int GodLevel { get; set; }
            public string GodName { get; set; }
            public int Mastery_Level { get; set; }
            public string Match { get; set; }
            public string Queue { get; set; }
            public string Rank_Stat { get; set; }
            public int SkinId { get; set; }
            public int Tier { get; set; }
            public string mapGame { get; set; }
            public string playerCreated { get; set; }
            public string playerId { get; set; }
            public string playerName { get; set; }
            public string playerRegion { get; set; }
            public string ret_msg { get; set; }
            public int taskForce { get; set; }
            public string tierLosses { get; set; }
            public string tierWins { get; set; }
        }

        public class QueueMatchDetails
        {
            public string Active_Flag { get; set; }
            public string Match { get; set; }
            public string ret_msg { get; set; }
        }

        public class SessionInfo
        {
            public string ret_msg { get; set; }
            public string session_id { get; set; }
            public string timestamp { get; set; }

        }

        public class Menuitem
        {
            public string description { get; set; }
            public string value { get; set; }
        }

        public class Rankitem
        {
            public string description { get; set; }
            public string value { get; set; }
        }

        public class AbilityDescription
        {
            public string description { get; set; }
            public string secondaryDescription { get; set; }
            public List<Menuitem> menuitems { get; set; }
            public List<Rankitem> rankitems { get; set; }
            public string cooldown { get; set; }
            public string cost { get; set; }
        }

        public class AbilityRoot
        {
            public AbilityDescription itemDescription { get; set; }
        }

        public class Gods
        {
            public int abilityId1 { get; set; }
            public int abilityId2 { get; set; }
            public int abilityId3 { get; set; }
            public int abilityId4 { get; set; }
            public int abilityId5 { get; set; }
            public AbilityRoot abilityDescription1 { get; set; }
            public AbilityRoot abilityDescription2 { get; set; }
            public AbilityRoot abilityDescription3 { get; set; }
            public AbilityRoot abilityDescription4 { get; set; }
            public AbilityRoot abilityDescription5 { get; set; }
            public int id { get; set; }
            public string Pros { get; set; }
            public string Type { get; set; }
            public string Roles { get; set; }
            public string Name { get; set; }
            public string Title { get; set; }
            public string OnFreeRotation { get; set; }
            public string Lore { get; set; }
            public int Health { get; set; }
            public Double HealthPerLevel { get; set; }
            public Double Speed { get; set; }
            public Double HealthPerFive { get; set; }
            public Double HP5PerLevel { get; set; }
            public Double Mana { get; set; }
            public Double ManaPerLevel { get; set; }
            public Double ManaPerFive { get; set; }
            public Double MP5PerLevel { get; set; }
            public Double PhysicalProtection { get; set; }
            public Double PhysicalProtectionPerLevel { get; set; }
            public Double MagicProtection { get; set; }
            public Double MagicProtectionPerLevel { get; set; }
            public Double PhysicalPower { get; set; }
            public Double PhysicalPowerPerLevel { get; set; }
            public Double AttackSpeed { get; set; }
            public Double AttackSpeedPerLevel { get; set; }
            public string Pantheon { get; set; }
            public string Ability1 { get; set; }
            public string Ability2 { get; set; }
            public string Ability3 { get; set; }
            public string Ability4 { get; set; }
            public string Ability5 { get; set; }
            public string Item1 { get; set; }
            public string Item2 { get; set; }
            public string Item3 { get; set; }
            public string Item4 { get; set; }
            public string Item5 { get; set; }
            public string Item6 { get; set; }
            public string Item7 { get; set; }
            public string Item8 { get; set; }
            public string Item9 { get; set; }
            public int ItemId1 { get; set; }
            public int ItemId2 { get; set; }
            public int ItemId3 { get; set; }
            public int ItemId4 { get; set; }
            public int ItemId5 { get; set; }
            public int ItemId6 { get; set; }
            public int ItemId7 { get; set; }
            public int ItemId8 { get; set; }
            public int ItemId9 { get; set; }
            public string ret_msg { get; set; }
        }

        public class Player
        {
            public int? ActivePlayerId { get; set; }
            public string Avatar_URL { get; set; }
            public string Created_Datetime { get; set; }
            public int? HoursPlayed { get; set; }
            public int? Id { get; set; }
            public string Last_Login_Datetime { get; set; }
            public int? Leaves { get; set; }
            public int? Level { get; set; }
            public int? Losses { get; set; }
            public int? MasteryLevel { get; set; }
            //public string MergedPlayers { get; set; }
            public int? MinutesPlayed { get; set; }
            public string Name { get; set; }
            public string Personal_Status_Message { get; set; }
            public string Platform { get; set; }
            public Double? Rank_Stat_Conquest { get; set; }
            public Double? Rank_Stat_Conquest_Controller { get; set; }
            public Double? Rank_Stat_Duel { get; set; }
            public Double? Rank_Stat_Duel_Controller { get; set; }
            public Double? Rank_Stat_Joust { get; set; }
            public Double? Rank_Stat_Joust_Controller { get; set; }
            public GamemodeStats RankedConquest { get; set; }
            public GamemodeStats RankedConquestController { get; set; }
            public GamemodeStats RankedDuel { get; set; }
            public GamemodeStats RankedDuelController { get; set; }

            public GamemodeStats RankedJoust { get; set; }

            public string Region { get; set; }
            public int? TeamId { get; set; }
            public string Team_Name { get; set; }
            public int? Tier_Conquest { get; set; }
            public int? Tier_Duel { get; set; }
            public int Tier_Joust { get; set; }
            public int? Total_Achievements { get; set; }
            public int? Total_Worshippers { get; set; }
            public int? Wins { get; set; }
            public string hz_gamer_tag { get; set; }
            public string hz_player_name { get; set; }
            public string ret_msg { get; set; }
        }
        public class GamemodeStats
        {
            public int? Leaves { get; set; }
            public int? Losses { get; set; }
            public string Name { get; set; }
            public int? Points { get; set; }
            public int? PrevRank { get; set; }
            public int? Rank { get; set; }
            public Double? Rank_Stat { get; set; }
            public Double? Rank_Variance { get; set; }
            public string Season { get; set; }
            public string Tier { get; set; }
            public string Trend { get; set; }
            public int? Wins { get; set; }
            public int? player_id { get; set; }
            public string ret_msg { get; set; }
        }
    }
}
