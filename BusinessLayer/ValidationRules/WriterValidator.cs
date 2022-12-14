using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class WriterValidator : AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("Yazar adını boş geçemezsiniz!");
            RuleFor(x => x.WriterSurname).NotEmpty().WithMessage("Yazar soyadını boş geçemezsiniz!");
            RuleFor(x => x.WriterName).MinimumLength(2).WithMessage("Lütfen  en az 3 karakter girişi yapınız");
            RuleFor(x => x.WriterSurname).MaximumLength(50).WithMessage("50 karakterden fazla deger girişi yapmayınız!");
            RuleFor(x => x.WriterAbout).MaximumLength(50).WithMessage("50 karakterden fazla deger girişi yapmayınız!");
            RuleFor(x => x.WriterAbout).NotEmpty().WithMessage("Hakkında açıklaması boş geçemezsiniz!");
            RuleFor(x => x.WriterTitle).NotEmpty().WithMessage("Yazar Ünvanını boş geçemezsiniz!");
            //odev yazarın hakkında kısmında mutlaka a harfi geçsin
            // RuleFor(x => x.WriterAbout).Must(x => x != null && x.ToUpper().Contains("A")).WithMessage("Hakkında kısmında en az bir a harfi içermelidir");

        }
    }
}
