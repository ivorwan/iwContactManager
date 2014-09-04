using iwContactManager.Models.Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace iwContactManager.ViewModels
{
    public class ValidatorViewModel
    {
        [Required]
        public string ValidatorType { get; set; }
        public AValidator aValidator { get; set; }
    }
}