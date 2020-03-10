using Microsoft.AspNetCore.Mvc;
using Senai.Senatur.WebApi.DatabaseFirst.Domains;
using Senai.Senatur.WebApi.DatabaseFirst.Interfaces;
using Senai.Senatur.WebApi.DatabaseFirst.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Senatur.WebApi.DatabaseFirst.Controllers
{
    [Produces("application/json")]

    [Route("api/[controller]")]

    [ApiController]
    public class EmpresaController : ControllerBase 
    {
        private IEmpresaRepository _empresaRepository;

        public EmpresaController()
        {
            _empresaRepository = new EmpresaRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_empresaRepository.Listar());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_empresaRepository.BuscarPorId(id));
        }

        [HttpPost]
        public IActionResult Cadastrar(Empresa novoPacote)
        {
            _empresaRepository.Cadastrar(novoPacote);

            return Ok("Novo Usuário Cadastrado com Sucesso!");
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            _empresaRepository.Deletar(id);

            return StatusCode(204);
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarPorId(int id, Empresa empresaAtualizada)
        {
            Empresa empresa = _empresaRepository.BuscarPorId(id);

            if (id == null)
            {
                try
                {
                    _empresaRepository.Atualizar(id, empresaAtualizada);
                }
                catch (Exception erro)
                {
                    return BadRequest(erro);
                }

                return NotFound("Id Especificado não encontrada, ou não existe no Banco de Dados");
            }

            return StatusCode(404);
        }
    }
}
