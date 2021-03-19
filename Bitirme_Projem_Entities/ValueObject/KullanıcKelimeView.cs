using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bitirme_Projem_Entities.ValueObject
{
    public  class KullanıcKelimeView
    {
       
        public string KelimeTurkcesi { get; set; }
       
        public string KelimeIngilizce { get; set; }

        public int Tekrarsayılarii { get; set; }

        public string DiziAdlari { get; set; }
    }
}
