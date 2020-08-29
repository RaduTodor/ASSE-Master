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
        }
    }
}
