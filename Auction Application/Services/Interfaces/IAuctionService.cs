// <copyright file="IAuctionService.cs" company="Transilvania University of Brasov">
// Todor Radu Constantin
// </copyright>

namespace Auction_Application.Services.Interfaces
{
    using System.Collections.Generic;
    using Auction_Application.DomainModels;

    /// <summary>
    /// Defines the <see cref="IAuctionService" />.
    /// </summary>
    public interface IAuctionService
    {
        /// <summary>
        /// The GetListOfAuctions.
        /// </summary>
        /// <returns>The list of auctions.</returns>
        IList<Auction> GetListOfAuctions();

        /// <summary>
        /// The GetListOfAuctionsSoldBy.
        /// </summary>
        /// <param name="person">The person<see cref="Person"/>.</param>
        /// <returns>The list of auctions.</returns>
        IList<Auction> GetListOfAuctionsSoldBy(Person person);

        /// <summary>
        /// The DeleteAuction.
        /// </summary>
        /// <param name="auction">The auction.</param>
        /// <returns>Success or not.</returns>
        bool DeleteAuction(Auction auction);

        /// <summary>
        /// The UpdateAuction.
        /// </summary>
        /// <param name="auction">The auction.</param>
        /// <returns>Success or not.</returns>
        bool UpdateAuction(Auction auction);

        /// <summary>
        /// The GetAuctionById.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The auction.</returns>
        Auction GetAuctionById(int id);

        /// <summary>
        /// The AddAuction.
        /// </summary>
        /// <param name="auction">The auction parameter.</param>
        /// <returns>The auction.</returns>
        bool AddAuction(Auction auction);

        /// <summary>
        /// The EndAuctionManually.
        /// </summary>
        /// <param name="auction">The auction<see cref="Auction"/>.</param>
        /// <param name="person">The person<see cref="Person"/>.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        bool EndAuctionManually(Auction auction, Person person);
    }
}
