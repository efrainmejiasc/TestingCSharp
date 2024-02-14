using com.sun.security.ntlm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesDeSoftware.Clases.HTTP_APITC.ApiTcResponse
{
    public class PWExecuteOrderTcClientResponseDto
    {
        public string message { get; set; }
        public int code { get; set; }
        public DateTime current_time { get; set; }
        public OrderExecuteOrderTcClientResponse order { get; set; }
        public ClientExecuteOrderTcClientResponse client { get; set; }
        public ExtraDataExecuteOrderTcClientResponse extra_data { get; set; }
        public string validation_hash { get; set; }
    }


    public class AntifraudExecuteOrderTcClientResponse
    {
        public string evaluation { get; set; }
        public int score { get; set; }
        public int risk_score { get; set; }
        public int fraud_score { get; set; }
        public List<object> triggered_rules { get; set; }
    }

    public class ClientExecuteOrderTcClientResponse
    {
        public string uuid { get; set; }
    }

    public class CofExecuteOrderTcClientResponse
    {
        public bool is_available { get; set; }
    }

    public class ExtraDataExecuteOrderTcClientResponse
    {
        public PaymentExecuteOrderTcClientResponse payment { get; set; }
    }

    public class OrderExecuteOrderTcClientResponse
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
        public List<TransactionExecuteOrderTcClientResponse> transactions { get; set; }
        public object token { get; set; }
        public string ip { get; set; }
        public string reference { get; set; }
        public string dynamic_descriptor { get; set; }
        public object threeds_data { get; set; }
    }

    public class PaymentExecuteOrderTcClientResponse
    {
        public string installments { get; set; }
    }


    public class SourceExecuteOrderTcClientResponse
    {
        public string @object { get; set; }
        public string uuid { get; set; }
        public string type { get; set; }
        public string token { get; set; }
        public string brand { get; set; }
        public string country { get; set; }
        public string holder { get; set; }
        public int bin { get; set; }
        public string last4 { get; set; }
        public bool is_saved { get; set; }
        public string expire_month { get; set; }
        public string expire_year { get; set; }
        public string additional { get; set; }
        public string bank { get; set; }
        public object prepaid { get; set; }
        public DateTime validation_date { get; set; }
        public DateTime creation_date { get; set; }
        public string brand_description { get; set; }
        public string origin { get; set; }
        public CofExecuteOrderTcClientResponse cof { get; set; }
    }

    public class TransactionExecuteOrderTcClientResponse
    {
        public string uuid { get; set; }
        public DateTime created { get; set; }
        public DateTime created_from_client_timezone { get; set; }
        public string operative { get; set; }
        public int amount { get; set; }
        public string authorization { get; set; }
        public string processor_id { get; set; }
        public string status { get; set; }
        public string error { get; set; }
        public SourceExecuteOrderTcClientResponse source { get; set; }
        public AntifraudExecuteOrderTcClientResponse antifraud { get; set; }
        public object device { get; set; }
        public object error_details { get; set; }
    }

}
