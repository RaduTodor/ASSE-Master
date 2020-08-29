// <copyright file="CategoryValidator.cs" company="Transilvania University of Brasov">
// Todor Radu Constantin
// </copyright>

namespace Auction_Application.DomainModels.Validators
{
    using FluentValidation;

    /// <summary>
    /// Defines the <see cref="CategoryValidator" />.
    /// </summary>
    public class CategoryValidator : AbstractValidator<Category>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CategoryValidator"/> class.
        /// </summary>
        public CategoryValidator()
        {
            RuleFor(x => x.NAME).NotEmpty().WithErrorCode("This field is required.");
            RuleFor(x => x.NAME).Length(2, 50).WithErrorCode("The name size is not correct.");
        }
    }
}
