using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bitirme_Projem_BussinesLayer
{
   public class BussinesLayerResult<T> where T:class
    {
        public List<string> Hatalar { get; set; }
        public T Sonuc { get; set; }
    }
}
