using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using firstMvcProject.Models.Interface;
using firstMvcProject.Models.DBModel;
using System.Data.Entity;

namespace firstMvcProject.Models.Repository
{
    public class CategoryRepository : IRepository<Kategoriler>
    {
        private NorthwindEntities db;

        public CategoryRepository(NorthwindEntities _db)
        {
            db = _db;
        }
        
        public void delete(Kategoriler model)
        {
            db.Kategoriler.Remove(model);
            db.SaveChanges();
        }

        public Kategoriler get(int Id)
        {
          return  db.Kategoriler.Find(Id);
        }

        public List<Kategoriler> getAll()
        {
           return db.Kategoriler.ToList();

        }

        public void save(Kategoriler model)
        {
            db.Kategoriler.Add(model);
            db.SaveChanges();
        }

        public void update(Kategoriler model)
        {
            db.Entry(model).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}