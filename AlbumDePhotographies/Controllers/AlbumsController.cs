using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AlbumDePhotographies.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace AlbumDePhotographies.Controllers
{
    public class AlbumsController : Controller
    {
        private readonly Context _context;

        private readonly IHostingEnvironment _hostingEnvironment;

        public AlbumsController(Context context, IHostingEnvironment hostingEnvironment)
        {
            _context = context;
            _hostingEnvironment = hostingEnvironment;
        }

        // GET: Albums
        public async Task<IActionResult> Index()
        {
            return View(await _context.Albums.ToListAsync());
        }

        // GET: Albums/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var album = await _context.Albums
                .FirstOrDefaultAsync(m => m.AlbumId == id);
            if (album == null)
            {
                return NotFound();
            }

            return View(album);
        }

        // GET: Albums/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Albums/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AlbumId,Nom,PhotoCouverture,Debut,Fin")] Album album, IFormFile ficher)
        {
            if (ModelState.IsValid)
            {
                var lienUpload = Path.Combine(_hostingEnvironment.WebRootPath,"Photos" );

                if(ficher != null)
                {
                    using(FileStream fileStream = new FileStream(Path.Combine(lienUpload, ficher.FileName), FileMode.Create))
                    {
                        await ficher.CopyToAsync(fileStream);
                        album.PhotoCouverture = "~/Photos/" + ficher.FileName;
                    }
                }

                _context.Add(album);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(album);
        }

        // GET: Albums/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var album = await _context.Albums.FindAsync(id);
            if (album == null)
            {
                return NotFound();
            }

            TempData["PhotoCouverture"] = album.PhotoCouverture;

            return View(album);
        }

        // POST: Albums/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AlbumId,Nom,PhotoCouverture,Debut,Fin")] Album album, IFormFile ficher)
        {
            if (id != album.AlbumId)
            {
                return NotFound();
            }

            if (String.IsNullOrEmpty(album.PhotoCouverture))
            {
                var teste = TempData["PhotoCouverture"];
                album.PhotoCouverture = TempData["PhotoCouverture"].ToString();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var lienUpload = Path.Combine(_hostingEnvironment.WebRootPath, "Photos");

                    if (ficher != null)
                    {
                        using (FileStream fileStream = new FileStream(Path.Combine(lienUpload, ficher.FileName), FileMode.Create))
                        {
                            await ficher.CopyToAsync(fileStream);
                            album.PhotoCouverture = "~/Photos/" + ficher.FileName;
                        }
                    }

                    _context.Update(album);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AlbumExists(album.AlbumId))
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
            return View(album);
        }

        // POST: Albums/Delete/5
        [HttpPost]
        public async Task<JsonResult> Delete(int AlbumId)
        {
            var album = await _context.Albums.FindAsync(AlbumId);
            IEnumerable<string> liens = _context.Photos.Where(p => p.AlbumId == AlbumId).Select(p => p.Lien);

            foreach (var l in liens) 
            {
                var lienPhoto = l.Replace("~", "wwwroot");
                System.IO.File.Delete(lienPhoto);
            }

            _context.Photos.RemoveRange(_context.Photos.Where(x => x.AlbumId == AlbumId));

            string lienPhotoCouverture = album.PhotoCouverture;
            lienPhotoCouverture = lienPhotoCouverture.Replace("~", "wwwroot");
            System.IO.File.Delete(lienPhotoCouverture);


            _context.Albums.Remove(album);
            await _context.SaveChangesAsync();
            return Json("Album a été supprimé");
        }

        private bool AlbumExists(int id)
        {
            return _context.Albums.Any(e => e.AlbumId == id);
        }
    }
}
