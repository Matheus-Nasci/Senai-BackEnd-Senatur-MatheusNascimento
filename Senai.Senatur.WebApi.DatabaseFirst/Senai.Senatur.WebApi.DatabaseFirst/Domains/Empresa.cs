using System;
using System.Collections.Generic;

namespace Senai.Senatur.WebApi.DatabaseFirst.Domains
{
    public partial class Empresa
    {
        public Empresa()
        {
            Pacote = new HashSet<Pacote>();
        }

        public int IdEmpresa { get; set; }
        public string NomeEmpresa { get; set; }

        public ICollection<Pacote> Pacote { get; set; }
    }
}
