using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using System;
using System.Linq;


namespace SoccerPagesBTG.DBClasses
{
    public class Member
    {
        private static readonly string conn_str = Properties.Settings.Default.mongoDbConnect;
        private static readonly string db_str = Properties.Settings.Default.db;

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

        [BsonElement("IsScheduler")]
        public bool IsScheduler { get; set; }

        [BsonElement("IsAdmin")]
        public bool IsAdmin { get; set; }

        [BsonElement("EligibleToPlay")]
        public DateTime EligibleDate { get; set; }

        [BsonElement("email")]
        public string Email { get; set; }

        [BsonElement("notes")]
        public string Notes { get; set; }

        public Member() { }



        internal static string GetIdByName(string fname, string lname)
        {
            MongoClient client = new MongoClient(conn_str);
            var db = client.GetDatabase(db_str);
            var collection = db.GetCollection<Member>("Members");

            var filter = Builders<Member>.Filter.Eq("First_name", fname) & Builders<Member>.Filter.Eq("Last_name", lname);

            var member = collection.Find(filter).FirstOrDefault();
            return member != null ? member.Id.ToString() : string.Empty;
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

        public static void CreateMember(Member m)
        {
            MongoClient client = new MongoClient(conn_str);
            var db = client.GetDatabase(db_str);
            var collection = db.GetCollection<Member>("Members");

            collection.InsertOne(m);
        }

        public static void UpdateMember(Member updatedMember)
        {
            MongoClient client = new MongoClient(conn_str);
            var db = client.GetDatabase(db_str);
            var collection = db.GetCollection<Member>("Members");

            var filter = Builders<Member>.Filter.Eq(s => s.Id, updatedMember.Id);
            var result = collection.ReplaceOne(filter, updatedMember);
        }

        public static Member GetMemberById(string id)
        {
            if (string.IsNullOrEmpty(id)) { return null; }
            MongoClient client = new MongoClient(conn_str);
            var db = client.GetDatabase(db_str);
            var collection = db.GetCollection<Member>("Members");

            try
            {
                var filter = Builders<Member>.Filter.Eq("_id", ObjectId.Parse(id));
                return collection.Find(filter).FirstOrDefault();
            }
            catch (FormatException)
            {
                // Handle the case where id is not a valid ObjectId
                return null;
            }
        }

        public static List<Member> GetAllMembers()
        {
            MongoClient client = new MongoClient(conn_str);
            var db = client.GetDatabase(db_str);
            var collection = db.GetCollection<Member>("Members");

            List<Member> members = collection.Find(_ => true).ToList();
            return members;
        }

        public static List<Member> GetReferees()
        {
            MongoClient client = new MongoClient(conn_str);
            var db = client.GetDatabase(db_str);
            var collection = db.GetCollection<Member>("Members");

            var filter = Builders<Member>.Filter.Eq("IsRef", true);
            var referees = collection.Find(filter).ToList();
            return referees;
        }

        public static List<Member> GetFreeAgents()
        {
            MongoClient client = new MongoClient(conn_str);
            var db = client.GetDatabase(db_str);
            var collection = db.GetCollection<Member>("Members");

            // Define a filter to find players without a team
            var filter = Builders<Member>.Filter.Where(member => member.IsPlayer && string.IsNullOrEmpty(member.TeamId));

            // Execute the query
            return collection.Find(filter).ToList();
        }

    }
}
