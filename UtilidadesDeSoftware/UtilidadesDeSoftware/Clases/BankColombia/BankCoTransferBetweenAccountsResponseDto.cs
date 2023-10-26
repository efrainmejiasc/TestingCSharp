using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UtilidadesDeSoftware.Clases.BankColombia.Helper;

namespace UtilidadesDeSoftware.Clases.BankColombia
{
    public  class BankCoTransferBetweenAccountsResponseDto
    {
        public MetaTransferBetweenAccountsResponse meta { get; set; }
        public DataTransferBetweenAccountsResponse data { get; set; }
    }
    public class MetaTransferBetweenAccountsResponse
    {
        public string _messageId { get; set; }
        public DateTime _requestDateTime { get; set; }
        public string _applicationId { get; set; }
    }

    public class TransactionTransferBetweenAccountsResponse
    {
        public DateTime transactionDate { get; set; }
        public long amount { get; set; }
    }

    public class ThirdpartyTransactionDetailTransferBetweenAccountsResponse
    {
        public TransactionTransferBetweenAccountsResponse transaction { get; set; }
    }

    public class DataTransferBetweenAccountsResponse
    {
        public ThirdpartyTransactionDetailTransferBetweenAccountsResponse thirdpartyTransactionDetail { get; set; }
    }

}
