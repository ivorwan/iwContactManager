using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace iwContactManager.Models.Validators
{
    [Table("ValueValidator")]
    public class ValueValidator : AOperatorValidator
    {

        public override bool IsValid()
        {
            throw new NotImplementedException();
        }
    }
}