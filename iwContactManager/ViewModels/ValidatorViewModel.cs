using iwContactManager.Models.Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace iwContactManager.ViewModels
{
    public class ValidatorViewModel
    {
        [Required]
        public string ValidatorType { get; set; }
        public AValidator aValidator { get; set; }

        //public SelectList ListIDSelectList { get; set; }
        //public SelectList ValidatorTypeSelectList { get; set; }

    }
}