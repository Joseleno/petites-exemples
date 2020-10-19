using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Agenda.Models;

namespace Agenda.Controllers
{
    public class TachesController : Controller
    {
        private readonly AgendaContext _context;

        public TachesController(AgendaContext context)
        {
            _context = context;
        }

        // GET: Taches
        public async Task<IActionResult> Index()
        {
            return View(await _context.Tache.ToListAsync());
        }

        // GET: Taches/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tache = await _context.Tache
                .FirstOrDefaultAsync(m => m.TacheId == id);
            if (tache == null)
            {
                return NotFound();
            }

            return View(tache);
        }

        // GET: Taches/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Taches/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TacheId,Title,Description,Debut,Fin,Priorite")] Tache tache)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tache);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tache);
        }

        // GET: Taches/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tache = await _context.Tache.FindAsync(id);
            if (tache == null)
            {
                return NotFound();
            }
            return View(tache);
        }

        // POST: Taches/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TacheId,Title,Description,Debut,Fin,Priorite")] Tache tache)
        {
            if (id != tache.TacheId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tache);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TacheExists(tache.TacheId))
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
            return View(tache);
        }

        // GET: Taches/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tache = await _context.Tache
                .FirstOrDefaultAsync(m => m.TacheId == id);
            if (tache == null)
            {
                return NotFound();
            }

            return View(tache);
        }

        // POST: Taches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tache = await _context.Tache.FindAsync(id);
            _context.Tache.Remove(tache);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TacheExists(int id)
        {
            return _context.Tache.Any(e => e.TacheId == id);
        }
    }
}
