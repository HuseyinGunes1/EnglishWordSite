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
   public class Kullanıcı_Kelime_Manager
    {
        private RepositoryDeseni<Kullanıcı_Kelime> KullanıcıKelime = new RepositoryDeseni<Kullanıcı_Kelime>();
        public bool Varmi(int Kelimeid,int Kullaniciid)
        {
            bool Var = false;
           Kullanıcı_Kelime Kelimem = KullanıcıKelime.Listele().Find(x => x.Kelime_Id == Kelimeid && x.Kullanicı_Id==Kullaniciid);
            if (Kelimem == null)
            {
                return Var;
            }
            else
            {
                Var = true;
                return Var;
            }
        }

        public bool KelimeListemdeVarmı(int Kelimeid,int Kategoriid, int Kullaniciid)
        {
            bool Var = false;
            Kullanıcı_Kelime Kelimem = KullanıcıKelime.Listele().Find(x => x.Kelime_Id == Kelimeid && x.Kategori_Id==Kategoriid && x.Kullanicı_Id == Kullaniciid);
            if (Kelimem == null)
            {
                return Var;
            }
            else
            {
                Var = true;
                return Var;
            }
        }
        public bool BildigimKelimeListemdeVarmı(int Kelimeid, int Kategoriid, int Kullaniciid)
        {
            bool Var = false;
            Kullanıcı_Kelime Kelimem = KullanıcıKelime.Listele().Find(x => x.Kelime_Id == Kelimeid && x.Kategori_Id == Kategoriid && x.Kullanicı_Id == Kullaniciid);
            if (Kelimem == null)
            {
                return Var;
            }
            else
            {
                Var = true;
                return Var;
            }
        }

        public bool OgrenecegimKelimeListemdeVarmı(int Kelimeid, int Kategoriid, int Kullaniciid)
        {
            bool Var = false;
            Kullanıcı_Kelime Kelimem = KullanıcıKelime.Listele().Find(x => x.Kelime_Id == Kelimeid && x.Kategori_Id == Kategoriid && x.Kullanicı_Id == Kullaniciid);
            if (Kelimem == null)
            {
                return Var;
            }
            else
            {
                Var = true;
                return Var;
            }
        }
        public int KelimeListemeEkle(int Kullaniciid,int Kategoriid,int Kelimeid)
        {
            BussinesLayerResult<Kullanıcı_Kelime> repo = new BussinesLayerResult<Kullanıcı_Kelime>();
            Kullanıcı_Kelime K_Kelime = KullanıcıKelime.Listele().Find(x => x.Kelime_Id == Kelimeid && x.Kullanicı_Id == Kullaniciid && x.Kategori_Id==Kategoriid);

            if (K_Kelime != null)
            {
                return 0;
                
            }
            else
            {
                int deger = KullanıcıKelime.Ekle(new Kullanıcı_Kelime
                {
                    Kelime_Id = Kelimeid,
                    Kullanicı_Id=Kullaniciid,
                    Kategori_Id=Kategoriid,

                    
                });
                return 1;
                
            }
           
            
        }

        public int KelimeListesiSayisi(int Kullaniciid, int Kategoriid)
        {
            int deger = KullanıcıKelime.Listele().Where(x =>  x.Kullanicı_Id == Kullaniciid && x.Kategori_Id == Kategoriid).Count();
            return deger;
        }

        public int BildiğimKelimelereEkle(int Kullaniciid, int Kategoriid, int Kelimeid)
        {
            BussinesLayerResult<Kullanıcı_Kelime> repo = new BussinesLayerResult<Kullanıcı_Kelime>();
            Kullanıcı_Kelime K_Kelime = KullanıcıKelime.Listele().Find(x => x.Kelime_Id == Kelimeid && x.Kullanicı_Id == Kullaniciid && x.Kategori_Id == Kategoriid);
            if (K_Kelime != null)
            {
                return 0;

            }
            else
            {
                int deger = KullanıcıKelime.Ekle(new Kullanıcı_Kelime
                {
                    Kelime_Id = Kelimeid,
                    Kullanicı_Id = Kullaniciid,
                    Kategori_Id = Kategoriid,


                });
                return 1;

            }
        }
        public int BildigimKelimelerSayisi(int Kullaniciid, int Kategoriid)
        {
            int deger = KullanıcıKelime.Listele().Where(x =>  x.Kullanicı_Id == Kullaniciid && x.Kategori_Id == Kategoriid).Count();
            return deger;
        }

        public int OgrenecegimKelimelereEkle(int Kullaniciid, int Kategoriid, int Kelimeid)
        {
            BussinesLayerResult<Kullanıcı_Kelime> repo = new BussinesLayerResult<Kullanıcı_Kelime>();
            Kullanıcı_Kelime K_Kelime = KullanıcıKelime.Listele().Find(x => x.Kelime_Id == Kelimeid && x.Kullanicı_Id == Kullaniciid && x.Kategori_Id == Kategoriid);
            if (K_Kelime != null)
            {
                return 0;

            }
            else
            {
                int deger = KullanıcıKelime.Ekle(new Kullanıcı_Kelime
                {
                    Kelime_Id = Kelimeid,
                    Kullanicı_Id = Kullaniciid,
                    Kategori_Id = Kategoriid,


                });
                return 1;

            }
        }
        public int OgrenecegimKelimelerSayisi(int Kullaniciid, int Kategoriid)
        {
            int deger = KullanıcıKelime.Listele().Where(x =>  x.Kullanicı_Id == Kullaniciid && x.Kategori_Id == Kategoriid).Count();
            return deger;
        }
    }
}
