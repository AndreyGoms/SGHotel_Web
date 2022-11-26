using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SGHotel.Models;
using SGHotel.Models.Data;

namespace SGHotel.Controllers
{
    public class ContaModelsController : Controller
    {
        private readonly BancoContext _context;

        public ContaModelsController(BancoContext context)
        {
            _context = context;
        }

        // GET: ContaModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.Contas.ToListAsync());
        }

        // GET: ContaModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contaModel = await _context.Contas
                .FirstOrDefaultAsync(m => m.IdConta == id);
            if (contaModel == null)
            {
                return NotFound();
            }

            return View(contaModel);
        }

        // GET: ContaModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ContaModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ContaModel contaModel)
        {
            if (contaModel.dt_lancamento <= contaModel.dt_vencimento)
            {
                _context.Add(contaModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(contaModel);
        }

        // GET: ContaModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contaModel = await _context.Contas.FindAsync(id);
            if (contaModel == null)
            {
                return NotFound();
            }
            return View(contaModel);
        }

        // POST: ContaModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ContaModel contaModel)
        {
            if (id != contaModel.IdConta)
            {
                return NotFound();
            }

            if (contaModel.dt_lancamento <= contaModel.dt_vencimento)
            {
                try
                {
                    _context.Update(contaModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContaModelExists(contaModel.IdConta))
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
            return View(contaModel);
        }

        // GET: ContaModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contaModel = await _context.Contas
                .FirstOrDefaultAsync(m => m.IdConta == id);
            if (contaModel == null)
            {
                return NotFound();
            }

            return View(contaModel);
        }

        // POST: ContaModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var contaModel = await _context.Contas.FindAsync(id);
            _context.Contas.Remove(contaModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContaModelExists(int id)
        {
            return _context.Contas.Any(e => e.IdConta == id);
        }

    }
}
