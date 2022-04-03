using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace APIAndreAirLines.Model
{
    public class Aeroporto
    {
        [Key]
        [JsonProperty("sigla")]
        public string Sigla { get; set; }

        [JsonProperty("nome")]
        public string Nome { get; set; }

        [JsonProperty("endereco")]
        public Endereco Endereco { get; set; }
    }
}
