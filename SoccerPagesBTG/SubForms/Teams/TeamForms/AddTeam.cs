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
    public partial class AddTeam : Form
    {
        public string name, mgrId;


        private static readonly string conn_str = "<yourDBconn>";
        private static readonly string db_str = "<yourDBstring";

        public AddTeam()
        {
            InitializeComponent();
            GetAllMemberList();
        }

        private void ButtonOK_Click(object sender, EventArgs e)
        {
            name = textBoxName.Text;
            string[] mgrName = comboBoxManager.Text.Split(',');
            mgrId = Member.GetIdByName(mgrName[1].Trim(), mgrName[0]);
        }

        private void GetAllMemberList()
        {
            MongoClient client = new MongoClient(conn_str);
            var db = client.GetDatabase(db_str);
            var collection = db.GetCollection<Member>("Members");

            var filter = Builders<Member>.Filter.Eq("TeamId", "");

            var membersWithNullTeam = collection.Find(filter).ToList();

            List<string> potentialMgrs = new List<string>();
            foreach (var d in membersWithNullTeam)
            {
                potentialMgrs.Add((d.Last_name + ", " + d.First_name));
            }
            comboBoxManager.DataSource = potentialMgrs;
            if(potentialMgrs.Count>0) { comboBoxManager.SelectedIndex = 0; }
            
        }
    }
}
