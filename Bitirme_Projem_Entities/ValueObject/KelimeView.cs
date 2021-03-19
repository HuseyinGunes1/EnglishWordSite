using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bitirme_Projem_Entities.ValueObject
{
   public class KelimeView
    {
        public int Kelime_Id { get; set; }
       
        public string Kelime_Turk { get; set; }
       
        public string Kelime_İng { get; set; }

        public int Tekrarsayıs { get; set; }
    }
}
