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
    public partial class Form2 : Form
    {
        Dictionary<char, float> dic = new Dictionary<char, float>();
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
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
            string str = textBox1.Text;
            MessageBox.Show($"Загальна кількість символів: {textBox1.Text.Length}");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            string str = textBox1.Text;
            str = str.ToLower();
            string str1 = "";
            for (int i = 0; i < str.Length; i++)
            {
                if (Char.IsLetter(str[i]))
                {
                    str1 += str[i];
                }
            }
            foreach (char ch in str1)
            {
                if (dic.ContainsKey(ch))
                    dic[ch]++;
                else
                    dic.Add(ch, 1);
            }
            dataGridView1.Columns.Add("Letter", "Letter");
            dataGridView1.Columns.Add("Count", "Count");
            foreach (KeyValuePair<char, float> item in dic)
            {
                dataGridView1.Rows.Add(item.Key, item.Value);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            string str = textBox1.Text;
            str = str.ToLower();
            string str1 = "";
            for (int i = 0; i < str.Length; i++)
            {
                if (Char.IsLetter(str[i]))
                {
                    str1 += str[i];
                }
            }
            var counted = str1.GroupBy(c => c).Select(g => new { g.Key, Count = g.Count() }).OrderByDescending(o => o.Count);
            int leng = str1.Length;
            foreach (char ch in str1)
            {
                if (dic.ContainsKey(ch))
                    dic[ch]++;
                else
                    dic.Add(ch, 1);
            }
            dataGridView1.Columns.Add("Letter", "Letter");
            dataGridView1.Columns.Add("Count", "Count");
            foreach (KeyValuePair<char, float> kvp in dic.OrderBy(key => key.Key))
            {
                float r = (kvp.Value / leng) * 100;
                float r1 = (float)Math.Round(r, 1);
                dataGridView1.Rows.Add(kvp.Key, r1);
                //textBox2.Text += string.Format("{0}-{1}% \t", kvp.Key, r1);
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                using (TextWriter tw = new StreamWriter(sfd.FileName))
                {
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
                    using (TextWriter tw = new StreamWriter(sfd.FileName))
                    {
                        for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                        {
                            for (int j = 0; j < dataGridView1.Columns.Count; j++)
                            {
                                tw.Write($"{dataGridView1.Rows[i].Cells[j].Value.ToString()}");

                                if (j != dataGridView1.Columns.Count - 1)
                                {
                                    tw.Write(",");
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
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            textBox1.Text = "";
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
