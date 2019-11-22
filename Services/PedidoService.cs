using LanchoneteCore.Models;
using LanchoneteCore.Services.Exceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LanchoneteCore.Services
{
    public class PedidoService
    {
        private readonly LanchoneteCoreContext _context;

        public PedidoService(LanchoneteCoreContext context)
        {
            _context = context;
        }

        public async Task<Pedido> FindByIdAsync(int id)
        {
            return await _context.Pedido.Include(obj => obj.Produto).Include(obj2 => obj2.Atendente).FirstOrDefaultAsync(obj => obj.PedidoID == id);
        }
        public Pedido FindById(int id)
        {
            return _context.Pedido.Include(obj => obj.Produto).FirstOrDefault(obj => obj.PedidoID == id);
        }
        public void Update(Pedido obj)
        {
            if (!_context.Pedido.Any(x => x.PedidoID == obj.PedidoID))
            {
                throw new NotFoundException("Pedido não encontrado");
            }
            try
            {
                _context.Update(obj);
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        }

        public async Task<List<Pedido>> FindAllAsync()
        {
            return await _context.Pedido.Include(obj => obj.Produto).Include(obj2 => obj2.Atendente).Include(obj3 => obj3.Cliente).ToListAsync();
        }
    }
}
