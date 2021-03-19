using Bitirme_Projem_BussinesLayer;
using Bitirme_Projem_Entities;
using Bitirme_Projem_Entities.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bitirme_Projem_MVC.Controllers
{
    public class AdminController : Controller
    {
        SehirManager sehir = new SehirManager();
        public ActionResult AdminSayfasi()
        {
            return View();
        }

        public ActionResult KelimeEkle()
        {
            DiziBölümView model = new DiziBölümView();

            Kullanıcı_Kelime_Manager Manager = new Kullanıcı_Kelime_Manager();


            List<Diziler> DiziListesi = sehir.DiziListesi();
            model.My_Diziler = (from x in DiziListesi
                                select new SelectListItem
                                {
                                    Text = x.Dizi_Ad,
                                    Value = x.Dizi_Id.ToString()

                                }).ToList();
            model.My_Diziler.Insert(0, new SelectListItem { Text = "Film Seçiniz", Value = " " });
            model.My_Sezon.Insert(0, new SelectListItem { Text = "Sezon Seçiniz", Value = " " });
            return View(model);
        }
        [HttpPost]
        public JsonResult DiziKelimeEkle(string Kelime,string Anlami,int TekrarSayisi,int Bolumid)
        {
            AdminManager Manager = new AdminManager();
            int deger = Manager.KelimeEkleme(Kelime, Anlami, TekrarSayisi);

          int id=  Manager.Kelimeid(Kelime, Anlami, TekrarSayisi);
            Manager.KelimeDiziEkle(id, Bolumid);
                return Json(deger, JsonRequestBehavior.AllowGet);
            
        }
        public ActionResult SezonEkle(/*int Diziid,string SezonAd*/)
        {
            DiziBölümView model = new DiziBölümView();

            Kullanıcı_Kelime_Manager Manager = new Kullanıcı_Kelime_Manager();


            List<Diziler> DiziListesi = sehir.DiziListesi();
            model.My_Diziler = (from x in DiziListesi
                                select new SelectListItem
                                {
                                    Text = x.Dizi_Ad,
                                    Value = x.Dizi_Id.ToString()

                                }).ToList();
            model.My_Diziler.Insert(0, new SelectListItem { Text = "Film Seçiniz", Value = " " });
            model.My_Sezon.Insert(0, new SelectListItem { Text = "Sezon Seçiniz", Value = " " });
            return View(model);
        }

        public JsonResult DiziSezonEkle(string Sezon,int Diziid)
        {
            AdminManager Manager = new AdminManager();
           int deger= Manager.SezonEkle(Sezon,Diziid);
            return Json(deger, JsonRequestBehavior.AllowGet);


        }

        public ActionResult BölümEkle(/*int Diziid,string SezonAd*/)
        {
            DiziBölümView model = new DiziBölümView();

            Kullanıcı_Kelime_Manager Manager = new Kullanıcı_Kelime_Manager();


            List<Diziler> DiziListesi = sehir.DiziListesi();
            model.My_Diziler = (from x in DiziListesi
                                select new SelectListItem
                                {
                                    Text = x.Dizi_Ad,
                                    Value = x.Dizi_Id.ToString()

                                }).ToList();
            model.My_Diziler.Insert(0, new SelectListItem { Text = "Film Seçiniz", Value = " " });
            model.My_Sezon.Insert(0, new SelectListItem { Text = "Sezon Seçiniz", Value = " " });
            return View(model);
        }
        public JsonResult DiziBolumEkle(string BolumAdi, int Sezonid)
        {
            AdminManager Manager = new AdminManager();
            int deger = Manager.BolumEkle(BolumAdi, Sezonid);
            return Json(deger, JsonRequestBehavior.AllowGet);


        }

        public ActionResult DiziEkle()
        {
            return View();
        }
        public JsonResult DiziEkleme(string DiziAdi)
        {
            AdminManager Manager = new AdminManager();
            int deger = Manager.DiziEkle(DiziAdi);
            return Json(deger, JsonRequestBehavior.AllowGet);


        }











        public ActionResult KelimeListesi()
        {
            AdminManager Manager = new AdminManager();

            List<Kelimeler> liste = Manager.KelimeListesi();
            return View(liste);
        }
    }
}