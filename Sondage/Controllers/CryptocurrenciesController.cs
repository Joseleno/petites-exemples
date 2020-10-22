using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using Microsoft.EntityFrameworkCore;
using Sondage.Models;

namespace Sondage.Controllers
{
    public class CryptocurrenciesController : Controller
    {
        private readonly SondageContext _context;

        public CryptocurrenciesController(SondageContext context)
        {
            _context = context;
        }

        // GET: Cryptocurrencies
        public async Task<IActionResult> Index()
        {
            return View(await _context.Cryptocurrency.ToListAsync());
        }

        public async Task<IActionResult> SelecitonerCrypto(List<Cryptocurrency> cryptos)
        {
            foreach(var item in cryptos)
            {
                if(item.Selectionne)
                {
                    Cryptocurrency cryptocurrency = await  _context.Cryptocurrency.FirstAsync(x => x.CryptocurrencyId == item.CryptocurrencyId);
                    cryptocurrency.Quantite ++;
                    _context.Update(cryptocurrency);
                    await _context.SaveChangesAsync();
                }
            }

            return RedirectToAction(nameof(Index));
        }

        public JsonResult GenererGraphique()
        {
            return Json(_context.Cryptocurrency.Select(x => new { x.Nom, x.Quantite }));
        }

        // GET: Cryptocurrencies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cryptocurrencies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CryptocurrencyId,Nom,Quantite")] Cryptocurrency cryptocurrency)
        {
            if (ModelState.IsValid)
            {
                cryptocurrency.Quantite = 0;
                _context.Add(cryptocurrency);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cryptocurrency);
        }
    }
}
