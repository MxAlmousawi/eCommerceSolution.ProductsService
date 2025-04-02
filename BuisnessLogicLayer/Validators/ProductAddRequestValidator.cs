using BuisnessLogicLayer.Dto;
using FluentValidation;

namespace BuisnessLogicLayer.Validators
{
    public class ProductAddRequestValidator : AbstractValidator<ProductAddRequest>
    {
        public ProductAddRequestValidator()
        {
            RuleFor(x => x.ProductName).NotEmpty();
            RuleFor(x => x.Category).IsInEnum();
            RuleFor(x => x.UnitPrice).GreaterThan(0).LessThan(double.MaxValue);
            RuleFor(x => x.QuantityInStock).GreaterThan(0).LessThan(int.MaxValue);
        }
    }
}
