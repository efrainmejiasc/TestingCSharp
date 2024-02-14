using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesDeSoftware.Clases.HTTP_APITC.ApiTcRequest
{
    public class PWCreateOrderTcClientRequestDto
    {
        public string url_ok { get; set; }
        public string url_ko { get; set; }
        public string description { get; set; }
        public string reference { get; set; }
        public string dynamic_descriptor { get; set; }
        public int form_id { get; set; }
        public int terminal_id { get; set; }
        public ExtraDataCreateOrderTcClientRequest extra_data { get; set; }
    }

    public class ExtraDataCreateOrderTcClientRequest
    {
        public PaymentCreateOrderTcClientRequest payment { get; set; }
    }

    public class PaymentCreateOrderTcClientRequest
    {
        public int installments { get; set; }
    }
}
