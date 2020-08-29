// <copyright file="ScoreHistoryValidator.cs" company="Transilvania University of Brasov">
// Todor Radu Constantin
// </copyright>

namespace Auction_Application.DomainModels.Validators
{
    using FluentValidation;

    /// <summary>
    /// Defines the <see cref="ScoreHistoryValidator" />.
    /// </summary>
    public class ScoreHistoryValidator : AbstractValidator<Score_History>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ScoreHistoryValidator"/> class.
        /// </summary>
        public ScoreHistoryValidator()
        {
            RuleFor(x => x.Person).NotEmpty().WithErrorCode("This field is required.");
            RuleFor(x => x.SCORE).NotEmpty().WithErrorCode("This field is required.");
            RuleFor(x => x.DATE).NotEmpty().WithErrorCode("This field is required.");
            RuleFor(x => x.SCORE).ScalePrecision(2, 4).WithErrorCode("The score size is not correct.");
            RuleFor(x => x.SCORE).LessThanOrEqualTo(10).WithErrorCode("The score must be smaller than or equal to 10");
            RuleFor(x => x.SCORE).GreaterThanOrEqualTo(0).WithErrorCode("The score must be greater than or equal to 0");
        }
    }
}
