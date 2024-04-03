using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form5 : Form
    {
        string publickey = "";
        string vi = "";
        string tagi = "";
        public Form5()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {

        }
        [Obsolete]
        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(richTextBox1.Text))
                return;


            byte[] nonce = new byte[12];
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(nonce);
            }

            var strKey = !string.IsNullOrEmpty(publickey) ? publickey : textBox1.Text;

            byte[] key = Convert.FromBase64String(strKey);

            using (var cipher = new AesGcm(key))
            {
                byte[] plaintextBytes = System.Text.Encoding.UTF8.GetBytes(richTextBox1.Text.Trim());
                byte[] ciphertext = new byte[plaintextBytes.Length];
                byte[] tag = new byte[16];

                cipher.Encrypt(nonce, plaintextBytes, ciphertext, tag);

                var encryptedData = new
                {
                    tag = Convert.ToBase64String(tag),
                    vi = Convert.ToBase64String(nonce),
                    dt = Convert.ToBase64String(ciphertext)
                };

                string json = JsonConvert.SerializeObject(encryptedData);
                richTextBox1.Text = json;
                textBox1.Text = strKey;
                textBox2.Text = Convert.ToBase64String(nonce);
                textBox3.Text = Convert.ToBase64String(tag);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var form4 = new Form4();
            form4.Show();
            this.Close();
        }

      
    }
}
