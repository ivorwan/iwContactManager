using iwContactManager.Models;
using iwContactManager.Models.Validators;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace iwContactManager.Services.EntityFramework
{
    public class ValidatorService : IValidatorService, IDisposable
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public IList<AValidator> GetValidators()
        {
            return db.Validators.ToList();
        }

        public AValidator GetValidator(int id)
        {
            return db.Validators.Find(id);
            
        }

        public void DeleteValidator(AValidator validator)
        {
            db.Validators.Remove(validator);
            db.SaveChanges();
        }

        public void UpdateValidator(AValidator validator)
        {
            db.Entry(validator).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void InsertValidator(AValidator validator)
        {
            db.Validators.Add(validator);
            db.SaveChanges();
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}