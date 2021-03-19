using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Bitirme_Projem_Entities.ValueObject
{
    public class LoginGirisView
    {
        [DisplayName("Kullanıcı Adınız"), Required(ErrorMessage = "Kullanıcı Adı Boş Geçilemez"), MinLength(5, ErrorMessage = "Kullanıcı Adı Minimum 5 Karekter Olmalıdır"), MaxLength(25, ErrorMessage = "Kullanıcı Adı Maximum 25 Karekter Olmalıdır")]
        public string Kullanici_Ad { get; set; }
        [DisplayName("E-Posta"), Required(ErrorMessage = "E-Posta Boş Geçilemez"), MaxLength(60, ErrorMessage = "E-Posta Maximum 60 Karekter Olmalıdır"), DataType(DataType.EmailAddress)]
        public string Kullanici_EPosta { get; set; }
        [DisplayName("Parola"), Required(ErrorMessage = "Şifre Boş Geçilemez"), MinLength(6, ErrorMessage = "E-Posta Minimum 6 Karekter Olmalıdır"), MaxLength(25, ErrorMessage = "Şifre Maximum 25 Karekter Olmalıdır"), DataType(DataType.Password)]
        public string Kullanici_Sifre { get; set; }
    }
}