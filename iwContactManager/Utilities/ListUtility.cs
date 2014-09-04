using iwContactManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace iwContactManager.Utilities
{
    public static class ListUtility
    {
        private static ApplicationDbContext db = new ApplicationDbContext();


        public static SelectList GetListIDSelectList(object selectedListID = null)
        {
            return new SelectList(db.Lists, "ID", "ListName");
        }

        public static SelectList GetValidatorTypesSelectList(object selectedValidatorType = null)
        {
            List<SelectListItem> types = new List<SelectListItem>();
            types.Add(new SelectListItem() { Text = "Select One", Value = "" });
            types.Add(new SelectListItem() { Text = "AgeValidator", Value = "AgeValidator" });
            types.Add(new SelectListItem() { Text = "DupeListValidator", Value = "DupeListValidator" });
            types.Add(new SelectListItem() { Text = "FilterValidator", Value = "FilterValidator" });

            SelectList list = new SelectList(types, "Text", "value");

            return list;
        }
    }
}