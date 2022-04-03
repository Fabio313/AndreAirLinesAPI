using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace APIAndreAirLines.Model
{
    public class Endereco
    {
        public int Id { get; set; }

        [JsonProperty("cep")]
        [Required]
        public string Cep { get; set; }

        [JsonProperty("localidade")]
        public string Localidade { get; set; }

        [JsonProperty("logradouro")]
        public string Logradouro { get; set; }
        
        [JsonProperty("pais")]
        public string Pais { get; set; }

        [JsonProperty("bairro")]
        public string Bairro { get; set; }

        [JsonProperty("numero")]
        public int Numero { get; set; }

        [JsonProperty("uf")]
        public string Uf { get; set; }

        [JsonProperty("complemento")]
        public string Complemento { get; set; }


        //utilizado quando encontra o cep na api dos correios assim sendo sempre no Brasil
        public Endereco(string localidade, string logradouro, string bairro, string uf, string complemento, string cep)
        {
            Cep = cep;
            Localidade = localidade;
            Logradouro = logradouro;
            Bairro = bairro;
            Uf = uf;
            Complemento = complemento;
            Pais = "Brasil";
        }
    }
}
