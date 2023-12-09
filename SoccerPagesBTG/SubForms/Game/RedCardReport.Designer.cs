
namespace SoccerPagesBTG
{
    partial class RedCardReport
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
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.comboBoxTeam = new System.Windows.Forms.ComboBox();
            this.textBoxGameTime = new System.Windows.Forms.TextBox();
            this.comboBoxPlayer = new System.Windows.Forms.ComboBox();
            this.comboBoxOffense = new System.Windows.Forms.ComboBox();
            this.labelOffense = new System.Windows.Forms.Label();
            this.textBoxGameLocation = new System.Windows.Forms.TextBox();
            this.labelTeam = new System.Windows.Forms.Label();
            this.labelPlayer = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.Description = new System.Windows.Forms.Label();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Enabled = false;
            this.dateTimePicker1.Location = new System.Drawing.Point(10, 10);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(201, 20);
            this.dateTimePicker1.TabIndex = 0;
            // 
            // comboBoxTeam
            // 
            this.comboBoxTeam.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTeam.FormattingEnabled = true;
            this.comboBoxTeam.Location = new System.Drawing.Point(8, 81);
            this.comboBoxTeam.Name = "comboBoxTeam";
            this.comboBoxTeam.Size = new System.Drawing.Size(122, 21);
            this.comboBoxTeam.TabIndex = 1;
            this.comboBoxTeam.SelectedIndexChanged += new System.EventHandler(this.ComboBoxTeam_SelectedIndexChanged);
            // 
            // textBoxGameTime
            // 
            this.textBoxGameTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxGameTime.Enabled = false;
            this.textBoxGameTime.Location = new System.Drawing.Point(226, 10);
            this.textBoxGameTime.Name = "textBoxGameTime";
            this.textBoxGameTime.Size = new System.Drawing.Size(61, 20);
            this.textBoxGameTime.TabIndex = 2;
            // 
            // comboBoxPlayer
            // 
            this.comboBoxPlayer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPlayer.FormattingEnabled = true;
            this.comboBoxPlayer.Location = new System.Drawing.Point(149, 81);
            this.comboBoxPlayer.Name = "comboBoxPlayer";
            this.comboBoxPlayer.Size = new System.Drawing.Size(138, 21);
            this.comboBoxPlayer.TabIndex = 3;
            // 
            // comboBoxOffense
            // 
            this.comboBoxOffense.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxOffense.DropDownWidth = 400;
            this.comboBoxOffense.FormattingEnabled = true;
            this.comboBoxOffense.Items.AddRange(new object[] {
            "DOGSO {Denying obvious goal scoring oppotunity}",
            "SFP {Serious Foul Play}",
            "B/S {Biting or spitting at someone}",
            "VC {Violent conduct}",
            "AL {Using offensive, insulting, or abusive language and/or gestures}",
            "2YC {Receiving a second caution in the same match}"});
            this.comboBoxOffense.Location = new System.Drawing.Point(62, 111);
            this.comboBoxOffense.Name = "comboBoxOffense";
            this.comboBoxOffense.Size = new System.Drawing.Size(317, 21);
            this.comboBoxOffense.TabIndex = 4;
            // 
            // labelOffense
            // 
            this.labelOffense.AutoSize = true;
            this.labelOffense.Location = new System.Drawing.Point(12, 114);
            this.labelOffense.Name = "labelOffense";
            this.labelOffense.Size = new System.Drawing.Size(44, 13);
            this.labelOffense.TabIndex = 5;
            this.labelOffense.Text = "Offense";
            // 
            // textBoxGameLocation
            // 
            this.textBoxGameLocation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxGameLocation.Enabled = false;
            this.textBoxGameLocation.Location = new System.Drawing.Point(10, 37);
            this.textBoxGameLocation.Name = "textBoxGameLocation";
            this.textBoxGameLocation.Size = new System.Drawing.Size(201, 20);
            this.textBoxGameLocation.TabIndex = 6;
            // 
            // labelTeam
            // 
            this.labelTeam.AutoSize = true;
            this.labelTeam.Location = new System.Drawing.Point(47, 62);
            this.labelTeam.Name = "labelTeam";
            this.labelTeam.Size = new System.Drawing.Size(34, 13);
            this.labelTeam.TabIndex = 7;
            this.labelTeam.Text = "Team";
            // 
            // labelPlayer
            // 
            this.labelPlayer.AutoSize = true;
            this.labelPlayer.Location = new System.Drawing.Point(205, 62);
            this.labelPlayer.Name = "labelPlayer";
            this.labelPlayer.Size = new System.Drawing.Size(36, 13);
            this.labelPlayer.TabIndex = 8;
            this.labelPlayer.Text = "Player";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(8, 158);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(371, 144);
            this.richTextBox1.TabIndex = 9;
            this.richTextBox1.Text = "";
            // 
            // Description
            // 
            this.Description.AutoSize = true;
            this.Description.Location = new System.Drawing.Point(10, 142);
            this.Description.Name = "Description";
            this.Description.Size = new System.Drawing.Size(60, 13);
            this.Description.TabIndex = 10;
            this.Description.Text = "Description";
            // 
            // buttonOK
            // 
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOK.Location = new System.Drawing.Point(304, 15);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 11;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.ButtonOK_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonCancel.Location = new System.Drawing.Point(304, 40);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 12;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // RedCardReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightCyan;
            this.ClientSize = new System.Drawing.Size(387, 310);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.Description);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.labelPlayer);
            this.Controls.Add(this.labelTeam);
            this.Controls.Add(this.textBoxGameLocation);
            this.Controls.Add(this.labelOffense);
            this.Controls.Add(this.comboBoxOffense);
            this.Controls.Add(this.comboBoxPlayer);
            this.Controls.Add(this.textBoxGameTime);
            this.Controls.Add(this.comboBoxTeam);
            this.Controls.Add(this.dateTimePicker1);
            this.Name = "RedCardReport";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.ComboBox comboBoxTeam;
        private System.Windows.Forms.TextBox textBoxGameTime;
        private System.Windows.Forms.ComboBox comboBoxPlayer;
        private System.Windows.Forms.ComboBox comboBoxOffense;
        private System.Windows.Forms.Label labelOffense;
        private System.Windows.Forms.TextBox textBoxGameLocation;
        private System.Windows.Forms.Label labelTeam;
        private System.Windows.Forms.Label labelPlayer;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label Description;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
    }
}