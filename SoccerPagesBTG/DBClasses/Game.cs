using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using MongoDB.Bson.Serialization;

namespace SoccerPagesBTG.DBClasses
{
    public class Game
    {
        private static readonly string conn_str = Properties.Settings.Default.mongoDbConnect;
        private static readonly string db_str = Properties.Settings.Default.db;


        [BsonId]
        public ObjectId Id { get; set; }

        [BsonElement("HomeTeam")]
        public string HomeTeam { get; set; }

        [BsonElement("HomeScore")]
        public int HomeScore { get; set; }

        [BsonElement("AwayTeam")]
        public string AwayTeam { get; set; }

        [BsonElement("AwayScore")]
        public int AwayScore { get; set; }

        [BsonElement("Location")]
        public string Location { get; set; }

        [BsonElement("GameDate")]
        public DateTime GameDate { get; set; }

        [BsonElement("GameTime")]
        public string GameTime { get; set; }

        [BsonElement("REF1")]
        public string Ref1 { get; set; }

        [BsonElement("REF2")]
        public string Ref2 { get; set; }

        [BsonElement("REF3")]
        public string Ref3 { get; set; }

        [BsonElement("NotificationOn")]
        public string Notification { get; set; }


        public static void CreateDBRecord(Game g)
        {
            MongoClient client = new MongoClient(conn_str);
            var db = client.GetDatabase(db_str);
            var collection = db.GetCollection<Game>("Games");
            collection.InsertOne(g);
        }

        public static List<Game> GetAllGames()
        {
            MongoClient client = new MongoClient(conn_str);
            var db = client.GetDatabase(db_str);
            var collection = db.GetCollection<Game>("Games");

            var filter = Builders<Game>.Filter.Empty;
            var games = collection.Find(filter).ToList();

            return games;
        }

        public static List<Game> GetAllTeamPlayedGames(string team)
        {
            MongoClient client = new MongoClient(conn_str);
            var db = client.GetDatabase(db_str);
            var collection = db.GetCollection<Game>("Games");

            var filter = Builders<Game>.Filter.And(
               Builders<Game>.Filter.Or(
                   Builders<Game>.Filter.Ne(g => g.HomeScore, -1),
                   Builders<Game>.Filter.Ne(g => g.AwayScore, -1)
               ),
               Builders<Game>.Filter.Or(
                   Builders<Game>.Filter.Eq(g => g.HomeTeam, team),
                   Builders<Game>.Filter.Eq(g => g.AwayTeam, team)
               )
           );

            var playedGames = collection.Find(filter).ToList();

            return playedGames;
        }

        public static int[] GetTeamRecord(string t)
        {

            List<Game> games = GetAllTeamPlayedGames(t);

            int w=0, l=0, d=0;
            foreach(var game in games)
            {
                if(game.HomeTeam == t)
                {
                    if (game.HomeScore > game.AwayScore) w++;
                    else if (game.HomeScore < game.AwayScore) l++;
                    else d++;
                }
                if(game.AwayTeam == t)
                {
                    if (game.HomeScore > game.AwayScore) l++;
                    else if (game.HomeScore < game.AwayScore) w++;
                    else d++;
                }
            }
            int[] record = { w, l, d };
            return record;
        }

        public static List<Game> GetGamesByDate(DateTime dt)
        {
            MongoClient client = new MongoClient(conn_str);
            var db = client.GetDatabase(db_str);
            var collection = db.GetCollection<Game>("Games");

            // Convert the input DateTime to UTC to ensure consistency
            DateTime utcDate = TimeZoneInfo.ConvertTimeToUtc(dt);

            // Construct the filter to find games within the specified date

            var filter = Builders<Game>.Filter.And(
                Builders<Game>.Filter.Gte(g => g.GameDate, utcDate.Date.AddDays(-.5)),
                Builders<Game>.Filter.Lte(g => g.GameDate, utcDate.Date.AddDays(.5))
            );

            List<Game> games = collection.Find(filter).ToList();
            return games;
        }

        public static (string ConflictType, string ConflictingItem) CheckSchedulingConflicts(Game g1, Game g2)
        {
            if (g1.GameDate == g2.GameDate && g1.GameTime == g2.GameTime)
            {
                if (string.Equals(g1.Location, g2.Location, StringComparison.OrdinalIgnoreCase)) { return ("Location", g1.Location); }

                if (TeamConflict(g1.HomeTeam, g2)) { return ("Team", g1.HomeTeam); }
                if (TeamConflict(g1.AwayTeam, g2)) { return ("Team", g1.AwayTeam); }

                if (RefereeConflict(g1.Ref1, g2)) { return ("Referee", g1.Ref1); }
                if (RefereeConflict(g1.Ref2, g2)) { return ("Referee", g1.Ref2); }
                if (RefereeConflict(g1.Ref3, g2)) { return ("Referee", g1.Ref3); }
            }
            return ("None", null);
        }

        private static bool TeamConflict(string team, Game game)
        {
            return string.Equals(team, game.HomeTeam, StringComparison.OrdinalIgnoreCase) ||
                   string.Equals(team, game.AwayTeam, StringComparison.OrdinalIgnoreCase);
        }

        private static bool RefereeConflict(string referee, Game game)
        {
            return !string.IsNullOrEmpty(referee) &&
                   (string.Equals(referee, game.Ref1, StringComparison.OrdinalIgnoreCase) ||
                    string.Equals(referee, game.Ref2, StringComparison.OrdinalIgnoreCase) ||
                    string.Equals(referee, game.Ref3, StringComparison.OrdinalIgnoreCase));
        }
    }
}
