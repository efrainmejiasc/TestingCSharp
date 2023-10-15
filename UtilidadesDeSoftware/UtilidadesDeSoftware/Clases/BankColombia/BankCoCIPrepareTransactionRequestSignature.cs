using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesDeSoftware.Clases.BankColombia
{
    public class BankCoCIPrepareTransactionRequestsignatureSignature
    {
        public string type { get; set; }
        public List<string> required { get; set; }
        public PropertiesCIPrepareTransactionRequestSignature properties { get; set; }
    }

    public class AcceptanceCIPrepareTransactionRequestSignature
    {
        public string type { get; set; }
        public int maxLength { get; set; }
        public string example { get; set; }
        public string description { get; set; }
        public List<bool> @enum { get; set; }
    }

    public class AmountCIPrepareTransactionRequestSignature
    {
        public string type { get; set; }
        public int minLength { get; set; }
        public int example { get; set; }
        public string description { get; set; }
    }

    public class ConfirmIdCIPrepareTransactionRequestSignature
    {
        public string type { get; set; }
        public int maxLength { get; set; }
        public string example { get; set; }
        public string description { get; set; }
    }

    public class ContactDetailCIPrepareTransactionRequestSignature
    {
        public string type { get; set; }
        public List<string> required { get; set; }
        public PropertiesCIPrepareTransactionRequestSignature properties { get; set; }
    }

    public class CustomerCIPrepareTransactionRequestSignature
    {
        public string type { get; set; }
        public List<string> required { get; set; }
        public PropertiesCIPrepareTransactionRequestSignature properties { get; set; }
    }

    public class DataCIPrepareTransactionRequestSignature
    {
        public string type { get; set; }
        public List<string> required { get; set; }
        public PropertiesCIPrepareTransactionRequestSignature properties { get; set; }
    }

    public class EmailCIPrepareTransactionRequestSignature
    {
        public string type { get; set; }
        public int minLength { get; set; }
        public int maxLength { get; set; }
        public string example { get; set; }
        public string description { get; set; }
    }

    public class FinancialInstitutionCodeCIPrepareTransactionRequestSignature
    {
        public string type { get; set; }
        public int minLength { get; set; }
        public int maxLength { get; set; }
        public string example { get; set; }
        public string description { get; set; }
    }

    public class FullNameCIPrepareTransactionRequestSignature
    {
        public string type { get; set; }
        public int minLength { get; set; }
        public int maxLength { get; set; }
        public string example { get; set; }
        public string description { get; set; }
    }

    public class GatewayTermsCIPrepareTransactionRequestSignature
    {
        public string type { get; set; }
        public List<string> required { get; set; }
        public PropertiesCIPrepareTransactionRequestSignature properties { get; set; }
    }

    public class IdentificationCIPrepareTransactionRequestSignature
    {
        public string type { get; set; }
        public List<string> required { get; set; }
        public PropertiesCIPrepareTransactionRequestSignature properties { get; set; }
    }

    public class MobilePhoneNumberCIPrepareTransactionRequestSignature
    {
        public string type { get; set; }
        public int minLength { get; set; }
        public int maxLength { get; set; }
        public string example { get; set; }
        public string description { get; set; }
    }

    public class OperationCIPrepareTransactionRequestSignature
    {
        internal RedirectUrlCIPrepareTransactionRequestSignature redirect_url;

        public string type { get; set; }
        public List<string> required { get; set; }
        public string description { get; set; }
        public PropertiesCIPrepareTransactionRequestSignature properties { get; set; }
    }

    public class PaymentDescriptionCIPrepareTransactionRequestSignature
    {
        public string type { get; set; }
        public int minLength { get; set; }
        public int maxLength { get; set; }
        public string example { get; set; }
        public string description { get; set; }
    }

    public class PaymentMethodCIPrepareTransactionRequestSignature
    {
        public string type { get; set; }
        public List<string> required { get; set; }
        public PropertiesCIPrepareTransactionRequestSignature properties { get; set; }
    }

    public class PropertiesCIPrepareTransactionRequestSignature
    {
        public DataCIPrepareTransactionRequestSignature data { get; set; }
        public OperationCIPrepareTransactionRequestSignature operation { get; set; }
        public ConfirmIdCIPrepareTransactionRequestSignature confirmId { get; set; }
        public CustomerCIPrepareTransactionRequestSignature customer { get; set; }
        public TermsConditionCIPrepareTransactionRequestSignature termsCondition { get; set; }
        public ContactDetailCIPrepareTransactionRequestSignature contactDetail { get; set; }
        public PaymentMethodCIPrepareTransactionRequestSignature payment_method { get; set; }
        public AmountCIPrepareTransactionRequestSignature amount { get; set; }
        public RedirectUrlCIPrepareTransactionRequestSignature redirect_url { get; set; }
        public IdentificationCIPrepareTransactionRequestSignature identification { get; set; }
        public RelationshipIdCIPrepareTransactionRequestSignature relationshipId { get; set; }
        public GatewayTermsCIPrepareTransactionRequestSignature gatewayTerms { get; set; }
        public AcceptanceCIPrepareTransactionRequestSignature acceptance { get; set; }
        public FullNameCIPrepareTransactionRequestSignature fullName { get; set; }
        public MobilePhoneNumberCIPrepareTransactionRequestSignature mobilePhoneNumber { get; set; }
        public EmailCIPrepareTransactionRequestSignature email { get; set; }
        public TypeCIPrepareTransactionRequestSignature type { get; set; }
        public UserTypeCIPrepareTransactionRequestSignature user_type { get; set; }
        public FinancialInstitutionCodeCIPrepareTransactionRequestSignature financial_institution_code { get; set; }
        public PaymentDescriptionCIPrepareTransactionRequestSignature payment_description { get; set; }
    }

    public class RedirectUrlCIPrepareTransactionRequestSignature
    {
        public string type { get; set; }
        public int minLength { get; set; }
        public int maxLength { get; set; }
        public string example { get; set; }
        public string description { get; set; }
    }

    public class RelationshipIdCIPrepareTransactionRequestSignature
    {
        public string type { get; set; }
        public int minLength { get; set; }
        public int maxLength { get; set; }
        public string example { get; set; }
        public string description { get; set; }
    }
    public class TermsConditionCIPrepareTransactionRequestSignature
    {
        public string type { get; set; }
        public List<string> required { get; set; }
        public PropertiesCIPrepareTransactionRequestSignature properties { get; set; }
    }

    public class TypeCIPrepareTransactionRequestSignature
    {
        public string type { get; set; }
        public int minLength { get; set; }
        public int maxLength { get; set; }
        public string example { get; set; }
        public string description { get; set; }
    }

    public class UserTypeCIPrepareTransactionRequestSignature
    {
        public string type { get; set; }
        public int minLength { get; set; }
        public int maxLength { get; set; }
        public string example { get; set; }
        public string description { get; set; }
        public List<string> @enum { get; set; }
    }

}
