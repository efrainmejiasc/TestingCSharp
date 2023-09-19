using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UtilidadesDeSoftware
{
    public partial class Cadenas : Form
    {
        public Cadenas()
        {
            InitializeComponent();
        }

        private void Cadenas_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //var cadena = textBox1.Text.Substring(textBox1.Text.Length - 7, 7);
            var cadena = textBox1.Text.Substring(textBox1.Text.Length - 4, 4);
            textBox2.Text = cadena;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var numero = Convert.ToDecimal(textBox4.Text);
            var strNumero = numero.ToString("#,##0.00");
            textBox3.Text = strNumero;
        }
    }
}
