using Bitirme_Projem_Entities;
using Bitirme_Projem_Entities.ValueObject;
using Bitirme_Projem_DataAcessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Helpers;

namespace Bitirme_Projem_BussinesLayer
{
   public  class UserManager
    {
        private RepositoryDeseni<Uyeler> uye = new RepositoryDeseni<Uyeler>();

        public Uyeler UyeKayıt(LoginGirisView data)
        {
            //E-posta kontrolü
            BussinesLayerResult<Uyeler> repo = new BussinesLayerResult<Uyeler>();

            Uyeler kisi = uye.Listele().Find(x => x.Kullanici_EPosta == data.Kullanici_EPosta);//Kullanıcı E-mailleri eşleşiyormu Eşleşiyorsa bir kullanıcı dönecek bize
            
            if (kisi != null)//belirtilen e-mail var ise hata mesajı yolla
            {
                    throw new Exception("E-Posta adresi Zaten Var");
            }

            else
            {
                int sayı= uye.Ekle(new Uyeler
                {
                    Kullanici_Ad = data.Kullanici_Ad,
                    Kullanici_EPosta = data.Kullanici_EPosta,
                    Kullanici_Sifre = data.Kullanici_Sifre,
                    ActiveGuid = Guid.NewGuid(),
                    IsActive = false
                });

                if (sayı == 1) //Insert edilen kullanıcıları ekleme
                {
                    repo.Sonuc = uye.Listele().Find(x => x.Kullanici_EPosta == data.Kullanici_EPosta);
                }
               



                string gönderilecekkisi = data.Kullanici_EPosta;
                string Uri = "http://localhost:60580";
                string Active = $"{Uri}/Anasayfa/UserActive/{repo.Sonuc.ActiveGuid}";
                string body = $"Hesabını Aktifleştirmek için <a href='{Active}' target='_blank'>Tıklayınız</a> ";
                MailHelper.MailGönder(gönderilecekkisi,body,"Aktivasyon Kodu");//Aktivasyon kodunu gönderme
            }
            return kisi;
        }
        public BussinesLayerResult<Uyeler> UyeGiris(LoginView data)
        {
            BussinesLayerResult<Uyeler> repo = new BussinesLayerResult<Uyeler>();
            repo.Sonuc=uye.Listele().Find(x => x.Kullanici_EPosta == data.Kullanici_EPosta && x.Kullanici_Sifre == data.Kullanici_Sifre);
            
            if (repo.Sonuc != null)
            {
                if (!repo.Sonuc.IsActive)
                {
                    throw new Exception("Kullanıcı Aktifleştirilmemiştir");
                }

               
            }
            else
            {
                throw new Exception("E-Posta veya Şifre Hatalı");
            }

            return repo;
        }

        public Uyeler Active(Guid id)
        {
            Uyeler kisi = uye.Listele().Find(x => x.ActiveGuid == id);
           
            if (kisi != null)
            {
                if (kisi.IsActive)
                {
                    throw new Exception("Kullanıcı Zaten Aktif Edilmiş");
                   
                }
                    kisi.IsActive = true;
                   uye.Güncelle(kisi);
                
            }

            else
            {
                throw new Exception("Aktifleştirilecek kullanıcı bulunamadı");
            }

            return kisi;
        }

       
       
    }
}
