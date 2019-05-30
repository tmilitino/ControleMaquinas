using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Computador;
using Computador.Models;

namespace Computador.Controllers
{
    public class MaquinasController : Controller
    {
        private readonly ApplicationContext _context;

        public MaquinasController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: Maquinas
        public async Task<IActionResult> Index(string searchString)
        {
            ViewData["CurrentFilter"] = searchString;

            var maq = from s in _context.Maquina
                           select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                maq = maq.Where(s => s.Marca.Contains(searchString)
                                       || s.Setor.Contains(searchString) 
                                       || s.Chave.Contains(searchString));
            }
            return View(await maq.AsNoTracking().ToListAsync());
        }

        // GET: Maquinas/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var maquina = await _context.Maquina
                .FirstOrDefaultAsync(m => m.Id == id);
            if (maquina == null)
            {
                return NotFound();
            }

            return View(maquina);
        }

        // GET: Maquinas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Maquinas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Chave,Setor,Marca")] Maquina maquina)
        {
            if (ModelState.IsValid)
            {
                _context.Add(maquina);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(maquina);
        }

        // GET: Maquinas/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var maquina = await _context.Maquina.FindAsync(id);
            if (maquina == null)
            {
                return NotFound();
            }
            return View(maquina);
        }

        // POST: Maquinas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,Chave,Setor,Marca")] Maquina maquina)
        {
            if (id != maquina.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(maquina);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MaquinaExists(maquina.Id))
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
            return View(maquina);
        }

        // GET: Maquinas/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var maquina = await _context.Maquina
                .FirstOrDefaultAsync(m => m.Id == id);
            if (maquina == null)
            {
                return NotFound();
            }

            return View(maquina);
        }

        // POST: Maquinas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var maquina = await _context.Maquina.FindAsync(id);
            _context.Maquina.Remove(maquina);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MaquinaExists(string id)
        {
            return _context.Maquina.Any(e => e.Id == id);
        }
    }
}
