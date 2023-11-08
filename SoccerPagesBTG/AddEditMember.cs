using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SoccerPagesBTG
{
    public partial class AddEditMember : Form
    {
        public string firstName, lastName;
        public bool isRef, isPlayer;

        private void buttonOK_Click(object sender, EventArgs e)
        {
            firstName = textBoxFName.Text;
            lastName = textBoxLName.Text;
            isRef = bool.Parse(comboBoxRef.SelectedItem.ToString());
            isPlayer = bool.Parse(comboBoxPlayer.SelectedItem.ToString());
        }

        public AddEditMember()
        {
            InitializeComponent();
            comboBoxRef.SelectedItem = "false";
            comboBoxPlayer.SelectedItem = "true";
        }

    }
}
