using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesDeSoftware.Clases.BankColombia
{
    public class BankCoCIRetrieveStatusTransactionResponseDto
    {
        public MetaCIRetrieveStatusTransactionResponse meta { get; set; }
        public DataCIRetrieveStatusTransactionResponse data { get; set; }
    }

    public class MetaCIRetrieveStatusTransactionResponse
    {
       // public string description { get; set; }
        public string _messageId { get; set; }
        public DateTime _requestDateTime { get; set; }
        public string _applicationId { get; set; }
    }

    public class DataCIRetrieveStatusTransactionResponse
    {
        public TransactionCIRetrieveStatusTransactionResponse Transaction { get; set; }
    }

    public class TransactionCIRetrieveStatusTransactionResponse
    {
        [StringLength(20, MinimumLength = 1, ErrorMessage = "La longitud debe estar entre 1 y 20 caracteres.")]
        public string operationStatus { get; set; }

        [StringLength(255, MinimumLength = 1, ErrorMessage = "La longitud debe estar entre 1 y 255 caracteres.")]
        public string detailsOperationStatus { get; set; }
        public DateTime dateTimeRecord { get; set; }
        public DateTime dateTimeUpdate { get; set; }
    }
}
