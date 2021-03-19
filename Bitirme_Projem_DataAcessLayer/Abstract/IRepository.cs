using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bitirme_Projem_DataAcessLayer.Abstract
{
    public interface IRepository<Tablo>
    {
         List<Tablo> Listele();
         int Kaydet();
         int Ekle(Tablo nesne);
         int Güncelle(Tablo nesne);
         int Sil(Tablo nesne);
        
    }
}
