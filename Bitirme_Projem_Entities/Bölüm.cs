using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bitirme_Projem_Entities
{
   public class Bölüm
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Required]
        public int Bölüm_Id { get; set; }
        public string Dizi_Bölüm_Ad { get; set; }
        public int Sezon_Id { get; set; }
        public virtual Sezon Sezon  { get; set; }
      
        public ICollection<Kelime_Dizi> Kelime_Dizi { get; set; }


    }
}
