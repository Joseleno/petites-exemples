using GestionCV.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace GestionCV.Controllers
{
    public class CurriculumsController : Controller
    {
        private readonly Context _context;

        public CurriculumsController(Context context)
        {
            _context = context;
        }

        // GET: Curriculums
        
        public async Task<IActionResult> Index()
        {
            if (HttpContext.Session.GetInt32("UtilisateurId") == null)
            {
                return RedirectToAction("Login", "Utilisateurs");
            }


            var context = _context.Curriculum.Include(c => c.Utilisateur);
            return View(await context.ToListAsync());
        }

        // GET: Curriculums/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var curriculum = await _context.Curriculum
                .Include(c => c.Utilisateur)
                .FirstOrDefaultAsync(m => m.CurriculumId == id);
            if (curriculum == null)
            {
                return NotFound();
            }

            return View(curriculum);
        }

        // GET: Curriculums/Create
        public IActionResult Create()
        {
            
            return View();
        }

        // POST: Curriculums/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CurriculumId,Nom,UtilisateurId")] Curriculum curriculum)
        {
            if (HttpContext.Session.GetInt32("UtilisateurId")==null)
            {
                return RedirectToAction("Login", "Utilisateurs");
            }
            curriculum.UtilisateurId = int.Parse(HttpContext.Session.GetInt32("UtilisateurId").ToString());

            if (ModelState.IsValid)
            {
                _context.Add(curriculum);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            
            return View(curriculum);
        }

        // GET: Curriculums/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var curriculum = await _context.Curriculum.FindAsync(id);
            if (curriculum == null)
            {
                return NotFound();
            }
            
            return View(curriculum);
        }

        // POST: Curriculums/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CurriculumId,Nom,UtilisateurId")] Curriculum curriculum)
        {
            if (id != curriculum.CurriculumId)
            {
                return NotFound();
            }
            curriculum.UtilisateurId = int.Parse(HttpContext.Session.GetInt32("UtilisateurId").ToString());

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(curriculum);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CurriculumExists(curriculum.CurriculumId))
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
            
            return View(curriculum);
        }
      
        // POST: Curriculums/Delete/5
        [HttpPost]
        public async Task<JsonResult> Delete(int id)
        {
            var curriculum = await _context.Curriculum.FindAsync(id);
            _context.Curriculum.Remove(curriculum);
            await _context.SaveChangesAsync();
            return Json(curriculum.Nom + " a été exclu avec succès");
        }

        private bool CurriculumExists(int id)
        {
            return _context.Curriculum.Any(e => e.CurriculumId == id);
        }
    }
}
