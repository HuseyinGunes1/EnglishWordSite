using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bitirme_Projem_Entities
{
    [Table("Sezon")]
    public class Sezon
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Required]
        public int Sezon_Id { get; set; }
        public string Dizi_Sezon_Ad { get; set; }
        public int Dizi_Id { get; set; }
        public virtual Diziler Diziler { get; set; }
        public virtual ICollection<Bölüm> Bölüm { get; set; }
   
    }
}
