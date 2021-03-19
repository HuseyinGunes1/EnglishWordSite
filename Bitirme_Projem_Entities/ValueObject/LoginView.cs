using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Bitirme_Projem_Entities.ValueObject
{
   public class LoginView
    {
        [DisplayName("E-Posta"), Required(ErrorMessage = "E-Posta Boş Geçilemez"), MaxLength(60, ErrorMessage = "E-Posta Maximum 60 Karekter Olmalıdır"), DataType(DataType.EmailAddress)]
        public string Kullanici_EPosta { get; set; }
        [DisplayName("Parola"), Required(ErrorMessage = "Şifre Boş Geçilemez"), MinLength(6, ErrorMessage = "E-Posta Minimum 6 Karekter Olmalıdır"), MaxLength(25, ErrorMessage = "Şifre Maximum 25 Karekter Olmalıdır"), DataType(DataType.Password)]
        public string Kullanici_Sifre { get; set; }
    }
}
