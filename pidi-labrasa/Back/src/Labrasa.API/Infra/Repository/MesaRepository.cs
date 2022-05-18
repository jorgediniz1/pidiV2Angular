using Labrasa.API.Domain.Interfaces;
using Labrasa.API.Domain.Models;
using Labrasa.API.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace Labrasa.API.Infra.Repository
{
    public class MesaRepository : IMesaRepository
    {
        private readonly LabrasaContext _context;

        public MesaRepository(LabrasaContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Mesa>> PegarTodas()
        {
            try
            {
                var mesaList = await _context.Mesas.ToListAsync();
                return mesaList;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
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
                    var mesa = await _context.Mesas.FirstOrDefaultAsync(m => m.Id == id);
                    _context.Mesas.Remove(mesa);
                    await _context.SaveChangesAsync();

                    return true;
                }
                catch(Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Mesa> Atualizar(Mesa mesa)
        {
            try
            {
                var me = await _context.Mesas.FindAsync(mesa.Id);
                _context.Entry(me).CurrentValues.SetValues(mesa);
               
                _context.Update(me);

                await _context.SaveChangesAsync();

                return mesa;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
          
                    
        }

        public async Task<Mesa> Incluir(Mesa mesa)
        {
            try
            {
                await _context.AddAsync(mesa);
                await _context.SaveChangesAsync();

                return mesa;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Mesa> PegarPeloId(int id)
        {
            try
            {
                var mesa = await _context.Mesas.FirstOrDefaultAsync(m => m.Id == id);
                return mesa;
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
                var prod = _context.Mesas.FirstOrDefault(m => m.Id == id);
                return prod != null ? true : false; 
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
       
    }
}
