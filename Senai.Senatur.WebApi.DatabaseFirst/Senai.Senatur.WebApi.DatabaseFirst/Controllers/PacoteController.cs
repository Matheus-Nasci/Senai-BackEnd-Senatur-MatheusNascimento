using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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
    [Authorize]
    public class PacoteController : ControllerBase
    {
        private IPacoteRepository _pacoteRepository;

        public PacoteController()
        {
            _pacoteRepository = new PacoteRepository();
        }

        /// <summary>
        /// Metodo Listar Pacotes de Viagem 
        /// </summary>
        /// <returns>Lista de Pacotes</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Get()
        {
            return Ok(_pacoteRepository.Listar());
        }

        /// <summary>
        /// Buscar o Pacote por ID na URL 
        /// </summary>
        /// <param name="id">BuscarPorId</param>
        /// <returns>_pacoteRepository</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetById(int id)
        {
            return Ok(_pacoteRepository.BuscarPorId(id));
        }

        /// <summary>
        /// Cadastrar Pacotes
        /// </summary>
        /// <param name="novoPacote"></param>
        /// <returns>Novo Pacote Cadastrado</returns>
        /// 
        [Authorize(Roles = "1")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult Cadastrar(Pacote novoPacote)
        {
            _pacoteRepository.Cadastrar(novoPacote);

            return Ok("Novo Pacote Cadastrado com Sucesso!");
        }

        /// <summary>
        /// Deleta um Pacote por ID
        /// </summary>
        /// <param name="id">IdPacote</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Deletar(int id)
        {
            _pacoteRepository.Deletar(id);

            return StatusCode(202);
        }

        /// <summary>
        /// Atualiza um Pacote pela URL usando ID
        /// </summary>
        /// <param name="id">IdPacote</param>
        /// <param name="pacoteAtualizado"></param>
        /// <returns>Um Pacote com Informações Atualizadas</returns>
        [Authorize(Roles = "1")]
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult AtualizarPorId(int id, Pacote pacoteAtualizado)
        {
            Pacote pacote = _pacoteRepository.BuscarPorId(id);

            if (pacote != null)
            {
                try
                {
                    _pacoteRepository.AtualizarPorId(id, pacoteAtualizado);

                    return StatusCode(200);
                }
                catch (Exception erro)
                {
                    return BadRequest(erro);
                }
            }
            else
            {
                return NotFound("Id Especificado não encontrada, ou não existe no Banco de Dados");
            }

        }

        [HttpGet("Ativo")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult BuscarPacoteAtivo()
        {
            _pacoteRepository.BuscarPacoteAtivo();

            return Ok(_pacoteRepository.BuscarPacoteAtivo());
        }

        [HttpGet("Inativo")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult BuscarPacoteInativo()
        {
            _pacoteRepository.BuscarPacoteInvativo();

            return Ok(_pacoteRepository.BuscarPacoteInvativo());

        }

        [HttpGet("cidade/{nomeCidade}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult ListarCidade(string nomeCidade)
        {
            _pacoteRepository.ListarCidade(nomeCidade);

            return Ok(_pacoteRepository.ListarCidade(nomeCidade));

        }
    }
}
