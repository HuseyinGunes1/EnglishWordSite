  using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bitirme_Projem_Entities
{
    [Table("Kelime_Dizi")]
    public class Kelime_Dizi
    {
        [Key, Required]
        public int id { get; set; }
        public int Kelime_Id { get; set; }
        public int Bölüm_Id { get; set; }
       
        public virtual Kelimeler  Kelime { get; set; }
        public virtual Bölüm Bölüm { get; set; }
     
    }
}
