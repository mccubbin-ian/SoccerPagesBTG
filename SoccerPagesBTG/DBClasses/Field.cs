using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SoccerPagesBTG.DBClasses
{
    public class Field
    {
        private static readonly string conn_str = Properties.Settings.Default.mongoDbConnect;
        private static readonly string db_str = Properties.Settings.Default.db;

        [BsonId]
        public ObjectId Id { get; set; }

        [BsonElement("Name")]
        public string Name { get; set; }
        [BsonElement("Addr1")]
        public string Addr1 { get; set; }
        [BsonElement("Addr2")]
        public string Addr2 { get;  set; }
        [BsonElement("City")]
        public string City { get; set; }
        [BsonElement("State")]
        public string State { get; set; }
        [BsonElement("Zip")]
        public string Zip { get; set; }

        public Field(){}
        public override string ToString()
        {
            return Name;
        }
        public static bool DeleteDBRecord(string id)
        {
            MongoClient client = new MongoClient(conn_str);
            var db = client.GetDatabase(db_str);
            var collection = db.GetCollection<Field>("Fields");

            var filter = Builders<Field>.Filter.Eq("_id", ObjectId.Parse(id));
            var result = collection.DeleteOne(filter);

            if (result.DeletedCount > 0)
            {
                return true;
            }
            else return false;
        }
        public static bool UpdateDBRecord(Field f)
        {
            MongoClient client = new MongoClient(conn_str);
            var db = client.GetDatabase(db_str);
            var collection = db.GetCollection<Field>("Fields");

            var filter = Builders<Field>.Filter.Eq(s => s.Id, f.Id);
            var result = collection.ReplaceOne(filter, f);
            return (result.ModifiedCount > 0);
        }
        internal static Field GetFieldbyName(string n)
        {
            MongoClient client = new MongoClient(conn_str);
            var db = client.GetDatabase(db_str);
            var collection = db.GetCollection<Field>("Fields");

            var filter = Builders<Field>.Filter.Eq("Name", n);
            return collection.Find(filter).FirstOrDefault();
        }
        internal static Field GetFieldByDgvRow(DataGridViewRow r)
        {
            Field f = new Field()
            {
                Name = r.Cells["Name"].Value?.ToString(),
                Addr1 = r.Cells["Addr1"].Value?.ToString(),
                Addr2 = r.Cells["Addr2"].Value?.ToString(),
                City = r.Cells["City"].Value?.ToString(),
                State = r.Cells["State"].Value?.ToString(),
                Zip = r.Cells["Zip"].Value?.ToString(),
                Id = ObjectId.Parse(r.Cells["Id"].Value.ToString())
            };
            return f;
        }
        public static void CreateDBRecord(Field f)
        {
            MongoClient client = new MongoClient(conn_str);
            var db = client.GetDatabase(db_str);
            var collection = db.GetCollection<Field>("Fields");

            collection.InsertOne(f);
        }
        internal static List<Field> GetAllFields()
        {
            MongoClient client = new MongoClient(conn_str);
            var db = client.GetDatabase(db_str);
            var collection = db.GetCollection<Field>("Fields");

            var filter = Builders<Field>.Filter.Empty;
            return collection.Find(filter).ToList();
        }
    }
}
