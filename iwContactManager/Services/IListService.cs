using iwContactManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace iwContactManager.Services
{
    public interface IListService
    {
        IList<List> GetLists();

        List GetList(int id);

        void DeleteList(List list);
        void UpdateList(List list);
        void InsertList(List list);
    }
}