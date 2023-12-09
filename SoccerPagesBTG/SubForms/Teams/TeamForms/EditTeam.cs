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
    public partial class EditTeam : Form
    {
        public Team t;
        public string tMgr, tCap;

        public EditTeam(string teamName)
        {
            InitializeComponent();
            t = Team.GetTeambyName(teamName);
            textBoxTeamName.Text = t.Name;
            InitializeAsync();
        }

        private (Member Manager, Member Captain) GetManagerAndCaptain()
        {
            Member mgr = Member.GetMemberById(t.ManagerID);
            Member cpt = Member.GetMemberById(t.CaptainID);
            return (mgr, cpt);
        }

        private async Task InitializeAsync()
        {
            var (mgr, cpt) = GetManagerAndCaptain();

            List<Member> nonAssociatedMembers = await Member.GetAllNoTeamAssociation();
            List<string> mgrCandidates = Team.GetRoster(t.Id.ToString());
            foreach (Member m in nonAssociatedMembers){ mgrCandidates.Add($"{m.Last_name}, {m.First_name}"); }
            if(!mgrCandidates.Contains($"{mgr.Last_name}, {mgr.First_name}")){ mgrCandidates.Add($"{mgr.Last_name}, {mgr.First_name}"); }
            comboBoxManager.DataSource = mgrCandidates;
            comboBoxManager.Text = $"{mgr.Last_name}, {mgr.First_name}";
            comboBoxCaptain.DataSource = Team.GetRoster(t.Id.ToString());
            comboBoxCaptain.Text = $"{cpt.Last_name}, {cpt.First_name}";
        }

        private void ButtonOK_Click(object sender, EventArgs e)
        {
            tMgr = comboBoxManager.Text;
            tCap = comboBoxCaptain.Text;
            string[] cap = tMgr.Split(',');
            string[] mgr = tCap.Split(',');
            string mgrId = Member.GetIdByName(mgr[1].Trim(), mgr[0]);
            string capId = Member.GetIdByName(cap[1].Trim(), cap[0]);
            t.CaptainID = capId;
            t.ManagerID = mgrId;
        }
    }
}
