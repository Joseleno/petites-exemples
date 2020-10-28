using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EntityFrameWorkRelationships.Models;
using X.PagedList;

namespace EntityFrameWorkRelationships.Controllers
{
    public class PersonnesController : Controller
    {
        private readonly Context _context;

        public PersonnesController(Context context)
        {
            _context = context;
        }

        // GET: Personnes
        public async Task<IActionResult> Index(int? page)
        {
            var context = _context.Gens.Include(p => p.Adresse).Include(p => p.Telephone);
            const int itensPourPage = 5;
            int nPage = (page ?? 1);
            return View(await context.OrderBy(p=>p.Nom.ToString()).ToPagedListAsync(nPage, itensPourPage));
        }

        [HttpPost]
        public async Task<IActionResult> Index(string txChercher)
        {
            if (!string.IsNullOrEmpty(txChercher))
            {
                return View(await _context.Gens.Where(x => x.Nom.Contains(txChercher)).ToListAsync());
            }
            return View(await _context.Gens.ToListAsync());
        }

        // GET: Personnes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personne = await _context.Gens
                .Include(p => p.Adresse)
                .Include(p => p.Telephone)
                .FirstOrDefaultAsync(m => m.PersonneId == id);
            if (personne == null)
            {
                return NotFound();
            }

            return View(personne);
        }

        // GET: Personnes/Create
        public IActionResult Create()
        {
            ViewData["AdresseId"] = new SelectList(_context.Adresse, "AdresseId", "CodePostal");
            ViewData["TelephoneId"] = new SelectList(_context.Set<Telephone>(), "TelephoneId", "Numero");
            return View();
        }

        // POST: Personnes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PersonneId,Nom,DateNaissance,Poids,AdresseId,TelephoneId")] Personne personne)
        {
            if (ModelState.IsValid)
            {
                _context.Add(personne);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AdresseId"] = new SelectList(_context.Adresse, "AdresseId", "CodePostal", personne.AdresseId);
            ViewData["TelephoneId"] = new SelectList(_context.Set<Telephone>(), "TelephoneId", "Numero", personne.TelephoneId);
            return View(personne);
        }

        // GET: Personnes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personne = await _context.Gens.FindAsync(id);
            if (personne == null)
            {
                return NotFound();
            }
            ViewData["AdresseId"] = new SelectList(_context.Adresse, "AdresseId", "CodePostal", personne.AdresseId);
            ViewData["TelephoneId"] = new SelectList(_context.Set<Telephone>(), "TelephoneId", "Numero", personne.TelephoneId);
            return View(personne);
        }

        // POST: Personnes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PersonneId,Nom,DateNaissance,Poids,AdresseId,TelephoneId")] Personne personne)
        {
            if (id != personne.PersonneId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(personne);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PersonneExists(personne.PersonneId))
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
            ViewData["AdresseId"] = new SelectList(_context.Adresse, "AdresseId", "CodePostal", personne.AdresseId);
            ViewData["TelephoneId"] = new SelectList(_context.Set<Telephone>(), "TelephoneId", "Numero", personne.TelephoneId);
            return View(personne);
        }

        // GET: Personnes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personne = await _context.Gens
                .Include(p => p.Adresse)
                .Include(p => p.Telephone)
                .FirstOrDefaultAsync(m => m.PersonneId == id);
            if (personne == null)
            {
                return NotFound();
            }

            return View(personne);
        }

        // POST: Personnes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var personne = await _context.Gens.FindAsync(id);
            _context.Gens.Remove(personne);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PersonneExists(int id)
        {
            return _context.Gens.Any(e => e.PersonneId == id);
        }
    }
}
