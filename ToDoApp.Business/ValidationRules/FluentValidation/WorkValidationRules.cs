using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Entities.Concrete;

namespace ToDoApp.Business.ValidationRules.FluentValidation
{
    public class WorkValidationRules : AbstractValidator<Work>
    {
        public WorkValidationRules()
        {
            RuleFor(work => work.Defination).NotNull();
            RuleFor(work => work.Defination).NotEmpty();
            RuleFor(work => work.Defination).MaximumLength(250);
        } 
    }
}
