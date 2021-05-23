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
    public partial class Form14 : Form
    {
        public Form14()
        {
            InitializeComponent();
        }

        private void Form14_Load(object sender, EventArgs e)
        {

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
                exponent /= 2;

            }
            return x % mod;
        }
        static long Jacobian(long a, long n)
        {
            if (n <= 0 || n % 2 == 0)
                return 0;

            long ans = 1L;

            if (a < 0)
            {
                a = -a;
                if (n % 4 == 3)
                    ans = -ans;
            }

            if (a == 1)
                return ans;

            while (a != 0)
            {
                if (a < 0)
                {
                    a = -a;
                    if (n % 4 == 3)
                        ans = -ans;
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
        static bool solovayStrassen(long p, int iteration)
        {
            if (p < 2)
                return false;
            if (p != 2 && p % 2 == 0)
                return false;

            Random rand = new Random();
            for (int i = 0; i < iteration; i++)
            {
                long r = Math.Abs(rand.Next());
                long a = r % (p - 1) + 1;
                long jacobian = (p + Jacobian(a, p)) % p;
                long mod = modulo(a, (p - 1) / 2, p);

                if (jacobian == 0 || mod != jacobian)
                    return false;
            }
            return true;
        }
        private long polinomialValue(List<long> coef, int x)
        {
            double res = 0;
            for (int i = 0; i < coef.Count; i++)
            {
                res += coef[i] * Math.Pow(x, i);
            }
            return Convert.ToInt64(res);
        }
        List<long> coef = new List<long>();

        private void button1_Click(object sender, EventArgs e)
        {
            long s = Convert.ToInt64(textBox1.Text);
            int n = Convert.ToInt32(textBox4.Text);
            int k = Convert.ToInt32(textBox5.Text);

            long p = s + 1;
            while (true)
            {
                if (solovayStrassen(p, 50))
                {
                    break;
                }
                else
                {
                    p++;
                }
            }
            coef.Add(s);
            var random = new Random();
            for (int i = 0; i < k - 1; i++)
            {

                coef.Add(random.Next(1, (int)p));

            }

            List<Tuple<int, long>> points = new List<Tuple<int, long>>();
            for (int i = 0; i < n; i++)
            {
                points.Add(Tuple.Create(i + 1, polinomialValue(coef, i + 1)));
                string point = $"({i + 1}, {polinomialValue(coef, i + 1)})";
                checkedListBox1.Items.Add(point);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            List<Tuple<int, long>> checkedPoints = new List<Tuple<int, long>>();
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                if (checkedListBox1.GetItemCheckState(i) == CheckState.Checked)
                {
                    checkedPoints.Add(Tuple.Create(i + 1, polinomialValue(coef, i + 1)));
                }
            }

            int k1 = checkedPoints.Count;
            double res = 0;
            for (int i = 0; i < k1; i++)
            {
                double prod = 1;
                for (int m = 0; m < k1; m++)
                {
                    if (m != i)
                    {
                        prod *= checkedPoints[m].Item1 / (double)(checkedPoints[m].Item1 - checkedPoints[i].Item1);
                    }
                }
                res += checkedPoints[i].Item2 * prod;
            }

            textBox2.Text = Math.Round(res).ToString();
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
        "Чи ви впевнені що хочете вийти?",
        "Увага!",
        MessageBoxButtons.YesNo,
        MessageBoxIcon.Information,
        MessageBoxDefaultButton.Button1,
        MessageBoxOptions.DefaultDesktopOnly);

            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
