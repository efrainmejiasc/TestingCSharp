using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesDeSoftware.Clases.BankColombia
{
    public class BankCoCIRetrieveTermsResponseDto
    {
        public MetaCIRetrieveTermsResponse meta { get; set; }
        public DataCIRetrieveTermsResponse data { get; set; }
    }

    public class MetaCIRetrieveTermsResponse
    {
       // public string description { get; set; }
        public string _messageId { get; set; }
        public DateTime _requestDateTime { get; set; }
        public string _applicationId { get; set; }
    }

    public class DataCIRetrieveTermsResponse
    {
        public TermsConditionCIRetrieveTermsResponse termsCondition { get; set; }

        [StringLength(200)]
        public string confirmId { get; set; }
    }

    public class TermsConditionCIRetrieveTermsResponse
    {
        public GatewayTermsCIRetrieveTermsResponse gatewayTerms { get; set; }
    }

    public class GatewayTermsCIRetrieveTermsResponse
    {
        [StringLength(700)]
        public string url { get; set; }
    }
}
