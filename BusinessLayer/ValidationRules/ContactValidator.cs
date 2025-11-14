using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;
using FluentValidation;

namespace BusinessLayer.ValidationRules
{
    public class ContactValidator:AbstractValidator<Contact>
    {
        public ContactValidator()
        {
            RuleFor(x => x.NameUsername).NotEmpty().WithMessage("Ad Soyad Boş Bırakılamaz!");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Mesajın Konusu Boş Bırakılamaz!");
            RuleFor(x => x.Message).NotEmpty().WithMessage("Mesaj Kısmı Boş Bırakılamaz");
            RuleFor(x => x.Mail).NotEmpty().WithMessage("Mail Kısmı Boş Bırakılamaz!");
        }
    }
}
