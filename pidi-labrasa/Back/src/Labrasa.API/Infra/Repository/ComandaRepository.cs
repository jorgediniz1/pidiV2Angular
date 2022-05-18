using Labrasa.API.Domain.Interfaces;
using Labrasa.API.Domain.Models;
using Labrasa.API.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace Labrasa.API.Infra.Repository
{
    public class ComandaRepository : IComandaRepository
    {
        private readonly LabrasaContext _context;

        public ComandaRepository(LabrasaContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Comanda>> PegarTodos()
        {
            try
            {
                List<Comanda> listComanda = await _context.Comandas.ToListAsync();
                return listComanda;
            }
            catch (Exception)
            {
                throw;
            }
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
                    var com = await _context.Comandas.FirstOrDefaultAsync(c => c.Id == id);
                    _context.Comandas.Remove(com);
                    return await _context.SaveChangesAsync() > 0;
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

        public async Task<Comanda> Atualizar(Comanda comanda)
        {
            try
            {
                var com = await _context.Comandas.FindAsync(comanda.Id);
                _context.Entry(com).CurrentValues.SetValues(comanda);
                _context.Update(com);

                await _context.SaveChangesAsync();

                return comanda;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Comanda> Incluir(Comanda comanda)
        {
            try
            {
                await _context.Comandas.AddAsync(comanda);
                await _context.SaveChangesAsync();
                return comanda;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Comanda> PegarPeloId(int id)
        {
            try
            {
                var com = await _context.Comandas.FirstOrDefaultAsync(c => c.Id == id);
                return com;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }



        //Verifica se o objeto em questão existe
        private bool Exists(int id)
        {
            try
            {
                var com = _context.Comandas.FirstOrDefault(c => c.Id == id);
                return com != null ? true : false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
