using Entity.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
   public class MyContext : IdentityDbContext<IdentityUser>
    {
        public static MyContext db;
        public MyContext() : base("DefaultConnection")
        {

        }
        public virtual DbSet<Yorum> Yorumlar { get; set; }
        public virtual DbSet<Haber> Haberler { get; set; }
        public virtual DbSet<Kategori> Kategoriler { get; set; }
        public virtual DbSet<Kullanici> Kullanicilar { get; set; }

    }
}
