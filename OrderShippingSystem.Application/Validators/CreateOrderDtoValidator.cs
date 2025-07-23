using FluentValidation;
using OrderShippingSystem.Application.Features.Orders.Dtos;

namespace OrderShippingSystem.Application.Validators
{
    public class CreateOrderDtoValidator : AbstractValidator<CreateOrderDto>
    {
        public CreateOrderDtoValidator()
        {
            RuleFor(x => x.UserId).GreaterThan(0).WithMessage("Kullanıcı ID geçerli OLMALI.");
            RuleFor(x => x.TotalPrice).GreaterThan(0).WithMessage("Toplam fiyat 0 OLMAMALI.");
            RuleFor(x => x.CargoCompanyId).GreaterThan(0).WithMessage("Kargo şirketi SEÇ.");

            RuleForEach(x => x.Items).SetValidator(new OrderItemDtoValidator());
        }
    }

    public class OrderItemDtoValidator : AbstractValidator<OrderItemDto>
    {
        public OrderItemDtoValidator()
        {
            RuleFor(x => x.ProductId).GreaterThan(0).WithMessage("Ürün ID geçerli OLACAK.");
            RuleFor(x => x.Quantity).GreaterThan(0).WithMessage("Ürün adedi 0 OLAMAZ.");
        }
    }
}
