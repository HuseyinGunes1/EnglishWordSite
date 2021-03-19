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
    [Table("Admin")]
    public class Admin
    {
        public int Admin_Id { get; set; }
        [DisplayName("Kullanıcı Adınız"), Required(ErrorMessage = "Kullanıcı Adı Boş Geçilemez"), MinLength(5, ErrorMessage = "Kullanıcı Adı Minimum 5 Karekter Olmalıdır"), MaxLength(25, ErrorMessage = "Kullanıcı Adı Maximum 25 Karekter Olmalıdır")]
        public string Kullanici_Ad { get; set; }
       
        [DisplayName("Parola"), Required(ErrorMessage = "Şifre Boş Geçilemez"), MinLength(6, ErrorMessage = "E-Posta Minimum 6 Karekter Olmalıdır"), MaxLength(25, ErrorMessage = "Şifre Maximum 25 Karekter Olmalıdır"), DataType(DataType.Password)]
        public string Kullanici_Sifre { get; set; }

    }
}
