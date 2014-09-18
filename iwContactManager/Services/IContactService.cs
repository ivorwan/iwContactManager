using iwContactManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace iwContactManager.Services
{
    public interface IContactService
    {
        IList<Contact> GetContacts();

        Contact GetContact(int contactID);

        void DeleteContact(Contact contact);
        void UpdateContact(Contact contact);
        void InsertContact(Contact contact);

    }
}