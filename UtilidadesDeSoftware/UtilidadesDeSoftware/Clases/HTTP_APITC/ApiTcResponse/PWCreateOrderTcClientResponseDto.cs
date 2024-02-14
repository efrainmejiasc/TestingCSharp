using com.sun.security.ntlm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UtilidadesDeSoftware.Clases.HTTP_APITC.ApiTcRequest;

namespace UtilidadesDeSoftware.Clases.HTTP_APITC.ApiTcResponse
{
    public class PWCreateOrderTcClientResponseDto
    {
        public string message { get; set; }
        public int code { get; set; }
        public DateTime current_time { get; set; }
        public OrderCreateOrderTcClientResponse order { get; set; }
        public ClientCreateOrderTcClientResponse client { get; set; }
        public ExtraDataCreateOrderTcClientResponse extra_data { get; set; }
        public string validation_hash { get; set; }
    }

    public class ClientCreateOrderTcClientResponse
    {
        public string uuid { get; set; }
    }

    public class ExtraDataCreateOrderTcClientResponse
    {
        public PaymentCreateOrderTcClientResponse payment { get; set; }
    }

    public class OrderCreateOrderTcClientResponse
    {
        public string uuid { get; set; }
        public DateTime created { get; set; }
        public DateTime created_from_client_timezone { get; set; }
        public int amount { get; set; }
        public string currency { get; set; }
        public bool paid { get; set; }
        public string status { get; set; }
        public bool safe { get; set; }
        public int refunded { get; set; }
        public object additional { get; set; }
        public string service { get; set; }
        public string service_uuid { get; set; }
        public string customer { get; set; }
        public object cof_txnid { get; set; }
        public List<object> transactions { get; set; }
        public string token { get; set; }
        public object ip { get; set; }
        public string reference { get; set; }
        public string dynamic_descriptor { get; set; }
        public object threeds_data { get; set; }
    }

    public class PaymentCreateOrderTcClientResponse
    {
        public string installments { get; set; }
    }
}
