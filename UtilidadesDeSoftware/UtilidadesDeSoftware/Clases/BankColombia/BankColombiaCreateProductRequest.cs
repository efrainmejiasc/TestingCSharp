using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesDeSoftware.Clases.BankColombia
{
    public class BankColombiaCreateProductRequest
    {
        public string type { get; set; }
        public List<string> required { get; set; }
        public Properties properties { get; set; }
    }

    public class DataCreateProductRequest
    {
        public string type { get; set; }
        public List<string> required { get; set; }
        public Properties properties { get; set; }
    }

    public class EnrollmentKey
    {
        public string type { get; set; }
        public int maxLength { get; set; }
        public string example { get; set; }
        public string description { get; set; }
    }

    public class Properties
    {
        public DataCreateProductRequest data { get; set; }
        public SecurityCreateProductRequest security { get; set; }
        public SecurityCode securityCode { get; set; }
        public EnrollmentKey enrollmentKey { get; set; }
    }
    public class SecurityCreateProductRequest
    {
        public string type { get; set; }
        public List<string> required { get; set; }
        public Properties properties { get; set; }
    }

    public class SecurityCode
    {
        public string type { get; set; }
        public int maxLength { get; set; }
        public string example { get; set; }
        public string description { get; set; }
    }
}
