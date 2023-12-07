using SoccerPagesBTG.DBClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SoccerPagesBTG
{
    public partial class AddToRoster : Form
    {
        public string player_id, team_id;
        public AddToRoster(string t_id)
        {
            InitializeComponent();
            comboBox1.Items.Clear();
            List<Member> fa = Member.GetFreeAgents();
            foreach (Member m in fa)
            {
                comboBox1.Items.Add($"{m.Last_name}, {m.First_name}");
            }
            team_id = t_id;
        }

        private void buttonAddPlayer_Click(object sender, EventArgs e)
        {
            string[] name = comboBox1.SelectedItem.ToString().Split(',');
            player_id = Member.GetIdByName(name[1].Trim(), name[0]);
        }
    }
}
