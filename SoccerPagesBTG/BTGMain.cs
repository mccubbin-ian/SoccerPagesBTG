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
using System.Diagnostics;

namespace SoccerPagesBTG
{
    public partial class FormBTG : Form
    {
        private static Process mailStopProcess;
        private static Member login = null;

        #region Initializers
        public FormBTG()
        {
            InitializeComponent();
            FormLogin loginForm = new FormLogin();
            if (loginForm.ShowDialog() == DialogResult.OK)
            {
                if (loginForm.loginId != string.Empty)
                {
                    string uId = loginForm.loginId;
                    login = Member.GetMemberById(uId);
                    Text += " " + login.Last_name + ", " + login.First_name;
                    
                }
                EstablishUserAccess(login);
            }
            DateTime today = DateTime.Now.Date;
            int daysUntilSunday = ((int)DayOfWeek.Sunday - (int)today.DayOfWeek + 7) % 7;
            DateTime nextSunday = today.AddDays(daysUntilSunday);
            dateTimePickerUpcomingGames.Value = nextSunday.Date;
            UpdateTeamPage();
            UpdateMatchPage(); 
            UpdateMemberPage(Member.GetAllMembers());
            UpdateFieldPage();
            Task.Run(()=> runMailStop());
        }

        private void EstablishUserAccess(Member login)
        {
            if (login == null)
            {
                buttonAddField.Visible =
                buttonAddGame.Visible =
                buttonRemoveField.Visible =
                buttonAddMember.Visible =
                buttonRemoveMember.Visible =
                buttonAddPlayer.Visible =
                buttonAddTeam.Visible =
                buttonDropPlayer.Visible =
                buttonReportScore.Visible = false;
                return;
            }
            if(login.IsAdmin)
            {
                buttonAddField.Visible = 
                buttonAddGame.Visible = 
                buttonAddMember.Visible = 
                buttonRemoveMember.Visible = 
                buttonAddPlayer.Visible = 
                buttonAddTeam.Visible = 
                buttonDropPlayer.Visible = 
                buttonRemoveField.Visible = 
                buttonReportScore.Visible = true;
                return;
            }
            else if (login.IsScheduler)
            {
                buttonAddField.Visible =
                buttonAddGame.Visible =
                buttonRemoveField.Visible = true;

                buttonAddMember.Visible = 
                buttonRemoveMember.Visible = 
                buttonAddPlayer.Visible = 
                buttonAddTeam.Visible = 
                buttonDropPlayer.Visible = 
                buttonReportScore.Visible = false;
                return;
            }
            else if (login.IsRef)
            {
                buttonAddField.Visible = 
                buttonAddGame.Visible = 
                buttonRemoveField.Visible = 
                buttonAddMember.Visible = 
                buttonRemoveMember.Visible = 
                buttonAddPlayer.Visible = 
                buttonAddTeam.Visible = 
                buttonDropPlayer.Visible = false;

                buttonReportScore.Visible = true;
                return;
            }
            else if (login.IsPlayer)
            {
                buttonAddField.Visible = 
                buttonAddGame.Visible = 
                buttonRemoveField.Visible = 
                buttonAddMember.Visible = 
                buttonRemoveMember.Visible =
                buttonAddPlayer.Visible = 
                buttonAddTeam.Visible = 
                buttonDropPlayer.Visible = 
                buttonReportScore.Visible = false;
                return;
            }

        }

        static async void runMailStop()
        {

            string file = @"C:\Users\mccubbii\Documents\BTG\Mailstop\mailstop.exe";

            ProcessStartInfo stInfo = new ProcessStartInfo
            {
                FileName = file,
                UseShellExecute = false,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                CreateNoWindow = false
            };

            mailStopProcess = new Process { StartInfo = stInfo };

            mailStopProcess.OutputDataReceived += (sender, e) => Console.WriteLine(e.Data);
            mailStopProcess.ErrorDataReceived += (sender, e) => Console.WriteLine($"Error: {e.Data}");

            mailStopProcess.Start();
            mailStopProcess.BeginOutputReadLine();
            mailStopProcess.BeginErrorReadLine();
        }

