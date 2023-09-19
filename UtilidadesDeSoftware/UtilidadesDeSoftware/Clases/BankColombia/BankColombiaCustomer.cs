using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesDeSoftware.Clases.BankColombia
{
    public class BankColombiaCustomer
    {
        public Data data { get; set; }
      
    }
    public class Customer
    {
        public Identification identification { get; set; }
    }

    public class Data
    {
        public Customer customer { get; set; }
    }

    public class Identification
    {
        public string type { get; set; }
        public string number { get; set; }
        public string issuedDate { get; set; }
    }

}
