using Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
   public class Repository
    {
        public class YorumRep : BaseRepository<Yorum> { }
        public class HaberRep : BaseRepository<Haber> { }
        public class KategoriRep : BaseRepository<Kategori> { }
    }
}
