using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Models
{
    [Table("Kullanicilar")]
    public class Kullanici
    {
        [Key]
        public int KullaniciID { get; set; }
        [StringLength(25)]
        public string Ad { get; set; }
        [StringLength(25)]
        public string Soyad { get; set; }
        [Required, StringLength(25)]
        public string KullaniciAdi { get; set; }
        [Required, StringLength(70)]
        public string Email { get; set; }
        [Required, StringLength(25)]
        public string Sifre { get; set; }


        public bool AdminMi { get; set; }
        
        public virtual List<Yorum> Yorumlar { get; set; }
        

    }
}
