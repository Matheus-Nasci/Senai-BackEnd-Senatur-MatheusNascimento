using System;
using System.Collections.Generic;

namespace Senai.Senatur.WebApi.DatabaseFirst.Domains
{
    public partial class EstadoPacote
    {
        public EstadoPacote()
        {
            Pacote = new HashSet<Pacote>();
        }

        public int IdEstadoPacote { get; set; }
        public string Estado { get; set; }

        public ICollection<Pacote> Pacote { get; set; }
    }
}
