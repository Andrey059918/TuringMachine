using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TuringMachine
{
    public partial class LoaderDialog : Form
    {
        public List<CheckBox> Boxes;
        public LoaderDialog()
        {
            InitializeComponent();
            Visible = false;
            Boxes = new List<CheckBox>() { checkBox1, checkBox2, checkBox3 };
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (Control ctrl in panel1.Controls) {
                (ctrl as CheckBox).Checked = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach (Control ctrl in panel1.Controls)
            {
                (ctrl as CheckBox).Checked = !(ctrl as CheckBox).Checked;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            foreach (Control ctrl in panel1.Controls)
            {
                (ctrl as CheckBox).Checked = false;
            }
        }

        private void LoaderDialog_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '1') { checkBox1.Checked = !checkBox1.Checked; }
            if (e.KeyChar == '2') { checkBox2.Checked = !checkBox2.Checked; }
            if (e.KeyChar == '3') { checkBox3.Checked = !checkBox3.Checked; }
            if (e.KeyChar == 'a' || e.KeyChar == 'A') { button1_Click(null, EventArgs.Empty); }
            if (e.KeyChar == 's' || e.KeyChar == 'S') { button2_Click(null, EventArgs.Empty); }
            if (e.KeyChar == 'd' || e.KeyChar == 'D') { button3_Click(null, EventArgs.Empty); }
        }
    }
}
