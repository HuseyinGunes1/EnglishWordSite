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
   
        [Table("Diziler")]
        public class Diziler
        {
            [Key, Required(), DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int Dizi_Id { get; set; }
            [DisplayName("Dizi Adı"), Required()]
            public string Dizi_Ad { get; set; }
      
        public virtual ICollection<Sezon> Sezon { get; set; }
    }
    
}
