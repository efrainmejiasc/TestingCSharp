using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesDeSoftware.Clases.HTTP_APITC.ApiTcResponse
{
    public class PWRetrieveAllTransactionStatusesResponseDto
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public DateTime createdat { get; set; }
        public object updatedat { get; set; }
    }
   
}
