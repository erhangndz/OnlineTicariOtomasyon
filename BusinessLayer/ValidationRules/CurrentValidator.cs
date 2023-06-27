using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class CurrentValidator : AbstractValidator<Current>
    {
        public CurrentValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Adı boş bırakamazsınız!");
            RuleFor(x => x.Name).MinimumLength(3).WithMessage("İsim en az 3 karakter olmalı!");
            RuleFor(x => x.Surname).NotEmpty().WithMessage("Soyadı boş bırakamazsınız!");
            RuleFor(x => x.Surname).MinimumLength(3).WithMessage("Soyisim en az 3 karakter olmalı!");
            RuleFor(x => x.City).NotEmpty().WithMessage("Şehri boş bırakamazsınız!");
            RuleFor(x => x.City).MaximumLength(14).WithMessage("Şehir ismi en fazla 14 Karakter olmalı!");
            RuleFor(x => x.Mail).NotEmpty().WithMessage("Mail adresini boş bırakamazsınız!");
            RuleFor(x => x.Mail).EmailAddress().WithMessage("Geçerli bir email adresi girin!");
        }
    }
}
