// <copyright file="ConfigurationValidator.cs" company="Transilvania University of Brasov">
// Todor Radu Constantin
// </copyright>

namespace Auction_Application.DomainModels.Validators
{
    using FluentValidation;

    /// <summary>
    /// Defines the <see cref="ConfigurationValidator" />.
    /// </summary>
    public class ConfigurationValidator : AbstractValidator<Configuration>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ConfigurationValidator"/> class.
        /// </summary>
        public ConfigurationValidator()
        {
            RuleFor(x => x.ID).NotEmpty().WithErrorCode("This field is required.");
            RuleFor(x => x.VALUE).NotEmpty().WithErrorCode("This field is required.");
            RuleFor(x => x.ID).Length(2, 50).WithErrorCode("The id size is not correct.");
        }
    }
}
