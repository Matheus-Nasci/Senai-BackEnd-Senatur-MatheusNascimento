using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Senai.Senatur.WebApi.DatabaseFirst.Domains
{
    public partial class Empresa
    {
        public Empresa()
        {
            Pacote = new HashSet<Pacote>();
        }

        public int IdEmpresa { get; set; }

        [Required(ErrorMessage = "É Preciso o nome da Empresa")]
        public string NomeEmpresa { get; set; }

        public ICollection<Pacote> Pacote { get; set; }
    }
}
