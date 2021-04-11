using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Krypta_all
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 frm2 = new Form2();
            frm2.Activate();
            frm2.Show();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 frm3 = new Form3();
            frm3.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form4 frm4 = new Form4();
            frm4.Activate();
            frm4.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form5 frm5 = new Form5();
            frm5.Activate();
            frm5.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form6 frm6 = new Form6();
            frm6.Activate();
            frm6.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form7 frm7 = new Form7();
            frm7.Activate();
            frm7.Show();
        }
    }
}
