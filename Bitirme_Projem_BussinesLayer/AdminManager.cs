using Bitirme_Projem_DataAcessLayer.EntityFramework;
using Bitirme_Projem_Entities;
using Bitirme_Projem_Entities.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bitirme_Projem_BussinesLayer
{
  
    

    public class AdminManager
    {
        private RepositoryDeseni<Kelimeler> Kelimelerim = new RepositoryDeseni<Kelimeler>();
        private RepositoryDeseni<Kelime_Dizi> Kelime_Dizim = new RepositoryDeseni<Kelime_Dizi>();
        private RepositoryDeseni<Sezon> Sezonlar = new RepositoryDeseni<Sezon>();
        private RepositoryDeseni<Bölüm> Bölümler = new RepositoryDeseni<Bölüm>();
        private RepositoryDeseni<Diziler> Dizi = new RepositoryDeseni<Diziler>();
        public int KelimeEkleme(string Kelime,string Anlami,int Tekrar)
        {
            List<Kelimeler>  KelimeListesi = Kelimelerim.Listele().Where(x => x.Kelime_Turk == Anlami && x.Kelime_İng == Kelime).ToList();
            if (KelimeListesi.Count > 0)
            {
                return 0;
            }
            else
            {
                int sayi = Kelimelerim.Ekle(new Kelimeler
                {
                    Kelime_İng = Kelime,
                    Kelime_Turk = Anlami,
                    Tekrarsayıs = Tekrar
                });

                return sayi;
            }
          

            
           
        }
        public int Kelimeid(string Kelime, string Anlami, int Tekrar)
        {
            Kelimeler model = Kelimelerim.Listele().Find(x => x.Kelime_İng == Kelime && x.Kelime_Turk == Anlami && x.Tekrarsayıs == Tekrar);
            int id = model.Kelime_Id;
            return id;
        }

        public int KelimeDiziEkle(int Kelimeid,int Bölümid)
        {
            int sayı = Kelime_Dizim.Ekle(new Kelime_Dizi
            {
                Kelime_Id = Kelimeid,
                Bölüm_Id=Bölümid
            });
            return sayı;
        }

        public int SezonEkle(string SezonAd,int Diziid)
        {
            int sayı = Sezonlar.Ekle(new Sezon
            {
                Dizi_Sezon_Ad=SezonAd,
                Dizi_Id=Diziid
            });
            return sayı;
        }
        public int BolumEkle(string BolumAdi, int Sezonid)
        {
            int sayı = Bölümler.Ekle(new Bölüm
            {
                Dizi_Bölüm_Ad=BolumAdi,
                Sezon_Id=Sezonid
            });
            return sayı;
        }
        public int DiziEkle(string DiziAdi)
        {
            int sayı = Dizi.Ekle(new Diziler
            {
                Dizi_Ad=DiziAdi
            });
            return sayı;
        }

        public List<Kelimeler> KelimeListesi()
        {
            List<Kelimeler> Kelimem = Kelimelerim.Listele();
            return Kelimem;
        }
        public Kelimeler KelimeListe(string kelime,string ing)
        {
            Kelimeler Kelimem = Kelimelerim.Listele().Find(x => x.Kelime_İng == kelime && x.Kelime_Turk == ing);
            return Kelimem;
        }
    }
}
