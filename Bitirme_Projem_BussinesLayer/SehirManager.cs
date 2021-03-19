using Bitirme_Projem_Entities;
using Bitirme_Projem_Entities.ValueObject;
using Bitirme_Projem_DataAcessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bitirme_Projem_BussinesLayer
{
    public class SehirManager
    {
       private RepositoryDeseni<Diziler> Dizi = new RepositoryDeseni<Diziler>();
       private RepositoryDeseni<Sezon> Sezon = new RepositoryDeseni<Sezon>();
       private RepositoryDeseni<Bölüm> Bölüm = new RepositoryDeseni<Bölüm>();
       private RepositoryDeseni<Kelime_Dizi> Kelime_Dizi = new RepositoryDeseni<Kelime_Dizi>();
       private RepositoryDeseni<Kelimeler> Kelimeler = new RepositoryDeseni<Kelimeler>();


        public List<Diziler> DiziListesi()
        {
           
            return Dizi.Listele();
        }
        public List<Sezon> SezonListesi(int id)
        {

            List<Sezon> sezonlar = Sezon.Listele().Where(x=>x.Dizi_Id==id).ToList();
            return sezonlar;
            
        }

        public List<Bölüm> BölümListesi(int id)
        {

            List<Bölüm> Bölümler = Bölüm.Listele().Where(x => x.Sezon_Id == id).ToList();
            return Bölümler;

        }

        public List<Kelime_Dizi> DiziKelimeListesi(int id)
        {
            List<Kelime_Dizi> Kelimeler = Kelime_Dizi.Listele().Where(x => x.Bölüm_Id == id).ToList();
            return Kelimeler;
        }
        public List<Kelimeler> KelimeListem()
        {
            return Kelimeler.Listele();
        }
    }
}
