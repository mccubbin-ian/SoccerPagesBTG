
namespace SoccerPagesBTG
{
    partial class ScoreReport
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dateTimePickerGameDay = new System.Windows.Forms.DateTimePicker();
            this.textBoxGameTime = new System.Windows.Forms.TextBox();
            this.labelHomeTeam = new System.Windows.Forms.Label();
            this.textBoxHomeName = new System.Windows.Forms.TextBox();
            this.numericUpDownHomeScore = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownAwayScore = new System.Windows.Forms.NumericUpDown();
            this.textBoxAwayTeam = new System.Windows.Forms.TextBox();
            this.labelAway = new System.Windows.Forms.Label();
            this.buttonRedCardReport = new System.Windows.Forms.Button();
            this.dataGridViewRedCards = new System.Windows.Forms.DataGridView();
            this.ColumnGameId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnRCID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnTeam = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPlayer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnOffense = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonConfirm = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.textBoxLocation = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownHomeScore)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAwayScore)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRedCards)).BeginInit();
            this.SuspendLayout();
            // 
            // dateTimePickerGameDay
            // 
            this.dateTimePickerGameDay.Enabled = false;
            this.dateTimePickerGameDay.Location = new System.Drawing.Point(12, 12);
            this.dateTimePickerGameDay.Name = "dateTimePickerGameDay";
            this.dateTimePickerGameDay.Size = new System.Drawing.Size(185, 20);
            this.dateTimePickerGameDay.TabIndex = 0;
            // 
            // textBoxGameTime
            // 
            this.textBoxGameTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxGameTime.Enabled = false;
            this.textBoxGameTime.Location = new System.Drawing.Point(203, 12);
            this.textBoxGameTime.Name = "textBoxGameTime";
            this.textBoxGameTime.Size = new System.Drawing.Size(75, 20);
            this.textBoxGameTime.TabIndex = 1;
            // 
            // labelHomeTeam
            // 
            this.labelHomeTeam.AutoSize = true;
            this.labelHomeTeam.Enabled = false;
            this.labelHomeTeam.Location = new System.Drawing.Point(12, 88);
            this.labelHomeTeam.Name = "labelHomeTeam";
            this.labelHomeTeam.Size = new System.Drawing.Size(35, 13);
            this.labelHomeTeam.TabIndex = 2;
            this.labelHomeTeam.Text = "Home";
            // 
            // textBoxHomeName
            // 
            this.textBoxHomeName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxHomeName.Enabled = false;
            this.textBoxHomeName.Location = new System.Drawing.Point(53, 84);
            this.textBoxHomeName.Name = "textBoxHomeName";
            this.textBoxHomeName.Size = new System.Drawing.Size(168, 20);
            this.textBoxHomeName.TabIndex = 3;
            // 
            // numericUpDownHomeScore
            // 
            this.numericUpDownHomeScore.Location = new System.Drawing.Point(227, 84);
            this.numericUpDownHomeScore.Name = "numericUpDownHomeScore";
            this.numericUpDownHomeScore.Size = new System.Drawing.Size(51, 20);
            this.numericUpDownHomeScore.TabIndex = 4;
            // 
            // numericUpDownAwayScore
            // 
            this.numericUpDownAwayScore.Location = new System.Drawing.Point(227, 110);
            this.numericUpDownAwayScore.Name = "numericUpDownAwayScore";
            this.numericUpDownAwayScore.Size = new System.Drawing.Size(51, 20);
            this.numericUpDownAwayScore.TabIndex = 7;
            // 
            // textBoxAwayTeam
            // 
            this.textBoxAwayTeam.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxAwayTeam.Enabled = false;
            this.textBoxAwayTeam.Location = new System.Drawing.Point(53, 110);
            this.textBoxAwayTeam.Name = "textBoxAwayTeam";
            this.textBoxAwayTeam.Size = new System.Drawing.Size(168, 20);
            this.textBoxAwayTeam.TabIndex = 6;
            // 
            // labelAway
            // 
            this.labelAway.AutoSize = true;
            this.labelAway.Enabled = false;
            this.labelAway.Location = new System.Drawing.Point(12, 114);
            this.labelAway.Name = "labelAway";
            this.labelAway.Size = new System.Drawing.Size(33, 13);
            this.labelAway.TabIndex = 5;
            this.labelAway.Text = "Away";
            // 
            // buttonRedCardReport
            // 
            this.buttonRedCardReport.Location = new System.Drawing.Point(53, 136);
            this.buttonRedCardReport.Name = "buttonRedCardReport";
            this.buttonRedCardReport.Size = new System.Drawing.Size(97, 23);
            this.buttonRedCardReport.TabIndex = 8;
            this.buttonRedCardReport.Text = "Add Red Card...";
            this.buttonRedCardReport.UseVisualStyleBackColor = true;
            this.buttonRedCardReport.Click += new System.EventHandler(this.ButtonRedCardReport_Click);
            // 
            // dataGridViewRedCards
            // 
            this.dataGridViewRedCards.AllowUserToAddRows = false;
            this.dataGridViewRedCards.AllowUserToDeleteRows = false;
            this.dataGridViewRedCards.AllowUserToResizeColumns = false;
            this.dataGridViewRedCards.AllowUserToResizeRows = false;
            this.dataGridViewRedCards.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewRedCards.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnGameId,
            this.ColumnID,
            this.ColumnRCID,
            this.ColumnTeam,
            this.ColumnPlayer,
            this.ColumnOffense});
            this.dataGridViewRedCards.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataGridViewRedCards.Location = new System.Drawing.Point(0, 185);
            this.dataGridViewRedCards.Name = "dataGridViewRedCards";
            this.dataGridViewRedCards.RowHeadersVisible = false;
            this.dataGridViewRedCards.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dataGridViewRedCards.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewRedCards.Size = new System.Drawing.Size(401, 124);
            this.dataGridViewRedCards.TabIndex = 9;
            // 
            // ColumnGameId
            // 
            this.ColumnGameId.HeaderText = "Game";
            this.ColumnGameId.Name = "ColumnGameId";
            this.ColumnGameId.ReadOnly = true;
            this.ColumnGameId.Visible = false;
            // 
            // ColumnID
            // 
            this.ColumnID.HeaderText = "ID";
            this.ColumnID.Name = "ColumnID";
            this.ColumnID.ReadOnly = true;
            this.ColumnID.Visible = false;
            // 
            // ColumnRCID
            // 
            this.ColumnRCID.HeaderText = "RedCardID";
            this.ColumnRCID.Name = "ColumnRCID";
            this.ColumnRCID.ReadOnly = true;
            this.ColumnRCID.Visible = false;
            // 
            // ColumnTeam
            // 
            this.ColumnTeam.HeaderText = "Team";
            this.ColumnTeam.Name = "ColumnTeam";
            this.ColumnTeam.ReadOnly = true;
            // 
            // ColumnPlayer
            // 
            this.ColumnPlayer.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnPlayer.HeaderText = "Player";
            this.ColumnPlayer.Name = "ColumnPlayer";
            this.ColumnPlayer.ReadOnly = true;
            // 
            // ColumnOffense
            // 
            this.ColumnOffense.HeaderText = "Offense";
            this.ColumnOffense.Name = "ColumnOffense";
            this.ColumnOffense.ReadOnly = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(139, 162);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(139, 16);
            this.label1.TabIndex = 10;
            this.label1.Text = "Red Card Offenses";
            // 
            // buttonConfirm
            // 
            this.buttonConfirm.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonConfirm.Location = new System.Drawing.Point(314, 9);
            this.buttonConfirm.Name = "buttonConfirm";
            this.buttonConfirm.Size = new System.Drawing.Size(75, 23);
            this.buttonConfirm.TabIndex = 11;
            this.buttonConfirm.Text = "Confirm";
            this.buttonConfirm.UseVisualStyleBackColor = true;
            this.buttonConfirm.Click += new System.EventHandler(this.ButtonConfirm_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(314, 38);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 12;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // textBoxLocation
            // 
            this.textBoxLocation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxLocation.Enabled = false;
            this.textBoxLocation.Location = new System.Drawing.Point(12, 38);
            this.textBoxLocation.Name = "textBoxLocation";
            this.textBoxLocation.Size = new System.Drawing.Size(266, 20);
            this.textBoxLocation.TabIndex = 13;
            // 
            // ScoreReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightCyan;
            this.ClientSize = new System.Drawing.Size(401, 309);
            this.Controls.Add(this.textBoxLocation);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonConfirm);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridViewRedCards);
            this.Controls.Add(this.buttonRedCardReport);
            this.Controls.Add(this.numericUpDownAwayScore);
            this.Controls.Add(this.textBoxAwayTeam);
            this.Controls.Add(this.labelAway);
            this.Controls.Add(this.numericUpDownHomeScore);
            this.Controls.Add(this.textBoxHomeName);
            this.Controls.Add(this.labelHomeTeam);
            this.Controls.Add(this.textBoxGameTime);
            this.Controls.Add(this.dateTimePickerGameDay);
            this.Name = "ScoreReport";
            this.Text = "ScoreReport";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownHomeScore)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAwayScore)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRedCards)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateTimePickerGameDay;
        private System.Windows.Forms.TextBox textBoxGameTime;
        private System.Windows.Forms.Label labelHomeTeam;
        private System.Windows.Forms.TextBox textBoxHomeName;
        private System.Windows.Forms.NumericUpDown numericUpDownHomeScore;
        private System.Windows.Forms.NumericUpDown numericUpDownAwayScore;
        private System.Windows.Forms.TextBox textBoxAwayTeam;
        private System.Windows.Forms.Label labelAway;
        private System.Windows.Forms.Button buttonRedCardReport;
        private System.Windows.Forms.DataGridView dataGridViewRedCards;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonConfirm;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnGameId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnRCID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTeam;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPlayer;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnOffense;
        private System.Windows.Forms.TextBox textBoxLocation;
    }
}