        #endregion

        #region MatchPage (Main)
        private void UpdateMatchPage()
        {
            UpdateTeamStandings();
            UpdateMatchBoard();
        }

        private void UpdateTeamStandings()
        {
            dataGridViewStandings.Rows.Clear();
            List<string> teams = Team.GetTeamNames();
            foreach(string t in teams)
            {
                int[] record=Game.GetTeamRecord(t);
                DataGridViewTextBoxCell teamName = new DataGridViewTextBoxCell() { Value = t };
                DataGridViewTextBoxCell w = new DataGridViewTextBoxCell() { Value = record[0] };
                DataGridViewTextBoxCell l = new DataGridViewTextBoxCell() { Value = record[1] };
                DataGridViewTextBoxCell d = new DataGridViewTextBoxCell() { Value = record[2] };
                DataGridViewTextBoxCell pts = new DataGridViewTextBoxCell() { Value = int.Parse(w.Value.ToString())* 3 + int.Parse(d.Value.ToString())};
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
                DataGridViewTextBoxCell id = new DataGridViewTextBoxCell() { Value= g.Id };
                DataGridViewTextBoxCell homeTeam = new DataGridViewTextBoxCell() { Value = g.HomeTeam };
                DataGridViewTextBoxCell homeScore = new DataGridViewTextBoxCell();
                if(g.HomeScore==-1) { homeScore.Value = String.Empty; } else { homeScore.Value = g.HomeScore; }
                DataGridViewTextBoxCell awayTeam = new DataGridViewTextBoxCell() { Value = g.AwayTeam };
                DataGridViewTextBoxCell awayScore = new DataGridViewTextBoxCell();
                if (g.AwayScore == -1) { awayScore.Value = String.Empty; } else { awayScore.Value = g.AwayScore; }
                DataGridViewTextBoxCell location = new DataGridViewTextBoxCell() { Value = g.Location };
                DataGridViewTextBoxCell time = new DataGridViewTextBoxCell() { Value = g.GameTime };
                DataGridViewRow r = new DataGridViewRow();
                r.Cells.AddRange(id, homeTeam, homeScore, awayTeam, awayScore, location, time);
                dataGridViewMatches.Rows.Add(r);
            }
        }

