using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    public class CustomerData
    {
        public ContactDetail ContactDetail { get; set; }
        public PersonalData PersonalData { get; set; }
    }

    public class ContactDetail
    {
        public string Email { get; set; }
        public string MobilePhoneNumber { get; set; }
    }

    public class PersonalData
    {
        public string FirstName { get; set; }
        public string FirstSurname { get; set; }
        public DateTime BirthDate { get; set; }
        public bool PoliticallyExposedPerson { get; set; }
    }

    public class ProductTerms
    {
        public string Version { get; set; }
        public bool Acceptance { get; set; }
    }

    public class ClausesCustomer
    {
        public string Version { get; set; }
        public bool Acceptance { get; set; }
    }

    public class WalletTerms
    {
        public string Version { get; set; }
        public bool Acceptance { get; set; }
    }

    public class TermsCondition
    {
        public ProductTerms ProductTerms { get; set; }
        public ClausesCustomer ClausesCustomer { get; set; }
        public WalletTerms WalletTerms { get; set; }
    }

    public class Security
    {
        public string EnrollmentKey { get; set; }
    }

    public class JsonData
    {
        public string FirmwareMobil { get; set; }
        public CustomerData Data { get; set; }
        public TermsCondition TermsCondition { get; set; }
        public Security Security { get; set; }
    }
}
