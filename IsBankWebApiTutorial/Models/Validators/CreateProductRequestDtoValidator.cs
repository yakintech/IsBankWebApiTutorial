using FluentValidation;
using IsBankWebApiTutorial.Models.DTO;
using IsBankWebApiTutorial.Models.ORM;

namespace IsBankWebApiTutorial.Models
{
    public class CreateProductRequestDtoValidator : AbstractValidator<CreateProductRequestDto>
    {
        public CreateProductRequestDtoValidator()
        {
            RuleFor(item => item.Name)
                .NotEmpty()
                .WithMessage("Bos gecilemez");

            RuleFor(item => item.UnitPrice)
                .GreaterThan(0)
                .WithMessage("Fiyat 0 dan buyuk olmak zorunda");
        }
    }
}
