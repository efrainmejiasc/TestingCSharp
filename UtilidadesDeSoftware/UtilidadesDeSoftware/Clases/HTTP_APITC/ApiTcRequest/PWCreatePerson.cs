using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesDeSoftware.Clases.HTTP_APITC.ApiTcRequest
{
    public class PWCreatePerson
    {
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string ididentificationtype { get; set; }
        public string identification { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string state { get; set; }
        public string city { get; set; }
        public string address { get; set; }
        public string zipcode { get; set; }
    }
}
