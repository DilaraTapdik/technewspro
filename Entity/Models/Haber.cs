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
   public class Haber
    {

        [Key]
        public int HaberID { get; set; }
        [DisplayName("Başlık")]
        [Required]
        public string Title { get; set; }
        [DisplayName("İçerik")]
        [Required]
        public string Content { get; set; }
        public string ResimURL { get; set; }
        public DateTime EklemeTarihi { get; set; }
        public int? ToplamOy { get; set; }
        public int GoruntulenmeSayisi { get; set; }
        [ForeignKey("Kategorisi")]
        public int KategoriID { get; set; }
        public virtual List<Kategori> Kategorisi { get; set; }
        public Haber()
        {
            EklemeTarihi = DateTime.Today;
        }
  
    }
}
