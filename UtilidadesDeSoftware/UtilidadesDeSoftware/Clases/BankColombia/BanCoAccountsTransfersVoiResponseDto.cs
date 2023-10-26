using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesDeSoftware.Clases.BankColombia
{
    public class BanCoAccountsTransfersVoiResponseDto
    {
        public MetaAccountsTransfersVoiResponse meta { get; set; }
        public DataAccountsTransfersVoiResponse data { get; set; }
    }

    public class MetaAccountsTransfersVoiResponse
    {
        public string _messageId { get; set; }
        public DateTime _requestDateTime { get; set; }
        public string _applicationId { get; set; }
    }

    public class DataAccountsTransfersVoiResponse
    {
        public bool voidedTransaction { get; set; }
    }
}
