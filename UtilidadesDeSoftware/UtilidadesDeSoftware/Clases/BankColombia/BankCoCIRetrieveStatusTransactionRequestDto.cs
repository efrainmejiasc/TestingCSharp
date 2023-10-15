using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesDeSoftware.Clases.BankColombia
{
    public class BankCoCIRetrieveStatusTransactionRequestDto
    {
        public DataCIRetrieveStatusTransactionRequest data { get; set; }
    }

    public class DataCIRetrieveStatusTransactionRequest
    {
        public OperationCIRetrieveStatusTransactionRequest operation { get; set; }
    }

    public class OperationCIRetrieveStatusTransactionRequest
    {
        public CustomerCIRetrieveStatusTransactionRequest customer { get; set; }
        public string identifierRecordPrepared { get; set; }
    }

    public class CustomerCIRetrieveStatusTransactionRequest
    {
        public IdentificationCIRetrieveStatusTransactionRequest identification { get; set; }
    }

    public class IdentificationCIRetrieveStatusTransactionRequest
    {
        [StringLength(33, MinimumLength = 1, ErrorMessage = "La longitud debe estar entre 1 y 33 caracteres.")]
        public string relationshipId { get; set; }
    }

}
