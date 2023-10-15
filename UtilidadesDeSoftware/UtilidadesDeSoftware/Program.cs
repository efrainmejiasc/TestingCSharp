using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UtilidadesDeSoftware
{
    static class Program
    {
        /// <summary>
        /// Por esa Mujer.
        /// </summary>
        [STAThread]
        static void Main()
       {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new BankCoHeaders());
        }
    }
}
