// <copyright file="IAuctionDataService.cs" company="Transilvania University of Brasov">
// Todor Radu Constantin
// </copyright>

namespace Auction_Application.DataMappers.Interfaces
{
    using System.Collections.Generic;
    using Auction_Application.DomainModels;

    /// <summary>
    /// Defines the <see cref="IAuctionDataService" />.
    /// </summary>
    public interface IAuctionDataService
    {
        /// <summary>
        /// The GetAllAuctions.
        /// </summary>
        /// <returns>All Auctions.</returns>
        IList<Auction> GetAllAuctions();

        /// <summary>
        /// The AddAuction.
        /// </summary>
        /// <param name="auction">The Auction.</param>
        void AddAuction(Auction auction);

        /// <summary>
        /// The DeleteAuction.
        /// </summary>
        /// <param name="auction">The Auction.</param>
        void DeleteAuction(Auction auction);

        /// <summary>
        /// The UpdateAuction.
        /// </summary>
        /// <param name="auction">The Auction.</param>
        void UpdateAuction(Auction auction);

        /// <summary>
        /// The GetAuctionById.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The <see cref="Auction"/>.</returns>
        Auction GetAuctionById(int id);
    }
}
