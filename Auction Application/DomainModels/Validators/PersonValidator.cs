// <copyright file="PersonValidator.cs" company="Transilvania University of Brasov">
// Todor Radu Constantin
// </copyright>

namespace Auction_Application.DomainModels.Validators
{
    using FluentValidation;

    /// <summary>
    /// Defines the <see cref="PersonValidator" />.
    /// </summary>
    public class PersonValidator : AbstractValidator<Person>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PersonValidator"/> class.
        /// </summary>
        public PersonValidator()
        {
            RuleFor(x => x.FIRST_NAME).NotEmpty().WithErrorCode("This field is required.");
            RuleFor(x => x.FIRST_NAME).Length(2, 50).WithErrorCode("The first name size is not correct.");
            RuleFor(x => x.LAST_NAME).NotEmpty().WithErrorCode("This field is required.");
            RuleFor(x => x.LAST_NAME).Length(2, 50).WithErrorCode("The last name size is not correct.");
            RuleFor(x => x.Role).NotEmpty().WithErrorCode("This field is required.");
            RuleFor(x => x.SCORE).NotEmpty().WithErrorCode("This field is required.");
            RuleFor(x => x.SCORE).ScalePrecision(2, 4).WithErrorCode("The score size is not correct.");
            RuleFor(x => x.SCORE).LessThanOrEqualTo(11).WithErrorCode("The score must be smaller than or equal to 10");
            RuleFor(x => x.SCORE).GreaterThanOrEqualTo(0).WithErrorCode("The score must be greater than or equal to 0");
        }
    }
}
