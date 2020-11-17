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
    public class FormationsController : Controller
    {
        private readonly Context _context;

        public FormationsController(Context context)
        {
            _context = context;
        }

        // GET: Formations/Create
        public IActionResult Create(int id)
        {
            Formation formation = new Formation();
            formation.CurriculumId = id;

            ViewData["TypeCoursId"] = new SelectList(_context.TypeCours, "TypeCoursId", "Type");
            return View(formation);
        }

        // POST: Formations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FormationId,TypeCoursId,Institution,AnneeDebut,AnneeFin,NomCours,CurriculumId")] Formation formation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(formation);
                await _context.SaveChangesAsync();
                return RedirectToAction("Details", "Curriculums", new { id = formation.CurriculumId});
            }
            ViewData["TypeCoursId"] = new SelectList(_context.TypeCours, "TypeCoursId", "Type", formation.TypeCoursId);
            return View(formation);
        }

        // GET: Formations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var formation = await _context.Formation.FindAsync(id);
            if (formation == null)
            {
                return NotFound();
            }
            ViewData["TypeCoursId"] = new SelectList(_context.TypeCours, "TypeCoursId", "Type", formation.TypeCoursId);
            return View(formation);
        }

        // POST: Formations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FormationId,TypeCoursId,Institution,AnneeDebut,AnneeFin,NomCours,CurriculumId")] Formation formation)
        {
            if (id != formation.FormationId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(formation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FormationExists(formation.FormationId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Details", "Curriculums", new { id = formation.CurriculumId });
            }
            ViewData["TypeCoursId"] = new SelectList(_context.TypeCours, "TypeCoursId", "Type", formation.TypeCoursId);
            return View(formation);
        }

        // POST: Formations/Delete/5
        [HttpPost]
        public async Task<JsonResult> Delete(int id)
        {
            var formation = await _context.Formation.FindAsync(id);
            _context.Formation.Remove(formation);
            await _context.SaveChangesAsync();
            return Json("Formation a été supprimmé avec succès");
        }

        private bool FormationExists(int id)
        {
            return _context.Formation.Any(e => e.FormationId == id);
        }
    }
}
