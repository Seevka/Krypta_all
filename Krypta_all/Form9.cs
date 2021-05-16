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
    public partial class Form9 : Form
    {
        public Form9()
        {
            InitializeComponent();
        }
        static long modulo(long Base, long exponent, long mod)
        {
            long x = 1;
            long y = Base;

            while (exponent > 0)
            {
                if (exponent % 2 == 1)
                    x = (x * y) % mod;

                y = (y * y) % mod;
                exponent = exponent / 2;

            }
            return x % mod;
        }

        // To calculate Jacobian symbol of
        // a given number
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

        // To perform the Solovay-Strassen Primality Test
        static bool solovoyStrassen(long p, int iteration)
        {
            if (p < 2)
                return false;
            if (p != 2 && p % 2 == 0)
                return false;

            // Create Object for Random Class
            Random rand = new Random();
            for (int i = 0; i < iteration; i++)
            {

                // Generate a random number r
                long r = Math.Abs(rand.Next());
                long a = r % (p - 1) + 1;
                long jacobian = (p + calculateJacobian(a, p)) % p;
                long mod = modulo(a, (p - 1) / 2, p);

                if (jacobian == 0 || mod != jacobian)
                    return false;
            }
            return true;
        }

        private void Form9_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox4.Text = "";
            int iter = int.Parse(textBox1.Text);
            long num1 = long.Parse(textBox2.Text);
            long num2 = long.Parse(textBox3.Text);



            if (solovoyStrassen(num1, iter))
                textBox4.Text+=(num1 + " is prime\r\n");
            else
                textBox4.Text += (num1 + " is composite\r\n");

            if (solovoyStrassen(num2, iter))
                textBox4.Text += (num2 + " is prime\r\n");
            else
                textBox4.Text += (num2 + " is composite\r\n");
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }

    }
