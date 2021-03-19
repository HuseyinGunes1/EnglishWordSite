using Bitirme_Projem_DataAcessLayer.EntityFramework;
using Bitirme_Projem_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bitirme_Projem_BussinesLayer
{
   public class GuncelleManager
    {
        RepositoryDeseni<Kullanıcı_Kelime> KullaniciKelime = new RepositoryDeseni<Kullanıcı_Kelime>();
        public int OgrenecegimKelimeGuncelle(int Kullaniciid,int kelimeid,int kategoriid)
        {
            Kullanıcı_Kelime tablo = KullaniciKelime.Listele().Find(x => x.Kullanicı_Id == Kullaniciid && x.Kelime_Id == kelimeid && x.Kategori_Id == kategoriid);
            tablo.Kategori_Id = 2;
           int sonuc= KullaniciKelime.Güncelle(tablo);
           return sonuc;
        }
        public int BildigimKelimeGuncelle(int Kullaniciid, int kelimeid, int kategoriid)
        {
            Kullanıcı_Kelime tablom = KullaniciKelime.Listele().Find(x => x.Kullanicı_Id == Kullaniciid && x.Kelime_Id == kelimeid && x.Kategori_Id == kategoriid);
            tablom.Kategori_Id = 3;
            int sonuc = KullaniciKelime.Güncelle(tablom);
            return sonuc;
        }
    }
}
