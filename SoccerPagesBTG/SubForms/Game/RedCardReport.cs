using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SoccerPagesBTG.DBClasses;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;

namespace SoccerPagesBTG
{
    public partial class RedCardReport : Form
    {
        public Game game;
        private RedCard rc;


        public RedCardReport(Game g, string reportId=null)
        {
            game = g;
            InitializeComponent();
            dateTimePicker1.Value = g.GameDate;
            textBoxGameTime.Text = g.GameTime;
            textBoxGameLocation.Text = g.Location;
            comboBoxTeam.Items.AddRange(new string[] { g.HomeTeam, g.AwayTeam });
            comboBoxTeam.SelectedIndex = comboBoxOffense.SelectedIndex = 0;
            if(reportId != null)
            {
                rc = RedCard.GetRedCardById(reportId);
                string[] player = Member.GetNameById(rc.Player);
                comboBoxTeam.Text = rc.Team;
                comboBoxPlayer.Text = $"{player[1]}, {player[0]}";
                comboBoxOffense.Text = rc.Violation;
                richTextBox1.Text = rc.Description;
            }
        }

        private void ComboBoxTeam_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxPlayer.Items.Clear();
            Team t = Team.GetTeambyName(comboBoxTeam.Text);
            comboBoxPlayer.Items.AddRange(Team.GetRoster(t.Id.ToString()).ToArray());
        }

        private void ButtonOK_Click(object sender, EventArgs e)
        {
            bool create = rc==null;
            if(create) 
            { 
                rc = new RedCard();
            }
            rc.GameId = game.Id.ToString();
            rc.Description = richTextBox1.Text;
            rc.Team = comboBoxTeam.Text;
            string[] player = comboBoxPlayer.Text.Split(',');
            string playerId = Member.GetIdByName(player[1].Trim(), player[0]);
            rc.Player = playerId;
            rc.Violation = comboBoxOffense.Text;
            if(create) { RedCard.CreateRedCardReport(rc); }
            else { RedCard.UpdateRedCardReport(rc); }
        }
    }
}
