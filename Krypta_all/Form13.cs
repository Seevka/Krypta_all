using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Krypta_all
{
    public partial class Form13 : Form
    {
        char[] characters = new char[] { '#', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J',
            'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S',
            'T', 'U', 'V', 'W', 'X', 'Y', 'Z',' ',
            '1', '2', '3', '4', '5', '6', '7','8', '9', '0' };
        public Form13()
        {
            InitializeComponent();
        }
        string messege;
        string check_messege;
        List<string> check_sign;

        private void Form13_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            string filename;
            openFileDialog.InitialDirectory = @"C:\Users\Sevka\source\repos\Krypta_all\Krypta_all\";
            openFileDialog.Filter = "txt files (*.txt)|*.txt";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                filename = openFileDialog.FileName;
                using (StreamReader reader = new StreamReader(filename))
                {
                    messege = reader.ReadToEnd().ToUpper();
                    textBox1.Text = messege;
                }
            }
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
        public static int Euclid1(int a, int b)
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
        private long getprime(long n)
        {
            int l = Convert.ToInt32((Math.Log(n, 2)));
            if (Math.Pow(2, l) < n)
            {
                l += 1;
            }
            var r = new Random();
            int x = r.Next(0, Convert.ToInt32(Math.Pow(2, l)));
            while (x >= n || Euclid1((int)n, x) != 1)
            {
                x = r.Next(0, Convert.ToInt32(Math.Pow(2, l)));
            }
            return x;
        }

        private long calcD(long m, long e)
        {
            long d = 2;
            while (true)
            {
                if ((e * d) % m == 1)
                    break;
                else
                    d++;
            }
            return d;
        }
        private long calcE(long m)
        {
            return getprime((int)m);
        }
        private List<string> Sign(string mess, long d, long n)
        {
            List<string> result = new List<string>();

            BigInteger bi;

            for (int i = 0; i < mess.Length; i++)
            {
                int index = Array.IndexOf(characters, mess[i]);

                bi = new BigInteger(index);
                bi = BigInteger.Pow(bi, (int)d);

                BigInteger n_ = new BigInteger((int)n);

                bi %= n_;

                result.Add(bi.ToString());
            }
            return result;
        }

        private bool Check(List<string> input, long e, long n, string mess)
        {
            BigInteger bi;
            string mes_ = "";
            foreach (string item in input)
            {
                bi = new BigInteger(Convert.ToDouble(item));
                bi = BigInteger.Pow(bi, (int)e);

                BigInteger n_ = new BigInteger((int)n);

                bi %= n_;

                int index = Convert.ToInt32(bi.ToString());

                mes_ += characters[index].ToString();
            }
            return mess == mes_;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if ((textBox4.Text.Length > 0) && (textBox5.Text.Length > 0))
            {
                long p = Convert.ToInt64(textBox4.Text);
                long q = Convert.ToInt64(textBox5.Text);

                if (solovayStrassen(p, 50) && solovayStrassen(q, 50))
                {
                    long n = p * q;
                    long m = (p - 1) * (q - 1);
                    long e_ = calcE(m);
                    long d = calcD(m, e_);
                    textBox6.Text = n.ToString();
                    textBox8.Text = e_.ToString();
                    textBox7.Text = d.ToString();
                    List<string> enc = Sign(messege, d, n);

                    SaveFileDialog savefile = new SaveFileDialog();
                    savefile.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
                    if (savefile.ShowDialog() == DialogResult.OK)
                    {
                        using (StreamWriter sw = new StreamWriter(savefile.FileName))
                        {
                            for (int i = 0; i < enc.Count - 1; i++)
                            {
                                sw.Write(enc[i] + Environment.NewLine);
                            }

                            sw.Write(enc[enc.Count - 1]);
                        }
                    }
                }
                else
                    MessageBox.Show("p or q not prime");
            }
            else
                MessageBox.Show("Input p and q!");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            string filename;
            openFileDialog.InitialDirectory = @"C:\Users\Sevka\source\repos\Krypta_all\Krypta_all\";
            openFileDialog.Filter = "txt files (*.txt)|*.txt";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                filename = openFileDialog.FileName;
                using (StreamReader reader = new StreamReader(filename))
                {
                    check_messege = reader.ReadToEnd().ToUpper();
                    textBox2.Text = check_messege;
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            string filename;
            openFileDialog.InitialDirectory = @"C:\Users\Sevka\source\repos\Krypta_all\Krypta_all\";
            openFileDialog.Filter = "txt files (*.txt)|*.txt";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                filename = openFileDialog.FileName;
                using (StreamReader reader = new StreamReader(filename))
                {
                    check_sign = reader.ReadToEnd().Split('\n').ToList();
                    textBox3.Text = Signd(check_sign);
                }
            }
        }

        private string Signd(List<string>list)
        {
            string text= "";
            foreach(var ch in list)
            {
                text += ch + " ";
            }
            return text;
        }
        private void button5_Click(object sender, EventArgs e)
        {
                long e_ = Convert.ToInt64(textBox8.Text);
                long n = Convert.ToInt64(textBox6.Text);
                if (Check(check_sign, e_, n, check_messege))
                {
                    MessageBox.Show("Correct", "Result");
                }
                else
                {
                    MessageBox.Show("Incorrect", "Result");
                }
            }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
        "Бажаєте зберегти дані перед виходом?",
        "Увага!",
        MessageBoxButtons.YesNoCancel,
        MessageBoxIcon.Information,
        MessageBoxDefaultButton.Button1,
        MessageBoxOptions.DefaultDesktopOnly);

            if (result == DialogResult.Yes)
            {
                button1.BackColor = Color.Red;
                SaveFileDialog sfd = new SaveFileDialog();
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    File.WriteAllText(sfd.FileName, textBox3.Text);
                }
                MessageBox.Show(
            "       Успішно збережено!",
            ""
            );
                this.Close();
            }
            if (result == DialogResult.No)
            {
                this.Close();
            }
        }
    }
    }

