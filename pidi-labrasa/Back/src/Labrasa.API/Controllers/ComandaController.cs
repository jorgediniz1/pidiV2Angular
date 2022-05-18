using Labrasa.API.Domain.Interfaces;
using Labrasa.API.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Labrasa.API.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class ComandaController : Controller
    {
        private readonly IComandaRepository _context;

        public ComandaController(IComandaRepository context)
        {
            _context = context;
        }

        [HttpGet]
        //[Authorize]
        public async Task <IActionResult> GetAll()
        {
            try
            {
                return Ok(await _context.PegarTodos());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPost]
        public async Task <IActionResult> Post(Comanda comanda)
        {
            try
            {
                if(comanda == null)
                {
                    return BadRequest();
                }
                return Ok(await _context.Incluir(comanda));               
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var com = await _context.PegarPeloId(id);
               
                if(com == null)
                {
                    return NotFound();
                }
                return Ok(com);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(Comanda comanda)
        {
            try
            {
                var com = await _context.PegarPeloId(comanda.Id);
                
                if(com != null)
                {
                    await _context.Atualizar(comanda);
                    return Ok(com);
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return BadRequest();
        }

        [HttpDelete]
        public async Task<bool> Delete(int id)
        {
            try
            {
                await _context.Apagar(id);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
