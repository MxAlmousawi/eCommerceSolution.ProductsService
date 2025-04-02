using BuisnessLogicLayer.Dto;
using FluentValidation;

namespace BuisnessLogicLayer.Validators
{
    public class ProductUpdateRequestValidator : AbstractValidator<ProductUpdateRequest>
    {
        public ProductUpdateRequestValidator()
        {
            RuleFor(x => x.ProductId).NotEmpty();
            RuleFor(x => x.ProductName).NotEmpty();
            RuleFor(x => x.Category).IsInEnum();
            RuleFor(x => x.UnitPrice).GreaterThan(0).LessThan(double.MaxValue);
            RuleFor(x => x.QuantityInStock).GreaterThan(0).LessThan(int.MaxValue);
        }
    }
}
