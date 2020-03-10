using System;
using System.Collections.Generic;

namespace Senai.Senatur.WebApi.DatabaseFirst.Domains
{
    public partial class Pacote
    {
        public int IdPacote { get; set; }
        public string NomePacote { get; set; }
        public string Descricao { get; set; }
        public DateTime DataIda { get; set; }
        public DateTime DataVolta { get; set; }
        public decimal? Valor { get; set; }
        public string Cidade { get; set; }
        public int? IdEmpresa { get; set; }
        public int? IdEstadoPacote { get; set; }

        public Empresa IdEmpresaNavigation { get; set; }
        public EstadoPacote IdEstadoPacoteNavigation { get; set; }
    }
}
