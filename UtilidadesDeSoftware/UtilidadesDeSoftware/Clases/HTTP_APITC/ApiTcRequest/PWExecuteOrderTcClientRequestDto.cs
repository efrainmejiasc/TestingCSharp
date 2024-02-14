using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesDeSoftware.Clases.HTTP_APITC.ApiTcRequest
{
    public class PWExecuteOrderTcClientRequestDto
    {
        public string order_uuid { get; set; }
        public string card_uuid { get; set; }
        public string customer_ip { get; set; }
        public int idtransaction { get; set; }
        public bool successResponse { get; set; }
    }
}
