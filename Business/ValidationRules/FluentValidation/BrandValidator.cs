using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class BrandValidator : AbstractValidator<Brand>
    {
        public BrandValidator()
        {
            RuleFor(b => b.BrandName).NotEmpty().WithMessage("Boş olamaz");
            RuleFor(b => b.BrandName).MinimumLength(2).WithMessage("2 karakterden az olamaz");
        }
    }
}
