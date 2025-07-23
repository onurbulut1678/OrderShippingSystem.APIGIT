using FluentValidation;
using OrderShippingSystem.Application.Features.Products.DTOs;

namespace OrderShippingSystem.Application.Validators
{
    public class CreateProductDtoValidator : AbstractValidator<CreateProductDto>
    {
        public CreateProductDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Ürün adı boş olamaz.")
                .MaximumLength(100).WithMessage("Ürün adı en fazla 100 karakter OLACAK.");

            RuleFor(x => x.Price)
                .GreaterThan(0).WithMessage("Fiyat 0 OLMAMALI.");

            RuleFor(x => x.Category)
                .NotEmpty().WithMessage("Kategori boş olamaz.");
        }
    }
}
