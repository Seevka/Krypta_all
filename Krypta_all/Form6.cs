using System;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using System.Drawing;
using System.IO;

namespace Krypta_all
{
    public partial class Form6 : Form
    {
        string UserAnswer;
        public Form6()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
            var cipher = new VigenereCipher("АБВГҐДЕЄЖЗИІЇЙКЛМНОПРСТУФХЦЧШЩЬЮЯ");
            var inputText = textBox1.Text.ToUpper();
            UserAnswer = Interaction.InputBox("Введіть, будь ласка, ключ ", "Ключ").ToUpper();
            textBox2.Text += cipher.Encrypt(inputText, UserAnswer);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
            var cipher = new VigenereCipher("АБВГҐДЕЄЖЗИІЇЙКЛМНОПРСТУФХЦЧШЩЬЮЯ");
            var inputText = textBox1.Text;
            UserAnswer = Interaction.InputBox("Введіть, будь ласка, ключ ", "Ключ").ToUpper();
            textBox2.Text += cipher.Decrypt(inputText, UserAnswer);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(sfd.FileName, textBox1.Text + "\r\n" + textBox2.Text + "\r\nКлюч:" + UserAnswer);
            }
            MessageBox.Show(
        "       Успішно збережено!",
        ""
        );
        }

        private void button5_Click(object sender, EventArgs e)
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
                    File.WriteAllText(sfd.FileName, textBox1.Text + "\r\n" + textBox2.Text + "\r\nКлюч:" + UserAnswer); 
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

        private void button6_Click(object sender, EventArgs e)
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
    }
}
