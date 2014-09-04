using iwContactManager.Models.Validators;
//using iwContactManager.Models.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace iwContactManager.Models
{
    public class List
    {
        public int ID { get; set; }
        public string ListName { get; set; }
        public string ListDescription { get; set;  }

        public virtual ICollection<AValidator> Validators { get; set; }
    }
}