        private void buttonAddGame_Click(object sender, EventArgs e)
        {
            using (AddGame aeg = new AddGame())
            {
                if (aeg.ShowDialog() == DialogResult.OK)
                {
                    Game.CreateDBRecord(aeg.g);
                }
            }
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

        private void dataGridViewMatches_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        #endregion

        #region FieldPage
        private void UpdateFieldPage()
        {
            listBoxFields.DataSource = Field.GetAllFields().Select(f => f.Name).ToList();
        }

        private void buttonAddField_Click(object sender, EventArgs e)
        {
            using (AddEditField aef = new AddEditField())
            {
                if (aef.ShowDialog() == DialogResult.OK)
                {
                    Field.CreateDBRecord(aef.f);
                }
            }
            listBoxFields.DataSource = Field.GetAllFields().Select(f => f.Name).ToList();
        }

        private void listBoxFields_DoubleClick(object sender, EventArgs e)
        {
            if (login == null) { return; }
            else if (login.IsAdmin || login.IsScheduler)
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

        #endregion

        #region MemberPage
        private void buttonAddMember_Click(object sender, EventArgs e)
        {
            using (AddEditMember aem = new AddEditMember(login))
            {
                if (aem.ShowDialog() != DialogResult.OK) { }
                else { AddUpdateMember(aem); }
            }
            UpdateMemberPage(Member.GetAllMembers());
        }

        private void dataGridViewMembers_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (login == null) { return; }
            Member m = Member.GetMemberById(dataGridViewMembers.Rows[e.RowIndex].Cells["ColumnMemberId"].Value.ToString());
            if (login.IsAdmin || login.Id.ToString() == m.Id.ToString())
            {
                using (AddEditMember aem = new AddEditMember(login, m))
                {
                    if (aem.ShowDialog() != DialogResult.OK) { }
                    else
                    {
                        AddUpdateMember(aem);
                        UpdateMemberPage(Member.GetAllMembers());
                    }
                }
            }

        }

        private static void AddUpdateMember(AddEditMember aem)
        {
            Member newMember = aem.newMember;
            Member oldMember = aem.oldMember;
            if (aem.oldMember != null)
            {
                string message = "You have updated user:\n " +
                    $"First_Name: {oldMember.First_name} to {newMember.First_name}\n" +
                    $"Last_Name: {oldMember.Last_name} to {newMember.Last_name}\n" +
                    $"E-mail: {oldMember.Email} to {newMember.Email}\n" +
                    $"Team: {Team.GetTeamNameById(oldMember.TeamId)} to {Team.GetTeamNameById(newMember.TeamId)}\n" +
                    $"isPlayer: {oldMember.IsPlayer} to {newMember.IsPlayer}\n" +
                    $"isRef: {oldMember.IsRef} to {newMember.IsRef}\n" +
                    $"isAdmin: {oldMember.IsAdmin} to {newMember.IsAdmin}\n" +
                    $"isScheduler: {oldMember.IsScheduler} to {newMember.IsScheduler}\n" +
                    $"EligibleDate: {oldMember.EligibleDate.Date} to {newMember.EligibleDate.Date}\n" +
                    $"Notes: {oldMember.Notes} to {newMember.Notes}\n" +
                    "Confirm Changes?";
                var result = MessageBox.Show(message, "Edit User", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes) { Member.UpdateMember(newMember); }
            }
            else
            {
                string message = message = "You have created a new user:\n " +
                    $"First_Name: {newMember.First_name}\n" +
                    $"Last_Name: {newMember.Last_name}\n" +
                    $"E-mail: {newMember.Email}\n" +
                    $"Team: {Team.GetTeamNameById(newMember.TeamId)}\n" +
                    $"isPlayer: {newMember.IsPlayer}\n" +
                    $"isRef: {newMember.IsRef}\n" +
                    $"isAdmin: {newMember.IsAdmin}\n" +
                    $"isScheduler: {newMember.IsScheduler}\n" +
                    $"EligibleDate: {newMember.EligibleDate.Date}\n" +
                    $"Notes: {newMember.Notes}\n" +
                    "Confirm?";
                var result = MessageBox.Show(message, "Create New User", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes) { Member.CreateMember(newMember); }
            }
        }

        private void UpdateMemberPage(List<Member> members)
        {
            dataGridViewMembers.Rows.Clear();
            List<Team> teams = Team.GetTeams();
            foreach (Member m in members)
            {
                DataGridViewTextBoxCell id = new DataGridViewTextBoxCell() { Value = m.Id.ToString() };
                DataGridViewTextBoxCell membername = new DataGridViewTextBoxCell() { Value = $"{m.Last_name}, {m.First_name}" };
                DataGridViewTextBoxCell isPlayer = new DataGridViewTextBoxCell() { Value = m.IsPlayer };
                DataGridViewTextBoxCell isReferee = new DataGridViewTextBoxCell() { Value = m.IsRef };
                DataGridViewTextBoxCell isEligible = new DataGridViewTextBoxCell() { Value = m.EligibleDate.Date.ToShortDateString() };
                DataGridViewTextBoxCell team = new DataGridViewTextBoxCell() { Value = Team.GetTeamNameById(m.TeamId) };
                DataGridViewTextBoxCell email = new DataGridViewTextBoxCell() { Value = m.Email };
                DataGridViewTextBoxCell notes = new DataGridViewTextBoxCell() { Value = m.Notes };

                DataGridViewRow r = new DataGridViewRow();
                r.Cells.AddRange(id, membername, isPlayer, isReferee, isEligible, team, email, notes);
                dataGridViewMembers.Rows.Add(r);
            }
            if (login == null)
            {
                dataGridViewMembers.Columns["ColumnEmail"].Visible = false;
            }
            dataGridViewMembers.Columns["ColumnMemberId"].Visible = login?.IsAdmin ?? false;
            dataGridViewMembers.Sort(dataGridViewMembers.Columns["ColumnName"], System.ComponentModel.ListSortDirection.Ascending);
        }

        #region CheckBoxes
        private void radioButtonReferees_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonReferees.Checked)
            {
                UpdateMemberPage(Member.GetReferees());
            }
        }

