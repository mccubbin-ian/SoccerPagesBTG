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
using MongoDB.Driver;
using MongoDB.Bson;

namespace SoccerPagesBTG
{
    public partial class AddEditGame : Form
    {
        public Game g;
        public List<string> TeamList = Team.GetTeamNames();
        public List<string> RefereeList = Member.GetReferees();
        public List<string> Fields = Field.GetAllFields().Select(f=> f.Name).ToList();
        public DateTime t = new DateTime();
        public string home, away, ref1, ref2, ref3, field;


        public AddEditGame()
        {
            InitializeComponent();
            DateTime d = DateTime.Now;
            int dayOffset = ((int)DayOfWeek.Sunday - (int)d.DayOfWeek + 7) % 7;
            comboBoxLocation.Items.Clear();
            dateTimePicker1.Value= d.AddDays(dayOffset);
            comboBoxLocation.Items.AddRange(Fields.ToArray());
            comboBoxAway.Items.AddRange(TeamList.ToArray());
            comboBoxHome.Items.AddRange(TeamList.ToArray());
            comboBoxRef1.Items.AddRange(RefereeList.ToArray());
            comboBoxRef2.Items.AddRange(RefereeList.ToArray());
            comboBoxRef3.Items.AddRange(RefereeList.ToArray());
        }

        private void comboBoxRef1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxRef1.SelectedItem != null)
            {
                bool eqR2 = false;
                bool eqR3 = false;
                if (comboBoxRef2.SelectedItem != null) { eqR2 = comboBoxRef2.SelectedItem.ToString() == comboBoxRef1.SelectedItem.ToString(); }
                if (comboBoxRef3.SelectedItem != null) { eqR3 = comboBoxRef3.SelectedItem.ToString() == comboBoxRef1.SelectedItem.ToString(); }
                if (eqR2 || eqR3) { comboBoxRef1.SelectedIndex = comboBoxRef2.SelectedIndex = comboBoxRef3.SelectedIndex = -1; }
            }
        }

        private void comboBoxRef2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxRef2.SelectedItem != null)
            {
                bool eqR1 = false;
                bool eqR3 = false;
                if (comboBoxRef1.SelectedItem != null) { eqR1 = comboBoxRef1.SelectedItem.ToString() == comboBoxRef2.SelectedItem.ToString(); }
                if (comboBoxRef3.SelectedItem != null) { eqR3 = comboBoxRef3.SelectedItem.ToString() == comboBoxRef2.SelectedItem.ToString(); }
                if (eqR1 || eqR3) { comboBoxRef1.SelectedIndex = comboBoxRef2.SelectedIndex = comboBoxRef3.SelectedIndex = -1; }
            }
        }

        private void comboBoxRef3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxRef3.SelectedItem != null) // Corrected the check here
            {
                bool eqR1 = false;
                bool eqR2 = false;
                if (comboBoxRef1.SelectedItem != null) { eqR1 = comboBoxRef1.SelectedItem.ToString() == comboBoxRef3.SelectedItem.ToString(); }
                if (comboBoxRef2.SelectedItem != null) { eqR2 = comboBoxRef2.SelectedItem.ToString() == comboBoxRef3.SelectedItem.ToString(); }
                if (eqR1 || eqR2) { comboBoxRef1.SelectedIndex = comboBoxRef2.SelectedIndex = comboBoxRef3.SelectedIndex = -1; }
            }
        }

        private void buttonNextWeek_Click(object sender, EventArgs e)
        {
            DateTime dt = dateTimePicker1.Value;
            dt = dt.AddDays(7);
            dateTimePicker1.Value = dt;
        }

        private void buttonPreviousWeek_Click(object sender, EventArgs e)
        {
            DateTime dt = dateTimePicker1.Value;
            dt = dt.AddDays(-7);
            dateTimePicker1.Value = dt;
        }

        private void comboBoxHome_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxHome.SelectedItem != null)
            {
                if (comboBoxAway.SelectedItem == null) { return; }
                if (comboBoxAway.SelectedItem.ToString()==comboBoxHome.SelectedItem.ToString())
                {
                    comboBoxAway.SelectedIndex = -1;
                    comboBoxHome.SelectedIndex = -1;
                }
            }
        }

        private void comboBoxAway_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxAway.SelectedItem != null)
            {
                if (comboBoxHome.SelectedItem == null) { return; }
                if (comboBoxAway.SelectedItem.ToString() == comboBoxHome.SelectedItem.ToString())
                {
                    comboBoxAway.SelectedIndex = -1;
                    comboBoxHome.SelectedIndex = -1;
                }
            }
        }

        private void buttonOKCommit_Click(object sender, EventArgs e)
        {
            DateTime t = dateTimePicker1.Value;
            string[] timestamp = comboBoxGameTime.SelectedItem.ToString().Split(':');
            TimeSpan ts = new TimeSpan(int.Parse(timestamp[0]), int.Parse(timestamp[1]), 0);
            t = t.Date + ts;
            t = t.ToUniversalTime();

            g = new Game()
            {
                Location = comboBoxLocation.Text,
                Time = t,
                HomeTeam = comboBoxHome.Text,
                AwayTeam = comboBoxAway.Text,
                AwayScore = (int)numericUpDownHome.Value,
                HomeScore = (int)numericUpDownAway.Value,
                Ref1 = comboBoxRef1.Text,
                Ref2 = comboBoxRef2.Text,
                Ref3 = comboBoxRef3.Text,
                Notification = string.Empty
            };
        }
    }
}
