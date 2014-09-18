using iwContactManager.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace iwContactManager.Services.EntityFramework
{
    public class ContactService : IContactService, IDisposable
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public IList<Contact> GetContacts()
        {
            return db.Contacts.ToList();
            
        }

        public Contact GetContact(int id)
        {
            Contact contact = db.Contacts.Find(id);
            return contact;
        }

        public void DeleteContact(Contact contact)
        {
            //Contact contact = db.Contacts.Find(id);
            db.Contacts.Remove(contact);
            db.SaveChanges();
        }

        public void UpdateContact(Models.Contact contact)
        {
            db.Entry(contact).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void InsertContact(Contact contact)
        {
            db.Contacts.Add(contact);
            db.SaveChanges();
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}