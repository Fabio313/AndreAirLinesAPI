using System;
using Newtonsoft.Json;

namespace APIAndreAirLines.Model
{
    public class Passagem
    {
        public int Id { get; set; }

        [JsonProperty("voo")]
        public Voo Voo { get; set; }

        [JsonProperty("passageiro")]
        public Passageiro Passageiro { get; set; }

        [JsonProperty("valor")]
        public double Valor { get; set; }

        [JsonProperty("precobase")]
        public PrecoBase PrecoBase { get; set; }

        [JsonProperty("classe")]
        public Classe Classe { get; set; }

        [JsonProperty("datacadastro")]
        public DateTime DataCadastro { get; set; }
    }

}
