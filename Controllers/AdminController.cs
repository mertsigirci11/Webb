using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Randevu_Sistemi.Data;
using Randevu_Sistemi.Models;
using Randevu_Sistemi.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Randevu_Sistemi.Controllers
{
    public class AdminController : Controller
    {
        private readonly RandevuDbContext _context = null;

        public AdminController(RandevuDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {

            return View();
        }
        public IActionResult Edit()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Edit(Doktor model)
        {
            var doktor = new Doktor()
            {
                DoktorAd = model.DoktorAd,
                DoktorSoyad = model.DoktorSoyad,
                DoktorSifre = model.DoktorSifre,
                Aktiflik = model.Aktiflik
            };


            var result = _context.Doktorlar.SingleOrDefault(b => b.DoktorAd == model.DoktorAd && b.DoktorAd== model.DoktorAd);
            if (result != null)
            {
                result.DoktorAd = doktor.DoktorAd;
                result.DoktorSoyad = doktor.DoktorSoyad;
                result.DoktorSifre = doktor.DoktorSifre;
                result.Aktiflik = doktor.Aktiflik;
                _context.SaveChanges();
            }

            return View();
        }

        [HttpPost]
        public IActionResult Index(Doktor model)
        {
            var doktor = new Doktor()
            {
                DoktorAd = model.DoktorAd,
                DoktorSoyad = model.DoktorSoyad,
                DoktorSifre = model.DoktorSifre,
                Aktiflik = true
            };

            _context.Doktorlar.Add(doktor);
            _context.SaveChanges();

            return View();
        }
        public IActionResult GirisYap()
        {
            return View();
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> GirisYap(Admin model)
        {
            var bilgiler = _context.Adminler.FirstOrDefault(x => x.AdminAd == model.AdminAd && x.AdminSifre == model.AdminSifre);
            if (bilgiler != null)
            {
                //islemler
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, model.AdminAd)
                };
                var doktorIdentity = new ClaimsIdentity(claims, authenticationType: "Login");
                ClaimsPrincipal principal = new ClaimsPrincipal(doktorIdentity);
                await HttpContext.SignInAsync(principal);
                return RedirectToAction(controllerName: "Admin", actionName: "Index");
            }
            return View();
        }

        public IActionResult Listele()
        {
            return View(_context.Doktorlar.ToList());
        }


        public IActionResult AktifYap(int id, string ad, string soyad, string sifre, bool aktiflik)
        {
            Doktor doktor = new Doktor()
            {
                DoktorID = id,
                DoktorAd = ad,
                DoktorSifre = sifre,
                DoktorSoyad = soyad
            };

            doktor.Aktiflik = true;
            _context.Doktorlar.Update(doktor);
            _context.SaveChanges();
            return RedirectToAction(actionName: "Listele");
        }
        public IActionResult PasifYap(int id, string ad, string soyad, string sifre, bool aktiflik)
        {
            Doktor doktor = new Doktor()
            {
                DoktorID = id,
                DoktorAd = ad,
                DoktorSifre = sifre,
                DoktorSoyad = soyad
            };
            doktor.Aktiflik = false;
            _context.Doktorlar.Update(doktor);
            _context.SaveChanges();
            return RedirectToAction(actionName: "Listele");
        }
        
    }
}
