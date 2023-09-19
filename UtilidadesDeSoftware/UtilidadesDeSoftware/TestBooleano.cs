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
    public partial class TestBooleano : Form
    {
        public TestBooleano()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var test = new TestingBool();
            MessageBox.Show(test.error.ToString());
        }

        public class TestingBool
        {
            public bool error {get;set;}
        }
    }
}
