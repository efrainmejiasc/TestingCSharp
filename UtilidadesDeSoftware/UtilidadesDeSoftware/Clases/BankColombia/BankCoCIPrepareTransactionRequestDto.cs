using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesDeSoftware.Clases.BankColombia
{
    public class BankCoCIPrepareTransactionRequestDto
    {
        public DataCIPrepareTransactionRequest data { get; set; }
    }

    public class CustomerCIPrepareTransactionRequest
    {
        public IdentificationCIPrepareTransactionRequest identification { get; set; }
    }

    public class IdentificationCIPrepareTransactionRequest
    {
        [StringLength(33, MinimumLength = 1, ErrorMessage = "La longitud debe estar entre 1 y 33 caracteres.")]
        public string relationshipId { get; set; }
    }

    public class GatewayTermsCIPrepareTransactionRequest
    {
        public bool acceptance { get; set; }
    }

    public class TermsConditionCIPrepareTransactionRequest
    {
        public GatewayTermsCIPrepareTransactionRequest gatewayTerms { get; set; }
    }

    public class ContactDetailCIPrepareTransactionRequest
    {
        [StringLength(50, MinimumLength = 1, ErrorMessage = "La longitud debe estar entre 1 y 50 caracteres.")]
        public string fullName { get; set; }

        [StringLength(20, MinimumLength = 1, ErrorMessage = "La longitud debe estar entre 1 y 20 caracteres.")]
        public string mobilePhoneNumber { get; set; }

        [StringLength(250, MinimumLength = 1, ErrorMessage = "La longitud debe estar entre 1 y 250 caracteres.")]
        public string email { get; set; }
    }

    public class PaymentMethodCIPrepareTransactionRequest
    {
        public string type { get; set; }
        public string user_type { get; set; }    // Enum = 0 o 1

        [StringLength(4, MinimumLength = 1, ErrorMessage = "La longitud debe estar entre 1 y 4 caracteres.")]
        public string financial_institution_code { get; set; }

        [StringLength(64, MinimumLength = 1, ErrorMessage = "La longitud debe estar entre 1 y 64 caracteres.")]
        public string payment_description { get; set; }
    }

    public class OperationCIPrepareTransactionRequest
    {
        public CustomerCIPrepareTransactionRequest customer { get; set; }
        public TermsConditionCIPrepareTransactionRequest termsCondition { get; set; }
        public ContactDetailCIPrepareTransactionRequest contactDetail { get; set; }
        public PaymentMethodCIPrepareTransactionRequest payment_method { get; set; }

        [Range(1, 15000, ErrorMessage = "El valor debe estar entre 1 y 15000.")]
        public decimal amount { get; set; }


        [StringLength(250, MinimumLength = 1, ErrorMessage = "La longitud debe estar entre 1 y 250 caracteres.")]
        public string redirect_url { get; set; }
    }

    public class DataCIPrepareTransactionRequest
    {
        public OperationCIPrepareTransactionRequest operation { get; set; }

        [StringLength(700, MinimumLength = 1, ErrorMessage = "La longitud debe estar entre 1 y 700 caracteres.")]
        public string confirmId { get; set; }
    }

}
