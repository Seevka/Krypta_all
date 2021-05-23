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

        private void button8_Click(object sender, EventArgs e)
        {
            Form8 frm8 = new Form8();
            frm8.Activate();
            frm8.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Form9 frm9 = new Form9();
            frm9.Activate();
            frm9.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Form10 frm10 = new Form10();
            frm10.Activate();
            frm10.Show();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Form12 frm12 = new Form12();
            frm12.Activate();
            frm12.Show();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Form13 frm13 = new Form13();
            frm13.Activate();
            frm13.Show();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            Form14 frm14 = new Form14();
            frm14.Activate();
            frm14.Show();
        }
    }
}
