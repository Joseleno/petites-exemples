using GestionCV.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace GestionCV.Controllers
{
    public class ObjectifsController : Controller
    {
        private readonly Context _context;

        public ObjectifsController(Context context)
        {
            _context = context;
        }

        // GET: Objectifs/Create
        public IActionResult Create(int id)
        {
            Objectif objectif = new Objectif();
            objectif.CurriculumId = id;
            return View(objectif);
        }

        // POST: Objectifs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ObjectifId,Description,CurriculumId")] Objectif objectif)
        {
            if (ModelState.IsValid)
            {
                _context.Add(objectif);
                await _context.SaveChangesAsync();
                return RedirectToAction("Details", "Curriculums", new { id = objectif.CurriculumId });
            }

            return View(objectif);
        }

        // GET: Objectifs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var objectif = await _context.Objectif.FindAsync(id);
            if (objectif == null)
            {
                return NotFound();
            }

            return View(objectif);
        }

        // POST: Objectifs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ObjectifId,Description,CurriculumId")] Objectif objectif)
        {
            if (id != objectif.ObjectifId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(objectif);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ObjectifExists(objectif.ObjectifId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Details", "Curriculums", new { id = objectif.CurriculumId });
            }

            return View(objectif);
        }

        // GET: Objectifs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var objectif = await _context.Objectif
                .Include(o => o.Curriculum)
                .FirstOrDefaultAsync(m => m.ObjectifId == id);
            if (objectif == null)
            {
                return NotFound();
            }

            return View(objectif);
        }

        // POST: Objectifs/Delete/5
        [HttpPost]
        public async Task<JsonResult> Delete(int id)
        {
            var objectif = await _context.Objectif.FindAsync(id);
            _context.Objectif.Remove(objectif);
            await _context.SaveChangesAsync();
            return Json("Objectif a été exclu avec succès");
        }

        private bool ObjectifExists(int id)
        {
            return _context.Objectif.Any(e => e.ObjectifId == id);
        }
    }
}
