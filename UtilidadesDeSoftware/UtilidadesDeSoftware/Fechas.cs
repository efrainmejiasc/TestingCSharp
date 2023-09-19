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

    }
}
