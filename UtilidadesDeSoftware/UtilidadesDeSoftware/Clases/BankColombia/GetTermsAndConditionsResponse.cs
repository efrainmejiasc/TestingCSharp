using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesDeSoftware.Clases.BankColombia
{
    public class GetTermsAndConditionsResponse
    {
        public DataTermsConditionResponse data { get; set; }
        public Meta meta { get; set; }
    }

    public class ClausesCustomerBankCoresponse
    {
        public string version { get; set; }
        public string url { get; set; }
    }

    public class DataTermsConditionResponse
    {
        public TermsConditionBankCoResponse termsCondition { get; set; }
    }

    public class Meta
    {
        public DateTime _requestDateTime { get; set; }
        public string _applicationId { get; set; }
        public string _messageId { get; set; }
    }

    public class ProductTermsBankCoResponse
    {
        public string version { get; set; }
        public string url { get; set; }
    }

    public class TermsConditionBankCoResponse
    {
        public ClausesCustomerBankCoresponse clausesCustomer { get; set; }
        public WalletTerms walletTerms { get; set; }
        public ProductTermsBankCoResponse productTerms { get; set; }
    }

    public class WalletTermsBankCoresponse
    {
        public string version { get; set; }
        public string url { get; set; }
    }
}
