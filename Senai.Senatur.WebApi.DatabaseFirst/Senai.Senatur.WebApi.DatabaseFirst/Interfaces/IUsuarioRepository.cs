using Senai.Senatur.WebApi.DatabaseFirst.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Senatur.WebApi.DatabaseFirst.Interfaces
{
    interface IUsuarioRepository
    {
        List<Usuario> Listar();

        Usuario BuscarPorId(int id);

        void Deletar(int id);

        void Atualizar(int id, Usuario usuarioAtualizado);

        void Cadastrar(Usuario novoUsuario);

        Usuario BuscarPorEmailSenha(string email, string senha);
    }
}
