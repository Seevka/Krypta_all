using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Net;
namespace Krypta_all
{
    public partial class Form3 : Form
    {
        string newstr = "";
        char[] z;
        char[] mas1;
        char[] o;
        char[] o1;
        char[] text2;
        char[] text1;
        char[] mas;
        char[] mass;
        string str;
        string str1;
        string alphabet;
        string newstr1;
        string xz;
        string xz1;
        
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                InitialDirectory = @"C:\Users\Sevka\source\repos\Crypta\Crypta",
                Title = "Browse Text Files",

                CheckFileExists = true,
                CheckPathExists = true,

                DefaultExt = "txt",
                Filter = "txt files (*.txt)|*.txt",
                FilterIndex = 2,
                RestoreDirectory = true,

                ReadOnlyChecked = true,
                ShowReadOnly = true
            };

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string filename = openFileDialog1.FileName;
                string fileText = File.ReadAllText(filename);
                textBox1.Text = fileText;
            }
            str = textBox1.Text;
        }

        private void button2_Click(object sender, EventArgs e)
        {

            textBox2.Text = "";
            textBox3.Text = "";
            Random rnd = new Random((char)DateTime.Now.Ticks);
            mas = new char[26];
            mass = new char[26];
            for (int i = 0; i < 26; i++)
            {
                char a1 = (char)rnd.Next(0x0061, 0x007B);
                if (!mas.Contains(a1))
                {
                    mas[i] = a1;
                }
                else
                    i--;
            }

            for (int i = 0; i < 26; i++)
            {
                char a11 = (char)rnd.Next(0x0041, 0x005B);
                if (!mass.Contains(a11))
                {
                    mass[i] = a11;
                }
                else
                    i--;
            }
            z = mas.Concat(mass).ToArray();

            alphabet = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
 
            mas1 = alphabet.ToCharArray();
            //List<KeyValuePair<char, char>> dic = new List<KeyValuePair<char, char>>();
            //for (int i = 0; i < 52; i++)
            //{
            //    dic.Add(new KeyValuePair<char, char>(mas1[i], z[i]));
            //}
            for (int i = 0; i < 52; i++)
            {
                listBox1.Items.Add(mas1[i]+"-"+z[i]);
                //dataGridView1.DataSource = dic;
            }
            str = textBox1.Text;
            str1 = "";
            for (int i = 0; i < str.Length; i++)
            {
                if (Char.IsLetter(str[i]) || Char.IsWhiteSpace(str[i]))
                {
                    str1 += str[i];
                }
            }

            text1 = str1.ToCharArray();
            bool x;
            for (int i = 0; i < text1.Length; i++)
            {
                x = true;

                for (int j = 0; j < mas1.Length; j++)
                {
                    if (text1[i] == mas1[j])
                    {
                        newstr += z[j];
                        x = false;
                    }
                }
                if (x)
                {
                    newstr += text1[i];
                }
            }
            textBox2.Text = newstr;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
            textBox3.Text = "";
            text2 = newstr.ToCharArray();
            newstr1 = "";
            bool x;

            for (int i = 0; i < text2.Length; i++)
            {
                x = true;
                for (int j = 0; j < z.Length; j++)
                {
                    if (text2[i] == z[j])
                    {
                        newstr1 += mas1[j];
                        x = false;
                    }
                }
                if (x)
                {
                    newstr1 += text2[i];
                }
            }
            textBox3.Text += newstr1;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(sfd.FileName, textBox2.Text);
            }
            MessageBox.Show(
        "       Успішно збережено!",
        ""
        );
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(sfd.FileName, textBox3.Text);
            }
            MessageBox.Show(
        "       Успішно збережено!",
        ""
        );
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
                    File.WriteAllText(sfd.FileName, "Зашифрований:\r\n" + textBox2.Text + "\r\n" + "Розшифрований:\r\n" + textBox3.Text);
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

        private void button7_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void button7_Click_1(object sender, EventArgs e)
        {

        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            string t;
            t = listBox1.Items.ToString();
            
            {
                SaveFileDialog sfd = new SaveFileDialog();
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    Stream file_stream = sfd.OpenFile();
                    StreamWriter sw = new StreamWriter(file_stream);

                    for (int i = 0; i < 51; i++)
                    {
                        sw.WriteLine(t);
                    }

                    
                }
                MessageBox.Show(
            "       Успішно збережено!",
            ""
            );
            }
        }
    }
}
