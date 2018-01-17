using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.ViewModels
{
    public class KayıtView
    {
        [Required(ErrorMessage = "Kullanici adi boş geçilemez.")]
        public string Ad { get; set; }
        [Required(ErrorMessage = "Kullanici adi boş geçilemez.")]
        public string Soyad { get; set; }
        [Required(ErrorMessage = "Kullanici adi boş geçilemez.")]
        public string KullaniciAdi { get; set; }

        [Required(ErrorMessage = "Email boş geçilemez"), DataType(DataType.EmailAddress)]

        public string Email { get; set; }
        [Required(ErrorMessage = "Şifre boş geçilemez."), DataType(DataType.Password)]
        public string Sifre { get; set; }

    }

}
