using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Validation.FluentValidation
{
    public class MessageValidator: AbstractValidator<Message>
    {
        public MessageValidator()
        {
            RuleFor(p => p.MessageInfo).MinimumLength(40).WithMessage("minimum uzunlug 40 olmalidir").NotNull().WithMessage("bosh gondrile bilmez");
           
        }
    }
}
