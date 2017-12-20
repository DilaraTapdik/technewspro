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
   public class Yorum
    {
        [Key]
        public int YorumID { get; set; }
        public string KullaniciAd { get; set; }
        //public string ResimURL { get; set; }
        [Required]
        [DisplayName("Yorum İçeriği")]
        public string YorumIcerik { get; set; }
        public int YorumBegeni { get; set; }
        [ForeignKey("Haberi")]
        public int HaberID { get; set; }
        public virtual Haber Haberi { get; set; }
        public DateTime YorumTarihi { get; set; }
        public Yorum()
        {
            YorumTarihi = DateTime.Now;
        }

    }
}
