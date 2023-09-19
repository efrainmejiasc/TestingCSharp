using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesDeSoftware.Clases.HTTPClass
{
    public class AuthRenaper
    {
        public int Codigo_Http { get; set; }
        public string Mensaje_Http { get; set; }
        public DataToken Data { get; set; }

        public class DataToken
        {
            public int Codigo { get; set; }
            public string Mensaje { get; set; }
            public string Token { get; set; }
        }

    }
}
