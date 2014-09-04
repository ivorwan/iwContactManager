using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace iwContactManager.Models.Validators
{
    public abstract class AValidator
    {
        public int ID { get; set; }
        
        [Required]
        public int ListID { get; set;  }

        [Required]
        public string Description { get; set; }

        [Required]
        public string ValueToValidate { get; set; }

        public virtual List List { get; set; }

        public abstract bool IsValid();
    }
}