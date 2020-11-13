using GestionCV.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace GestionCV.Controllers
{
    public class TypeCoursController : Controller
    {
        private readonly Context _context;

        public TypeCoursController(Context context)
        {
            _context = context;
        }

        // GET: TypeCours
        public async Task<IActionResult> Index()
        {
            return View(await _context.TypeCours.ToListAsync());
        }

        // GET: TypeCours/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TypeCours/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TypeCoursId,Type")] TypeCours typeCours)
        {
            if (ModelState.IsValid)
            {
                _context.Add(typeCours);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(typeCours);
        }

        // GET: TypeCours/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var typeCours = await _context.TypeCours.FindAsync(id);
            if (typeCours == null)
            {
                return NotFound();
            }
            return View(typeCours);
        }

        // POST: TypeCours/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TypeCoursId,Type")] TypeCours typeCours)
        {
            if (id != typeCours.TypeCoursId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(typeCours);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TypeCoursExists(typeCours.TypeCoursId))
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
            return View(typeCours);
        }

        // POST: TypeCours/Delete/5
        [HttpPost]
        public async Task<JsonResult> Delete(int id)
        {
            var typeCours = await _context.TypeCours.FindAsync(id);
            var type = typeCours.Type.ToString();
            _context.TypeCours.Remove(typeCours);
            await _context.SaveChangesAsync();
            return Json("Type de cours " + type + " supprimé avec succès");
        }

        private bool TypeCoursExists(int id)
        {
            return _context.TypeCours.Any(e => e.TypeCoursId == id);
        }
    }
}
