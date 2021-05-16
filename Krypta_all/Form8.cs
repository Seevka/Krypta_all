using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace Krypta_all
{
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
        }

        private static string Euclid(int a, int b)
        {
            if (b == 0)
            {
                return $"GCD({a},{b})={a}, u=1, v=0";
            }
            int r0 = a;
            int r1 = b;
            int u0 = 1;
            int v1 = 1;
            int v0 = 0;
            int u1 = 0;
            int i = 1;
            int q;
            while (r1 > 0)
            {
                int temp = r1;
                q = r0 / r1;
                r1 = r0 % r1;
                r0 = temp;

                int tempU = u1;
                int tempV = v1;
                u1 = u0 - q * u1;
                u0 = tempU;

                v1 = v0 - q * v1;
                v0 = tempV;

                i++;
            }
            return $"Найбільший спільний дільник({a},{b})={r0}\r\n t={u0}\r\n k={v0}";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
            string a, b;
            try
            {
                a = Interaction.InputBox("Введіть, будь ласка, перше число ", "Перше число");
                b = Interaction.InputBox("Введіть, будь ласка, друге число ", "друге число");
                textBox2.Text = Euclid(int.Parse(a), int.Parse(b));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error 404");
            }
        }

        private static int Euclid1(int a, int b)
        {
            if (b == 0)
            {
                return a;
            }
            int r0 = a;
            int r1 = b;
            int u0 = 1;
            int v1 = 1;
            int v0 = 0;
            int u1 = 0;
            int i = 1;
            int q;
            while (r1 > 0)
            {
                int temp = r1;
                q = r0 / r1;
                r1 = r0 % r1;
                r0 = temp;

                int tempU = u1;
                int tempV = v1;
                u1 = u0 - q * u1;
                u0 = tempU;

                v1 = v0 - q * v1;
                v0 = tempV;

                i++;
            }
            return r0;
        }

        private static int power(int x, int y, int p)
        {
            int res = 1;
            x = x % p;
            if (x == 0)
            {
                return 0;
            }
            while (y > 0)
            {
                if ((y & 1) != 0)
                {
                    res = (res * x) % p;
                }

                y = y >> 1;
                x = (x * x) % p;
            }
            return res;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
            string x1 = Interaction.InputBox("Введіть, будь ласка, перше число ", "Перше число");
            string d1d = Interaction.InputBox("Введіть, будь ласка, друге число ", "друге число");
            string m1 = Interaction.InputBox("Введіть, будь ласка, mod ", "mod");
            int x = Convert.ToInt32(x1);
            int d = Convert.ToInt32(d1d);
            int n = Convert.ToInt32(m1);
            textBox2.Text = $"{power(x, d, n)}";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
            string n1 = textBox1.Text;
            int n = Convert.ToInt32(n1);
            int l = Convert.ToInt32((Math.Log(n, 2)));
            if (Math.Pow(2, l) < n)
            {
                l += 1;
            }
            var r = new Random();
            int x = r.Next(0, Convert.ToInt32(Math.Pow(2, l)));
            while (x >= n)
            {
                x = r.Next(0, Convert.ToInt32(Math.Pow(2, l)));
            }
            textBox2.Text = x.ToString();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
            string n2 = textBox3.Text;
            int n = Convert.ToInt32(n2);
            int l = Convert.ToInt32((Math.Log(n, 2)));
            if (Math.Pow(2, l) < n)
            {
                l += 1;
            }
            var r = new Random();
            int x = r.Next(0, Convert.ToInt32(Math.Pow(2, l)));
            while (x >= n || Euclid1(n, x) != 1)
            {
                x = r.Next(0, Convert.ToInt32(Math.Pow(2, l)));
            }
            textBox2.Text = x.ToString();
        }
    }
}
