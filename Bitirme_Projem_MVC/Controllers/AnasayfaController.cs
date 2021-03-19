      using Bitirme_Projem_Entities.ValueObject;
using Bitirme_Projem_BussinesLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using Bitirme_Projem_Entities;

namespace Bitirme_Projem_MVC.Controllers
{
    public class AnasayfaController : Controller
    {
        // GET: Anasayfa
        public ActionResult Anasayfa()
        {
            QuartzTriger.Start();
            if (TempData["Model"] != null)
            {
                var model = TempData["Model"];
                return View(model);
            }

            return View();

        }
       public ActionResult Kaydol()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Kaydol(LoginGirisView model)
        {
            if (ModelState.IsValid)
            {
                UserManager t = new UserManager();
                try
                {
                    t.UyeKayıt(model);
                }
                catch(Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);

                    return View(model);
                }
                TempData["Model"] = "E-mail Adresinize Gönderilen Aktivasyon Kodunu Doğruladıktan Sonra Sisteme Giriş Yapabilirsiniz";

                return RedirectToAction("Anasayfa");
               
            }
           
            return View(model );

        
}
        [HandleError(View = "HataSayfasi")]
        public ActionResult UserActive(Guid id)
        {
            
            if (id != null)
            {
                UserManager u = new UserManager();
                try
                {
                    u.Active(id);
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                    return RedirectToAction("UserActiveNot");
                }
                
            }
            else
            {
                return RedirectToAction("Anasayfa");
            }
            
            return View();
        }
        public ActionResult GirisYap()
        {
            if (TempData["msga"] != null)
            {
                var model = TempData["msga"];
                return View(model);
            }

            return View();
        }
        [HttpPost]
        public ActionResult GirisYap(LoginView data)
        {
            Kullanıcı_Kelime_Manager manager = new Kullanıcı_Kelime_Manager();
            if (ModelState.IsValid)
            {
                try
                {
                    UserManager u = new UserManager();
                    BussinesLayerResult<Uyeler> repo = u.UyeGiris(data);
                    Session["user_ad"] = repo.Sonuc.Kullanici_Ad.ToUpper(); 
                    Session["user_id"] = repo.Sonuc.Kullanicı_Id;
                    Session["Sayı"] = manager.KelimeListesiSayisi(repo.Sonuc.Kullanicı_Id,1);
                    Session["Bildigim"] = manager.BildigimKelimelerSayisi(repo.Sonuc.Kullanicı_Id, 2);
                    Session["Ogrenecegim"] = manager.OgrenecegimKelimelerSayisi(repo.Sonuc.Kullanicı_Id, 3);
                }
                catch(Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                   
                    return View(data);
                }
               
                ViewData["msg"] = "Kaydınız başarıyla yapıldı. Mail hesabınıza giderek üyeliğinizi aktif edebilirsiniz.";
                return RedirectToAction("FilmKelimeleri", "KullaniciEkrani"); //Yönlendirme
            }
           
           
            
            return View(data);
        
}
        public ActionResult ÇıkısYap()
        {
            Session.Clear();
            return View("Anasayfa");
        }
        public ActionResult UserActiveNot()
        {
            return View();
        }

        public ActionResult HataSayfasi()
        {
            return View();
        }


    }

  
    }

    
