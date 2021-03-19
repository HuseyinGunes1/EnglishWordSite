using Bitirme_Projem_DataAcessLayer.EntityFramework;
using Bitirme_Projem_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bitirme_Projem_BussinesLayer
{
   public class KullaniciListeManager
    {
        RepositoryDeseni<Kelimeler> Kelimeler = new RepositoryDeseni<Kelimeler>();
        RepositoryDeseni<Kullanıcı_Kelime> KullaniciKelime = new RepositoryDeseni<Kullanıcı_Kelime>();

        public List<Kelimeler> KelimeListesi()
        {
            return Kelimeler.Listele();
        }

        public List<Kullanıcı_Kelime> KullaniciKelimeListesi()
        {
            return KullaniciKelime.Listele();
        }
    }
}
