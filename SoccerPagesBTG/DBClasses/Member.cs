using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;

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

            try
            {
                var client = new MongoClient(conn_str);
                var db = client.GetDatabase(db_str);
                var collection = db.GetCollection<Member>("Members");

                var filter = Builders<Member>.Filter.Eq("First_name", fname) & Builders<Member>.Filter.Eq("Last_name", lname);

                var member = collection.Find(filter).FirstOrDefault();
                return member?.Id.ToString() ?? string.Empty;
            }
            finally
            {
            }
        }

        internal static string[] GetNameById(string Id)
        {
            try
            {
                var client = new MongoClient(conn_str);
                var db = client.GetDatabase(db_str);
                var collection = db.GetCollection<Member>("Members");

                ObjectId memberId = new ObjectId(Id);

                var filter = Builders<Member>.Filter.Eq("_id", memberId);
                var member = collection.Find(filter).FirstOrDefault();
                string[] name = new string[2];
                name[0] = member.First_name;
                name[1] = member.Last_name;
                return name;
            }
            finally
            {}
        }

        public static void CreateMember(Member m)
        {

            try
            {
                var client  = new MongoClient(conn_str);
                var db = client.GetDatabase(db_str);
                var collection = db.GetCollection<Member>("Members");

                collection.InsertOne(m);
            }
            finally
            {}
        }

        public static void UpdateMember(Member updatedMember)
        {

            try
            {
                var client  = new MongoClient(conn_str);
                var db = client.GetDatabase(db_str);
                var collection = db.GetCollection<Member>("Members");

                var filter = Builders<Member>.Filter.Eq(s => s.Id, updatedMember.Id);
                var result = collection.ReplaceOne(filter, updatedMember);
            }
            finally
            {}
        }

        public static Member GetMemberById(string id)
        {
            if (string.IsNullOrEmpty(id)) { return null; }


            try
            {
                var client = new MongoClient(conn_str);
                var db = client.GetDatabase(db_str);
                var collection = db.GetCollection<Member>("Members");

                try
                {
                    var filter = Builders<Member>.Filter.Eq("_id", ObjectId.Parse(id));
                    return collection.Find(filter).FirstOrDefault();
                }
                catch (FormatException)
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions that might occur during database access
                Console.WriteLine($"Error in GetMemberById: {ex.Message}");
                return null;
            }
            finally
            { }
        }

        public static async Task<List<Member>> GetAllMembersAsync()
        {
            MongoClient client = null;

            try
            {
                client = new MongoClient(conn_str);
                var db = client.GetDatabase(db_str);
                var collection = db.GetCollection<Member>("Members");

                return await collection.Find(_ => true).ToListAsync();
            }
            finally
            {}
        }

        public static async Task<List<Member>> GetRefereesAsync()
        {

            try
            {
                var client = new MongoClient(conn_str);
                var db = client.GetDatabase(db_str);
                var collection = db.GetCollection<Member>("Members");

                var filter = Builders<Member>.Filter.Eq("IsRef", true);
                return await collection.Find(filter).ToListAsync();
            }
            finally
            {}
        }

        public static async Task<List<Member>> GetFreeAgentsAsync()
        {
            MongoClient client = null;

            try
            {
                client = new MongoClient(conn_str);
                var db = client.GetDatabase(db_str);
                var collection = db.GetCollection<Member>("Members");

                var filter = Builders<Member>.Filter.Where(member => member.IsPlayer && string.IsNullOrEmpty(member.TeamId));
                return await collection.Find(filter).ToListAsync();
            }
            finally
            {}
        }
    }
}
