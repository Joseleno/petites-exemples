using Agenda.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Agenda.ViewComponets
{
    public class PrioriteBasViewComponent : ViewComponent
    {
        private readonly AgendaContext _agendaContext;

        public PrioriteBasViewComponent(AgendaContext agendaContext)
        {
            _agendaContext = agendaContext;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(await _agendaContext.Tache.Where(t => t.Priorite.Equals("BAS", System.StringComparison.OrdinalIgnoreCase)).ToListAsync());
        }
    }
}
