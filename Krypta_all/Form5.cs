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
using Microsoft.VisualBasic;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Net;

namespace Krypta_all
{
    public partial class Form5 : Form
    {
        string str;
        Dictionary<char, char> dic2 = new Dictionary<char, char>();
        public Form5()
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
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            string buf = textBox1.Text;

            string alphabet = "abcdefghijklmnopqrstuvwxyz";

            Dictionary<char, float> dic = new Dictionary<char, float>();
            foreach (char ch in alphabet)
                dic.Add(ch, 0);

            string lowerStr = buf.ToLower();

            foreach (char ch in lowerStr)
                if (alphabet.Contains(ch.ToString()))
                    dic[ch]++;

            var sbu = new StringBuilder();

            foreach (char c in lowerStr)
                if (!char.IsPunctuation(c))
                    sbu.Append(c);

            lowerStr = sbu.ToString();
            string d = lowerStr.Replace(" ", "");

            dic = dic.OrderBy(x => (float)Math.Round((x.Value / d.Length) * 100, 2))
                .ToDictionary(x => x.Key, x => (float)Math.Round((x.Value / d.Length) * 100, 2));

            char[] array = dic.Keys.ToArray();

            Dictionary<char, float> dic1 = new Dictionary<char, float>();

            string[] lines = File.ReadAllLines(@"C:\Users\Sevka\source\repos\Krypta_all\Krypta_all\bin\Eng.txt");
            foreach (string line in lines)
                dic1.Add(Convert.ToChar(line.Split()[0]), Convert.ToSingle(line.Split()[1]));


            dic1 = dic1.OrderBy(x => x.Value).ToDictionary(x => x.Key, x => x.Value);

            char[] array1 = dic1.Keys.ToArray();

           
            for (int i = 0; i < 26; i++)
            {
                dic2.Add(array[i], array1[i]);
            }

            StringBuilder sb = new StringBuilder();

            foreach (var pair in dic2)
            {
                sb.AppendLine($"{pair.Key} -> {pair.Value} ");
            }
            dataGridView1.Columns.Add("Before","Before");
            dataGridView1.Columns.Add("After", "After");
            foreach (KeyValuePair<char, char> item in dic2)
            {
                dataGridView1.Rows.Add(item.Key, item.Value);
            }

            char[] letters = buf.ToCharArray();

            foreach (var letter in letters)
            {
                int index = buf.IndexOf(letter);
                while (index != -1)
                {
                    if (dic2.ContainsKey(letter))
                    {
                        letters[index] = dic2[letter];
                    }
                    index = buf.IndexOf(letter, index + 1);
                }
            }

            string newFileText = new string(letters);
            //newFileText = newFileText.Replace('b', '&').Replace('p', 'b').Replace('g', 'p').Replace('&', 'g').Replace('f', '#').Replace('w', 'f').Replace('y', 'w').Replace('#', 'y').Replace('c','%').Replace('m','c').Replace('%','m').Replace('q', '!').Replace('j','q').Replace('!','j');
            textBox2.Text = newFileText;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string buf = textBox2.Text;

            char[] letter1 = buf.ToCharArray();
            bool j = true;
            char value=' ';
            if (j)
            {
              string up = Interaction.InputBox("Введіть, будь ласка, яку букву змінити ", "Буква для зміни");
                string down = Interaction.InputBox("Введіть, будь ласка, на яку букву змінити ", "Буква на яку змінити");

                foreach (var i in letter1)
                {
                    int n = buf.IndexOf(i);
                    while (n != -1)
                    {
                        if (letter1[n] == char.Parse(up))
                        {
                            letter1[n] = char.Parse(down);
                        }
                        n = buf.IndexOf(i, n + 1);
                    }
                }
                dic2.Remove(char.Parse(up));
                dic2.Add(char.Parse(up), char.Parse(down));
                dataGridView1.Rows.Clear();
                dataGridView1.Refresh();
                foreach (KeyValuePair<char, char> item in dic2)
                {
                    dataGridView1.Rows.Add(item.Key, item.Value);
                }
                string newWord = new string(letter1);
                textBox2.Text = newWord;
            }
        }

        private void button4_Click(object sender, EventArgs e)
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
                    File.WriteAllText(sfd.FileName, $"Your text: {textBox2.Text}\r\nYour replacement plate:\r\n");
                    using (TextWriter tw = new StreamWriter(sfd.FileName))
                    {
                        tw.Write($"Your text: {textBox2.Text}\rYour replacement plate:\r");
                        for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                        {
                            for (int j = 0; j < dataGridView1.Columns.Count; j++)
                            {
                                tw.Write($"{dataGridView1.Rows[i].Cells[j].Value.ToString()}");

                                if (j != dataGridView1.Columns.Count - 1)
                                {
                                    tw.Write("-");
                                }
                            }
                            tw.WriteLine();
                        }
                    }
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

        private void button5_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                using (TextWriter tw = new StreamWriter(sfd.FileName))
                {
                    tw.Write($"Your text: {textBox2.Text}\rYour replacement plate:\r");
                    for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                    {
                        for (int j = 0; j < dataGridView1.Columns.Count; j++)
                        {
                            tw.Write($"{dataGridView1.Rows[i].Cells[j].Value.ToString()}");

                            if (j != dataGridView1.Columns.Count - 1)
                            {
                                tw.Write("-");
                            }
                        }
                        tw.WriteLine();
                    }
                }
            }
            MessageBox.Show(
        "       Успішно збережено!",
        ""
        );
        }
    }
}
