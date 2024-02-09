using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesDeSoftware.Clases.HTTP_APITC.ApiTcResponse
{
    public class PWCreateTransactionResponseDto
    {
        public bool status { get; set; }
        public Data data { get; set; }
    }

    public class Currencycode
    {
        public int id { get; set; }
        public string name { get; set; }
        public string code { get; set; }
        public string symbol { get; set; }
        public DateTime createdat { get; set; }
        public object updatedat { get; set; }
    }

    public class Data
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
        public object updatedat { get; set; }
        public object deletedat { get; set; }
        public object jsonresponse { get; set; }
        public string additionaldata { get; set; }
        public object responseUrl { get; set; }
        public bool validateResponse { get; set; }
        public object firstjsonresponse { get; set; }
        public object clearsaferesponse { get; set; }
        public object paymentedat { get; set; }
        public object originalAmount { get; set; }
        public object conversionRate { get; set; }
        public int consultaActual { get; set; }
        public bool isRedeban { get; set; }
        public Idperson idperson { get; set; }
        public Idstatus idstatus { get; set; }
        public object paymentmethod { get; set; }
        public object mediodepago { get; set; }
        public Idform idform { get; set; }
        public Currencycode currencycode { get; set; }
    }

    public class Idform
    {
        public string id { get; set; }
        public string name { get; set; }
        public bool testmode { get; set; }
        public bool esabierto { get; set; }
        public bool status { get; set; }
        public bool customizable { get; set; }
        public Idterminal idterminal { get; set; }
    }

    public class Ididentificationtype
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string code { get; set; }
        public DateTime createdat { get; set; }
        public object updatedat { get; set; }
        public string iddavivienda { get; set; }
        public bool status { get; set; }
    }

    public class Idmerchant
    {
        public string id { get; set; }
        public string name { get; set; }
        public string logo { get; set; }
        public string url { get; set; }
        public string contactinfo { get; set; }
        public string contactname { get; set; }
        public string phone { get; set; }
        public string city { get; set; }
        public string addressone { get; set; }
        public string addresstwo { get; set; }
        public string zipcode { get; set; }
        public string legaldocument { get; set; }
        public string apikey { get; set; }
        public object codigo_ciiu { get; set; }
        public DateTime createdat { get; set; }
        public object updatedat { get; set; }
        public string persontype { get; set; }
        public bool autorizacionSendEmails { get; set; }
        public List<object> autorizacionEmails { get; set; }
        public bool testMechant { get; set; }
        public object preRegistroId { get; set; }
        public string origenCompliance { get; set; }
        public object urlRetorno { get; set; }
        public bool ismarcablanca { get; set; }
        public int membersmaximum { get; set; }
        public string email_validation { get; set; }
        public int limiteFallidasPorHora { get; set; }
    }

    public class Idperson
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
        public Ididentificationtype ididentificationtype { get; set; }
    }

    public class Idstatus
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public DateTime createdat { get; set; }
        public object updatedat { get; set; }
    }

    public class Idterminal
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string webhook { get; set; }
        public DateTime createdat { get; set; }
        public DateTime updatedat { get; set; }
        public bool useclarsafe { get; set; }
        public bool habilitasubscripciones { get; set; }
        public bool reprocesarestados { get; set; }
        public bool habilitarnotificaciones { get; set; }
        public bool isdefaultmarcablanca { get; set; }
        public bool use3ds { get; set; }
        public bool red { get; set; }
        public bool enablecardtokenization { get; set; }
        public Idmerchant idmerchant { get; set; }
    }
}
