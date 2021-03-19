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
    [Table("Kelimelerim")]
    public class Kelimelerim
    {
        [Key, Required(), DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Kelime_Id { get; set; }
        [DisplayName("Türkçe "), Required()]
        public string Kelime_Turk { get; set; }
        [DisplayName("İngilizce"), Required()]
        public string Kelime_İng { get; set; }
        public ICollection<Kullanıcı_Kelime> Kullanıcı_Kelime { get; set; }
    }
}
