using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilidadesDeSoftware.Clases.BankColombia
{
    public class ScopeCashIn
    {
        public static string ScopePrepareTransaction = "TermsConditions:read:user Payment:write:user Product-balance:read:user"; // cashIn

        public static string ScopeFinancialInstitute = "Customer-viability:read:app"; 

        public static string TrasferBetweenAccounts = "Payment:write:user VoidTransfer-payment:write:user";
    }
}
