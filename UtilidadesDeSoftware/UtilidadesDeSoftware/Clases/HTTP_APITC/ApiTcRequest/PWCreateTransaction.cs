using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesDeSoftware.Clases.HTTP_APITC.ApiTcRequest
{
    public class PWCreateTransaction
    {
        public int form_id { get; set; }
        public int terminal_id { get; set; }
        public string idperson { get; set; }
        public string amount { get; set; }
        public string external_order { get; set; }
        public string ip { get; set; }
        public string additionalData { get; set; }
        public string currencycode { get; set; }
    }
}
