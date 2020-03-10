using Senai.Senatur.WebApi.DatabaseFirst.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Senatur.WebApi.DatabaseFirst.Interfaces
{
    interface IEmpresaRepository
    {
        List<Empresa> Listar();

        Empresa BuscarPorId(int id);

        void Deletar(int id);

        void Atualizar(int id, Empresa empresaAtualizada);

        void Cadastrar(Empresa novaEmpresa);
    }
}
