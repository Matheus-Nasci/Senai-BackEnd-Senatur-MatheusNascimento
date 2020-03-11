using Senai.Senatur.WebApi.DatabaseFirst.Domains;
using Senai.Senatur.WebApi.DatabaseFirst.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Senatur.WebApi.DatabaseFirst.Repositories
{
    public class PacoteRepository : IPacoteRepository
    {
        SenaturContext ctx = new SenaturContext();

        public void AtualizarPorId(int id, Pacote pacoteAtualizado)
        {
            Pacote pacote = ctx.Pacote.Find(id);

            pacote.NomePacote = pacoteAtualizado.NomePacote;
            pacote.Descricao = pacoteAtualizado.Descricao;
            pacote.DataIda = pacoteAtualizado.DataIda;
            pacote.DataVolta = pacoteAtualizado.DataVolta;
            pacote.Valor = pacoteAtualizado.Valor;
            pacote.Cidade = pacoteAtualizado.Cidade;
            pacote.EstadoPacote = pacoteAtualizado.EstadoPacote;
            pacote.IdEmpresaNavigation = pacoteAtualizado.IdEmpresaNavigation;

            ctx.Pacote.Update(pacoteAtualizado);

            ctx.SaveChanges();
        }

        public Pacote BuscarPorId(int id)
        {
            return ctx.Pacote.FirstOrDefault(p => p.IdPacote == id );
        }

        public void Cadastrar(Pacote novoPacote)
        {
            ctx.Pacote.Add(novoPacote);
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            Pacote pacote = ctx.Pacote.Find(id);

            ctx.Pacote.Remove(pacote);

            ctx.SaveChanges();
        }

        public List<Pacote> Listar()
        {
            return ctx.Pacote.ToList();

        }

        public List<Pacote> BuscarPacoteAtivo()
        {
            return ctx.Pacote.ToList().FindAll(p => p.EstadoPacote == true);
        }

        public List<Pacote> BuscarPacoteInvativo()
        {
            return ctx.Pacote.ToList().FindAll(p => p.EstadoPacote == false);
        }

        public List<Pacote> ListarCidade(string nomeCidade)
        {
            return ctx.Pacote.Where(p => p.Cidade.Contains(nomeCidade)).ToList();
        }
    } 
}
