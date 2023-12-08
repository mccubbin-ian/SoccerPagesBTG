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
    public partial class AddGame : Form
    {
        public Game g;
        public List<string> TeamList;
        public List<string> RefereeList;
        public List<string> Fields;
        public DateTime t = DateTime.Now.Date;
        public string home, away, ref1, ref2, ref3, field;


        public AddGame()
        {
            InitializeComponent();
            InitializeAsync();
        }

        private async void InitializeAsync()
        {
            DateTime d = DateTime.Now.Date;
            int dayOffset = ((int)DayOfWeek.Sunday - (int)d.DayOfWeek + 7) % 7;
            comboBoxLocation.Items.Clear();
            dateTimePicker1.Value = d.AddDays(dayOffset);

            await LoadDataAsync();

            comboBoxLocation.Items.AddRange(Fields.ToArray());
            comboBoxAway.Items.AddRange(TeamList.ToArray());
            comboBoxHome.Items.AddRange(TeamList.ToArray());
            comboBoxRef1.Items.AddRange(RefereeList.ToArray());
            comboBoxRef2.Items.AddRange(RefereeList.ToArray());
            comboBoxRef3.Items.AddRange(RefereeList.ToArray());
        }

        private async Task LoadDataAsync()
        {
            TeamList = await Task.Run(() => Team.GetTeamNames());
            var referees = await Member.GetRefereesAsync();
            RefereeList = referees.Select(r => $"{r.Last_name}, {r.First_name}").ToList();
            Fields = (await Task.Run(() => Field.GetAllFields())).Select(f => f.Name).ToList();
        }

        private void ComboBoxRefs_SelectedIndexChanged(ComboBox currentComboBox, ComboBox otherComboBox1, ComboBox otherComboBox2)
        {
            if (currentComboBox.SelectedItem != null)
            {
                bool eqOther1 = false;
                bool eqOther2 = false;

                if (otherComboBox1.SelectedItem != null)
                {
                    eqOther1 = otherComboBox1.SelectedItem.ToString() == currentComboBox.SelectedItem.ToString();
                }

                if (otherComboBox2.SelectedItem != null)
                {
                    eqOther2 = otherComboBox2.SelectedItem.ToString() == currentComboBox.SelectedItem.ToString();
                }

                if (eqOther1 || eqOther2)
                {
                    currentComboBox.SelectedIndex = otherComboBox1.SelectedIndex = otherComboBox2.SelectedIndex = -1;
                }
            }
        }

        private void ComboBoxRef1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBoxRefs_SelectedIndexChanged(comboBoxRef1, comboBoxRef2, comboBoxRef3);
        }

        private void ComboBoxRef2_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBoxRefs_SelectedIndexChanged(comboBoxRef2, comboBoxRef1, comboBoxRef3);
        }

        private void ComboBoxRef3_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBoxRefs_SelectedIndexChanged(comboBoxRef3, comboBoxRef1, comboBoxRef2);
        }

        private void ButtonNextWeek_Click(object sender, EventArgs e)
        {
            DateTime dt = dateTimePicker1.Value;
            dt = dt.AddDays(7);
            dateTimePicker1.Value = dt;
        }

        private void ButtonPreviousWeek_Click(object sender, EventArgs e)
        {
            DateTime dt = dateTimePicker1.Value;
            dt = dt.AddDays(-7);
            if(dt.Date>=DateTime.Now.Date) { dateTimePicker1.Value = dt; }
            
        }

        private void ComboBoxTeams_SelectedIndexChanged(ComboBox currentComboBox, ComboBox otherComboBox)
        {
            if (currentComboBox.SelectedItem != null)
            {
                if (otherComboBox.SelectedItem != null && otherComboBox.SelectedItem.ToString() == currentComboBox.SelectedItem.ToString())
                {
                    otherComboBox.SelectedIndex = -1;
                    currentComboBox.SelectedIndex = -1;
                }
            }
        }

        private void ComboBoxHome_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBoxTeams_SelectedIndexChanged(comboBoxHome, comboBoxAway);
        }

        private void ComboBoxAway_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBoxTeams_SelectedIndexChanged(comboBoxAway, comboBoxHome);
        }

        private void ButtonOKCommit_Click(object sender, EventArgs e)
        {
            DateTime t = dateTimePicker1.Value.Date;
            string ts = comboBoxGameTime.SelectedItem.ToString();

            List<Game> SundayGames = Game.GetGamesByDate(dateTimePicker1.Value.Date);

            g = new Game()
            {
                Location = comboBoxLocation.Text,
                GameDate = t,
                GameTime = ts,
                HomeTeam = comboBoxHome.Text,
                AwayTeam = comboBoxAway.Text,
                AwayScore = -1,
                HomeScore = -1,
                Ref1 = comboBoxRef1.Text,
                Ref2 = comboBoxRef2.Text,
                Ref3 = comboBoxRef3.Text,
                Notification = string.Empty
            };
            bool conflict = false;
            foreach (Game game in SundayGames)
            {
                ValueTuple<string,string> result = Game.CheckSchedulingConflicts(g, game);
                if (result.Item1 != "None")
                {
                    conflict = true;
                    var res=MessageBox.Show("There is a scheduling conflict of type: " + result.Item1.ToUpper() + "\n"
                        + result.Item2 + " already has a game at the same date/time.",
                        "Scheduling Conflict Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            if (!conflict) { DialogResult = DialogResult.OK; }    
        }
    }
}
