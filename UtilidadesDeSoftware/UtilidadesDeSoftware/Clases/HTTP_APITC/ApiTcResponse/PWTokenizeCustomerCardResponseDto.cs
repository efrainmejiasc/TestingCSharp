using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesDeSoftware.Clases.HTTP_APITC.ApiTcResponse
{
    public class PWTokenizeCustomerCardResponseDto
    {
        public string customerId { get; set; }
        public string typeObject { get; set; }
        public string uuidPl { get; set; }
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
        public string id { get; set; }
        public bool status { get; set; }
    }
}
