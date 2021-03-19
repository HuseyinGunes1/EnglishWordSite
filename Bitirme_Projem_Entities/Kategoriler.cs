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
    [Table("Kategoriler")]      
    public class Kategoriler    
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Required]   
        public int Kategori_Id { get; set; }  
        [DisplayName("Kategori Adı"), Required]
        public string Kategori_Ad { get; set; }

        public ICollection<Kullanıcı_Kelime> Kullanıcı_Kelime { get; set; }
    }

}
