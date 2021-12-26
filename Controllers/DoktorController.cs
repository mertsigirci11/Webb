using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Randevu_Sistemi.Data;
using Randevu_Sistemi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Randevu_Sistemi.Controllers
{
    public class DoktorController : Controller
    {

        private readonly RandevuDbContext _context = null;

        public DoktorController(RandevuDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Randevular()
        {
            return View();
        }
        [Authorize]
        public async Task<IActionResult> DoktorLogin(Doktor model)
        {
            var bilgiler = _context.Doktorlar.FirstOrDefault(x => x.DoktorID == model.DoktorID && x.DoktorSifre == model.DoktorSifre);
            if (bilgiler != null)
            {
                //islemler
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, model.DoktorID.ToString())
                };
                var doktorIdentity = new ClaimsIdentity(claims, authenticationType: "Login");
                ClaimsPrincipal principal = new ClaimsPrincipal(doktorIdentity);
                await HttpContext.SignInAsync(principal);
                return RedirectToAction("Index","Doktor");
            }
            return View();
        }
    }
}
