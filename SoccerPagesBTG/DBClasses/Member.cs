using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using System;
using System.Linq;


namespace SoccerPagesBTG.DBClasses
{
    class Member
    {
        private static readonly string conn_str = "mongodb+srv://test:test@testdb.ygmwifa.mongodb.net/";
        private static readonly string db_str = "BTG_DB";

        [BsonId]
        public ObjectId Id { get; set; }

        [BsonElement("First_name")]
        public string First_name { get; set; }

        [BsonElement("Last_name")]
        public string Last_name { get; set; }

        [BsonElement("TeamId")]
        public string TeamId { get; set; }

        [BsonElement("IsPlayer")]
        public bool IsPlayer { get; set; }

        [BsonElement("IsRef")]
        public bool IsRef { get; set; }

        [BsonElement("EligibleToPlay")]
        public DateTime EligibleDate { get; set; }

        public Member() { }



        internal static string GetIdByName(string fname, string lname)
        {
            MongoClient client = new MongoClient(conn_str);
            var db = client.GetDatabase(db_str);
            var collection = db.GetCollection<Member>("Members");

            var filter = Builders<Member>.Filter.Eq("First_name", fname) & Builders<Member>.Filter.Eq("Last_name", lname);

            var member = collection.Find(filter).FirstOrDefault();
            return member.Id.ToString();
        }

        internal static string[] GetNameById(string Id)
        {
            string[] name = new string[2];

            MongoClient client = new MongoClient(conn_str);
            var db = client.GetDatabase(db_str);
            var collection = db.GetCollection<Member>("Members");

            ObjectId memberId = new ObjectId(Id);

            var filter = Builders<Member>.Filter.Eq("_id", memberId);
            var member = collection.Find(filter).FirstOrDefault();

            name[0] = member.First_name;
            name[1] = member.Last_name;
            return name;
        }

        public static List<string> GetPlayersWithoutTeams()
        {
            MongoClient client = new MongoClient(conn_str);
            var db = client.GetDatabase(db_str);
            var collection = db.GetCollection<Member>("Members");
            
            var filter = Builders<Member>.Filter.Eq("TeamId", "") & Builders<Member>.Filter.Eq("IsPlayer", true);
            var membersWithNullTeam = collection.Find(filter).ToList();

            return membersWithNullTeam.Select(member => $"{member.Last_name}, {member.First_name}").ToList();
        }

        public static void CreateMember(Member m)
        {
            MongoClient client = new MongoClient(conn_str);
            var db = client.GetDatabase(db_str);
            var collection = db.GetCollection<Member>("Members");

            collection.InsertOne(m);
        }

        public static void UpdateMember(Member m)
        {
            MongoClient client = new MongoClient(conn_str);
            var db = client.GetDatabase(db_str);
            var collection = db.GetCollection<Member>("Members");

            var filter = Builders<Member>.Filter.Eq(s => s.Id, m.Id);
            var result = collection.ReplaceOne(filter, m);
        }

        public static Member GetMemberById(string id)
        {
            MongoClient client = new MongoClient(conn_str);
            var db = client.GetDatabase(db_str);
            var collection = db.GetCollection<Member>("Members");
            return collection.Find(member => member.Id == ObjectId.Parse(id)).FirstOrDefault();
        }

        public static List<string> GetAllMembers()
        {
            MongoClient client = new MongoClient(conn_str);
            var db = client.GetDatabase(db_str);
            var collection = db.GetCollection<Member>("Members");

            List<Member> members = collection.Find(_ => true).ToList();
            return members.Select(member => $"{member.Last_name}, {member.First_name}").ToList();
        }

        public static List<string> GetReferees()
        {
            MongoClient client = new MongoClient(conn_str);
            var db = client.GetDatabase(db_str);
            var collection = db.GetCollection<Member>("Members");

            var filter = Builders<Member>.Filter.Eq("TeamId", "") & Builders<Member>.Filter.Eq("IsRef", true);
            var referees = collection.Find(filter).ToList();
            return referees.Select(referee => $"{referee.Last_name}, {referee.First_name}").ToList();
        }

    }
}
