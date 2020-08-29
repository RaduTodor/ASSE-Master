// <copyright file="Auction_HistoryDataService.cs" company="Transilvania University of Brasov">
// Todor Radu Constantin
// </copyright>

namespace Auction_Application.DataMappers.ServiceImplementations
{
    using System.Collections.Generic;
    using System.Linq;
    using Auction_Application.DataMappers.Interfaces;
    using Auction_Application.DomainModels;

    /// <summary>
    /// Defines the <see cref="Auction_HistoryDataService" />.
    /// </summary>
    public class Auction_HistoryDataService : IAuction_HistoryDataService
    {
        /// <summary>
        /// The AddAuction_History.
        /// </summary>
        /// <param name="auction_History">The Auction_History<see cref="Auction_History"/>.</param>
        public void AddAuction_History(Auction_History auction_History)
        {
            using (ApplicationContext context = new ApplicationContext())
            {
                context.Auction_Histories.Add(auction_History);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// The DeleteAuction_History.
        /// </summary>
        /// <param name="auction_History">The Auction_History.</param>
        public void DeleteAuction_History(Auction_History auction_History)
        {
            using (ApplicationContext context = new ApplicationContext())
            {
                Auction_History toBeDeleted = new Auction_History { ID = auction_History.ID };
                context.Auction_Histories.Attach(toBeDeleted);
                context.Auction_Histories.Remove(toBeDeleted);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// The GetAllAuction_Histories.
        /// </summary>
        /// <returns>All Auction_Histories.</returns>
        public IList<Auction_History> GetAllAuction_Histories()
        {
            using (ApplicationContext context = new ApplicationContext())
            {
                return context.Auction_Histories.Select(Auction_History => Auction_History).ToList();
            }
        }

        /// <summary>
        /// The UpdateAuction_History.
        /// </summary>
        /// <param name="auction_History">The Auction_History.</param>
        public void UpdateAuction_History(Auction_History auction_History)
        {
            using (ApplicationContext context = new ApplicationContext())
            {
                Auction_History toBeUpdated = context.Auction_Histories.Find(auction_History.ID);

                if (toBeUpdated == null)
                {
                    return;
                }

                context.Entry(toBeUpdated).CurrentValues.SetValues(auction_History);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// The GetAuction_HistoryById.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The Auction_History.</returns>
        public Auction_History GetAuction_HistoryById(int id)
        {
            using (var context = new ApplicationContext())
            {
                return context.Auction_Histories.Where(Auction_History => Auction_History.ID == id).SingleOrDefault();
            }
        }
    }
}
