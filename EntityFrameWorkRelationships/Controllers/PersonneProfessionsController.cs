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
    public class PersonneProfessionsController : Controller
    {
        private readonly Context _context;

        public PersonneProfessionsController(Context context)
        {
            _context = context;
        }

        // GET: PersonneProfessions
        public async Task<IActionResult> Index(int? page)
        {
            const int itensPourPage = 5;
            int nPage = (page ?? 1);
            var context = _context.PersonneProfession.Include(p => p.Personne).Include(p => p.Profession);
            
            return View(await context.ToPagedListAsync(nPage, itensPourPage));
        }

        // GET: PersonneProfessions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personneProfession = await _context.PersonneProfession
                .Include(p => p.Personne)
                .Include(p => p.Profession)
                .FirstOrDefaultAsync(m => m.PersonneId == id);
            if (personneProfession == null)
            {
                return NotFound();
            }

            return View(personneProfession);
        }

        // GET: PersonneProfessions/Create
        public IActionResult Create()
        {
            ViewData["PersonneId"] = new SelectList(_context.Gens, "PersonneId", "Nom");
            ViewData["ProfessionId"] = new SelectList(_context.Set<Profession>(), "ProfessionId", "Title");
            return View();
        }

        // POST: PersonneProfessions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PersonneId,ProfessionId,Salaire")] PersonneProfession personneProfession)
        {
            if (ModelState.IsValid)
            {
                _context.Add(personneProfession);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PersonneId"] = new SelectList(_context.Gens, "PersonneId", "Nom", personneProfession.PersonneId);
            ViewData["ProfessionId"] = new SelectList(_context.Set<Profession>(), "ProfessionId", "Title", personneProfession.ProfessionId);
            return View(personneProfession);
        }

        // GET: PersonneProfessions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personneProfession = await _context.PersonneProfession.FindAsync(id);
            if (personneProfession == null)
            {
                return NotFound();
            }
            ViewData["PersonneId"] = new SelectList(_context.Gens, "PersonneId", "Nom", personneProfession.PersonneId);
            ViewData["ProfessionId"] = new SelectList(_context.Set<Profession>(), "ProfessionId", "ProfessionId", personneProfession.ProfessionId);
            return View(personneProfession);
        }

        // POST: PersonneProfessions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PersonneId,ProfessionId,Salaire")] PersonneProfession personneProfession)
        {
            if (id != personneProfession.PersonneId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(personneProfession);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PersonneProfessionExists(personneProfession.PersonneId))
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
            ViewData["PersonneId"] = new SelectList(_context.Gens, "PersonneId", "Nom", personneProfession.PersonneId);
            ViewData["ProfessionId"] = new SelectList(_context.Set<Profession>(), "ProfessionId", "ProfessionId", personneProfession.ProfessionId);
            return View(personneProfession);
        }

        // GET: PersonneProfessions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personneProfession = await _context.PersonneProfession
                .Include(p => p.Personne)
                .Include(p => p.Profession)
                .FirstOrDefaultAsync(m => m.PersonneId == id);
            if (personneProfession == null)
            {
                return NotFound();
            }

            return View(personneProfession);
        }

        // POST: PersonneProfessions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var personneProfession = await _context.PersonneProfession.FindAsync(id);
            _context.PersonneProfession.Remove(personneProfession);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PersonneProfessionExists(int id)
        {
            return _context.PersonneProfession.Any(e => e.PersonneId == id);
        }
    }
}
