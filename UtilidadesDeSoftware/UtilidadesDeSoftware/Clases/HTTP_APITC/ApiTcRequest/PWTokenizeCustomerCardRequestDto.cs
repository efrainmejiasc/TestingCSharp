using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesDeSoftware.Clases.HTTP_APITC.ApiTcRequest
{
    public class PWTokenizeCustomerCardRequestDto
    {
        public int idtransaction { get; set; }
        public int idterminal { get; set; }
        public string card_holder { get; set; }
        public string card_pan { get; set; }
        public string card_expiry_year { get; set; }
        public string card_expiry_month { get; set; }
        public string card_cvv { get; set; }
        public bool  autorizacionDatos { get; set; }
    }
}
