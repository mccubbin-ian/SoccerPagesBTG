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
    public partial class ScoreReport : Form
    {
        public Game game;
        
        public ScoreReport(Game g)
        {
            game = g;
            InitializeComponent();
            dateTimePickerGameDay.Value = g.GameDate;
            textBoxGameTime.Text = g.GameTime;
            textBoxLocation.Text = g.Location;
            textBoxHomeName.Text = g.HomeTeam;
            textBoxAwayTeam.Text = g.AwayTeam;
            if (g.AwayScore != -1) { numericUpDownAwayScore.Value = g.AwayScore; }
            if (g.HomeScore != -1) { numericUpDownHomeScore.Value = g.HomeScore; }
            UpdateRedCardDataGrid();
        }

        private void ButtonRedCardReport_Click(object sender, EventArgs e)
        {
            using (RedCardReport rcr = new RedCardReport(game))
            {
                if(rcr.ShowDialog()==DialogResult.OK)
                {
                    UpdateRedCardDataGrid();
                }
            }
        }

        private void UpdateRedCardDataGrid()
        {
            List<RedCard> rc = RedCard.GetRedCardsByGameId(game.Id.ToString());
            dataGridViewRedCards.Rows.Clear();
            foreach (var rpt in rc)
            {
                int idx=dataGridViewRedCards.Rows.Add();
                dataGridViewRedCards.Rows[idx].Cells["ColumnGameId"].Value = rpt.GameId;
                dataGridViewRedCards.Rows[idx].Cells["ColumnID"].Value = rpt.Id.ToString();
                dataGridViewRedCards.Rows[idx].Cells["ColumnTeam"].Value = rpt.Team;
                string[] player = Member.GetNameById(rpt.Player);
                dataGridViewRedCards.Rows[idx].Cells["ColumnPlayer"].Value = $"{player[1]}, {player[0]}";
                string offense = rpt.Violation.Split(' ')[0].Trim();
                dataGridViewRedCards.Rows[idx].Cells["ColumnOffense"].Value = offense;
            }
        }

        private void ButtonConfirm_Click(object sender, EventArgs e)
        {
            game.HomeScore = (int)numericUpDownHomeScore.Value;
            game.AwayScore = (int)numericUpDownAwayScore.Value;
        }
    }
}
