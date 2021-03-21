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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();

            string s = "This program is created by SevkaLab\r\nLeon is a Legendary Brawler who has the ability to briefly turn invisible to his enemies using his Super. He has medium health and high damage output at close range. As his blades travel, their damage is reduced. Leon has one of the fastest movement speeds as well. His Gadget, Clone Projector, creates a fake version of himself to confuse enemies. His first Star Power, Smoke Trails, gives him a movement speed boost while invisible. His second Star " +
                "Power, Invisiheal, heals him over time while he is invisible.";
            richTextBox1.Text += s;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
