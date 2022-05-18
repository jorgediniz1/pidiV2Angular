using Labrasa.API.Domain.Interfaces;
using Labrasa.API.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Labrasa.API.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class ProdutoController : Controller
    {
        private readonly IProdutoRepository _context;

        public ProdutoController(IProdutoRepository context)
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
            try
            {
                var prod = await _context.PegarPeloId(id);

                if(prod == null)
                {
                    return NotFound();
                }

                return Ok(prod);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Produto produto)
        {
            if (produto == null)
            {
                return BadRequest();
            }
            return Ok( await _context.Incluir(produto));
        }

        [HttpPut]
        public async Task<IActionResult> Update(Produto produto)
        {
            try
            {
                var prod = await _context.PegarPeloId(produto.Id);
                if (prod != null)
                {
                    await _context.Atualizar(produto);
                    return Ok(prod);
                }
            }
            catch (Exception ex)
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
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
           
        }
    }
}
