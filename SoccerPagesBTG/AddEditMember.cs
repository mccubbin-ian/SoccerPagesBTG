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

namespace SoccerPagesBTG
{
    public partial class AddEditMember : Form
    {
        public Member oldMember, newMember;
        public string objectID;


        public AddEditMember(Member accessingMember, Member m=null)
        {
            InitializeComponent();
            configureUserEntries(accessingMember, m);
        }

        private void configureUserEntries(Member accessing, Member m=null)
        {
            List<string> teams = Team.GetTeamNames();
            teams.Add("None");
            comboBoxTeam.DataSource = teams;
            comboBoxTeam.SelectedItem = "None";
            if (m != null)
            {
                oldMember = m;
                textBoxFName.Text = m.First_name;
                textBoxLName.Text = m.Last_name;
                textBoxEmail.Text = m.Email;
                dateTimePicker1.Value = m.EligibleDate.Date;
                comboBoxTeam.SelectedItem = Team.GetTeamNameById(m.TeamId);
                radioButtonPlayerTrue.Checked = m.IsPlayer;
                radioButtonRefTrue.Checked = m.IsRef;
                radioButtonSchedulerTrue.Checked = m.IsScheduler;
                radioButtonAdminTrue.Checked = m.IsAdmin;
                textBoxNotes.Text = m.Notes;
            }
            if (!accessing.IsAdmin)
            {
                dateTimePicker1.Enabled = comboBoxTeam.Enabled = tableLayoutPanelTFPlayer.Enabled
                    = tableLayoutPanelTFRef.Enabled = tableLayoutPanelScheduler.Enabled = tableLayoutPanelAdmin.Enabled
                    = textBoxNotes.Enabled = false;
            }
        }

        private void ButtonOK_Click(object sender, EventArgs e)
        {
            dateTimePicker1.Enabled = comboBoxTeam.Enabled = tableLayoutPanelTFPlayer.Enabled
                = tableLayoutPanelTFRef.Enabled = tableLayoutPanelScheduler.Enabled = tableLayoutPanelAdmin.Enabled
                = textBoxNotes.Enabled = true;
            setNewMember();
        }

        private void setNewMember()
        {
            newMember = new Member()
            {
                First_name = textBoxFName.Text,
                Last_name = textBoxLName.Text,
                Email = textBoxEmail.Text,
                TeamId = comboBoxTeam.Text == "None" ? string.Empty : Team.GetIdByTeamName(comboBoxTeam.Text),
                IsPlayer = radioButtonPlayerTrue.Checked,
                IsAdmin = radioButtonAdminTrue.Checked,
                IsRef = radioButtonRefTrue.Checked,
                IsScheduler = radioButtonSchedulerTrue.Checked,
                EligibleDate = dateTimePicker1.Value.Date,
                Notes = textBoxNotes.Text
            };
            if (oldMember != null) { newMember.Id = oldMember.Id; }          
        }
    }
}
