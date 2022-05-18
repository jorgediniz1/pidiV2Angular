using Labrasa.API.Domain.Interfaces;
using Labrasa.API.Domain.Models;
using Labrasa.API.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace Labrasa.API.Infra.Repository
{
    public class FuncionarioRepository : IFuncionarioRepository
    {
        private readonly LabrasaContext _context;

        public FuncionarioRepository(LabrasaContext context)
        {
            _context = context;
        }


        public async Task<Funcionario> Incluir(Funcionario funcionario)
        {
            try
            {              
                await _context.AddAsync(funcionario);
                await _context.SaveChangesAsync();

                return funcionario;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public async Task<Funcionario> Atualizar(Funcionario funcionario)
        {
            try
            {
                var func = await _context.Funcionarios.FindAsync(funcionario.Id);
                _context.Entry(func).CurrentValues.SetValues(funcionario);

                _context.Update(func);
  
                await _context.SaveChangesAsync();

                return func;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message); 
            }
        }

        public async Task<Funcionario> PegarPeloId(int id)
        {
            try
            {
                var func = await _context.Funcionarios.FirstOrDefaultAsync(x => x.Id == id);
               
                return func;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<Funcionario>> PegarTodos()
        {
            try
            {
                var funcList = await _context.Funcionarios.ToListAsync();
              
                return funcList;
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
                    var func = await _context.Funcionarios.FirstOrDefaultAsync(x => x.Id == id);
                    _context.Funcionarios.Remove(func);
                    await _context.SaveChangesAsync();

                    return true; 
                }
                catch(Exception)
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private bool Exists(int id)
        {
            try
            {
                var func = _context.Funcionarios.FirstOrDefault(x => x.Id == id);
                return func != null ? true : false;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        
    }
}
