using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio09.Domain.Entities
{
    public class ApiCep
    {
        [JsonProperty("street")]
        public string Street { get; set; }
        [JsonProperty("city")]
        public string City { get; set; }
        [JsonProperty("state")]
        public string State { get; set; }
        [JsonProperty("neighborhood")]
        public string Neighborhood { get; set; }
        [JsonProperty("cep")]
        public string Cep { get; set; }


    }
}
