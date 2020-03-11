using Senai.Senatur.WebApi.DatabaseFirst.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Senatur.WebApi.DatabaseFirst.Interfaces
{
    interface IPacoteRepository
    {
        List<Pacote> Listar();

        Pacote BuscarPorId(int id);

        void Deletar(int id);

        void AtualizarPorId(int id, Pacote pacoteAtualizado);

        void Cadastrar(Pacote novoPacote);

    }
}
