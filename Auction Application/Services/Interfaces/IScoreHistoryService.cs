// <copyright file="IScoreHistoryService.cs" company="Transilvania University of Brasov">
// Todor Radu Constantin
// </copyright>

namespace Auction_Application.Services.Interfaces
{
    using System.Collections.Generic;
    using Auction_Application.DomainModels;

    /// <summary>
    /// Defines the <see cref="IScoreHistoryService" />.
    /// </summary>
    public interface IScoreHistoryService
    {
        /// <summary>
        /// The GetListOfScoreHistories.
        /// </summary>
        /// <returns>The list of scoreHistories.</returns>
        IList<Score_History> GetListOfScoreHistories();

        /// <summary>
        /// The DeleteScoreHistory.
        /// </summary>
        /// <param name="scoreHistory">The scoreHistory.</param>
        /// <returns>Success or not.</returns>
        bool DeleteScoreHistory(Score_History scoreHistory);

        /// <summary>
        /// The UpdateScoreHistory.
        /// </summary>
        /// <param name="scoreHistory">The scoreHistory.</param>
        /// <returns>Success or not.</returns>
        bool UpdateScoreHistory(Score_History scoreHistory);

        /// <summary>
        /// The GetScoreHistoryById.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The scoreHistory.</returns>
        Score_History GetScoreHistoryById(int id);

        /// <summary>
        /// The AddScoreHistory.
        /// </summary>
        /// <param name="scoreHistory">The scoreHistory parameter.</param>
        /// <returns>The scoreHistory.</returns>
        bool AddScoreHistory(Score_History scoreHistory);
    }
}
