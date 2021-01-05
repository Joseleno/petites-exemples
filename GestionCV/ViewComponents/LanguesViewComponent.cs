﻿using GestionCV.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace GestionCV.ViewComponents
{
    public class LanguesViewComponent : ViewComponent
    {
        private readonly Context _context;

        public LanguesViewComponent(Context context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            return View(await _context.Langues.Where(l => l.CurriculumId == id).ToListAsync());
        }
    }
}
