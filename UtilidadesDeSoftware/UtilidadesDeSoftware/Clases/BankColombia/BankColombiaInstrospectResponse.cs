using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesDeSoftware.Clases.BankColombia
{
    public class BankColombiaInstrospectResponse
    {
        public string Type { get; set; }
        public bool AdditionalProperties { get; set; }
        public List<string> Required { get; set; }
        public Properties_  Properties { get; set; }
    }

    public class Active
    {
        public string type { get; set; }
    }

    public class ClientId
    {
        public string type { get; set; }
    }

    public class ClientName
    {
        public string type { get; set; }
    }

    public class ConsentedOn
    {
        public string type { get; set; }
    }

    public class ConsentedOnStr
    {
        public string type { get; set; }
    }

    public class Exp
    {
        public string type { get; set; }
    }

    public class Expstr
    {
        public string type { get; set; }
    }

    public class GrantType
    {
        public string type { get; set; }
    }

    public class Iat
    {
        public string type { get; set; }
    }

    public class Miscinfo
    {
        public string type { get; set; }
    }

    public class Nbf
    {
        public string type { get; set; }
    }

    public class Nbfstr
    {
        public string type { get; set; }
    }

    public class Properties_
    {
        public Active active { get; set; }
        public ClientId client_id { get; set; }
        public ClientName client_name { get; set; }
        public Username username { get; set; }
        public Sub sub { get; set; }
        public Exp exp { get; set; }
        public Expstr expstr { get; set; }
        public Iat iat { get; set; }
        public Nbf nbf { get; set; }
        public Nbfstr nbfstr { get; set; }
        public Scope scope { get; set; }
        public Miscinfo miscinfo { get; set; }
        public ConsentedOn consented_on { get; set; }
        public ConsentedOnStr consented_on_str { get; set; }
        public GrantType grant_type { get; set; }
    }

    public class Scope
    {
        public string type { get; set; }
    }

    public class Sub
    {
        public string type { get; set; }
    }

    public class Username
    {
        public string type { get; set; }
    }

}
