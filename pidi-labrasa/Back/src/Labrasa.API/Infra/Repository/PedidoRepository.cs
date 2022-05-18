using Labrasa.API.Domain.Interfaces;
using Labrasa.API.Domain.Models;
using Labrasa.API.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace Labrasa.API.Infra.Repository
{
    public class PedidoRepository : IPedidoRepository
    {
        private readonly LabrasaContext _context;

        public PedidoRepository(LabrasaContext context)
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
                    var ped = await _context.Pedidos.FirstOrDefaultAsync(p => p.Id == id); 
                    _context.Pedidos.Remove(ped);
                    await _context.SaveChangesAsync();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Pedido> Atualizar(Pedido pedido)
        {
            try
            {
                var ped = await _context.Pedidos.FindAsync(pedido.Id);
                _context.Entry(ped).CurrentValues.SetValues(pedido);

                _context.Update(ped);

                await _context.SaveChangesAsync();

                return ped;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Pedido> Incluir(Pedido pedido)
        {
            try
            {
                await _context.AddAsync(pedido);
                await _context.SaveChangesAsync();
                return pedido;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Pedido> PegarPeloId(int id)
        {
            try
            {
               var ped = await _context.Pedidos.FirstOrDefaultAsync(p => p.Id == id);
                return ped;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<Pedido>> PegarTodos()
        {

            try
            {
                var pedidoList = await _context.Pedidos.ToListAsync();
                return pedidoList;
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
                var ped = _context.Funcionarios.FirstOrDefault(x => x.Id == id);
                return ped != null ? true : false;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
