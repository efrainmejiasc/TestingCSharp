using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UtilidadesDeSoftware
{
    public partial class Fechas : Form
    {
        public Fechas()
        {
            InitializeComponent();
        }
        private void Fechas_Load(object sender, EventArgs e)
        {

        }
        private void Hora_Click(object sender, EventArgs e)
        {
            var hora = "12:00";                                                                 
            var currentHoour = DateTime.UtcNow.Hour.ToString();
            textBox1.Text = currentHoour + " - " + Convert.ToDateTime(hora).Hour.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox2.Text = DateTime.Now.Date.ToString("dd-MMMM-yyyy", new CultureInfo("ES-ES")).ToUpper();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //var transactionIdentifier = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString();
            var time = new DateTime(2023, 11, 03);
            var transactionIdentifier = time.Year.ToString() + time.Month.ToString() + time.Day.ToString();
            textBox3.Text = transactionIdentifier;


            Random _random = new Random(DateTime.UtcNow.Millisecond);
            var unixTimestamp = _random.NextDouble().ToString().Replace(",", "").Replace(".", "").Remove(0, 1).Substring(0, 6);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var a1 = 1000;
            var a2 = 300;
            textBox4.Text = (a1 + a2).ToString() +".00";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var cadena = "1234567890ABCDEF";
            textBox5.Text = cadena.Substring(cadena.Length - 12);
        }
    }
}
