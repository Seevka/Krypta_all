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
    public partial class Form10 : Form
    {
        public Form10()
        {
            InitializeComponent();
        }
        static long calculateJacobian(long a, long n)
        {
            if (n <= 0 || n % 2 == 0)
                return 0;

            long ans = 1L;

            if (a < 0)
            {
                a = -a; // (a/n) = (-a/n)*(-1/n)
                if (n % 4 == 3)
                    ans = -ans; // (-1/n) = -1 if n = 3 (mod 4)
            }

            if (a == 1)
                return ans; // (1/n) = 1

            while (a != 0)
            {
                if (a < 0)
                {
                    a = -a; // (a/n) = (-a/n)*(-1/n)
                    if (n % 4 == 3)
                        ans = -ans; // (-1/n) = -1 if n = 3 (mod 4)
                }

                while (a % 2 == 0)
                {
                    a /= 2;
                    if (n % 8 == 3 || n % 8 == 5)
                        ans = -ans;
                }

                long temp = a;
                a = n;
                n = temp;

                if (a % 4 == 3 && n % 4 == 3)
                    ans = -ans;

                a %= n;
                if (a > n / 2)
                    a = a - n;
            }

            if (n == 1)
                return ans;

            return 0;
        }

        private void Form10_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox4.Text = "";
            long num1 = long.Parse(textBox2.Text);
            long num2 = long.Parse(textBox3.Text);
            textBox4.Text+=(calculateJacobian(num1, num2));
        }
    }
}
