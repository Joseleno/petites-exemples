using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sondage.Models;
using System.Threading.Tasks;

namespace Sondage.Models.ViewComponents
{
    public class CryptocurrencyViewComponent : ViewComponent
    {
        private readonly SondageContext _sondageContext;
        
        public CryptocurrencyViewComponent(SondageContext sondageContext)
        {
            _sondageContext = sondageContext;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(await _sondageContext.Cryptocurrency.ToArrayAsync());
        }
    }
}
