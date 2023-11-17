using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UtilidadesDeSoftware.Clases.BankColombia.Helper;

namespace UtilidadesDeSoftware.Clases.BankColombia
{
    public  class BankCoTransfersBetweenAccountsResponseDto
    {
        public MetaTransfersBetweenAccountsResponse meta { get; set; }
        public DataTransfersBetweenAccountsResponse data { get; set; }
    }
    public class MetaTransfersBetweenAccountsResponse
    {
        public string _messageId { get; set; }
        public DateTime _requestDateTime { get; set; }
        public string _applicationId { get; set; }
    }

    public class TransactionTransfersBetweenAccountsResponse
    {
        public DateTime transactionDate { get; set; }
        public long amount { get; set; }
    }

    public class ThirdpartyTransactionDetailTransfersBetweenAccountsResponse
    {
        public TransactionTransfersBetweenAccountsResponse transaction { get; set; }
    }

    public class DataTransfersBetweenAccountsResponse
    {
        public ThirdpartyTransactionDetailTransfersBetweenAccountsResponse thirdpartyTransactionDetail { get; set; }
    }

}
