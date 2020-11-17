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
    public class ExperiencesProfessionnellesController : Controller
    {
        private readonly Context _context;

        public ExperiencesProfessionnellesController(Context context)
        {
            _context = context;
        }

      
        // GET: ExperiencesProfessionnelles/Create
        public IActionResult Create( int id)
        {
            ExperienceProfessionnelle ep = new ExperienceProfessionnelle();
            ep.CurriculumId = id;
            
            return View(ep);
        }

        // POST: ExperiencesProfessionnelles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ExperienceProfessionnelleId,Entreprise,TitrePoste,AnneeDebut,AnneeFin,Activites,CurriculumId")] ExperienceProfessionnelle experienceProfessionnelle)
        {
            if (ModelState.IsValid)
            {
                _context.Add(experienceProfessionnelle);
                await _context.SaveChangesAsync();
                return RedirectToAction("Details", "Curriculums", new { id = experienceProfessionnelle.CurriculumId });
            }
            
            return View(experienceProfessionnelle);
        }

        // GET: ExperiencesProfessionnelles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var experienceProfessionnelle = await _context.ExperiencesProfissionelles.FindAsync(id);
            if (experienceProfessionnelle == null)
            {
                return NotFound();
            }
           
            return View(experienceProfessionnelle);
        }

        // POST: ExperiencesProfessionnelles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ExperienceProfessionnelleId,Entreprise,TitrePoste,AnneeDebut,AnneeFin,Activites,CurriculumId")] ExperienceProfessionnelle experienceProfessionnelle)
        {
            if (id != experienceProfessionnelle.ExperienceProfessionnelleId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(experienceProfessionnelle);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExperienceProfessionnelleExists(experienceProfessionnelle.ExperienceProfessionnelleId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Details", "Curriculums", new { id = experienceProfessionnelle.CurriculumId });
            }
           
            return View(experienceProfessionnelle);
        }

        // POST: ExperiencesProfessionnelles/Delete/5
        [HttpPost]
        public async Task<JsonResult> Delete(int id)
        {
            var experienceProfessionnelle = await _context.ExperiencesProfissionelles.FindAsync(id);
            _context.ExperiencesProfissionelles.Remove(experienceProfessionnelle);
            await _context.SaveChangesAsync();
            return Json("L'experience Professionnelle a été supprimmé avec succès");
        }

        private bool ExperienceProfessionnelleExists(int id)
        {
            return _context.ExperiencesProfissionelles.Any(e => e.ExperienceProfessionnelleId == id);
        }
    }
}
