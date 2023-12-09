
namespace SoccerPagesBTG
{
    partial class EditTeam
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.comboBoxCaptain = new System.Windows.Forms.ComboBox();
            this.textBoxTeamName = new System.Windows.Forms.TextBox();
            this.labelTeamname = new System.Windows.Forms.Label();
            this.labelManager = new System.Windows.Forms.Label();
            this.labelCaptain = new System.Windows.Forms.Label();
            this.comboBoxManager = new System.Windows.Forms.ComboBox();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 32.82675F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 67.17326F));
            this.tableLayoutPanel1.Controls.Add(this.comboBoxCaptain, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.textBoxTeamName, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.labelTeamname, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.labelManager, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.labelCaptain, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.comboBoxManager, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.34F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(329, 88);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // comboBoxCaptain
            // 
            this.comboBoxCaptain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBoxCaptain.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCaptain.FormattingEnabled = true;
            this.comboBoxCaptain.Location = new System.Drawing.Point(112, 61);
            this.comboBoxCaptain.Name = "comboBoxCaptain";
            this.comboBoxCaptain.Size = new System.Drawing.Size(213, 21);
            this.comboBoxCaptain.TabIndex = 5;
            // 
            // textBoxTeamName
            // 
            this.textBoxTeamName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxTeamName.Location = new System.Drawing.Point(112, 4);
            this.textBoxTeamName.Name = "textBoxTeamName";
            this.textBoxTeamName.Size = new System.Drawing.Size(213, 20);
            this.textBoxTeamName.TabIndex = 0;
            // 
            // labelTeamname
            // 
            this.labelTeamname.AutoSize = true;
            this.labelTeamname.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelTeamname.Location = new System.Drawing.Point(4, 1);
            this.labelTeamname.Name = "labelTeamname";
            this.labelTeamname.Size = new System.Drawing.Size(101, 28);
            this.labelTeamname.TabIndex = 1;
            this.labelTeamname.Text = "Team Name";
            this.labelTeamname.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelManager
            // 
            this.labelManager.AutoSize = true;
            this.labelManager.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelManager.Location = new System.Drawing.Point(4, 30);
            this.labelManager.Name = "labelManager";
            this.labelManager.Size = new System.Drawing.Size(101, 27);
            this.labelManager.TabIndex = 2;
            this.labelManager.Text = "Manager";
            this.labelManager.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelCaptain
            // 
            this.labelCaptain.AutoSize = true;
            this.labelCaptain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelCaptain.Location = new System.Drawing.Point(4, 58);
            this.labelCaptain.Name = "labelCaptain";
            this.labelCaptain.Size = new System.Drawing.Size(101, 29);
            this.labelCaptain.TabIndex = 3;
            this.labelCaptain.Text = "Captain";
            this.labelCaptain.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // comboBoxManager
            // 
            this.comboBoxManager.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBoxManager.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxManager.FormattingEnabled = true;
            this.comboBoxManager.Location = new System.Drawing.Point(112, 33);
            this.comboBoxManager.Name = "comboBoxManager";
            this.comboBoxManager.Size = new System.Drawing.Size(213, 21);
            this.comboBoxManager.TabIndex = 4;
            // 
            // buttonOK
            // 
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOK.Location = new System.Drawing.Point(358, 12);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 1;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.ButtonOK_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(358, 41);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 2;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // EditTeam
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightCyan;
            this.ClientSize = new System.Drawing.Size(445, 88);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "EditTeam";
            this.Text = "EditTeam";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ComboBox comboBoxCaptain;
        private System.Windows.Forms.TextBox textBoxTeamName;
        private System.Windows.Forms.Label labelTeamname;
        private System.Windows.Forms.Label labelManager;
        private System.Windows.Forms.Label labelCaptain;
        private System.Windows.Forms.ComboBox comboBoxManager;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
    }
}