using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EntityFrameWorkRelationships.Models;
using X.PagedList;

namespace EntityFrameWorkRelationships.Controllers
{
    public class TelephonesController : Controller
    {
        private readonly Context _context;

        public TelephonesController(Context context)
        {
            _context = context;
        }

        //// GET: Telephones
        //public async Task<IActionResult> Index()
        //{
        //    return View(await _context.Telephone.ToListAsync());
        //}

        public async Task<IActionResult> Index(int? page)
        {
            const int itensPourPage = 5;
            int nPage = (page ?? 1);
            return View(await _context.Telephone.ToPagedListAsync(nPage, itensPourPage)); 

        }

        // GET: Telephones/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var telephone = await _context.Telephone
                .FirstOrDefaultAsync(m => m.TelephoneId == id);
            if (telephone == null)
            {
                return NotFound();
            }

            return View(telephone);
        }

        // GET: Telephones/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Telephones/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TelephoneId,Numero")] Telephone telephone)
        {
            if (ModelState.IsValid)
            {
                _context.Add(telephone);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(telephone);
        }

        // GET: Telephones/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var telephone = await _context.Telephone.FindAsync(id);
            if (telephone == null)
            {
                return NotFound();
            }
            return View(telephone);
        }

        // POST: Telephones/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TelephoneId,Numero")] Telephone telephone)
        {
            if (id != telephone.TelephoneId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(telephone);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TelephoneExists(telephone.TelephoneId))
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
            return View(telephone);
        }

        // GET: Telephones/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var telephone = await _context.Telephone
                .FirstOrDefaultAsync(m => m.TelephoneId == id);
            if (telephone == null)
            {
                return NotFound();
            }

            return View(telephone);
        }

        // POST: Telephones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var telephone = await _context.Telephone.FindAsync(id);
            _context.Telephone.Remove(telephone);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TelephoneExists(int id)
        {
            return _context.Telephone.Any(e => e.TelephoneId == id);
        }
    }
}
