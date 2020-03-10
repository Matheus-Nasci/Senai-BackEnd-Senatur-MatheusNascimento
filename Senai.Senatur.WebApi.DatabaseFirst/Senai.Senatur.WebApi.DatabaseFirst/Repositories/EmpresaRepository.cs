using Senai.Senatur.WebApi.DatabaseFirst.Domains;
using Senai.Senatur.WebApi.DatabaseFirst.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Senatur.WebApi.DatabaseFirst.Repositories
{
    public class EmpresaRepository : IEmpresaRepository
    {
        SenaturContext ctx = new SenaturContext();

        public void Atualizar(int id, Empresa empresaAtualizada)
        {
            Empresa empresa = ctx.Empresa.Find(id);

            empresa = BuscarPorId(empresa.IdEmpresa);

            empresa.NomeEmpresa = empresaAtualizada.NomeEmpresa;

            ctx.Empresa.Update(empresaAtualizada);

            ctx.SaveChanges();
        }

        public Empresa BuscarPorId(int id)
        {
            return ctx.Empresa.FirstOrDefault(e => e.IdEmpresa == id);
        }

        public void Cadastrar(Empresa novaEmpresa)
        {
            ctx.Empresa.Add(novaEmpresa);

            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            Empresa empresa = ctx.Empresa.Find(id);

            ctx.Empresa.Remove(empresa);

            ctx.SaveChanges();
        }

        public List<Empresa> Listar()
        {
            return ctx.Empresa.ToList();
        }
    }
}
