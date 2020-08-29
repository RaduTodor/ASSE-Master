// <copyright file="RoleValidator.cs" company="Transilvania University of Brasov">
// Todor Radu Constantin
// </copyright>

namespace Auction_Application.DomainModels.Validators
{
    using FluentValidation;

    /// <summary>
    /// Defines the <see cref="RoleValidator" />.
    /// </summary>
    public class RoleValidator : AbstractValidator<Role>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RoleValidator"/> class.
        /// </summary>
        public RoleValidator()
        {
            RuleFor(x => x.NAME).Length(2, 50).WithErrorCode("The role name size is not correct.");
        }
    }
}
