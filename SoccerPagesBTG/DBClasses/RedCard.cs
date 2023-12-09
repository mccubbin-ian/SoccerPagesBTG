using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;

namespace SoccerPagesBTG.DBClasses
{
    class RedCard
    {
        private static readonly string conn_str = Properties.Settings.Default.mongoDbConnect;
        private static readonly string db_str = Properties.Settings.Default.db;

        [BsonId]
        public ObjectId Id { get; set; }

        [BsonElement("GameId")]
        public string GameId { get; set; }
        [BsonElement("Team")]
        public string Team { get; set; }
        [BsonElement("PlayerID")]
        public string Player { get; set; }
        [BsonElement("OffenseCode")]
        public string Violation { get; set; }
        [BsonElement("Description")]
        public string Description { get; set; }
        [BsonElement("Decision")]
        public string Decision { get; set; }

        public static void CreateRedCardReport(RedCard r)
        {
            var client = new MongoClient(conn_str);
            var database = client.GetDatabase(db_str);
            var collection = database.GetCollection<RedCard>("Red_Cards");

            collection.InsertOne(r);
        }

        public static void UpdateRedCardReport(RedCard r)
        {
            try
            {
                var client = new MongoClient(conn_str);
                var db = client.GetDatabase(db_str);
                var collection = db.GetCollection<RedCard>("Red_Cards");

                var filter = Builders<RedCard>.Filter.Eq(s => s.Id, r.Id);
                var result = collection.ReplaceOne(filter, r);
            }
            finally
            { }
        }

        public static List<RedCard> GetRedCardsByGameId(string id)
        {
            var client = new MongoClient(conn_str);
            var database = client.GetDatabase(db_str);
            var collection = database.GetCollection<RedCard>("Red_Cards");

            var filter = Builders<RedCard>.Filter.Eq("GameId", id);
            var redCards = collection.Find(filter).ToList();

            return redCards;
        }

        public static RedCard GetRedCardById(string id)
        {
            var client = new MongoClient(conn_str);
            var database = client.GetDatabase(db_str);
            var collection = database.GetCollection<RedCard>("Red_Cards");

            var filter = Builders<RedCard>.Filter.Eq("_id", ObjectId.Parse(id));
            var redCard = collection.Find(filter).FirstOrDefault();

            return redCard;
        }

    }
}
