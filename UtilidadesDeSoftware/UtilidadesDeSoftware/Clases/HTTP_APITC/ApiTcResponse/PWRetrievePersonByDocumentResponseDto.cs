using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesDeSoftware.Clases.HTTP_APITC.ApiTcResponse
{
    public class PWRetrievePersonByDocumentResponseDto
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
        public object coutrycode { get; set; }
        public List<TarjetasguardadaRetrievePersonByDocumentResponse> tarjetasguardadas { get; set; }
        public IdidentificationtypeRetrievePersonByDocumentResponse ididentificationtype { get; set; }
    }

    public class IdidentificationtypeRetrievePersonByDocumentResponse
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string code { get; set; }
        public DateTime createdat { get; set; }
        public object updatedat { get; set; }
        public string iddavivienda { get; set; }
        public bool status { get; set; }
    }

    public class TarjetasguardadaRetrievePersonByDocumentResponse
    {
        public string id { get; set; }
        public string uuidPl { get; set; }
        public string customerId { get; set; }
        public string typeObject { get; set; }
        public string typePl { get; set; }
        public string token { get; set; }
        public string brand { get; set; }
        public string country { get; set; }
        public string holder { get; set; }
        public string last4 { get; set; }
        public bool isSaved { get; set; }
        public string additional { get; set; }
        public string bank { get; set; }
        public object prepaid { get; set; }
        public object validationDate { get; set; }
        public DateTime creationDate { get; set; }
        public string brandDescription { get; set; }
        public bool autorizacion1581 { get; set; }
        public bool status { get; set; }
    }
}
