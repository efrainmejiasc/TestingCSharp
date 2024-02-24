using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesDeSoftware.Clases.HTTP_APITC.ApiTcResponse
{
    public class PWRetrieveTransactionResponseDto
    {
        public string id { get; set; }
        public bool issubscription { get; set; }
        public int amount { get; set; }
        public string externalorder { get; set; }
        public object urllanding { get; set; }
        public string origen { get; set; }
        public object nextpaymentdate { get; set; }
        public string ip { get; set; }
        public string fullname { get; set; }
        public object status { get; set; }
        public DateTime createdat { get; set; }
        public DateTime updatedat { get; set; }
        public object deletedat { get; set; }
        public string jsonresponse { get; set; }
        public string additionaldata { get; set; }
        public object responseUrl { get; set; }
        public bool validateResponse { get; set; }
        public object firstjsonresponse { get; set; }
        public object clearsaferesponse { get; set; }
        public DateTime paymentedat { get; set; }
        public object originalAmount { get; set; }
        public object conversionRate { get; set; }
        public int consultaActual { get; set; }
        public bool isRedeban { get; set; }
        public IdpersonRetrieveTransactionResponse idperson { get; set; }
        public IdstatusRetrieveTransactionResponse idstatus { get; set; }
        public IdformRetrieveTransactionResponse idform { get; set; }
        public PaymentmethodRetrieveTransactionResponse paymentmethod { get; set; }
        public object idlinkpagoabierto { get; set; }
        public object idlinkpago { get; set; }
    }

    public class IdformRetrieveTransactionResponse
    {
        public string id { get; set; }
        public string name { get; set; }
        public bool testmode { get; set; }
        public bool esabierto { get; set; }
        public bool status { get; set; }
        public bool customizable { get; set; }
    }

    public class IdpersonRetrieveTransactionResponse
    {
        public string id { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public object treatment { get; set; }
        public object gender { get; set; }
        public string identification { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string state { get; set; }
        public string city { get; set; }
        public string address { get; set; }
        public string zipcode { get; set; }
        public object borndate { get; set; }
        public DateTime createdat { get; set; }
        public object updatedat { get; set; }
        public object deletedat { get; set; }
    }

    public class IdstatusRetrieveTransactionResponse
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public DateTime createdat { get; set; }
        public object updatedat { get; set; }
    }

    public class PaymentmethodRetrieveTransactionResponse
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public DateTime createdat { get; set; }
        public DateTime updatedat { get; set; }
        public string estado { get; set; }
        public object mensaje { get; set; }
    }
}
