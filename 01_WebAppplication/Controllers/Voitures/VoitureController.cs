﻿using System;
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
            return View();
        }

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
    }
}
