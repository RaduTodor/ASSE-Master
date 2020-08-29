// <copyright file="IAuction_HistoryDataService.cs" company="Transilvania University of Brasov">
// Todor Radu Constantin
// </copyright>

namespace Auction_Application.DataMappers.Interfaces
{
    using System.Collections.Generic;
    using Auction_Application.DomainModels;

    /// <summary>
    /// Defines the <see cref="IAuction_HistoryDataService" />.
    /// </summary>
    public interface IAuction_HistoryDataService
    {
        /// <summary>
        /// The GetAllAuction_Histories.
        /// </summary>
        /// <returns>All Auction_Histories.</returns>
        IList<Auction_History> GetAllAuction_Histories();

        /// <summary>
        /// The AddAuction_History.
        /// </summary>
        /// <param name="auction_History">The Auction_History.</param>
        void AddAuction_History(Auction_History auction_History);

        /// <summary>
        /// The DeleteAuction_History.
        /// </summary>
        /// <param name="auction_History">The Auction_History.</param>
        void DeleteAuction_History(Auction_History auction_History);

        /// <summary>
        /// The UpdateAuction_History.
        /// </summary>
        /// <param name="auction_History">The Auction_History.</param>
        void UpdateAuction_History(Auction_History auction_History);

        /// <summary>
        /// The GetAuction_HistoryById.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The <see cref="Auction_History"/>.</returns>
        Auction_History GetAuction_HistoryById(int id);
    }
}