        private void radioButtonAllMembers_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonAllMembers.Checked)
            {
                UpdateMemberPage(Member.GetAllMembers());
            }
        }

        private void radioButtonTeamManagers_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonTeamManagers.Checked)
            {
                List<Member> allManagers = new List<Member>();
                foreach (Team t in Team.GetTeams())
                {
                    allManagers.Add(Member.GetMemberById(t.ManagerID));
                }
                UpdateMemberPage(allManagers);
            }
        }

        private void radioButtonTeamCaptains_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonTeamCaptains.Checked)
            {
                List<Member> allCapitans = new List<Member>();
                foreach (Team t in Team.GetTeams())
                {
                    allCapitans.Add(Member.GetMemberById(t.CaptainID));
                }
                UpdateMemberPage(allCapitans);
            }
        }

        private void radioButtonFreeAgents_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonFreeAgents.Checked)
            {
                UpdateMemberPage(Member.GetFreeAgents());
            }
        }

        private void radioButtonSuspendedPlayers_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonSuspendedPlayers.Checked)
            {
                DateTime today = DateTime.Now.Date;
                int daysUntilSunday = ((int)DayOfWeek.Sunday - (int)today.DayOfWeek + 7) % 7;
                DateTime nextSunday = today.AddDays(daysUntilSunday).Date;
                List<Member> suspended = Member.GetAllMembers().Where(s => s.EligibleDate > nextSunday).ToList();
                UpdateMemberPage(suspended);
            }
        }

        #endregion

        private void dataGridViewMembers_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            int ColumnIdxPlayer = 2;
            int ColumnIdxRef = 3;
            int ColumnIdxEligible = 4;

            if (e.RowIndex < 0)
                return;

            Color backColor = Color.White, foreColor = Color.Black;

            // Common logic for both Player and Ref columns
            if (e.ColumnIndex == ColumnIdxPlayer || e.ColumnIndex == ColumnIdxRef)
            {
                string status = dataGridViewMembers.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                if (status == "True")
                {
                    backColor = Color.Green;
                    foreColor = Color.Green;
                }
                else
                {
                    backColor = Color.Red;
                    foreColor = Color.Red;
                }
            }

            // Specific logic for Eligible column
            if (e.ColumnIndex == ColumnIdxEligible)
            {
                string status = dataGridViewMembers.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();

                DateTime dt = DateTime.Parse(status);
                DateTime today = DateTime.Now.Date;
                int daysUntilSunday = ((int)DayOfWeek.Sunday - (int)today.DayOfWeek + 7) % 7;
                DateTime nextSunday = today.AddDays(daysUntilSunday);

                if (dataGridViewMembers.Rows[e.RowIndex].Cells["ColumnPlayer"].Value.ToString() == "False") { foreColor = Color.White; }
                else if (dt > nextSunday)
                {
                    backColor = Color.Red;
                    foreColor = Color.Red;
                }
                else
                {
                    backColor = Color.Green;
                    foreColor = Color.Green;
                }
            }

            e.CellStyle.BackColor = backColor;
            e.CellStyle.ForeColor = foreColor;
        }

        #endregion

        #region TeamPage
        private void UpdateTeamPage()
        {
            listBoxTeams.DataSource = Team.GetTeamNames();
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
            string team = listBoxTeams.SelectedItem.ToString();
            team = Team.GetIdByTeamName(team);
            using (AddToRoster atr = new AddToRoster(team))
            {
                if (atr.ShowDialog() == DialogResult.OK)
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

        #endregion

        #region Closing Actions
        private void FormBTG_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (mailStopProcess != null && !mailStopProcess.HasExited)
            {
                mailStopProcess.CloseMainWindow();
                mailStopProcess.WaitForExit();
            }
        }



        #endregion


       
    }
}
