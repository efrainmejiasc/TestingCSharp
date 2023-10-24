using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesDeSoftware.Clases.BankColombia.Helper
{
    public class BankCoTransferBetweenAccountsResponseDto
    {
        public DataTransferBetweenAccountsResponse data { get; set; }
    }

    public class DataTransferBetweenAccountsResponse
    {
        public CustomerTransferBetweenAccountsResponse customer { get; set; }
        public TransactionTransferBetweenAccountsResponse transaction { get; set; }
        public ThirdpartyDestinationAccountTransferBetweenAccountsResponse thirdpartyDestinationAccount { get; set; }
    }

    public class CustomerTransferBetweenAccountsResponse
    {
        public IdentificationTransferBetweenAccountsResponse identification { get; set; }
    }

    public class IdentificationTransferBetweenAccountsResponse
    {
        public string relationshipId { get; set; }
    }

    public class TransactionTransferBetweenAccountsResponse
    {
        public string user { get; set; }
        public string trackingId { get; set; }
        public string key { get; set; }
        public string amount { get; set; }
        public string reference1 { get; set; }
        public string transactionDate { get; set; }
    }

    public class ThirdpartyDestinationAccountTransferBetweenAccountsResponse
    {
        public AccountTransferBetweenAccountsResponse account { get; set; }
        public IdentificationAccountTransferBetweenAccountsResponse identification { get; set; }
    }

    public class AccountTransferBetweenAccountsResponse
    {
        public string type { get; set; }
        public string number { get; set; }
    }

    public class IdentificationAccountTransferBetweenAccountsResponse
    {
        public string type { get; set; }
        public string number { get; set; }
    }

}
