using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesDeSoftware.Clases.BankColombia
{
    public class ValidateCodeRequest
    {
        public DataValidateCodeRequest data { get; set; }
    }

    public class DataValidateCodeRequest
    {
        public SecurityValidateCodeRequest security { get; set; }
        public string securityCode { get; set; }
    }

    public class SecurityValidateCodeRequest
    {
        public string enrollmentKey { get; set; }
    }
}
