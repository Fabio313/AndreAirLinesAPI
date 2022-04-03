using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using APIAndreAirLines.Model;

namespace APIAndreAirLines.Data
{
    public class APIAndreAirLinesContext : DbContext
    {
        public APIAndreAirLinesContext(DbContextOptions<APIAndreAirLinesContext> options)
            : base(options)
        {
        }

        public DbSet<APIAndreAirLines.Model.Endereco> Endereco { get; set; }

        public DbSet<APIAndreAirLines.Model.Aeronave> Aeronave { get; set; }

        public DbSet<APIAndreAirLines.Model.Aeroporto> Aeroporto { get; set; }

        public DbSet<APIAndreAirLines.Model.Passageiro> Passageiro { get; set; }

        public DbSet<APIAndreAirLines.Model.Voo> Voo { get; set; }

        public DbSet<APIAndreAirLines.Model.Classe> Classe { get; set; }

        public DbSet<APIAndreAirLines.Model.PrecoBase> PrecoBase { get; set; }

        public DbSet<APIAndreAirLines.Model.Passagem> Passagem { get; set; }
    }
}
