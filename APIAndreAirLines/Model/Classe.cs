using Newtonsoft.Json;

namespace APIAndreAirLines.Model
{
    public class Classe
    {
        public int Id { get; set; }

        [JsonProperty("descricao")]
        public string Descricao { get; set; }

        [JsonProperty("valor")]
        public double Valor  { get; set; }
    }
}
