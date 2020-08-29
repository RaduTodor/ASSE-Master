// <copyright file="ProductValidator.cs" company="Transilvania University of Brasov">
// Todor Radu Constantin
// </copyright>

namespace Auction_Application.DomainModels.Validators
{
    using FluentValidation;

    /// <summary>
    /// Defines the <see cref="ProductValidator" />.
    /// </summary>
    public class ProductValidator : AbstractValidator<Product>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProductValidator"/> class.
        /// </summary>
        public ProductValidator()
        {
            RuleFor(x => x.NAME).NotEmpty().WithErrorCode("This field is required.");
            RuleFor(x => x.NAME).Length(2, 50).WithErrorCode("The first name size is not correct.");
            RuleFor(x => x.Category).NotEmpty().WithErrorCode("This field is required.");
        }
    }
}
