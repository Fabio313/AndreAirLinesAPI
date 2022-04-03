using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace APIAndreAirLines.Model
{
    public class Passageiro
    {
        [Key]
        [JsonProperty("cpf")]
        public string Cpf { get; set; }

        [JsonProperty("nome")]
        public string Nome { get; set; }

        [JsonProperty("telefone")]
        public string Telefone { get; set; }

        [JsonProperty("datanascimento")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DataNascimento { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("endereco")]
        public Endereco Endereco { get; set; }
    }
}
