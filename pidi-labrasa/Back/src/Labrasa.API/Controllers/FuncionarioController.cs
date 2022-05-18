using Labrasa.API.Domain.Interfaces;
using Labrasa.API.Domain.Models;
using Labrasa.API.Infra.Context;
using Labrasa.API.Infra.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Collections;

namespace Labrasa.API.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]

    public class FuncionarioController : Controller
    {
        private readonly IFuncionarioRepository _context;
        public FuncionarioController(IFuncionarioRepository context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _context.PegarTodos());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var funcionario = await _context.PegarPeloId(id);
            
            if (funcionario == null)
            {
                return NotFound();           
            }

            return Ok(funcionario);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Funcionario funcionario)
        {
            if(funcionario == null)
            {
                return BadRequest();
            }
            return Ok(await _context.Incluir(funcionario));
        }

        [HttpPut]
        public async Task<IActionResult> Update(Funcionario funcionario)
        {
            try
            {
                var func = await _context.PegarPeloId(funcionario.Id);
                
                if(func != null)
                {
                    await _context.Atualizar(funcionario);

                    return Ok();
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
           return BadRequest();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _context.Apagar(id));
        }

    }
}
