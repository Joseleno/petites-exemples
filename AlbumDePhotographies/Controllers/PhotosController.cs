using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AlbumDePhotographies.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace AlbumDePhotographies.Controllers
{
    public class PhotosController : Controller
    {
        private readonly Context _context;
        private readonly IHostingEnvironment _hostingEnvironment;

        public PhotosController(Context context, IHostingEnvironment hostingEnvironment)
        {
            _context = context;
            _hostingEnvironment = hostingEnvironment;
        }

       // GET: Photos/Create
        public IActionResult Create(int id)
        {
            ViewBag.Albums = _context.Albums.FirstOrDefault(x => x.AlbumId == id);
            return View();
        }

        // POST: Photos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PhotoId,Lien,AlbumId")] Photo photo, IFormFile ficher)
        {
            if (ModelState.IsValid)
            {
                var lienUpload = Path.Combine(_hostingEnvironment.WebRootPath, "Photos");

                if (ficher != null)
                {
                    using (FileStream fileStream = new FileStream(Path.Combine(lienUpload, ficher.FileName), FileMode.Create))
                    {
                        await ficher.CopyToAsync(fileStream);
                        photo.Lien = "~/Photos/" + ficher.FileName;
                    }
                }

                _context.Add(photo);
                await _context.SaveChangesAsync();
                return RedirectToAction("Details/", "Albums", new { id = photo.AlbumId });
            }
            ViewData["AlbumId"] = new SelectList(_context.Albums, "AlbumId", "Nom", photo.AlbumId);
            return View(photo);
        }

    }
}
