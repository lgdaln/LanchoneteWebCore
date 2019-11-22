using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LanchoneteCore.Models;
using LanchoneteCore.Models.ViewModels;
using LanchoneteCore.Services;
using LanchoneteCore.Services.Exceptions;

namespace LanchoneteCore.Controllers
{
    public class PedidoesController : Controller
    {
        private readonly LanchoneteCoreContext _context;
        private readonly ProdutoService _produtoService;
        private readonly AtendenteService _atendenteService;
        private readonly ClienteService _clienteService;
        private readonly PedidoService _pedidoService;




        public PedidoesController(LanchoneteCoreContext context, ProdutoService produtoService, AtendenteService atendenteService, PedidoService pedidoService, ClienteService clienteService)
        {
            _context = context;
            _produtoService = produtoService;
            _atendenteService = atendenteService;
            _clienteService = clienteService;
            _pedidoService = pedidoService;


        }

        // GET: Pedidoes
        public async Task<IActionResult> Index()
        {
            //return View(await _context.Pedido.ToListAsync());
                return View(await _pedidoService.FindAllAsync());
        }

        // GET: Pedidoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obj = await _pedidoService.FindByIdAsync(id.Value);
            
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        // GET: Pedidoes/Create
        public IActionResult Create()
        {
            var produtos = _produtoService.FindAll();
            var atendentes = _atendenteService.FindAll();
            var clientes = _clienteService.FindAll();


            var viewModel = new PedidoFormViewModel { Produtos = produtos, Atendentes = atendentes};
            return View(viewModel);
        }

        // POST: Pedidoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( Pedido pedido)
        {
            if (ModelState.IsValid)
            {
                pedido.Cliente = _context.Cliente.Last(); //Coloca a chave do último cliente inserido no pedido.
                pedido.Atendente = _context.Atendente.First(); //Coloca a chave do último Atendente inserido no pedido.

                pedido.Statusp = "Em andamento";
                pedido.Data = DateTime.Now.Date;

                DateTime data = DateTime.Now;
                String d = data.ToString("HH:mm");

                pedido.Hora = d;


                _context.Add(pedido);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pedido);
        }
        /*
        // GET: Pedidoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pedido = await _context.Pedido.FindAsync(id);
            var produto = await _context.Produto.FindAsync(pedido.ProdutoID);

            pedido.ProdutoID = produto.ProdutoID;
            if (pedido == null)
            {
                return NotFound();
            }
            return View(pedido);
        }
        */
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obj = _pedidoService.FindById(id.Value);
            if (obj == null)
            {
                return NotFound();
            }

            List<Produto> produtos = _produtoService.FindAll();
            PedidoFormViewModel viewModel = new PedidoFormViewModel { Pedido = obj, Produtos = produtos };
            return View(viewModel);
        }
        /*
        // POST: Pedidoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,  Pedido pedido)
        {
            if (id != pedido.PedidoID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pedido);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PedidoExists(pedido.PedidoID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(pedido);
        }
        */
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Pedido pedido)
        {
            if (id != pedido.PedidoID)
            {
                return BadRequest();
            }
            try
            {
                _pedidoService.Update(pedido);
                return RedirectToAction(nameof(Index));
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
            catch (DbConcurrencyException)
            {
                return BadRequest();
            }
        }



        // GET: Pedidoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pedido = await _context.Pedido
                .FirstOrDefaultAsync(m => m.PedidoID == id);
            if (pedido == null)
            {
                return NotFound();
            }

            return View(pedido);
        }

        // POST: Pedidoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pedido = await _context.Pedido.FindAsync(id);
            _context.Pedido.Remove(pedido);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PedidoExists(int id)
        {
            return _context.Pedido.Any(e => e.PedidoID == id);
        }
    }
}
