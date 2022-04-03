using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace APIAndreAirLines.Model
{
    public class Aeronave
    {
        [Key]
        [JsonProperty("codigo")]
        public string Codigo { get; set; }

        [JsonProperty("nome")]
        public string Nome { get; set; }

        [JsonProperty("capacidade")]
        public int Capacidade { get; set; }
    }
}
