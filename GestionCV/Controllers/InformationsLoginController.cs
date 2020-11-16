using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GestionCV.Models;
using Microsoft.AspNetCore.Http;
using System.Text;

namespace GestionCV.Controllers
{
    public class InformationsLoginController : Controller
    {
        private readonly Context _context;

        public InformationsLoginController(Context context)
        {
            _context = context;
        }

        // GET: InformationsLogin
        public async Task<IActionResult> Index()
        {
            if (HttpContext.Session.GetInt32("UtilisateurId") == null)
            {
                return NotFound();
            }
            var UtilisateurId = HttpContext.Session.GetInt32("UtilisateurId");
             
            return View(await _context.InformationLogin.Include(i => i.Utilisateur).Where(i => i.UtilisateurId == UtilisateurId).ToListAsync());
        }

        // GET: InformationsLogin/Details/5
        public IActionResult GetInformationLoginCSV() 
        {
            if (HttpContext.Session.GetInt32("UtilisateurId") == null)
            {
                return NotFound();
            }
            var UtilisateurId = HttpContext.Session.GetInt32("UtilisateurId");
            var infoLogin = _context.InformationLogin.Include(i => i.Utilisateur).Where(i => i.UtilisateurId == UtilisateurId).ToList();
            StringBuilder ficher = new StringBuilder();

            ficher.AppendLine("AdressIP;Date;Hour");

            foreach ( var i in infoLogin)
            {
                ficher.AppendLine(i.AdresseIp + ';'+ i.Date + ';' + i.Hour);
            }
            return File(Encoding.ASCII.GetBytes(ficher.ToString()), "text/csv", "infoLogin.csv");
        }
    }
}
