using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(u => u.FirstName).NotEmpty();
            RuleFor(u => u.FirstName).MinimumLength(2);
            RuleFor(u => u.LastName).NotEmpty();
            RuleFor(u => u.LastName).MinimumLength(2);
            RuleFor(u => u.Email).Must(ContainEt).WithMessage("Geçersiz eposta adresi");
            RuleFor(u => u.Password).MinimumLength(6).WithMessage("Şifre en az 6 karakter olmalı");
        }

        private bool ContainEt(string arg)
        {
            return arg.Contains("@");
        }
    }
}
