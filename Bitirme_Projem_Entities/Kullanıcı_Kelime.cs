using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bitirme_Projem_Entities
{
    public class Kullanıcı_Kelime
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Required]
        public int id { get; set; }
       public int Kullanicı_Id { get; set; }
       public int Kelime_Id { get; set; }
       public int Kategori_Id { get; set; }
        public virtual Uyeler Uyeler { get; set; }
        public virtual Kelimeler Kelimeler { get; set; }
        public virtual Kategoriler Kategoriler { get; set; }
    }
}
