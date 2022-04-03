using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace APIAndreAirLines.Model
{
    public class Voo
    {
        public int Id { get; set; }

        [JsonProperty("destino")]
        public Aeroporto Destino { get; set; }

        [JsonProperty("origem")]
        public Aeroporto Origem { get; set; }

        [JsonProperty("aeronave")]
        public Aeronave Aeronave { get; set; }

        [JsonProperty("horaembarque")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime HoraEmbarque { get; set; }

        [JsonProperty("horadesembarque")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime HoraDesembarque { get; set; }
    }
}
