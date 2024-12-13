using FluentValidation;
using OnlineEdu.WebUI.DTOs.BlogCategoryDtos;

namespace OnlineEdu.WebUI.Validators
{
    public class BlogCategoryValidator : AbstractValidator<CreateBlogCategoryDto>
    {
        public BlogCategoryValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Blog Kategori Adı Boş Bırakılamaz");
            RuleFor(x => x.Name).MaximumLength(30).WithMessage("Blog Kategori Adı Max 30 Karakter Olmalıdır.");
            RuleFor(x => x.Name).MinimumLength(3).WithMessage("Blog Kategori Adı Min 3 Karakter Olmalıdır.");

        }
    }
}
