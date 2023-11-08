
namespace SoccerPagesBTG
{
    partial class AddEditGame
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
            this.buttonPreviousWeek = new System.Windows.Forms.Button();
            this.buttonNextWeek = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.comboBoxHome = new System.Windows.Forms.ComboBox();
            this.labelHome = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxAway = new System.Windows.Forms.ComboBox();
            this.comboBoxGameTime = new System.Windows.Forms.ComboBox();
            this.comboBoxRef1 = new System.Windows.Forms.ComboBox();
            this.comboBoxRef2 = new System.Windows.Forms.ComboBox();
            this.comboBoxRef3 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.numericUpDownHome = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownAway = new System.Windows.Forms.NumericUpDown();
            this.buttonOKCommit = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.comboBoxLocation = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownHome)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAway)).BeginInit();
            this.SuspendLayout();
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Enabled = false;
            this.dateTimePicker1.Location = new System.Drawing.Point(20, 12);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.ShowUpDown = true;
            this.dateTimePicker1.Size = new System.Drawing.Size(185, 20);
            this.dateTimePicker1.TabIndex = 0;
            // 
            // buttonPreviousWeek
            // 
            this.buttonPreviousWeek.Location = new System.Drawing.Point(211, 12);
            this.buttonPreviousWeek.Name = "buttonPreviousWeek";
            this.buttonPreviousWeek.Size = new System.Drawing.Size(56, 20);
            this.buttonPreviousWeek.TabIndex = 1;
            this.buttonPreviousWeek.Text = "Previous";
            this.buttonPreviousWeek.UseVisualStyleBackColor = true;
            this.buttonPreviousWeek.Click += new System.EventHandler(this.buttonPreviousWeek_Click);
            // 
            // buttonNextWeek
            // 
            this.buttonNextWeek.Location = new System.Drawing.Point(273, 12);
            this.buttonNextWeek.Name = "buttonNextWeek";
            this.buttonNextWeek.Size = new System.Drawing.Size(56, 20);
            this.buttonNextWeek.TabIndex = 2;
            this.buttonNextWeek.Text = "Next";
            this.buttonNextWeek.UseVisualStyleBackColor = true;
            this.buttonNextWeek.Click += new System.EventHandler(this.buttonNextWeek_Click);
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(187, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(18, 20);
            this.panel1.TabIndex = 3;
            // 
            // comboBoxHome
            // 
            this.comboBoxHome.FormattingEnabled = true;
            this.comboBoxHome.Location = new System.Drawing.Point(58, 100);
            this.comboBoxHome.Name = "comboBoxHome";
            this.comboBoxHome.Size = new System.Drawing.Size(129, 21);
            this.comboBoxHome.TabIndex = 4;
            this.comboBoxHome.SelectedIndexChanged += new System.EventHandler(this.comboBoxHome_SelectedIndexChanged);
            // 
            // labelHome
            // 
            this.labelHome.AutoSize = true;
            this.labelHome.Location = new System.Drawing.Point(16, 103);
            this.labelHome.Name = "labelHome";
            this.labelHome.Size = new System.Drawing.Size(35, 13);
            this.labelHome.TabIndex = 5;
            this.labelHome.Text = "Home";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 130);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Away";
            // 
            // comboBoxAway
            // 
            this.comboBoxAway.FormattingEnabled = true;
            this.comboBoxAway.Location = new System.Drawing.Point(58, 127);
            this.comboBoxAway.Name = "comboBoxAway";
            this.comboBoxAway.Size = new System.Drawing.Size(129, 21);
            this.comboBoxAway.TabIndex = 6;
            this.comboBoxAway.SelectedIndexChanged += new System.EventHandler(this.comboBoxAway_SelectedIndexChanged);
            // 
            // comboBoxGameTime
            // 
            this.comboBoxGameTime.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxGameTime.FormattingEnabled = true;
            this.comboBoxGameTime.Items.AddRange(new object[] {
            "08:45",
            "10:35",
            "12:25"});
            this.comboBoxGameTime.Location = new System.Drawing.Point(59, 38);
            this.comboBoxGameTime.Name = "comboBoxGameTime";
            this.comboBoxGameTime.Size = new System.Drawing.Size(128, 21);
            this.comboBoxGameTime.TabIndex = 8;
            // 
            // comboBoxRef1
            // 
            this.comboBoxRef1.FormattingEnabled = true;
            this.comboBoxRef1.Location = new System.Drawing.Point(73, 159);
            this.comboBoxRef1.Name = "comboBoxRef1";
            this.comboBoxRef1.Size = new System.Drawing.Size(129, 21);
            this.comboBoxRef1.TabIndex = 9;
            this.comboBoxRef1.SelectedIndexChanged += new System.EventHandler(this.comboBoxRef1_SelectedIndexChanged);
            // 
            // comboBoxRef2
            // 
            this.comboBoxRef2.FormattingEnabled = true;
            this.comboBoxRef2.Location = new System.Drawing.Point(73, 184);
            this.comboBoxRef2.Name = "comboBoxRef2";
            this.comboBoxRef2.Size = new System.Drawing.Size(129, 21);
            this.comboBoxRef2.TabIndex = 10;
            this.comboBoxRef2.SelectedIndexChanged += new System.EventHandler(this.comboBoxRef2_SelectedIndexChanged);
            // 
            // comboBoxRef3
            // 
            this.comboBoxRef3.FormattingEnabled = true;
            this.comboBoxRef3.Location = new System.Drawing.Point(73, 209);
            this.comboBoxRef3.Name = "comboBoxRef3";
            this.comboBoxRef3.Size = new System.Drawing.Size(129, 21);
            this.comboBoxRef3.TabIndex = 11;
            this.comboBoxRef3.SelectedIndexChanged += new System.EventHandler(this.comboBoxRef3_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 163);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Referee1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 188);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Referee2";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 213);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Referee3";
            // 
            // numericUpDownHome
            // 
            this.numericUpDownHome.Location = new System.Drawing.Point(199, 100);
            this.numericUpDownHome.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.numericUpDownHome.Name = "numericUpDownHome";
            this.numericUpDownHome.Size = new System.Drawing.Size(44, 20);
            this.numericUpDownHome.TabIndex = 15;
            this.numericUpDownHome.Value = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            // 
            // numericUpDownAway
            // 
            this.numericUpDownAway.Location = new System.Drawing.Point(199, 128);
            this.numericUpDownAway.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.numericUpDownAway.Name = "numericUpDownAway";
            this.numericUpDownAway.Size = new System.Drawing.Size(44, 20);
            this.numericUpDownAway.TabIndex = 16;
            this.numericUpDownAway.Value = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            // 
            // buttonOKCommit
            // 
            this.buttonOKCommit.BackColor = System.Drawing.Color.LightGray;
            this.buttonOKCommit.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOKCommit.Location = new System.Drawing.Point(260, 165);
            this.buttonOKCommit.Name = "buttonOKCommit";
            this.buttonOKCommit.Size = new System.Drawing.Size(75, 23);
            this.buttonOKCommit.TabIndex = 17;
            this.buttonOKCommit.Text = "OK/Commit";
            this.buttonOKCommit.UseVisualStyleBackColor = false;
            this.buttonOKCommit.Click += new System.EventHandler(this.buttonOKCommit_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.BackColor = System.Drawing.Color.LightGray;
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(260, 198);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 18;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(203, 84);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 13);
            this.label5.TabIndex = 19;
            this.label5.Text = "Result";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(18, 42);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(30, 13);
            this.label6.TabIndex = 20;
            this.label6.Text = "Time";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(0, 72);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(48, 13);
            this.label7.TabIndex = 21;
            this.label7.Text = "Location";
            // 
            // comboBoxLocation
            // 
            this.comboBoxLocation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxLocation.FormattingEnabled = true;
            this.comboBoxLocation.Items.AddRange(new object[] {
            "08:45",
            "10:35",
            "12:25"});
            this.comboBoxLocation.Location = new System.Drawing.Point(58, 68);
            this.comboBoxLocation.Name = "comboBoxLocation";
            this.comboBoxLocation.Size = new System.Drawing.Size(128, 21);
            this.comboBoxLocation.TabIndex = 22;
            // 
            // AddEditGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(348, 236);
            this.Controls.Add(this.comboBoxLocation);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOKCommit);
            this.Controls.Add(this.numericUpDownAway);
            this.Controls.Add(this.numericUpDownHome);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBoxRef3);
            this.Controls.Add(this.comboBoxRef2);
            this.Controls.Add(this.comboBoxRef1);
            this.Controls.Add(this.comboBoxGameTime);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxAway);
            this.Controls.Add(this.labelHome);
            this.Controls.Add(this.comboBoxHome);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.buttonNextWeek);
            this.Controls.Add(this.buttonPreviousWeek);
            this.Controls.Add(this.dateTimePicker1);
            this.Name = "AddEditGame";
            this.Text = "AddGame";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownHome)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAway)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button buttonPreviousWeek;
        private System.Windows.Forms.Button buttonNextWeek;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox comboBoxHome;
        private System.Windows.Forms.Label labelHome;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxAway;
        private System.Windows.Forms.ComboBox comboBoxGameTime;
        private System.Windows.Forms.ComboBox comboBoxRef1;
        private System.Windows.Forms.ComboBox comboBoxRef2;
        private System.Windows.Forms.ComboBox comboBoxRef3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numericUpDownHome;
        private System.Windows.Forms.NumericUpDown numericUpDownAway;
        private System.Windows.Forms.Button buttonOKCommit;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox comboBoxLocation;
    }
}