using DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
   public class BaseRepository<T> where T : class
    {
        public BaseRepository()
        {
            if (MyContext.db == null) MyContext.db = new MyContext();
        }

        public List<T> GetAll()
        {
            List<T> liste = MyContext.db.Set<T>().ToList();
            return liste;
        }
        public List<T> Search(string value)
        {
            List<T> liste = MyContext.db.Set<T>().ToList();
            return liste;
        }
        public void DetachList(List<T> liste)
        {
            liste.ForEach(group => MyContext.db.Entry(group).State = System.Data.Entity.EntityState.Detached);
        }
        public T GetById(int id)
        {
            return MyContext.db.Set<T>().Find(id);
        }
        public void Insert(T obj)
        {
            MyContext.db.Set<T>().Add(obj);
            MyContext.db.SaveChanges();
        }
        public void Delete(int id)
        {
            var obj = MyContext.db.Set<T>().Find(id);
            MyContext.db.Entry(obj).State = System.Data.Entity.EntityState.Deleted;
            MyContext.db.SaveChanges();
        }
        public void Update(T obj)
        {
            MyContext.db.Entry(obj).State = System.Data.Entity.EntityState.Modified;
            MyContext.db.SaveChanges();
        }
        public T Find(Expression<Func<T, bool>> where)
        {
            return MyContext.db.Set<T>().FirstOrDefault(where);
        }
    }
}
