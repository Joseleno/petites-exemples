﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Gens.Models;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Rotativa.AspNetCore;

namespace Gens.Controllers
{
    public class PersonnesController : Controller
    {
        private readonly GensContext _context;

        public PersonnesController(GensContext context)
        {
            _context = context;
        }

        public async Task<JsonResult> PersonneValidation(string courriel)
        {
            var count = _context.Gens.Count(c => c.Courriel.Equals(courriel));
            
            if (await _context.Gens.AnyAsync(p => p.Courriel.Equals(courriel)) && count < 1)
                {
                    return Json("Personne déjà inscrite");
                }

            return Json(true);
        }

        // GET: Personnes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Gens.ToListAsync());
        }

        public IActionResult CreerCSV()
        {
            var gens = _context.Gens.ToList();
            StringBuilder ficher = new StringBuilder();
            ficher.AppendLine("Id;Nom;Age;Curriel") ;
            foreach(var p in gens)
            {
                ficher.AppendLine(p.PersonneId + ";" + p.Nom + ";" + p.Age + ";" + p.Courriel);
            }
            return File(Encoding.ASCII.GetBytes(ficher.ToString()), "text/csv", "Gens.csv");
        }

        public IActionResult CreerPDF()
        {
            return new ViewAsPdf("PDF", _context.Gens.ToList()) { FileName = "Gens.pdf" };
        }


        // GET: Personnes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Personnes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PersonneId,Nom,Age,DateNaissance,Courriel,ConfirmationCourriel")] Personne personne)
        {
            if (ModelState.IsValid)
            {
                _context.Add(personne);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
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
            return View(personne);
        }

        // POST: Personnes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PersonneId,Nom,Age,DateNaissance,Courriel,ConfirmationCourriel")] Personne personne)
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
