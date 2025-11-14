using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;
using FluentValidation;

namespace BusinessLayer.ValidationRules
{
    public class BlogValidator: AbstractValidator<Blog>
    {
        public BlogValidator()
        {
            RuleFor(x => x.BlogTitle).NotEmpty().WithMessage("Blog Başlığı Boş Geçilemez.");
            RuleFor(x => x.BlogTitle).MinimumLength(10).WithMessage("Lütfen En Az 10 Karakterlik Başlık Giriniz.");
            RuleFor(x => x.BlogTitle).MaximumLength(70).WithMessage("Lütfen en fazla 70 karakterlik Blog Başlık adı girişi yapınız.");

            RuleFor(x => x.BlogContent).NotEmpty().WithMessage("Blog İçeriği Boş Geçilemez");
            RuleFor(x => x.BlogContent).MinimumLength(20).WithMessage("Lütfen En Az 20 karakterlik Blog İçeriği girişi yapınız.");
        }
            
    }
}
