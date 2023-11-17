using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesDeSoftware.Clases.BankColombia
{
    public class BankCoAccountsTransfersVoidRequestDto
    {
        public DataAccountsTransfersVoidReques data { get; set; }
    }

    public class RelationshipIdAccountsTransfersVoidReques
    {
        public string relationshipId { get; set; }
    }

    public class DestinationAccountsTransfersVoidReques
    {
        public string type { get; set; }
        public string number { get; set; }
    }

    public class TransactionAccountsTransfersVoidReques
    {
        public string originalTrackingId { get; set; }
        public string transactionDate { get; set; }
    }

    public class DataAccountsTransfersVoidReques
    {
        public string trackingId { get; set; }
        public RelationshipIdAccountsTransfersVoidReques identificationAccount { get; set; }
        public DestinationAccountsTransfersVoidReques destinationAccount { get; set; }
        public TransactionAccountsTransfersVoidReques transaction { get; set; }
    }
}
