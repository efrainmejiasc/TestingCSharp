using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesDeSoftware.Clases.BankColombia
{
    public class AcceptTermsAndConditionsResponse
    {
        public DataAcceptTermsResponse  data { get; set; }
    }

    public class DataAcceptTermsResponse
    {
        public SecurityAcceptTermsResponse security { get; set; }
        public string profileCustomer { get; set; }
        public SecurityCodeInformation securityCodeInformation { get; set; }
        public DateTime acceptedDate { get; set; }
        public string startAcquisition { get; set; }
    }


    public class SecurityAcceptTermsResponse
    {
        public string enrollmentKey { get; set; }
    }

    public class SecurityCodeInformation
    {
        public int numberTries { get; set; }
        public DateTime expirationDate { get; set; }
    }
}
