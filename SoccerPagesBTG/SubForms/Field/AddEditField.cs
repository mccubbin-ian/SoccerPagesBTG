using MongoDB.Bson;
using SoccerPagesBTG.DBClasses;
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
    public partial class AddEditField : Form
    {
        public Field f;
        public AddEditField()
        {
            InitializeComponent();
            Text = "Add Field";
            textBoxID.Enabled = false;
            textBoxName.Select();
        }

        public AddEditField(Field fd)
        {
            InitializeComponent();
            Text = "Edit Field";
            textBoxID.Text = fd.Id.ToString();
            textBoxName.Text = fd.Name;
            textBoxA1.Text = fd.Addr1;
            textBoxA2.Text = fd.Addr2;
            textBoxCity.Text = fd.City;
            textBoxState.Text = fd.State;
            textBoxZip.Text = fd.Zip;
            textBoxName.Select();
        }

        private void ButtonOK_Click(object sender, EventArgs e)
        {
            f = new Field()
            {
                Name = textBoxName.Text,
                Addr1 = textBoxA1.Text,
                Addr2 = textBoxA2.Text,
                City = textBoxCity.Text,
                State = textBoxState.Text,
                Zip = textBoxZip.Text
            };
             
            if(Name.Contains("Edit"))
            {
                f.Id = ObjectId.Parse(textBoxID.Text);
            }
        }
    }
}
