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
    public class KullaniciEkraniController : Controller
    {
        SehirManager sehir = new SehirManager();
        // GET: KullaniciEkrani
        [Auth]
        public ActionResult AnaSayfa()
        {
            return View();
        }
        [Auth]
        public ActionResult FilmKelimeleri()
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
        public JsonResult SezonListe(int id)
        {
            DiziBölümView model = new DiziBölümView();

            List<Sezon> sezonlar = sehir.SezonListesi(id);
           List<SelectListItem> itemlist  = (from x in sezonlar  
                              select new SelectListItem
                              {
                                  Text = x.Dizi_Sezon_Ad,
                                  Value = x.Sezon_Id.ToString()
                              }).ToList();
            model.My_Bölüm.Insert(0, new SelectListItem { Text = "Bölüm Seçiniz", Value = " " });
            return Json(itemlist, JsonRequestBehavior.AllowGet);
            
        }
       
        [HttpPost]
        public JsonResult BölümListe(int id)
        {

            List<Bölüm> Bölümler = sehir.BölümListesi(id);
            List<SelectListItem> itemlist = (from x in Bölümler
                                             select new SelectListItem
                                             {
                                                 Text = x.Dizi_Bölüm_Ad,
                                                 Value = x.Bölüm_Id.ToString()
                                             }).ToList();
            return Json(itemlist, JsonRequestBehavior.AllowGet);

        }
       
        [HttpGet]
        public JsonResult KelimeListesi(int id)
        {
            List<Kelime_Dizi> kelime_Dizi = sehir.DiziKelimeListesi(id);
            List<Kelimeler> Kelime = sehir.KelimeListem();
           var Kelimelistesi = (from x in kelime_Dizi
                                              join k in Kelime on x.Kelime_Id equals k.Kelime_Id
                                              where x.Bölüm_Id == id
                                              select new
                                              {
                                                  KelimeId = k.Kelime_Id,
                                                  KelimeTurk = k.Kelime_Turk,
                                                  KelimeIng = k.Kelime_İng,
                                                  Kelimesayısı = k.Tekrarsayıs

                                              }).ToList();
            return Json(Kelimelistesi, JsonRequestBehavior.AllowGet);
        }
       
        [HttpPost]
        public JsonResult KelimeListesineEkle(int Kullaniciid, int Kategoriid  , int Kelimeid )
        {
            Kullanıcı_Kelime_Manager Manager = new Kullanıcı_Kelime_Manager();
            if (Manager.Varmi(Kelimeid,Kullaniciid) == false)
            {
                int durum = Manager.KelimeListemeEkle(Kullaniciid, Kategoriid, Kelimeid);


                if (durum == 1)
                {
                    return Json("1");
                }

                else
                {
                    return Json("3");
                }
            }
            else if (Manager.KelimeListemdeVarmı(Kelimeid, Kategoriid,Kullaniciid))
            {
                return Json("0");
            }
            else
            {
                return Json("2");
            }
            
            
        }
       
        public JsonResult KelimeSayisi(int Kullaniciid, int Kategoriid)
        {
            Kullanıcı_Kelime_Manager Manager = new Kullanıcı_Kelime_Manager();
            int deger = Manager.KelimeListesiSayisi(Kullaniciid, Kategoriid);
            Session["Sayı"] = deger;
            int sayi = deger;
            return Json(deger);
        }

        
        public JsonResult BildigimKelimeListesineEkle(int Kullaniciid, int Kategoriid, int Kelimeid)
        {
            Kullanıcı_Kelime_Manager Manager = new Kullanıcı_Kelime_Manager();
            if (Manager.Varmi(Kelimeid,Kullaniciid) == false)
            {
                int durum = Manager.BildiğimKelimelereEkle(Kullaniciid, Kategoriid, Kelimeid);


                if (durum == 1)
                {
                    return Json("1");
                }

                else
                {
                    return Json("3");
                }
            }
            else if (Manager.BildigimKelimeListemdeVarmı(Kelimeid, Kategoriid,Kullaniciid))
            {
                return Json("0");
            }
            else
            {
                return Json("2");
            }
            

        }
       
        public JsonResult BildigimKelimeSayisi(int Kullaniciid, int Kategoriid)
        {
            Kullanıcı_Kelime_Manager Manager = new Kullanıcı_Kelime_Manager();
            int deger = Manager.BildigimKelimelerSayisi(Kullaniciid, Kategoriid);
            Session["Bildigim"] = deger;
            int sayi = deger;
            return Json(deger);
        }

      
        public JsonResult OgrenecegimKelimeListesineEkle(int Kullaniciid, int Kategoriid, int Kelimeid)
        {
            Kullanıcı_Kelime_Manager Manager = new Kullanıcı_Kelime_Manager();
            
            if (Manager.Varmi(Kelimeid,Kullaniciid) == false)
            {
                int durum = Manager.OgrenecegimKelimelereEkle(Kullaniciid, Kategoriid, Kelimeid);


                if (durum == 1)
                {
                    return Json("1");
                }

                else
                {
                    return Json("3");
                }
            }

            else if (Manager.OgrenecegimKelimeListemdeVarmı(Kelimeid, Kategoriid,Kullaniciid))
            {
                return Json("0");
            }
            else
            {
                return Json("2");
            }
           

        }
       
        public JsonResult OgrenecegimKelimeSayisi(int Kullaniciid, int Kategoriid)
        {
            Kullanıcı_Kelime_Manager Manager = new Kullanıcı_Kelime_Manager();
            int deger = Manager.OgrenecegimKelimelerSayisi(Kullaniciid,Kategoriid);
            Session["Ogrenecegim"] = deger;
            int sayi = deger;
            return Json(deger);
        }
    }
}