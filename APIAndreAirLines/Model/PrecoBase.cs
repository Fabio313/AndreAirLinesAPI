using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace APIAndreAirLines.Model
{
    public class PrecoBase
    {

        public int Id { get; set; }

        [JsonProperty("origem")]
        public Aeroporto Origem { get; set; }

        [JsonProperty("destino")]
        public Aeroporto Destino { get; set; }

        [JsonProperty("valor")]
        public double Valor { get; set; }

        [JsonProperty("datainclusao")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DataInclusao { get; set; }
    }
}
