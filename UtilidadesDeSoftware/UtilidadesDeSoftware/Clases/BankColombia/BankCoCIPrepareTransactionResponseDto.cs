using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesDeSoftware.Clases.BankColombia
{
    public class BankCoCIPrepareTransactionResponseDto
    {
        public MetaCIPrepareTransactioResponse meta { get; set; }
        public DataCIPrepareTransactioResponse  data { get; set; }
    }
    public class MetaCIPrepareTransactioResponse
    {
        public string _messageId { get; set; }
        public DateTime _requestDateTime { get; set; }
        public string _applicationId { get; set; }
    }

    public class DataCIPrepareTransactioResponse
    {
        public OperationCIPrepareTransactioResponse operation { get; set; }
    }

    public class OperationCIPrepareTransactioResponse
    {
        public string identifierRecordPrepared { get; set; }
        public string operationStatus { get; set; }  // "enum": [ "Pending", "Rejected","Approved","Declined"]
        public string detailsOperationStatus { get; set; }
        public DateTime dateTimeRecord { get; set; }
        public string payment_url { get; set; }

    }

}
