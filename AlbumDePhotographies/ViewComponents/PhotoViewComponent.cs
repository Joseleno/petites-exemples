using AlbumDePhotographies.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace AlbumDePhotographies.ViewComponents
{
    public class PhotoViewComponent : ViewComponent
    {
        private readonly Context _context;

        public PhotoViewComponent(Context context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            return View(await _context.Photos.Where(x => x.AlbumId == id).ToListAsync());
        }

    }
}
