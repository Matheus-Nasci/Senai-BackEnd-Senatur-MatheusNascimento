using Senai.Senatur.WebApi.DatabaseFirst.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Senatur.WebApi.DatabaseFirst.Interfaces
{
    interface ITipoUsuarioRepository
    {
        List<TipoUsuario> Listar();

        TipoUsuario BuscarPorId(int id);

        void Deletar(int id);

        void Atualizar(int id, TipoUsuario tipoUsuarioAtualizado);

        void Cadastrar(TipoUsuario novoTipoUsuario);
    }
}
