using iwContactManager.Models.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace iwContactManager.ViewModels
{
    public class ListViewModel
    {
        public int ID { get; set; }
        public string ListName { get; set; }
        public string ListDescription { get; set; }

//        public virtual ICollection<AValidator> Validators { get; set; }
    }
}