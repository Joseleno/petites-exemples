using GestionCV.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace GestionCV.ViewComponents
{
    public class FormationsViewComponent : ViewComponent
    {
        private readonly Context _context;

        public FormationsViewComponent(Context context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            return View(await _context.Formation.Include(f => f.TypeCours).Where(f => f.CurriculumId == id).ToListAsync());
        }
    }
}
