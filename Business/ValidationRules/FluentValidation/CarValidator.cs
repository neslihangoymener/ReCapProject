using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator : AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(c => c.Description).NotEmpty().WithMessage("Boş olamaz");
            RuleFor(c => c.Description).MinimumLength(2).WithMessage("2 karakterden az olamaz");
            RuleFor(c => c.DailyPrice).NotEmpty().WithMessage("Boş olamaz");
            RuleFor(c => c.DailyPrice).GreaterThan(0).WithMessage("Günlük ücret 0'dan büyük olmalı");
            RuleFor(c => c.ModelYear).GreaterThanOrEqualTo(1900);
        }

     
    }
}
