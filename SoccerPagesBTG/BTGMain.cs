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
    public partial class FormBTG : Form
    {
        public FormBTG()
        {
            
            InitializeComponent();
            DateTime today = DateTime.Now;
            int daysUntilSunday = ((int)DayOfWeek.Sunday - (int)today.DayOfWeek + 7) % 7;
            DateTime nextSunday = today.AddDays(daysUntilSunday);
            dateTimePickerUpcomingGames.Value = nextSunday.Date;
            UpdateTeamPage();
            UpdateMatchBoard();
            UpdateMemberPage();
            UpdateFieldPage();
            UpdateTeamStandings();

        }

        private void UpdateTeamStandings()
        {
            dataGridViewStandings.Rows.Clear();
            List<string> teams = Team.GetTeamNames();
            foreach(string t in teams)
            {
                int[] record=Game.GetTeamRecord(t);
                DataGridViewTextBoxCell teamName = new DataGridViewTextBoxCell();
                teamName.Value = t;
                DataGridViewTextBoxCell w = new DataGridViewTextBoxCell();
                w.Value = record[0];
                DataGridViewTextBoxCell l = new DataGridViewTextBoxCell();
                l.Value = record[1];
                DataGridViewTextBoxCell d = new DataGridViewTextBoxCell();
                d.Value = record[2];
                DataGridViewTextBoxCell pts = new DataGridViewTextBoxCell();
                pts.Value = record[0] * 3 + record[2];
                DataGridViewRow r = new DataGridViewRow();
                r.Cells.AddRange(teamName, w, l, d, pts);
                dataGridViewStandings.Rows.Add(r);
            }
            dataGridViewStandings.Sort(dataGridViewStandings.Columns["ColumnPoints"], ListSortDirection.Descending);
        }

        private void UpdateMatchBoard()
        {
            dataGridViewMatches.Rows.Clear();
            List<Game> games= Game.GetGamesByDate(dateTimePickerUpcomingGames.Value);
            foreach (Game g in games)
            {
                DataGridViewTextBoxCell homeTeam = new DataGridViewTextBoxCell();
                homeTeam.Value = g.HomeTeam;
                DataGridViewTextBoxCell homeScore = new DataGridViewTextBoxCell();
                if(g.HomeScore==-1) { homeScore.Value = String.Empty; } else { homeScore.Value = g.HomeScore; }
                DataGridViewTextBoxCell awayTeam = new DataGridViewTextBoxCell();
                awayTeam.Value = g.AwayTeam;
                DataGridViewTextBoxCell awayScore = new DataGridViewTextBoxCell();
                if (g.AwayScore == -1) { awayScore.Value = String.Empty; } else { awayScore.Value = g.HomeScore; }
                DataGridViewTextBoxCell location = new DataGridViewTextBoxCell();
                location.Value = g.Location;
                DataGridViewTextBoxCell time = new DataGridViewTextBoxCell();
                DateTime dt = g.Time.ToLocalTime();
                time.Value = dt.ToString("h:mm");
                DataGridViewRow r = new DataGridViewRow();
                r.Cells.AddRange(homeTeam, homeScore, awayTeam, awayScore, location, time);
                dataGridViewMatches.Rows.Add(r);
            }
        }

        private void UpdateFieldPage()
        {
            listBoxFields.DataSource = Field.GetAllFields().Select(f => f.Name).ToList();
        }

        private void UpdateMemberPage()
        {
            listBoxMembers.DataSource = Member.GetAllMembers();
        }

        private void UpdateTeamPage()
        {
            listBoxTeams.DataSource = Team.GetTeamNames();
            
        }

        private void buttonAddMember_Click(object sender, EventArgs e)
        {
            using (AddEditMember memberform=new AddEditMember())
            {
                if(memberform.ShowDialog()==DialogResult.OK)
                {
                    Member m = new Member()
                    {
                        First_name = memberform.firstName,
                        Last_name = memberform.lastName,
                        IsPlayer = memberform.isPlayer,
                        IsRef = memberform.isRef,
                        EligibleDate = DateTime.Now,
                        TeamId = string.Empty
                    };
                    Member.CreateMember(m);
                }    
            }
            UpdateMemberPage();
        }

        private void buttonAddTeam_Click(object sender, EventArgs e)
        {
            using (AddEditTeam teamEditor = new AddEditTeam())
            {
                if (teamEditor.ShowDialog() == DialogResult.OK)
                {
                    Team t = new Team()
                    {
                        Name = teamEditor.name,
                        ManagerID = teamEditor.manager
                    };
                    Team.CreateTeam(t);
                }
            }
        }

        private void buttonAddPlayer_Click(object sender, EventArgs e)
        {
            string team=listBoxTeams.SelectedItem.ToString();
            team = Team.GetIdByTeamName(team);
            using (AddToRoster atr = new AddToRoster(team))
            {
                if(atr.ShowDialog() == DialogResult.OK)
                {
                    Member m = Member.GetMemberById(atr.player_id);
                    m.TeamId = atr.team_id;
                    Member.UpdateMember(m);
                }
            }
            List<string> roster = Team.GetRoster(team);
            roster.Sort();
            listBoxRoster.DataSource = roster;
        }

        private void listBoxTeams_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<string> roster = Team.GetRoster(Team.GetIdByTeamName(listBoxTeams.SelectedItem.ToString()));
            roster.Sort();
            listBoxRoster.DataSource = roster;
        }

        private void buttonAddGame_Click(object sender, EventArgs e)
        {
            using (AddEditGame aeg= new AddEditGame())
            {
                if(aeg.ShowDialog()==DialogResult.OK)
                {
                    Game.CreateDBRecord(aeg.g);
                }
            }
        }

        private void listBoxFields_DoubleClick(object sender, EventArgs e)
        {
            if (listBoxFields.SelectedItem != null)
            {
                Field f = Field.GetFieldbyName(listBoxFields.SelectedItem.ToString());
                using (AddEditField aef = new AddEditField(f))
                {
                    if (aef.ShowDialog() == DialogResult.OK)
                    {
                        Field.UpdateDBRecord(aef.f);
                    }
                }
            }
            listBoxFields.DataSource = Field.GetAllFields().Select(f => f.Name).ToList();
        }

        private void buttonAddField_Click(object sender, EventArgs e)
        {
            using (AddEditField aef= new AddEditField())
            {
                if (aef.ShowDialog() == DialogResult.OK)
                {
                    Field.CreateDBRecord(aef.f);
                }
            }
            listBoxFields.DataSource = Field.GetAllFields().Select(f => f.Name).ToList();
        }

        private void listBoxFields_SelectedIndexChanged(object sender, EventArgs e)
        {
            Field f = Field.GetFieldbyName(listBoxFields.SelectedItem.ToString());
            textBoxID.Text = f.Id.ToString();
            textBoxName.Text = f.Name;
            textBoxA1.Text = f.Addr1;
            textBoxA2.Text = f.Addr2;
            textBoxCity.Text = f.City;
            textBoxState.Text = f.State;
            textBoxZip.Text = f.Zip;
        }

        private void listBoxMembers_SelectedIndexChanged(object sender, EventArgs e)
        {
            string[] name = listBoxMembers.SelectedItem.ToString().Split(',');
            string id = Member.GetIdByName(name[1].Trim(), name[0]);
            Member m = Member.GetMemberById(id);
            labelROMemberID.Text = m.Id.ToString();
            labelFName.Text = m.First_name;
            labelLName.Text = m.Last_name;
            labelIsReferee.BackColor = m.IsRef ? Color.LightGreen : Color.Red;
            labelIsPlayer.BackColor = m.IsPlayer ? Color.LightGreen : Color.Red;
            labelEligible.BackColor = DateTime.Now >= TimeZoneInfo.ConvertTimeFromUtc(m.EligibleDate,TimeZoneInfo.Local) ? Color.LightGreen : Color.Red;
            labelMbrTeam.Text = Team.GetTeamNameById(m.TeamId.ToString());
        }

        private void buttonPrevWeekGames_Click(object sender, EventArgs e)
        {
            DateTime dt = dateTimePickerUpcomingGames.Value;
            dt = dt.AddDays(-7);
            dateTimePickerUpcomingGames.Value = dt;
            UpdateMatchBoard();
        }

        private void buttonNextWeekGames_Click(object sender, EventArgs e)
        {
            DateTime dt = dateTimePickerUpcomingGames.Value;
            dt = dt.AddDays(7);
            dateTimePickerUpcomingGames.Value = dt;
            UpdateMatchBoard();
        }
    }
}
