namespace DAL.Migrations
{
    using Entity.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DAL.MyContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(DAL.MyContext context)
        {
            //        //veritabanında roller yoksa ilk kurulumu yap
            //        #region rolleriOlustur
            //        if (context.Roles.Count() == 0)
            //        {
            //            context.Roles.Add(new IdentityRole() { Name = "Admin" });
            //            context.Roles.Add(new IdentityRole() { Name = "HaberModerator" });

            //            context.SaveChanges();
            //        }
            //        #endregion

            //        if (context.Users.Count() == 0)
            //        {
            //            #region kullaniciEkle
            //            UserStore<Kullanici> str = new UserStore<Kullanici>(new MyContext());
            //            UserManager<Kullanici> mng = new UserManager<Kullanici>(str);

            //            var admin = new Kullanici() { Email = "admin@tech.com", UserName = "admin@tech.com", AdSoyad = "Yonetici", Meslek = "Yonetici" };
            //            var habermoderator = new Kullanici() { Email = "habermoderator@tech.com", AdSoyad = "Haber Moderator", UserName = "habermoderator@tech.com" };



            //            mng.Create(admin, "Aa123456!"); //2. parametre sifresi
            //            mng.Create(habermoderator, "Aa123456!");
            //            context.SaveChanges();

            //            #endregion

            //            #region kullanicilariRollereEkle
            //            mng.AddToRole(admin.Id, "Admin");
            //            mng.AddToRole(habermoderator.Id, "HaberModerator");
            //            context.SaveChanges();
            //            #endregion

            //        }

        }
    }
}
