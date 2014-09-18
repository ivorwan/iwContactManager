using iwContactManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace iwContactManager.Services
{
    public class ContactService : IContactService
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public IList<Contact> GetContacts()
        {
            return db.Contacts.ToList();
            
        }

        public Contact GetContact(int contactID)
        {
            throw new NotImplementedException();
        }

        public void DeleteContact(Contact contact)
        {
            throw new NotImplementedException();
        }

        public void UpdateContact(Models.Contact contact)
        {
            throw new NotImplementedException();
        }

        public void InsertContact(Contact contact)
        {
            throw new NotImplementedException();
        }
    }
}