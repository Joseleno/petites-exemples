using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GestionCV.Models;

namespace GestionCV.Controllers
{
    public class LanguesController : Controller
    {
        private readonly Context _context;

        public LanguesController(Context context)
        {
            _context = context;
        }

        // GET: Langues/Create
        public IActionResult Create(int id)
        {
            Langue langue = new Langue();
            langue.CurriculumId = id;
            return View(langue);
        }

        // POST: Langues/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LangueId,Nom,Niveau,CurriculumId")] Langue langue)
        {
            if (ModelState.IsValid)
            {
                _context.Add(langue);
                await _context.SaveChangesAsync();
                return RedirectToAction("Details", "Curriculums", new { id = langue.CurriculumId });
            }
            
            return View(langue);
        }

        // GET: Langues/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var langue = await _context.Langues.FindAsync(id);
            if (langue == null)
            {
                return NotFound();
            }

            return View(langue);
        }

        // POST: Langues/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LangueId,Nom,Niveau,CurriculumId")] Langue langue)
        {
            if (id != langue.LangueId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(langue);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LangueExists(langue.LangueId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Details", "Curriculums", new { id = langue.CurriculumId });
            }
            ViewData["CurriculumId"] = new SelectList(_context.Curriculum, "CurriculumId", "Nom", langue.CurriculumId);
            return View(langue);
        }

        // POST: Langues/Delete/5
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var langue = await _context.Langues.FindAsync(id);
            _context.Langues.Remove(langue);
            await _context.SaveChangesAsync();
            return RedirectToAction("Details", "Curriculums", new { id = langue.CurriculumId });
        }

        private bool LangueExists(int id)
        {
            return _context.Langues.Any(e => e.LangueId == id);
        }
    }
}
