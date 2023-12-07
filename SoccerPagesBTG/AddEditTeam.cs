using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MongoDB.Driver;
using SoccerPagesBTG.DBClasses;
using MongoDB.Bson;



namespace SoccerPagesBTG
{
    public partial class AddEditTeam : Form
    {
        public string name, manager;

        private static readonly string conn_str = "mongodb+srv://test:test@testdb.ygmwifa.mongodb.net/";
        private static readonly string db_str = "BTG_DB";

        public AddEditTeam()
        {
            InitializeComponent();
            GetAllMemberList();
        }

        private void GetAllMemberList()
        {
            MongoClient client = new MongoClient(conn_str);
            var db = client.GetDatabase(db_str);
            var collection = db.GetCollection<Member>("Members");

            var filter = Builders<Member>.Filter.Eq("TeamId", "") & Builders<Member>.Filter.Eq("IsPlayer", true);
            var membersWithNullTeam = collection.Find(filter).ToList();

            List<string> potentialMgrs = new List<string>();
            foreach (var d in membersWithNullTeam)
            {
                potentialMgrs.Add((d.Last_name + ", " + d.First_name));
            }
            comboBox1.DataSource = potentialMgrs;
        }
    }
}
