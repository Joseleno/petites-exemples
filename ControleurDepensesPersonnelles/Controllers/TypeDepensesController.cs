using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ControleurDepensesPersonnelles.Models;
using System;

namespace ControleurDepensesPersonnelles.Controllers
{
    public class TypeDepensesController : Controller
    {
        private readonly Context _context;

        public TypeDepensesController(Context context)
        {
            _context = context;
        }

        // GET: TypeDepenses
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _context.TypeDepenses.OrderBy(td => td.Nom).ToListAsync());
        }

        [HttpPost]
        public async Task<IActionResult> Index(string txChercher)
        {
            if (!String.IsNullOrEmpty(txChercher))
            {
                return View(await _context.TypeDepenses.Where(td => td.Nom.Contains(txChercher, StringComparison.OrdinalIgnoreCase)).ToListAsync());

            }

            return View(await _context.TypeDepenses.OrderBy(td => td.Nom).ToListAsync());
        }

        [HttpPost]
        public JsonResult AjouterDepense(string txDepense)
        {
            if (!String.IsNullOrEmpty(txDepense))
            {

                if (!_context.TypeDepenses.Any(td => td.Nom.ToUpper().ToString().Equals(txDepense.ToUpper())))
                {
                    var typeDepense = new TypeDepense();
                    typeDepense.Nom = txDepense;
                    _context.Add(typeDepense);
                    _context.SaveChanges();
                    return Json(true);
                }
            }
            return Json(false);
        }

        public async Task<JsonResult> VerifierTypeDesp(string nom)
        {
            if (await _context.TypeDepenses.AnyAsync(td => td.Nom.ToUpper().ToString().Equals(nom.ToUpper())))
            {
                return Json("Ce type existe déjà");
            }
            return Json(true);
        }

        // GET: TypeDepenses/Create
        public IActionResult Create()
        {
            return View();
        }


        // POST: TypeDepenses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TypeDepenseId,Nom")] TypeDepense typeDepense)
        {
            if (ModelState.IsValid)
            {

                TempData["Confirmation"] = typeDepense.Nom + " a été enregistré avec succès.";

                _context.Add(typeDepense);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(typeDepense);
        }

        // GET: TypeDepenses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var typeDepense = await _context.TypeDepenses.FindAsync(id);
            if (typeDepense == null)
            {
                return NotFound();
            }
            return View(typeDepense);
        }

        // POST: TypeDepenses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TypeDepenseId,Nom")] TypeDepense typeDepense)
        {
            if (id != typeDepense.TypeDepenseId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    TempData["Confirmation"] = typeDepense.Nom + " a été modifié avec succès.";
                    _context.Update(typeDepense);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TypeDepenseExists(typeDepense.TypeDepenseId))
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
            return View(typeDepense);
        }

        // POST: TypeDepenses/Delete/5
        [HttpPost]
        public async Task<JsonResult> Delete(int id)
        {
            var typeDepense = await _context.TypeDepenses.FindAsync(id);

            TempData["Confirmation"] = typeDepense.Nom + " a été supprimé avec succès.";

            _context.TypeDepenses.Remove(typeDepense);
            await _context.SaveChangesAsync();
            return Json(typeDepense.Nom + "a été supprimé avec succès.");
        }

        private bool TypeDepenseExists(int id)
        {
            return _context.TypeDepenses.Any(e => e.TypeDepenseId == id);
        }

    }
}
