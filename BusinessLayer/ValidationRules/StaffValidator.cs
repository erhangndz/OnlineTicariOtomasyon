using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class StaffValidator : AbstractValidator<Staff>
    {
        public StaffValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Adı boş bırakamazsınız!");
            RuleFor(x => x.Name).MinimumLength(3).WithMessage("İsim en az 3 karakterden oluşmalı!");
            RuleFor(x => x.Surname).NotEmpty().WithMessage("Soyadını boş bırakamazsınız!");
            RuleFor(x => x.Surname).MinimumLength(3).WithMessage("Soyad en az 3 karakterden oluşmalı!");
            RuleFor(x => x.DepartmentID).NotEmpty().WithMessage("Departmanı boş bırakamazsınız!");
            RuleFor(x => x.Image).NotEmpty().WithMessage("Görseli boş bırakamazsınız!");
        }
    }
}
