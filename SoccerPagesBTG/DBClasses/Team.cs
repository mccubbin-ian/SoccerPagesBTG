using System.Collections.Generic;
using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Linq;

namespace SoccerPagesBTG.DBClasses
{
    public class Team
    {
        private static readonly string conn_str = Properties.Settings.Default.mongoDbConnect;
        private static readonly string db_str = Properties.Settings.Default.db;

        [BsonId]
        public ObjectId Id { get; set; }

        [BsonElement("Name")]
        public string Name { get; set; }

        [BsonElement("ManagerID")]
        public string ManagerID { get; set; }

        [BsonElement("CaptianID")]
        public string CaptainID { get; set; }

        public Team() { }

        public static void CreateTeam(Team t)
        {
            MongoClient client = new MongoClient(conn_str);
            var db = client.GetDatabase(db_str);
            var collection = db.GetCollection<Team>("Teams");

            collection.InsertOne(t);
        }

        public static void UpdateTeam(Team t)
        {
            MongoClient client = null;

            try
            {
                client = new MongoClient(conn_str);
                var db = client.GetDatabase(db_str);
                var collection = db.GetCollection<Team>("Teams");

                var filter = Builders<Team>.Filter.Eq(team => team.Id, t.Id);
                var result = collection.ReplaceOne(filter, t);
            }
            finally
            { }
        }

        public static Team GetTeambyId(string id)
        {
            if (id == string.Empty) { return null; }
            else
            {
                try
                {
                    MongoClient client = new MongoClient(conn_str);
                    var db = client.GetDatabase(db_str);
                    var collection = db.GetCollection<Team>("Teams");
                    var t = collection.Find(team => team.Id == ObjectId.Parse(id)).FirstOrDefault();
                    if (t == null) { return null; }
                    else return t;
                }
                catch (Exception)
                {
                    return null;
                }
            }
        }

        public static Team GetTeambyName(string n)
        {
            MongoClient client = new MongoClient(conn_str);
            var db = client.GetDatabase(db_str);
            var collection = db.GetCollection<Team>("Teams");

            var filter = Builders<Team>.Filter.Eq("Name", n);
            var team = collection.Find(filter).FirstOrDefault();
            return team;
        }

        public static List<string> GetRoster(string teamId)
        {
            MongoClient client = new MongoClient(conn_str);
            var db = client.GetDatabase(db_str);
            var collection = db.GetCollection<Member>("Members");
            var filter = Builders<Member>.Filter.And(
                Builders<Member>.Filter.Eq("TeamId", teamId),
                Builders<Member>.Filter.Eq("IsPlayer", true));

            var roster = collection.Find(filter).ToList();
            return roster.Select(player => $"{player.Last_name}, {player.First_name}").ToList();
        }

        internal static string GetIdByTeamName(string n)
        {
            MongoClient client = new MongoClient(conn_str);
            var db = client.GetDatabase(db_str);
            var collection = db.GetCollection<Team>("Teams");

            var filter = Builders<Team>.Filter.Eq("Name", n);
            var team = collection.Find(filter).FirstOrDefault();
            return team.Id.ToString();
        }

        internal static List<Team> GetTeams()
        {
            MongoClient client = new MongoClient(conn_str);
            var db = client.GetDatabase(db_str);
            var collection = db.GetCollection<Team>("Teams");

            List<Team> teams = collection.Find(_ => true).ToList();

            return teams;
        }

        internal static List<string> GetTeamNames()
        {
            MongoClient client = new MongoClient(conn_str);
            var db = client.GetDatabase(db_str);
            var collection = db.GetCollection<Team>("Teams");

            List<Team> teams = collection.Find(_ => true).ToList();

            return teams.Select(team => team.Name).ToList();
        }

        internal static string GetTeamNameById(string id)
        {
            if (id == string.Empty) { return string.Empty; }
            else
            {
                try
                {
                    MongoClient client = new MongoClient(conn_str);
                    var db = client.GetDatabase(db_str);
                    var collection = db.GetCollection<Team>("Teams");
                    var t = collection.Find(team => team.Id == ObjectId.Parse(id)).FirstOrDefault();
                    if (t == null) { return string.Empty; }
                    else return t.Name;
                } catch (Exception)
                {
                    return string.Empty;
                }
            }
        }
    }
}
