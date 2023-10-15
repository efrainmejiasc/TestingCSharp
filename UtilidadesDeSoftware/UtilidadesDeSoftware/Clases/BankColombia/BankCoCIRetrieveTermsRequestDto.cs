using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace UtilidadesDeSoftware.Clases.BankColombia
{
    public class BankCoCIRetrieveTermsRequestDto
    {
        public DataCIRetrieveTermsRequest data { get; set; }
    }

    public class DataCIRetrieveTermsRequest
    {
        public CustomerCIRetrieveTermsRequest customer { get; set; }
    }

    public class CustomerCIRetrieveTermsRequest
    {
        public IdentificationCIRetrieveTermsRequest identification { get; set; }
    }

    public class IdentificationCIRetrieveTermsRequest
    {
        [StringLength(33, MinimumLength = 1, ErrorMessage = "La longitud debe estar entre 1 y 33 caracteres.")]
        public string relationshipId { get; set; }
    }
}
