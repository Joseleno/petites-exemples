using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAppplication_01.Models;

namespace WebAppplication_01.Controllers.Voitures
{


    public class VoitureController : Controller
    {
        private readonly Context _context;

        public VoitureController(Context context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View(_context.Voitures.ToList());
        }
        [HttpGet]
        public IActionResult Nouvellevoiture()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Nouvellevoiture(Voiture carro)
        {
            if (ModelState.IsValid)
            {
                _context.Add(carro);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }

            return View(carro);
        }

        [HttpGet]
        public IActionResult Actualizer(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var carro = _context.Voitures.Find(id);

            return View(carro);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Actualizer(int id, Voiture v)
        {
            if (id == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                _context.Update(v);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }

            return View(v);
        }

        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carro = _context.Voitures.FirstOrDefault(x => x.VoitureId == id);
            
            return View(carro);

        }

        [HttpGet]
        public IActionResult Supprimir(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carro = _context.Voitures.FirstOrDefault(x => x.VoitureId == id);

            return View(carro);

        }

        [HttpPost, ActionName("Supprimir")]
        [ValidateAntiForgeryToken]
        public IActionResult ConfirmerSupprimir(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carro = _context.Voitures.FirstOrDefault(x => x.VoitureId == id);
            _context.Remove(carro);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));

        }

    }
}
