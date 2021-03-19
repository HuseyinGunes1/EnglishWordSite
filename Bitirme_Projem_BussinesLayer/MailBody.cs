using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bitirme_Projem_Entities;
using Bitirme_Projem_DataAcessLayer.EntityFramework;
using Bitirme_Projem_Entities.ValueObject;

namespace Bitirme_Projem_BussinesLayer
{
    public class MailBody
    {
        RepositoryDeseni<Kelimeler> Kelime = new RepositoryDeseni<Kelimeler>();
        RepositoryDeseni<Kullanıcı_Kelime> KullaniciKelime = new RepositoryDeseni<Kullanıcı_Kelime>();

        public string Body(int kullaniciid,int kategoriid)
        {
            List<Kelimeler> KelimeListesi = Kelime.Listele().ToList();
            List<Kullanıcı_Kelime> KullaniciKelimeListesi = KullaniciKelime.Listele().ToList();
            List<KullanıcKelimeView> deger = new List<KullanıcKelimeView>();
           var Deger = (from x in KelimeListesi
                         join k in KullaniciKelimeListesi on x.Kelime_Id equals k.Kelime_Id
                         where k.Kullanicı_Id == kullaniciid && k.Kategori_Id == kategoriid
                         select new
                         {
                             Kelimedwefsgd = x.Kelime_İng,
                             Anlami = x.Kelime_Turk,
                             Tekrarsayisi = x.Tekrarsayıs
                         }
                       ).ToList();


           

            string Kelimem = "";
                foreach(var x in Deger)
            {
               Kelimem=Kelimem+ @"<html>
                      <body>
                   <p>"+x.Kelimedwefsgd+""+"="+x.Anlami+" </p>"+
                   "</body> "+
                   " </html>";





            }

            
            return Kelimem;




        }
    }
}
