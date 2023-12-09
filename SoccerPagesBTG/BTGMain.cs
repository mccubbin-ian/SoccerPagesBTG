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
            InitializeAsync();
        }

        private async Task InitializeAsync()
        {
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
            UpdateMemberPage(await Member.GetAllMembersAsync());
            UpdateFieldPage();
            Task.Run(() => RunMailStop());
        }

        private void EstablishUserAccess(Member login)
        {
            buttonAddField.Enabled =
            buttonAddField.Visible =
            buttonAddGame.Enabled =
            buttonRemoveField.Enabled =
            buttonRemoveField.Visible = 
            buttonAddMember.Enabled =
            buttonAddMember.Visible =
            buttonRemoveMember.Enabled =
            buttonRemoveMember.Visible =
            buttonAddPlayer.Enabled =
            buttonAddTeam.Enabled =
            buttonAddTeam.Visible =
            buttonDropPlayer.Enabled =
            buttonReportScore.Enabled = false;

            if (login == null)
            {
                return;
            }

            if (login.IsAdmin)
            {
                buttonAddField.Enabled =
                buttonAddField.Visible =
                buttonAddGame.Enabled =
                buttonAddMember.Enabled =
                buttonAddMember.Visible =
                buttonRemoveMember.Enabled =
                buttonRemoveMember.Visible =
                buttonAddPlayer.Enabled =
                buttonAddTeam.Enabled =
                buttonAddTeam.Visible =
                buttonDropPlayer.Enabled =
                buttonRemoveField.Enabled =
                buttonRemoveField.Visible =
                buttonReportScore.Enabled = true;
            }
            else if (login.IsScheduler)
            {
                buttonAddField.Enabled =
                buttonAddField.Visible =
                buttonRemoveField.Visible =
                buttonAddGame.Enabled =
                buttonRemoveField.Enabled = true;
            }
            else if (login.IsRef)
            {
                buttonReportScore.Enabled = true;
            }
        }

        static async void RunMailStop()
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
            buttonReportScore.Visible = buttonReportScore.Enabled && dateTimePickerUpcomingGames.Value.Date <= DateTime.Now.Date;
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

        private void ButtonAddGame_Click(object sender, EventArgs e)
        {
            using (AddGame aeg = new AddGame())
            {
                if (aeg.ShowDialog() == DialogResult.OK)
                {
                    Game.CreateDBRecord(aeg.g);
                }
            }
        }

        private void ButtonPrevWeekGames_Click(object sender, EventArgs e)
        {
            DateTime dt = dateTimePickerUpcomingGames.Value;
            dt = dt.AddDays(-7);
            dateTimePickerUpcomingGames.Value = dt;
            UpdateMatchBoard();
        }

        private void ButtonNextWeekGames_Click(object sender, EventArgs e)
        {
            DateTime dt = dateTimePickerUpcomingGames.Value;
            dt = dt.AddDays(7);
            dateTimePickerUpcomingGames.Value = dt;
            UpdateMatchBoard();
        }

        private void ButtonReportScore_Click(object sender, EventArgs e)
        {
            if(dateTimePickerUpcomingGames.Value<DateTime.Now)
            {
                string gameId = dataGridViewMatches.SelectedRows[0].Cells["ColumnId"].Value.ToString();
                UpdateMatch(gameId);
            }

        }

        private void DataGridViewMatches_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dateTimePickerUpcomingGames.Value<DateTime.Now)
            {
                string gameId = dataGridViewMatches.Rows[e.RowIndex].Cells["ColumnId"].Value.ToString();
                UpdateMatch(gameId);
            }

        }

        private void UpdateMatch(string gameId)
        {
            using (ScoreReport sr = new ScoreReport(Game.GetGameById(gameId)))
            {
                if (sr.ShowDialog() == DialogResult.OK)
                {
                    Game g = sr.game;
                    Game.UpdateDBRecord(g);
                    UpdateMatchPage();
                }
            }
        }
        #endregion

        #region FieldPage
        private void UpdateFieldPage()
        {
            listBoxFields.DataSource = Field.GetAllFields().Select(f => f.Name).ToList();
        }

        private void ButtonAddField_Click(object sender, EventArgs e)
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

        private void ListBoxFields_DoubleClick(object sender, EventArgs e)
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

        private void ListBoxFields_SelectedIndexChanged(object sender, EventArgs e)
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
        private async void ButtonAddMember_Click(object sender, EventArgs e)
        {
            using (AddEditMember aem = new AddEditMember(login))
            {
                if (aem.ShowDialog() != DialogResult.OK) { }
                else { await AddUpdateMemberAsync(aem); }
            }

            UpdateMemberPage(await Member.GetAllMembersAsync());
        }

        private void ButtonRemoveMember_Click(object sender, EventArgs e)
        {
            string id = dataGridViewMembers.SelectedRows[0].Cells["ColumnMemberId"].Value.ToString();
            Member m = Member.GetMemberById(id);
            string message;
            if (m.TeamId != string.Empty)
            {
                Team t = Team.GetTeambyId(m.TeamId);
                if (t.ManagerID == m.Id.ToString())
                {
                    message = "Error with Removal:\n" +
                        $"{m.Last_name}, {m.First_name}\n" +
                        $"is {t.Name} Manager.\n" +
                        "Reassign Manager before deleting.";
                    MessageBox.Show(message, "Delete Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (t.CaptainID == m.Id.ToString())
                {
                    message = "Error with Removal:\n" +
                              $"{m.Last_name}, {m.First_name}\n" +
                              $"is {t.Name} Captain.\n" +
                              "Reassign Captain before deleting.";
                    MessageBox.Show(message, "Delete Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    message = "You are about to delete:\n" +
                              $"{m.Last_name}, {m.First_name} from the record.\n" +
                              "Are you sure?";
                    var result = MessageBox.Show(message, "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes)
                    {
                        Member.DeleteMember(m);
                    }

                }
            }

        }

        private async Task AddUpdateMemberAsync(AddEditMember aem)
        {
            await Task.Run(() => AddUpdateMember(aem));
        }

        private async void DataGridViewMembers_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (login == null) { return; }

            string memberId = dataGridViewMembers.Rows[e.RowIndex].Cells["ColumnMemberId"].Value.ToString();
            Member m = Member.GetMemberById(memberId);

            if (login.IsAdmin || login.Id.ToString() == m.Id.ToString())
            {
                using (AddEditMember aem = new AddEditMember(login, m))
                {
                    if (aem.ShowDialog() != DialogResult.OK) { }
                    else
                    {
                        await AddUpdateMemberAsync(aem);
                        UpdateMemberPage(await Member.GetAllMembersAsync());
                    }
                }
            }
        }

        private void DataGridViewMembers_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
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

        private static void AddUpdateMember(AddEditMember aem)
        {
            Member newMember = aem.newMember;
            Member oldMember = aem.oldMember;

            if (oldMember != null)
            {
                DisplayUpdateConfirmation(oldMember, newMember);
            }
            else
            {
                DisplayCreationConfirmation(newMember);
            }
        }

        private static void DisplayUpdateConfirmation(Member oldMember, Member newMember)
        {
            string message = $"You have updated user:\n" +
                $"First_Name: {oldMember.First_name} to {newMember.First_name}\n" +
                $"Last_Name: {oldMember.Last_name} to {newMember.Last_name}\n" +
                $"E-mail: {oldMember.Email} to {newMember.Email}\n" +
                $"Team: {Team.GetTeamNameById(oldMember.TeamId)} to {Team.GetTeamNameById(newMember.TeamId)}\n" +
                $"isPlayer: {oldMember.IsPlayer} to {newMember.IsPlayer}\n" +
                $"isRef: {oldMember.IsRef} to {newMember.IsRef}\n" +
                $"isAdmin: {oldMember.IsAdmin} to {newMember.IsAdmin}\n" +
                $"isScheduler: {oldMember.IsScheduler} to {newMember.IsScheduler}\n" +
                $"EligibleDate: {oldMember.EligibleDate.Date} to {newMember.EligibleDate.Date}\n" +
                "Confirm Changes?";

            var result = MessageBox.Show(message, "Edit User", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Member.UpdateMember(newMember);
            }
        }

        private static void DisplayCreationConfirmation(Member newMember)
        {
            string message = $"You have created a new user:\n" +
                $"First_Name: {newMember.First_name}\n" +
                $"Last_Name: {newMember.Last_name}\n" +
                $"E-mail: {newMember.Email}\n" +
                $"Team: {Team.GetTeamNameById(newMember.TeamId)}\n" +
                $"isPlayer: {newMember.IsPlayer}\n" +
                $"isRef: {newMember.IsRef}\n" +
                $"isAdmin: {newMember.IsAdmin}\n" +
                $"isScheduler: {newMember.IsScheduler}\n" +
                $"EligibleDate: {newMember.EligibleDate.Date}\n" +
                "Confirm?";

            var result = MessageBox.Show(message, "Create New User", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Member.CreateMember(newMember);
            }
        }


        private void UpdateMemberPage(List<Member> members)
        {
            dataGridViewMembers.Rows.Clear();
            foreach (Member m in members)
            {
                DataGridViewTextBoxCell id = new DataGridViewTextBoxCell() { Value = m.Id.ToString() };
                DataGridViewTextBoxCell membername = new DataGridViewTextBoxCell() { Value = $"{m.Last_name}, {m.First_name}" };
                DataGridViewTextBoxCell isPlayer = new DataGridViewTextBoxCell() { Value = m.IsPlayer };
                DataGridViewTextBoxCell isReferee = new DataGridViewTextBoxCell() { Value = m.IsRef };
                DataGridViewTextBoxCell isEligible = new DataGridViewTextBoxCell() { Value = m.EligibleDate.Date.ToShortDateString() };
                DataGridViewTextBoxCell team = new DataGridViewTextBoxCell() { Value = Team.GetTeamNameById(m.TeamId) };
                DataGridViewTextBoxCell email = new DataGridViewTextBoxCell() { Value = m.Email };

                DataGridViewRow r = new DataGridViewRow();
                r.Cells.AddRange(id, membername, isPlayer, isReferee, isEligible, team, email);
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
        private async void RadioButtonReferees_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonReferees.Checked)
            {
                UpdateMemberPage(await Member.GetRefereesAsync());
            }
        }

        private async void RadioButtonAllMembers_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonAllMembers.Checked)
            {
                UpdateMemberPage(await Member.GetAllMembersAsync());
            }
        }

        private void RadioButtonTeamManagers_CheckedChanged(object sender, EventArgs e)
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

        private void RadioButtonTeamCaptains_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonTeamCaptains.Checked)
            {
                List<Member> allCaptains = new List<Member>();
                foreach (Team t in Team.GetTeams())
                {
                    allCaptains.Add(Member.GetMemberById(t.CaptainID));
                }
                UpdateMemberPage(allCaptains);
            }
        }

        private async void RadioButtonFreeAgents_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonFreeAgents.Checked)
            {
                UpdateMemberPage(await Member.GetFreeAgentsAsync());
            }
        }

        private async void RadioButtonSuspendedPlayers_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonSuspendedPlayers.Checked)
            {
                DateTime today = DateTime.Now.Date;
                int daysUntilSunday = ((int)DayOfWeek.Sunday - (int)today.DayOfWeek + 7) % 7;
                DateTime nextSunday = today.AddDays(daysUntilSunday).Date;
                List<Member> suspended = await Member.GetAllMembersAsync();
                suspended = suspended.Where(s => s.EligibleDate > nextSunday).ToList();
                UpdateMemberPage(suspended);
            }
        }

        #endregion

        #endregion

        #region TeamPage
        private void UpdateTeamPage()
        {
            listBoxTeams.DataSource = Team.GetTeamNames();
            if(listBoxTeams.Items.Count>0) { listBoxTeams.SelectedIndex = 0; }
        }

        private void ButtonAddTeam_Click(object sender, EventArgs e)
        {
            using (AddTeam teamEditor = new AddTeam())
            {
                if (teamEditor.ShowDialog() == DialogResult.OK)
                {
                    Team t = new Team()
                    {
                        Name = teamEditor.name,
                        ManagerID = teamEditor.mgrId
                    };
                    Team.CreateTeam(t);
                    UpdateTeamPage();
                }
            }
        }

        private void ButtonAddPlayer_Click(object sender, EventArgs e)
        {
            string team = Team.GetIdByTeamName(listBoxTeams.SelectedItem.ToString());
            using (AddToRoster atr = new AddToRoster(team))
            {
                if (atr.ShowDialog() == DialogResult.OK)
                {
                    Member m = Member.GetMemberById(atr.player_id);
                    m.TeamId = atr.team_id;
                    Member.UpdateMember(m);
                }
            }
            UpdateRosterListBox(team);
        }

        private void ButtonAssignCaptain_Click(object sender, EventArgs e)
        {
            Team t = Team.GetTeambyName(listBoxTeams.Text);
            string[] name = listBoxRoster.Text.Split(',');
            Member m = Member.GetMemberById(Member.GetIdByName(name[1].Trim(), name[0]));
            string capConfirm = $"You are about to make {m.First_name} {m.Last_name}" +
                      $"the captian of the {t.Name}.  Are you sure?";
            var result = MessageBox.Show(capConfirm, "Captain Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                Member oldCaptain = Member.GetMemberById(t.CaptainID);
                Member.UpdateMember(oldCaptain);
                t.CaptainID = m.Id.ToString();
                Member.UpdateMember(m);
                UpdateRosterListBox(t.Id.ToString());
                radioButtonAllMembers.Checked = false;
                radioButtonAllMembers.Checked = true;
            }
        }

        private void ButtonDropPlayer_Click(object sender, EventArgs e)
        {
            string team = listBoxTeams.Text;
            string[] name = listBoxRoster.Text.Split(',');
            Team t = Team.GetTeambyName(team);
            Member m = Member.GetMemberById(Member.GetIdByName(name[1].Trim(), name[0]));
            if(t.CaptainID == m.Id.ToString())
            {
                MessageBox.Show($"{m.Last_name}, {m.First_name} is team captain, reassign Captain before dropping.", 
                    "Error Dropping Team Captain", MessageBoxButtons.OK, MessageBoxIcon.Error);

            } else
            {
                string removeConfirm = $"You are about to remove {m.First_name} {m.Last_name}" +
                      $"from the {team} roster.  Are you sure?";
                var result = MessageBox.Show(removeConfirm, "Remove Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    m.TeamId = string.Empty;
                    Member.UpdateMember(m);
                    UpdateRosterListBox(Team.GetIdByTeamName(team));
                    radioButtonAllMembers.Checked = false;
                    radioButtonAllMembers.Checked = true;
                }
            }
        }

        private void ListBoxTeams_DoubleClick(object sender, EventArgs e)
        {
            if (login == null) { return; }
            Team oldTeam = Team.GetTeambyName(listBoxTeams.Text);
            if (login.IsAdmin || login.Id.ToString() == oldTeam.ManagerID)
            {
                using (EditTeam eTeam = new EditTeam(listBoxTeams.Text))
                {
                    if (eTeam.ShowDialog() == DialogResult.OK)
                    {
                        Member oldMgr = Member.GetMemberById(oldTeam.ManagerID);
                        Member oldCap = Member.GetMemberById(oldTeam.CaptainID);
                        Team t = eTeam.t;
                        string message = "You are updating Team:\n" +
                            $"Name: {oldTeam.Name} to {t.Name}\n" +
                            $"Manager: {oldMgr.Last_name}, {oldMgr.First_name} to {eTeam.tMgr}\n" +
                            $"Captain: {oldCap.Last_name}, {oldCap.First_name} to {eTeam.tCap}\n" +
                            "Are you sure?";


                        var result = MessageBox.Show(message, "Edit Team Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (result == DialogResult.Yes)
                        {
                            Team.UpdateTeam(t);
                            Member mgr = Member.GetMemberById(t.ManagerID);
                            mgr.TeamId = t.Id.ToString();
                            Member.UpdateMember(mgr);
                            Member cap = Member.GetMemberById(t.CaptainID);
                            cap.TeamId = t.Id.ToString();
                            Member.UpdateMember(cap);
                            radioButtonAllMembers.Checked = false;
                            radioButtonAllMembers.Checked = true;
                            UpdateTeamPage();
                        }
                    }
                }
            }
        }

        private void UpdateRosterListBox(string teamId)
        {
            List<string> roster = Team.GetRoster(teamId);
            roster.Sort();
            listBoxRoster.DataSource = roster;
            if (listBoxRoster.Items.Count > 0) { listBoxRoster.SelectedIndex = 0; }
        }

        private void ListBoxTeams_SelectedIndexChanged(object sender, EventArgs e)
        {
            Team t = Team.GetTeambyName(listBoxTeams.SelectedItem.ToString());
            Member mgr = Member.GetMemberById(t.ManagerID);
            Member cpt = Member.GetMemberById(t.CaptainID);
            buttonAddPlayer.Visible = buttonDropPlayer.Visible = login.IsAdmin || login.Id == mgr.Id || login.Id == cpt.Id;
            buttonAssignCaptain.Visible = login.IsAdmin || login.Id == mgr.Id;
            buttonAddPlayer.Enabled = buttonDropPlayer.Enabled = login.IsAdmin || login.Id == mgr.Id || login.Id == cpt.Id;
            buttonAssignCaptain.Enabled = login.IsAdmin || login.Id == mgr.Id;
            UpdateRosterListBox(t.Id.ToString());
        }
        private void ListBoxRoster_SelectedIndexChanged(object sender, EventArgs e)
        {
            string[] name = listBoxRoster.SelectedItem.ToString().Split(',');
            Member m = Member.GetMemberById(Member.GetIdByName(name[1].Trim(), name[0]));
            labelRosterFname.Text = m.First_name;
            labelRosterLname.Text = m.Last_name;
            labelEligibleDate.Text = m.EligibleDate.Date.ToString();
            DateTime today = DateTime.Now.Date;
            int daysUntilSunday = ((int)DayOfWeek.Sunday - (int)today.DayOfWeek + 7) % 7;
            DateTime nextSunday = today.AddDays(daysUntilSunday);
            if (today.DayOfWeek == DayOfWeek.Sunday) { nextSunday.AddDays(7); }
            if (m.EligibleDate.Date > nextSunday) { labelEligibleDate.BackColor = Color.Red; }
            else { labelEligibleDate.BackColor = Color.LightCyan; }
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
