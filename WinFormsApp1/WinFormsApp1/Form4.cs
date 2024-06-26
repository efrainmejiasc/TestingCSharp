﻿using System.Security.Cryptography;

namespace WinFormsApp1
{
    public partial class Form4 : Form
    {

        string publickey = "F75HLl1ODgfHGI44MAEWZFMqvfJjGs6wmqwhwmqewi8=";
        string vi = "";
        string tagi = "";
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            var form5 = new Form5();
            form5.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(richTextBox1.Text))
                return;

            var strkey = (!string.IsNullOrEmpty(publickey)) ? publickey : textBox1.Text.Trim();
            var strvi = (!string.IsNullOrEmpty(vi)) ? vi : textBox2.Text.Trim();
            var strtag = (!string.IsNullOrEmpty(tagi)) ? tagi : textBox3.Text.Trim();

            byte[] ciphertext = Convert.FromBase64String(richTextBox1.Text);
            byte[] key = Convert.FromBase64String(strkey);
            byte[] nonce = Convert.FromBase64String(strvi);
            byte[] tag = Convert.FromBase64String(strtag);

            using (var cipher = new AesGcm(key))
            {
                byte[] plaintext = new byte[ciphertext.Length];

                cipher.Decrypt(nonce, ciphertext, tag, plaintext);

                richTextBox1.Text = System.Text.Encoding.UTF8.GetString(plaintext);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var form5 = new Form5();
            form5.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var form6 = new Form6();
            form6.Show();
            this.Hide();
        }
    }
}
