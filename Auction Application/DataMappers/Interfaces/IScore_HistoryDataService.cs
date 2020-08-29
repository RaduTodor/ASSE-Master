// <copyright file="IScore_HistoryDataService.cs" company="Transilvania University of Brasov">
// Todor Radu Constantin
// </copyright>

namespace Auction_Application.DataMappers.Interfaces
{
    using System.Collections.Generic;
    using Auction_Application.DomainModels;

    /// <summary>
    /// Defines the <see cref="IScore_HistoryDataService" />.
    /// </summary>
    public interface IScore_HistoryDataService
    {
        /// <summary>
        /// The GetAllScore_Histories.
        /// </summary>
        /// <returns>All Score_Histories.</returns>
        IList<Score_History> GetAllScore_Histories();

        /// <summary>
        /// The AddScore_History.
        /// </summary>
        /// <param name="score_History">The Score_History.</param>
        void AddScore_History(Score_History score_History);

        /// <summary>
        /// The DeleteScore_History.
        /// </summary>
        /// <param name="score_History">The Score_History.</param>
        void DeleteScore_History(Score_History score_History);

        /// <summary>
        /// The UpdateScore_History.
        /// </summary>
        /// <param name="score_History">The Score_History.</param>
        void UpdateScore_History(Score_History score_History);

        /// <summary>
        /// The GetScore_HistoryById.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The <see cref="Score_History"/>.</returns>
        Score_History GetScore_HistoryById(int id);
    }
}
