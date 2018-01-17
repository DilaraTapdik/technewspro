using Entity.Models;
using Entity.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BLL.Repository;

namespace BLL
{
    public class KullaniciYonetimi
    {
        private KullaniciRep kRep = new KullaniciRep();
        public Kullanici KullaniciYonetim(KayıtView data)
        {
            Kullanici kul = kRep.Find(x => x.KullaniciAdi == data.KullaniciAdi || x.Email == data.Email);
            if (kul != null)
            {
                throw new Exception("Kayıtlı Kullanici adı veya eposta adresi");
            }
            else
            {
                kRep.Insert(new Kullanici()
                {
                    KullaniciAdi = data.KullaniciAdi,
                    Email = data.Email,
                    Sifre = data.Sifre,
                    Ad = data.Ad,
                    Soyad = data.Soyad,
                    AdminMi = false
                });
            }
            return kul;
        }
        public Kullanici KullaniciGiris(GirisView data)
        {
            Kullanici kul = kRep.Find(x => x.KullaniciAdi == data.KullaniciAdi || x.Sifre == data.Sifre);
            if (kul != null)
            {
                return kul;
            }
            else
            {
                throw new Exception("Kullanici adı veya şifre uyuşmuyor.");
            }

        }
    }
}
