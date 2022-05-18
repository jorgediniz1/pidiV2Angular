using Labrasa.API.Domain.Interfaces;
using Labrasa.API.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Labrasa.API.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]

    public class PedidoController : Controller
    {
        private readonly IPedidoRepository _context;

        public PedidoController(IPedidoRepository context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
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

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var pedido = await _context.PegarPeloId(id);

                if(pedido == null)
                {
                    return NotFound();
                }
                return Ok(pedido);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Pedido pedido)
        {
            try
            {
                if(pedido == null)
                {
                    return BadRequest();
                }
                return Ok(await _context.Incluir(pedido));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(Pedido pedido)
        {
            try
            {
                var ped = await _context.PegarPeloId(pedido.Id);
                if(ped != null)
                {
                    await _context.Atualizar(pedido);
                    return Ok(ped);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return BadRequest();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {             
                return Ok(await _context.Apagar(id));
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
