using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Models
{
    public class Kategori
    {
        [Key]
        public int KategoriID { get; set; }
        [Required]
        public string KategoriAdi { get; set; }

    }
}
