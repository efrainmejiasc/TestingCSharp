using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesDeSoftware.Clases.HTTP_APITC.ApiTcResponse
{
    public class PWCreatePersonResponseDto
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
        public object borndate { get; set; }
        public DateTime createdat { get; set; }
        public object treatment { get; set; }
        public object gender { get; set; }
        public object updatedat { get; set; }
        public object deletedat { get; set; }
        public string id { get; set; }
    }
}
