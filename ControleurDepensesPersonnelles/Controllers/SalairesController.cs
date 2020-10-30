using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ControleurDepensesPersonnelles.Models;

namespace ControleurDepensesPersonnelles.Controllers
{
    public class SalairesController : Controller
    {
        private readonly Context _context;

        public SalairesController(Context context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var context = _context.Salaires.Include(s => s.Mois);
            return View(await context.ToListAsync());
        }

        [HttpPost]
        public async Task<IActionResult> Index(string txChercher)
        {
            var context = _context.Salaires.Include(s => s.Mois);
            
            if (!String.IsNullOrEmpty(txChercher))
            {
                return View(await context.Where(s => s.Mois.Nom.Contains(txChercher, StringComparison.OrdinalIgnoreCase)).ToListAsync());

            }

            return View(await context.ToListAsync());
        }
        


        // GET: Salaires/Create
        public IActionResult Create()
        {
            ViewData["MoisId"] = new SelectList(_context.Mois.Where(m => m.MoisId != m.Salaire.MoisId), "MoisId", "Nom");
            return View();
        }

        // POST: Salaires/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SalaireId,MoisId,Valeur")] Salaire salaire)
        {
            if (ModelState.IsValid)
            {
                TempData["Confirmation"] = "Salaire a été enregistré avec succès.";
                _context.Add(salaire);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MoisId"] = new SelectList(_context.Mois.Where(m => m.MoisId != m.Salaire.MoisId), "MoisId", "Nom", salaire.MoisId);
            return View(salaire);
        }

        // GET: Salaires/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salaire = await _context.Salaires.FindAsync(id);
            if (salaire == null)
            {
                return NotFound();
            }
            ViewData["MoisId"] = new SelectList(_context.Mois.Where(m => m.MoisId == id), "MoisId", "Nom", salaire.MoisId);
            return View(salaire);
        }

        // POST: Salaires/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SalaireId,MoisId,Valeur")] Salaire salaire)
        {
            if (id != salaire.SalaireId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    TempData["Confirmation"] = "Salaire a été changé avec succès.";
                    _context.Update(salaire);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SalaireExists(salaire.SalaireId))
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
            ViewData["MoisId"] = new SelectList(_context.Mois.Where(m => m.MoisId == id), "MoisId", "Nom", salaire.MoisId);
            return View(salaire);
        }

        
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var salaire = await _context.Salaires.FindAsync(id);
            _context.Salaires.Remove(salaire);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SalaireExists(int id)
        {
            return _context.Salaires.Any(e => e.SalaireId == id);
        }
    }
}
