// <copyright file="ScoreHistoryService.cs" company="Transilvania University of Brasov">
// Todor Radu Constantin
// </copyright>

namespace Auction_Application.Services.Implementation
{
    using System.Collections.Generic;
    using Auction_Application.DataMappers.Interfaces;
    using Auction_Application.DataMappers.ServiceImplementations;
    using Auction_Application.DomainModels;
    using Auction_Application.DomainModels.Validators;
    using Auction_Application.Services.Interfaces;
    using FluentValidation.Results;

    /// <summary>
    /// Defines the <see cref="ScoreHistoryService" />.
    /// </summary>
    public class ScoreHistoryService : IScoreHistoryService
    {
        /// <summary>
        /// Defines the Log.
        /// </summary>
        private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(typeof(ScoreHistoryService));

        /// <summary>
        /// Gets or sets the DataServices.
        /// </summary>
        public static IScore_HistoryDataService DataServices { get; set; } = new DaoFactory().Score_HistoryDataService;

        /// <summary>
        /// The AddScoreHistory.
        /// </summary>
        /// <param name="scoreHistory">The scoreHistory parameter.</param>
        /// <returns>The scoreHistory.</returns>
        public bool AddScoreHistory(Score_History scoreHistory)
        {
            var validator = new ScoreHistoryValidator();
            ValidationResult results = validator.Validate(scoreHistory);

            bool isValid = results.IsValid;

            if (isValid)
            {
                Log.Info("The scoreHistory is valid!");
                DataServices.AddScore_History(scoreHistory);
                Log.Info("The scoreHistory was added to the database!");
            }
            else
            {
                IList<ValidationFailure> failures = results.Errors;
                Log.Error($"The scoreHistory is not valid. The following errors occurred: {failures}");
            }

            return isValid;
        }

        /// <summary>
        /// The DeleteScoreHistory.
        /// </summary>
        /// <param name="scoreHistory">The scoreHistory parameter.</param>
        /// <returns>The scoreHistory.</returns>
        public bool DeleteScoreHistory(Score_History scoreHistory)
        {
            var validator = new ScoreHistoryValidator();
            ValidationResult results = validator.Validate(scoreHistory);

            bool isValid = results.IsValid;

            if (isValid)
            {
                Log.Info("The scoreHistory is valid!");
                DataServices.DeleteScore_History(scoreHistory);
                Log.Info("The scoreHistory was deleted from the database!");
            }
            else
            {
                IList<ValidationFailure> failures = results.Errors;
                Log.Error($"The scoreHistory is not valid. The following errors occurred: {failures}");
            }

            return isValid;
        }

        /// <summary>
        /// The GetListOfScoreHistories.
        /// </summary>
        /// <returns>List of scoreHistories.</returns>
        public IList<Score_History> GetListOfScoreHistories()
        {
            return DataServices.GetAllScore_Histories();
        }

        /// <summary>
        /// The GetScoreHistoryById.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The scoreHistory.</returns>
        public Score_History GetScoreHistoryById(int id)
        {
            return DataServices.GetScore_HistoryById(id);
        }

        /// <summary>
        /// The UpdateScoreHistory.
        /// </summary>
        /// <param name="scoreHistory">The scoreHistory.</param>
        /// <returns>Successful operation or not.</returns>
        public bool UpdateScoreHistory(Score_History scoreHistory)
        {
            var validator = new ScoreHistoryValidator();
            ValidationResult results = validator.Validate(scoreHistory);

            bool isValid = results.IsValid;

            if (isValid)
            {
                Log.Info("The scoreHistory is valid!");
                DataServices.UpdateScore_History(scoreHistory);
                Log.Info("The scoreHistory was updated in the database!");
            }
            else
            {
                IList<ValidationFailure> failures = results.Errors;
                Log.Error($"The scoreHistory is not valid. The following errors occurred: {failures}");
            }

            return isValid;
        }
    }
}
