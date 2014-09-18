using iwContactManager.Models.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace iwContactManager.Services
{
    public interface IValidatorService
    {
        IList<AValidator> GetValidators();

        AValidator GetValidator(int id);


        void DeleteValidator(AValidator validator);
        void UpdateValidator(AValidator validator);
        void InsertValidator(AValidator validator);
    }
}