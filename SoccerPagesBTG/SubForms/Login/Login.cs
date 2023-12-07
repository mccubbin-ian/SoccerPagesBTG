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
    public partial class FormLogin : Form
    {
        public string loginId = string.Empty;
        public FormLogin()
        {
            InitializeComponent();
            comboBoxLogin.SelectedIndex = 0;
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            string[] name = comboBoxLogin.Text.Split(new string[] { ") " }, StringSplitOptions.None);
            loginId=Member.GetIdByName(name[1].Split(',')[1].Trim(), name[1].Split(',')[0].Trim());
        }
    }
}
