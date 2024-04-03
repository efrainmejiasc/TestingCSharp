using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Vettica.Maas.App.Dtos.BankCo.Request;

namespace Vettica.Maas.App.Dtos.BankCo.Response
{
    public class BankCoGetInformationRequestDto: CommonPropertyCryptographicRequestDto
    {
        [JsonIgnore]
        public string Email {  get; set; }  
    }
}
