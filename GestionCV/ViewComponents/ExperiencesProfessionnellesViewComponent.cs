using GestionCV.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace GestionCV.ViewComponents
{
    public class ExperiencesProfessionnellesViewComponent : ViewComponent
    {
        private readonly Context _context;
        public ExperiencesProfessionnellesViewComponent(Context context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            return View(await _context.ExperiencesProfissionelles.Where(ep => ep.CurriculumId == id).ToListAsync());
        }
    }
}
