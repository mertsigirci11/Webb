using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Randevu_Sistemi.Data;
using Randevu_Sistemi.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Randevu_Sistemi.Controllers
{
    public class HastaController : Controller
    {
        public static string hastaTC;
        private readonly RandevuDbContext _context = null;

        public HastaController(RandevuDbContext context)
        {
            _context = context;
        }
        [Authorize]
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult GirisYap()
        {
            return View();
        }


        [HttpPost]
        public IActionResult GirisYap(Hasta model)
        {
            var bilgiler = _context.Hastalar.FirstOrDefault(x => x.HastaTCNo == model.HastaTCNo && x.HastaSifre == model.HastaSifre);
            hastaTC = model.HastaTCNo;
            if (bilgiler != null)
            {
                

                return RedirectToAction(controllerName: "Hasta", actionName: "RandevuAl");
            }
            return View();
        }


        public IActionResult KayitOl()
        {
            return View();
        }

        [HttpPost]
        public IActionResult KayitOl(Hasta model)
        {
            if (ModelState.IsValid)
            {
                var hasta = new Hasta()
                {
                    HastaTCNo = model.HastaTCNo,
                    HastaAd = model.HastaAd,
                    HastaSoyad = model.HastaSoyad,
                    HastaSifre = model.HastaSifre
                };
                if (_context.Hastalar.Where(x => x.HastaTCNo == model.HastaTCNo).Count() == 0)
                {
                    _context.Hastalar.Add(hasta);
                    _context.SaveChanges();
                    return RedirectToAction("KayitOl");
                }
                else
                {
                    return RedirectToAction("Hata");
                }

            }
            else
            {
                return RedirectToAction("KayitOl");
            }

        }

        public IActionResult Hata()
        {
            return View();
        }

        public IActionResult RandevuAl()
        {
            IEnumerable<Doktor> doktorlar = _context.Doktorlar.ToArray();
            ArrayList array = new ArrayList();

            ViewBag.Doktorlar = doktorlar;

            return View();
        }
        [HttpPost]
        public IActionResult RandevuAl(int doktorid,DateTime tarih,int saat)
        {
            Randevu randevu = new Randevu() { 
             HastaTCNo="1",
            DoktorID = doktorid,
            Tarih = tarih,
            RandevuSaati = saat.ToString()
            };
            _context.Randevular.Add(randevu);
            _context.SaveChanges();

            return RedirectToAction(controllerName:"Hasta",actionName:"RandevuListele");
        }

        public IActionResult RandevuListele(Randevu randevu)
        {
            IEnumerable<Randevu> randevular= _context.Randevular.Where(x=> x.HastaTCNo == hastaTC).ToArray();
            ViewBag.Randevu = randevular;

            return View();
        }


    }
}
