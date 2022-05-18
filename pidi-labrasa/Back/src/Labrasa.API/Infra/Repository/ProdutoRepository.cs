using Labrasa.API.Domain.Interfaces;
using Labrasa.API.Domain.Models;
using Labrasa.API.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace Labrasa.API.Infra.Repository
{
    public class ProdutoRepository : IProdutoRepository
    {

        private readonly LabrasaContext _context;

        public ProdutoRepository(LabrasaContext context)
        {
            _context = context;
        }

        public async Task<bool> Apagar(int id)
        {
            try
            {
                if (!Exists(id))
                {
                    return false;
                }
                try
                {
                    var prod = await _context.Produtos.FirstOrDefaultAsync(x => x.Id == id);
                    _context.Produtos.Remove(prod);
                    await _context.SaveChangesAsync();

                    return true;

                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Produto> Atualizar(Produto produto)
        {
            try
            {
                var prod = await _context.Produtos.FindAsync(produto.Id);
                _context.Entry(prod).CurrentValues.SetValues(produto);

                _context.Update(prod);

                await _context.SaveChangesAsync();

                return prod;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Produto> Incluir(Produto produto)
        {
            try
            {
                await _context.AddAsync(produto);
                await _context.SaveChangesAsync();

                return produto;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Produto> PegarPeloId(int id)
        {
            try
            {
                var prod = await _context.Produtos.FirstOrDefaultAsync(x => x.Id == id);
                return prod;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<Produto>> PegarTodos()
        {
            try
            {
                var prodList = await _context.Produtos.ToListAsync();

                return prodList;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private bool Exists(int id)
        {
            try
            {
                var prod =  _context.Produtos.FirstOrDefaultAsync(x => x.Id == id);
                return prod != null ? true : false;
                    
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
