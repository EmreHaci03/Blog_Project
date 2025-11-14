using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;
using FluentValidation;

namespace BusinessLayer.ValidationRules
{
    public class AuthorValidator:AbstractValidator<Author>
    {
        public AuthorValidator()
        {
            RuleFor(x => x.NameSurname).NotEmpty().WithMessage("Yazar Ad Ve Soyad Kısmı Boş Geçilemez.");
            RuleFor(x => x.AuthorTitle).NotEmpty().WithMessage("Yazar Başlığı Kısmı Boş Geçilemez.");
            RuleFor(x => x.AuthorImage).NotEmpty().WithMessage("Yazar Görseli  Kısmı Boş Geçilemez.");
            RuleFor(x => x.AuthorAbout).NotEmpty().WithMessage("Yazar Hakkında KısmıBoş Geçilemez.");

            RuleFor(x => x.NameSurname).MinimumLength(5).WithMessage("Yazar Ad Soyad Alanı En Az 5 Karakter Olmalı");
            RuleFor(x => x.NameSurname).MaximumLength(60).WithMessage("Yazar Ad Soyad Alanı En Fazla 60 Karakter Olmalı");

            RuleFor(x => x.AuthorTitle).MinimumLength(5).WithMessage("Yazar Ad Soyad Alanı En Az 5 Karakter Olmalı");
            RuleFor(x => x.AuthorTitle).MaximumLength(50).WithMessage("Yazar Ad Soyad Alanı En Fazla 50 Karakter Olmalı");

            RuleFor(x => x.AuthorImage).MinimumLength(5).WithMessage("Yazar Ad Soyad Alanı En Az 5 Karakter Olmalı");
            RuleFor(x => x.AuthorImage).MaximumLength(100).WithMessage("Yazar Ad Soyad Alanı En Fazla 100 Karakter Olmalı");

            RuleFor(x => x.AuthorAbout).MinimumLength(5).WithMessage("Yazar Ad Soyad Alanı En Az 5 Karakter Olmalı");
            RuleFor(x => x.AuthorAbout).MaximumLength(200).WithMessage("Yazar Ad Soyad Alanı En Fazla 200 Karakter Olmalı");
        }
    }
}
