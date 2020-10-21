using Agenda.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Agenda.ViewComponets
{
    public class PrioriteMoyenneViewComponent : ViewComponent
    {
        private readonly AgendaContext _agendaContext;

        public PrioriteMoyenneViewComponent(AgendaContext agendaContext)
        {
            _agendaContext = agendaContext;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(await _agendaContext.Tache.Where(t => t.Priorite.Equals("MOYENNE", System.StringComparison.OrdinalIgnoreCase)).ToListAsync());
        }
    }
}
