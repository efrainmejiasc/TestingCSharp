using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace WinFormsApp1.Kigo
{
    public class KGRetrieveUserResponseDto
    {
        public string id { get; set; }
        public int balance { get; set; }
        public DateTime created { get; set; }
        public string email { get; set; }
        public string mobile_phone { get; set; }
        public List<TransactionResponse> transactions { get; set; }
    }

    public class ParkingLotResponse
    {
        public int parking_lotId { get; set; }
        public string parking_lot_name { get; set; }
    }

    public class TransactionResponse
    {
        public string ticket_id { get; set; }
        public DateTime check_in_date { get; set; }
        public DateTime check_out_date { get; set; }
        public int check_in_gate_id { get; set; }
        public int total_time { get; set; }
        public string status { get; set; }
        public string payment_reference { get; set; }
        public DateTime payment_date { get; set; }
        public int total_amount { get; set; }
        public ParkingLotResponse parking_lot { get; set; }
    }
}
