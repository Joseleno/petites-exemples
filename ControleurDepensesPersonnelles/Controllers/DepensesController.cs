using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ControleurDepensesPersonnelles.Models;
using X.PagedList;

namespace ControleurDepensesPersonnelles.Controllers
{
    public class DepensesController : Controller
    {
        private readonly Context _context;

        public DepensesController(Context context)
        {
            _context = context;
        }

        // GET: Depenses
        public async Task<IActionResult> Index(int? page)
        {
            const int itensPage = 10;
            int numeroPage = (page ?? 1);
            var context = _context.Depenses.Include(d => d.Mois).Include(d => d.TypeDepense);
            return View(await context.OrderBy(d => d.MoisId).ToPagedListAsync(numeroPage, itensPage));
        }

        

        // GET: Depenses/Create
        public IActionResult Create()
        {
            ViewData["MoisId"] = new SelectList(_context.Mois, "MoisId", "Nom");
            ViewData["TypeDepenseId"] = new SelectList(_context.TypeDepenses, "TypeDepenseId", "Nom");
            return View();
        }

        // POST: Depenses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DepenseId,MoisId,TypeDepenseId,Valeur")] Depense depense)
        {
            if (ModelState.IsValid)
            {
                TempData["Confirmation"] = "Depénse a été enregistré avec succès.";
                _context.Add(depense);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MoisId"] = new SelectList(_context.Mois, "MoisId", "Nom", depense.MoisId);
            ViewData["TypeDepenseId"] = new SelectList(_context.TypeDepenses, "TypeDepenseId", "Nom", depense.TypeDepenseId);
            return View(depense);
        }

        // GET: Depenses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var depense = await _context.Depenses.FindAsync(id);
            if (depense == null)
            {
                return NotFound();
            }
            ViewData["MoisId"] = new SelectList(_context.Mois, "MoisId", "Nom", depense.MoisId);
            ViewData["TypeDepenseId"] = new SelectList(_context.TypeDepenses, "TypeDepenseId", "Nom", depense.TypeDepenseId);
            return View(depense);
        }

        // POST: Depenses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DepenseId,MoisId,TypeDepenseId,Valeur")] Depense depense)
        {
            if (id != depense.DepenseId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    TempData["Confirmation"] = "Depénse a été changé avec succès.";
                    _context.Update(depense);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DepenseExists(depense.DepenseId))
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
            ViewData["MoisId"] = new SelectList(_context.Mois, "MoisId", "Nom", depense.MoisId);
            ViewData["TypeDepenseId"] = new SelectList(_context.TypeDepenses, "TypeDepenseId", "Nom", depense.TypeDepenseId);
            return View(depense);
        }

        // POST: Depenses/Delete/5
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var depense = await _context.Depenses.FindAsync(id);
            _context.Depenses.Remove(depense);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DepenseExists(int id)
        {
            return _context.Depenses.Any(e => e.DepenseId == id);
        }
    }
}
