// <copyright file="AuctionDataService.cs" company="Transilvania University of Brasov">
// Todor Radu Constantin
// </copyright>

namespace Auction_Application.DataMappers.ServiceImplementations
{
    using System.Collections.Generic;
    using System.Linq;
    using Auction_Application.DataMappers.Interfaces;
    using Auction_Application.DomainModels;

    /// <summary>
    /// Defines the <see cref="AuctionDataService" />.
    /// </summary>
    public class AuctionDataService : IAuctionDataService
    {
        /// <summary>
        /// The AddAuction.
        /// </summary>
        /// <param name="auction">The Auction<see cref="Auction"/>.</param>
        public void AddAuction(Auction auction)
        {
            using (ApplicationContext context = new ApplicationContext())
            {
                context.Auctions.Add(auction);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// The DeleteAuction.
        /// </summary>
        /// <param name="auction">The Auction.</param>
        public void DeleteAuction(Auction auction)
        {
            using (ApplicationContext context = new ApplicationContext())
            {
                Auction toBeDeleted = new Auction { ID = auction.ID };
                context.Auctions.Attach(toBeDeleted);
                context.Auctions.Remove(toBeDeleted);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// The GetAllAuctions.
        /// </summary>
        /// <returns>All Auctions.</returns>
        public IList<Auction> GetAllAuctions()
        {
            using (ApplicationContext context = new ApplicationContext())
            {
                return context.Auctions.Select(Auction => Auction).ToList();
            }
        }

        /// <summary>
        /// The UpdateAuction.
        /// </summary>
        /// <param name="auction">The Auction.</param>
        public void UpdateAuction(Auction auction)
        {
            using (ApplicationContext context = new ApplicationContext())
            {
                Auction toBeUpdated = context.Auctions.Find(auction.ID);

                if (toBeUpdated == null)
                {
                    return;
                }

                context.Entry(toBeUpdated).CurrentValues.SetValues(auction);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// The GetAuctionById.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The Auction.</returns>
        public Auction GetAuctionById(int id)
        {
            using (var context = new ApplicationContext())
            {
                return context.Auctions.Where(Auction => Auction.ID == id).SingleOrDefault();
            }
        }
    }
}
