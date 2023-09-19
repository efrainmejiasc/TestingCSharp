using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesDeSoftware.Clases
{
    public class AcceptaceTerms
    {
        public Data_AcceptaceTerms data { get; set; }
    }
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class ClausesCustomer
    {
        public string version { get; set; }
        public bool acceptance { get; set; }
    }

    public class ContactDetail
    {
        public string email { get; set; }
        public string mobilePhoneNumber { get; set; }
    }

    public class Data_AcceptaceTerms
    {
        public ContactDetail contactDetail { get; set; }
        public PersonalData personalData { get; set; }
        public TermsCondition termsCondition { get; set; }
        public Security security { get; set; }
        public int identification { get; set; }
    }

    public class PersonalData
    {
        public string firstName { get; set; }
        public string firstSurname { get; set; }
        public string birthDate { get; set; }
        public bool politicallyExposedPerson { get; set; }
        public string secondName { get; set; }
        public string secondSurname { get; set; }
    }

    public class ProductTerms
    {
        public string version { get; set; }
        public bool  acceptance { get; set; }
    }

    public class Security
    {
        public string enrollmentKey { get; set; }
    }

    public class TermsCondition
    {
        public ProductTerms productTerms { get; set; }
        public ClausesCustomer clausesCustomer { get; set; }
        public WalletTerms walletTerms { get; set; }
    }

    public class WalletTerms
    {
        public string version { get; set; }
        public bool  acceptance { get; set; }
    }


}
