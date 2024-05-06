using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form6 : Form
    {
        string objAuthTCStr = string.Empty;
        public Form6()
        {
            InitializeComponent();
        }

        private void Form6_Load(object sender, EventArgs e)
        {
          
        } 

        private void ObtenerValoresTC()
        {
            objAuthTCStr = ValuesTokenCognito.json;
            var objAuth = JsonConvert.DeserializeObject<ValuesTokenCognito>(objAuthTCStr);
        }
    }
}
