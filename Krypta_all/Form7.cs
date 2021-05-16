using System;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using System.Drawing;
using System.Collections.Generic;
using System.IO;


namespace Krypta_all
{
    public partial class Form7 : Form
    {
        string userAnswer;
        public Form7()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
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
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(sfd.FileName, textBox1.Text + "\r\n" + textBox2.Text + "\r\nКлюч:"+userAnswer.ToLower());
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
                    File.WriteAllText(sfd.FileName, textBox1.Text + "\r\n" + textBox2.Text + "\r\nКлюч:" + userAnswer.ToLower());
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

        private void button1_Click(object sender, EventArgs e)
        {
            userAnswer = Interaction.InputBox("Введіть, будь ласка, ключ ", "Ключ").ToUpper();
            string sampleString = textBox1.Text.ToLower();
            string key = userAnswer;
            string encryptedString = encryptDecrypt(sampleString, key);
            textBox2.Text = encryptedString;
        }

        private string encryptDecrypt(String inputString, string key)
        {
            int keyLen = key.Length;

            String outputString = "";


            int len = inputString.Length;


            for (int i = 0; i < len; i++)
            {
                outputString = outputString +
                char.ToString((char)(inputString[i] ^ key[i % keyLen]));
            }
            return outputString;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            userAnswer = Interaction.InputBox("Введіть, будь ласка, ключ ", "Ключ").ToUpper();
            string encrypted = textBox1.Text;
            string key = userAnswer;
            string ww = encryptDecrypt(encrypted, key);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
