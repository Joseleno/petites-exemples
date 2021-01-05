using GestionCV.Models;
using GestionCV.Oultils;
using GestionCV.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

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

                EnregistrerInformationLogin(utilisateur.UtilisateurId);

                await _context.SaveChangesAsync();

                HttpContext.Session.SetInt32("UtilisateurId", utilisateur.UtilisateurId);

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Email, utilisateur.Courriel)
                };

                var userIdentity = new ClaimsIdentity(claims, "login");

                ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
                await HttpContext.SignInAsync(principal).ConfigureAwait(false);

                return RedirectToAction("Index", "Curriculums");
            }
            return View(utilisateur);
        }

        [HttpGet]
        public IActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                HttpContext.Session.Clear();
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel login)
        {
            if (ModelState.IsValid && _context.Utilisateur.Any(u => u.Courriel.Equals(login.Courriel) && u.MotDePasse.Equals(_md.GererHash(login.MotDePasse))))
            {
                int utilisateurId = _context.Utilisateur.Where(u => u.Courriel.Equals(login.Courriel) && u.MotDePasse.Equals(_md.GererHash(login.MotDePasse))).Select(u => u.UtilisateurId).Single();

                EnregistrerInformationLogin(utilisateurId);

                await _context.SaveChangesAsync();

                HttpContext.Session.SetInt32("UtilisateurId", utilisateurId);

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Email, login.Courriel)
                };

                var userIdentity = new ClaimsIdentity(claims, "login");

                ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
                await HttpContext.SignInAsync(principal).ConfigureAwait(false);

                return RedirectToAction("Index", "Curriculums");
            }

            return View(login);

        }

        public void EnregistrerInformationLogin(int id)
        {
            InformationLogin informationLogin = new InformationLogin
            {
                UtilisateurId = id,
                AdresseIp = Request.HttpContext.Connection.RemoteIpAddress.ToString(),
                Date = DateTime.Now.ToShortDateString(),
                Hour = DateTime.Now.ToShortTimeString()
            };

            _context.Add(informationLogin);

        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            HttpContext.Session.Clear();
            return RedirectToAction("Login", "Utilisateurs");
        }

        public JsonResult UtilisateurExist(string courriel) 
        {
            if (!_context.Utilisateur.Any(c => c.Courriel.Equals(courriel)))
            {
                return Json(true);
            }
            return Json("Courriel déjà inscrit");
                
        }

    }
}