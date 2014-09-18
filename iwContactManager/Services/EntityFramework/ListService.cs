using iwContactManager.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace iwContactManager.Services.EntityFramework
{
    public class ListService : IListService, IDisposable
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public IList<List> GetLists()
        {
            return db.Lists.ToList();
        }

        public List GetList(int id)
        {
            List list = db.Lists.Find(id);
            return list;
        }

        public void DeleteList(List list)
        {
            db.Lists.Remove(list);
            db.SaveChanges();
        }

        public void UpdateList(List list)
        {
            db.Entry(list).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void InsertList(List list)
        {
            db.Lists.Add(list);
            db.SaveChanges();
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}