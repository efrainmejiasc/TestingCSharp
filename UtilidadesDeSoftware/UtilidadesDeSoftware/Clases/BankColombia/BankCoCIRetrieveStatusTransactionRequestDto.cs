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
        public DataCIRetrieveStatusTransactionRequest Data { get; set; }
    }

    public class DataCIRetrieveStatusTransactionRequest
    {
        public OperationCIRetrieveStatusTransactionRequest Operation { get; set; }
    }

    public class OperationCIRetrieveStatusTransactionRequest
    {
        public CustomerCIRetrieveStatusTransactionRequest Customer { get; set; }
        public string IdentifierRecordPrepared { get; set; }
    }

    public class CustomerCIRetrieveStatusTransactionRequest
    {
        public IdentificationCIRetrieveStatusTransactionRequest Identification { get; set; }
    }

    public class IdentificationCIRetrieveStatusTransactionRequest
    {
        [StringLength(33, MinimumLength = 1, ErrorMessage = "La longitud debe estar entre 1 y 33 caracteres.")]
        public string RelationshipId { get; set; }
    }

}
