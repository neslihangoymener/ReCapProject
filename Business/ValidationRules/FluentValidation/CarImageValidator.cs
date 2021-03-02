using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    class CarImageValidator : AbstractValidator<CarImage>
    {
        public CarImageValidator()
        {
            RuleFor(c => c.CarId).NotEmpty().WithMessage("Boş olamaz");
            RuleFor(c => c.ImagePath).NotEmpty().WithMessage("Boş olamaz");
            RuleFor(ci => ci.CreateDate).NotEmpty();
        }


    }
}
