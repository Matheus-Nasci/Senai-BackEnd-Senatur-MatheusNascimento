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
    public class PacoteController  : ControllerBase
    {
        private IPacoteRepository _pacoteRepository;

        public PacoteController()
        {
            _pacoteRepository = new PacoteRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_pacoteRepository.Listar());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_pacoteRepository.BuscarPorId(id));
        }

        [HttpPost]
        public IActionResult Cadastrar(Pacote novoPacote)
        {
            _pacoteRepository.Cadastrar(novoPacote);

            return Ok("Novo Usuário Cadastrado com Sucesso!");
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            _pacoteRepository.Deletar(id);

            return StatusCode(204);
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarPorId(int id, Pacote pacoteAtualizado)
        {
            Pacote pacote = _pacoteRepository.BuscarPorId(id);

            if (id == null)
            {
                try
                {
                    _pacoteRepository.Atualizar(id, pacoteAtualizado);
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
