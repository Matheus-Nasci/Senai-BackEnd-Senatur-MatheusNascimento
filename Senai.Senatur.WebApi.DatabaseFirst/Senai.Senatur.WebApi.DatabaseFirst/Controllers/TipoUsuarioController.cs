﻿using Microsoft.AspNetCore.Mvc;
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
    public class TipoUsuarioController : ControllerBase
    {
        [Produces("application/json")]

        [Route("api/[controller]")]

        [ApiController]
        public class UsuarioController : ControllerBase
        {
            private ITipoUsuarioRepository _tipoUsuarioRepository;

            public UsuarioController()
            {
                _tipoUsuarioRepository = new TipoUsuarioRepository();
            }

            [HttpGet]
            public IActionResult Get()
            {
                return Ok(_tipoUsuarioRepository.Listar());
            }

            [HttpGet("{id}")]
            public IActionResult GetById(int id)
            {
                return Ok(_tipoUsuarioRepository.BuscarPorId(id));
            }

            [HttpPost]
            public IActionResult Cadastrar(TipoUsuario novoUsuario)
            {
                _tipoUsuarioRepository.Cadastrar(novoUsuario);

                return Ok("Novo Usuário Cadastrado com Sucesso!");
            }

            [HttpDelete("{id}")]
            public IActionResult Deletar(int id)
            {
                _tipoUsuarioRepository.Deletar(id);

                return StatusCode(204);
            }

            [HttpPut("{id}")]
            public IActionResult AtualizarPorId(int id, TipoUsuario TipousuarioAtualizado)
            {
                TipoUsuario tipousuario = _tipoUsuarioRepository.BuscarPorId(id);

                if (id == null)
                {
                    try
                    {
                        _tipoUsuarioRepository.Atualizar(id, TipousuarioAtualizado);
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
}
