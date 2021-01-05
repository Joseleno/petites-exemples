using GestionCV.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace GestionCV.ViewComponents
{
    public class ObjectifsViewComponent : ViewComponent
    {
        private readonly Context _context;


        public ObjectifsViewComponent(Context context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            return View(await _context.Objectif.Where(o => o.CurriculumId == id).ToListAsync());
        }


    }
}
