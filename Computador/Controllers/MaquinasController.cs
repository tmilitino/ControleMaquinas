﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Computador;
using Computador.Models;
using Computador.ViewModel;

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

            var maq = (from s in _context.Maquina
                       join f in _context.Setor on s.SetorId equals f.Id
                       select new MaquinaVieWModel()
                       {
                           Id = s.Id,
                           Chave = s.Chave,
                           SetorNome = f.Nome,
                           Marca = s.Marca
                       });
            if (!String.IsNullOrEmpty(searchString))
            {
                maq = maq.Where(s => s.Marca.Contains(searchString)
                                  || s.Chave.Contains(searchString)
                                  || s.SetorNome.Contains(searchString));
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
            var maq = (from s in _context.Maquina
                       join f in _context.Setor on s.SetorId equals f.Id
                       select new MaquinaVieWModel()
                       {
                           Id = s.Id,
                           Chave = s.Chave,
                           SetorNome = f.Nome,
                           Marca = s.Marca
                       });
            if (!String.IsNullOrEmpty(id))
            {
                maq = maq.Where(s => s.Id.Contains(id));
            }

            return View(await maq.AsNoTracking().ToListAsync());
        }

        // GET: Maquinas/Create
        public IActionResult Create()
        {
            ViewBag.Setores = new SelectList(_context.Setor,"Id","Nome");
            return View();
        }

        // POST: Maquinas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Chave,SetorId,Marca")] Maquina maquina)
        { 
            if (ModelState.IsValid)
            {
                _context.Add(maquina);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Setores = new SelectList(_context.Setor, "Id", "Nome", maquina.SetorId);

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

            ViewBag.Setores = new SelectList(_context.Setor, "Id", "Nome");

            return View(maquina);
        }

        // POST: Maquinas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,Chave,SetorId,Marca")] Maquina maquina)
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

            ViewBag.Setores = new SelectList(_context.Setor, "Id", "Nome", maquina.SetorId);

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


            var maq = (from s in _context.Maquina
                       join f in _context.Setor on s.SetorId equals f.Id
                       select new MaquinaVieWModel()
                       {
                           Id = s.Id,
                           Chave = s.Chave,
                           SetorNome = f.Nome,
                           Marca = s.Marca
                       });
            if (!String.IsNullOrEmpty(id))
            {
                maq = maq.Where(s => s.Id.Contains(id));
            }

            return View(await maq.AsNoTracking().ToListAsync());
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
