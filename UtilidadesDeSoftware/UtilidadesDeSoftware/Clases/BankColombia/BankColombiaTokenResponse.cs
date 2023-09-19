using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesDeSoftware.Clases.BankColombia
{
    public class BankColombiaTokenResponse
    {
        public string Token_Type { get; set; }
        public string Access_Token { get; set; }
        public string Scope { get; set; }
        public int Expires_In { get; set; }
        public int Consented_On { get; set; }
    }

}
