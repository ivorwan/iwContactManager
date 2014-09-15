using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace iwContactManager.Models.Validators
{
    [Table("DupeListValidator")]
    public class DupeListValidator : AValidator
    {
        [Required]
        public string DupeListId { get; set; }

        public override bool IsValid()
        {
            throw new NotImplementedException();
        }
    }
}