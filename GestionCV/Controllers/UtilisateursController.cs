using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GestionCV.Models;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using GestionCV.Oultils;

namespace GestionCV.Controllers
{
    public class UtilisateursController : Controller
    {
        private readonly IMd5 _md;
        private readonly Context _context;
        

        public UtilisateursController(Context context, IMd5 md5)
        {
            _context = context;
            _md = md5;
        }

        // GET: Utilisateurs/Create
        public IActionResult Enregistrer()
        {
            return View();
        }

        // POST: Utilisateurs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Enregistrer([Bind("UtilisateurId,Courriel,MotDePasse")] Utilisateur utilisateur)
        {
            if (ModelState.IsValid)
            {
                
                string md = _md.GererHash(utilisateur.MotDePasse).ToString();
                utilisateur.MotDePasse = md;

                _context.Add(utilisateur);
                await _context.SaveChangesAsync();

                InformationLogin donnes = new InformationLogin
                {
                    UtilisateurId = utilisateur.UtilisateurId, 
                    AdresseIp = Request.HttpContext.Connection.RemoteIpAddress.ToString(), 
                    Date = DateTime.Now.ToShortDateString(), 
                    Hour = DateTime.Now.ToShortTimeString() 
                };

                HttpContext.Session.SetInt32("UtilisateurId", utilisateur.UtilisateurId);

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Email, utilisateur.Courriel)
                };

                var userIdentity = new ClaimsIdentity(claims,"login");

                ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
                await HttpContext.SignInAsync(principal).ConfigureAwait(false);

                return RedirectToAction("Index", "Curriculums");
            }
            return View(utilisateur);
        }

        private bool UtilisateurExists(int id)
        {
            return _context.Utilisateur.Any(e => e.UtilisateurId == id);
        }
    }
}