using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using MongoDB.Bson.Serialization;
using MongoDB.Bson;

namespace SoccerPagesBTG.DBClasses
{
    public class Game
    {
        private static readonly string conn_str = "mongodb+srv://test:test@testdb.ygmwifa.mongodb.net/";
        private static readonly string db_str = "BTG_DB";

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

        [BsonElement("GameTime")]
        public DateTime Time { get; set; }

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

        public static List<Game> GetAllPlayedGames(string t)
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
                   Builders<Game>.Filter.Eq(g => g.HomeTeam, t),
                   Builders<Game>.Filter.Eq(g => g.AwayTeam, t)
               )
           );

            var playedGames = collection.Find(filter).ToList();

            return playedGames;
        }

        internal static int[] GetTeamRecord(string t)
        {

            List<Game> games = GetAllPlayedGames(t);

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

        internal static List<Game> GetGamesByDate(DateTime dt)
        {
            MongoClient client = new MongoClient(conn_str);
            var db = client.GetDatabase(db_str);
            var collection = db.GetCollection<Game>("Games");

            // Convert the input DateTime to UTC to ensure consistency
            DateTime utcDate = TimeZoneInfo.ConvertTimeToUtc(dt);

            // Construct the filter to find games within the specified date
            var filter = Builders<Game>.Filter.And(
                Builders<Game>.Filter.Gte(g => g.Time, utcDate.Date),
                Builders<Game>.Filter.Lt(g => g.Time, utcDate.Date.AddDays(1))
            );

            List<Game> games = collection.Find(filter).ToList();
            return games;
        }
    }
}
