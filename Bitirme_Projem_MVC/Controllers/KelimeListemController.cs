using Bitirme_Projem_BussinesLayer;
using Bitirme_Projem_Entities;
using Bitirme_Projem_Entities.ValueObject;
using Bitirme_Projem_MVC.Filter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bitirme_Projem_MVC.Controllers
{
    public class KelimeListemController : Controller
    {
        // GET: KelimeListem 
        KullaniciListeManager liste = new KullaniciListeManager();
        Kullanıcı_Kelime_Manager manager = new Kullanıcı_Kelime_Manager();
        GuncelleManager guncelle = new GuncelleManager();
        AdminManager admin = new AdminManager();
        [Auth]
        public ActionResult KelimeListesi()
        {
            return View();
        }
       
        [HttpPost]
        public JsonResult Kelimelistesi(int id, int Kategoriid)
        {
            List<Kelimeler> Kelime = liste.KelimeListesi();
            List<Kullanıcı_Kelime> KullaniciKelime = liste.KullaniciKelimeListesi();
            var Kelimeler = (from x in Kelime
                             join k in KullaniciKelime on x.Kelime_Id equals k.Kelime_Id
                             where k.Kullanicı_Id == id && k.Kategori_Id == Kategoriid
                             select new
                             {
                                 Kelimeid = x.Kelime_Id,
                                 Kelime = x.Kelime_İng,
                                 Anlami = x.Kelime_Turk,
                                 Tekrarsayisi = x.Tekrarsayıs
                             }

                           ).ToList();

            return Json(Kelimeler, JsonRequestBehavior.AllowGet);
        }
      
        [HttpPost]
        public JsonResult OgrenecegimGuncelle(int Kullaniciid, int Kategoriid, int Kelimeid)
        {
          int sonuc=  guncelle.OgrenecegimKelimeGuncelle(Kullaniciid, Kelimeid, Kategoriid);
            if (sonuc > 0)
            {
                return Json(new { result = true },JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { result = false }, JsonRequestBehavior.AllowGet);
            }

        }
      
        [HttpPost]
        public JsonResult BildigimGuncelle(int Kullaniciid, int Kategoriid, int Kelimeid)
        {
            int sonuc = guncelle.BildigimKelimeGuncelle(Kullaniciid, Kelimeid, Kategoriid);
            if (sonuc > 0)
            {
                return Json(new { result = true }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { result = false }, JsonRequestBehavior.AllowGet);
            }

        }

        [Auth]
        public ActionResult ÖğrenceğimKelime()
        {
            return View();
        }
        [Auth]
        public ActionResult BildiğimKelime()
        {
            return View();
        }
        [HttpGet]
        public ActionResult KelimeEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult KelimeEkle(Kelimeler model)
        {
         
            var id = Session["user_id"];
            admin.KelimeEkleme(model.Kelime_İng, model.Kelime_Turk, model.Tekrarsayıs);

            Kelimeler Kelimem = admin.KelimeListe(model.Kelime_İng, model.Kelime_Turk);
               
            
            int deger=manager.KelimeListemeEkle(Convert.ToInt32(id), 1,Kelimem.Kelime_Id );
            
            return View(model);
        }
    }
}