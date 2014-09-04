using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace iwContactManager.Models.Validators
{
    public enum OperatorType { Equals, LessThan, LessOrEqualThan, GreaterThan, GreatherOrEqualThan, In }

    public abstract class AOperatorValidator : AValidator
    {
        [Required]
        public OperatorType Operator { get; set; }

        [Required]
        public string ValueToCompareTo { get; set; }


    }
}