using Agenda.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Agenda.ViewComponets
{
    public class PrioriteHautViewComponent : ViewComponent
    {
        private readonly AgendaContext _agendaContext;

        public PrioriteHautViewComponent(AgendaContext agendaContext)
        {
            _agendaContext = agendaContext;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(await _agendaContext.Tache.Where(t => t.Priorite.Equals("HAUT", System.StringComparison.OrdinalIgnoreCase)).ToListAsync());
        }
    }
}
