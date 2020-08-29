// <copyright file="IAuctionHistoryService.cs" company="Transilvania University of Brasov">
// Todor Radu Constantin
// </copyright>

namespace Auction_Application.Services.Interfaces
{
    using System.Collections.Generic;
    using Auction_Application.DomainModels;

    /// <summary>
    /// Defines the <see cref="IAuctionHistoryService" />.
    /// </summary>
    public interface IAuctionHistoryService
    {
        /// <summary>
        /// The GetListOfAuctionHistories.
        /// </summary>
        /// <returns>The list of auctionHistories.</returns>
        IList<Auction_History> GetListOfAuctionHistories();

        /// <summary>
        /// The DeleteAuctionHistory.
        /// </summary>
        /// <param name="auctionHistory">The auctionHistory.</param>
        /// <returns>Success or not.</returns>
        bool DeleteAuctionHistory(Auction_History auctionHistory);

        /// <summary>
        /// The UpdateAuctionHistory.
        /// </summary>
        /// <param name="auctionHistory">The auctionHistory.</param>
        /// <returns>Success or not.</returns>
        bool UpdateAuctionHistory(Auction_History auctionHistory);

        /// <summary>
        /// The GetAuctionHistoryById.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The auctionHistory.</returns>
        Auction_History GetAuctionHistoryById(int id);

        /// <summary>
        /// The AddAuctionHistory.
        /// </summary>
        /// <param name="auctionHistory">The auctionHistory parameter.</param>
        /// <returns>The auctionHistory.</returns>
        bool AddAuctionHistory(Auction_History auctionHistory);

        /// <summary>
        /// The PlaceOffer.
        /// </summary>
        /// <param name="person">The person<see cref="Person"/>.</param>
        /// <param name="auction">The auction<see cref="Auction"/>.</param>
        /// <param name="currency">The currency<see cref="string"/>.</param>
        /// <param name="offer">The offer<see cref="decimal"/>.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        bool PlaceOffer(Person person, Auction auction, string currency, decimal offer);
    }
}
