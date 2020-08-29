// <copyright file="Score_HistoryDataService.cs" company="Transilvania University of Brasov">
// Todor Radu Constantin
// </copyright>

namespace Auction_Application.DataMappers.ServiceImplementations
{
    using System.Collections.Generic;
    using System.Linq;
    using Auction_Application.DataMappers.Interfaces;
    using Auction_Application.DomainModels;

    /// <summary>
    /// Defines the <see cref="Score_HistoryDataService" />.
    /// </summary>
    public class Score_HistoryDataService : IScore_HistoryDataService
    {
        /// <summary>
        /// The AddScore_History.
        /// </summary>
        /// <param name="score_History">The Score_History<see cref="Score_History"/>.</param>
        public void AddScore_History(Score_History score_History)
        {
            using (ApplicationContext context = new ApplicationContext())
            {
                context.Score_Histories.Add(score_History);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// The DeleteScore_History.
        /// </summary>
        /// <param name="score_History">The Score_History.</param>
        public void DeleteScore_History(Score_History score_History)
        {
            using (ApplicationContext context = new ApplicationContext())
            {
                Score_History toBeDeleted = new Score_History { ID = score_History.ID };
                context.Score_Histories.Attach(toBeDeleted);
                context.Score_Histories.Remove(toBeDeleted);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// The GetAllScore_Histories.
        /// </summary>
        /// <returns>All Score_Histories.</returns>
        public IList<Score_History> GetAllScore_Histories()
        {
            using (ApplicationContext context = new ApplicationContext())
            {
                return context.Score_Histories.Select(Score_History => Score_History).ToList();
            }
        }

        /// <summary>
        /// The UpdateScore_History.
        /// </summary>
        /// <param name="score_History">The Score_History.</param>
        public void UpdateScore_History(Score_History score_History)
        {
            using (ApplicationContext context = new ApplicationContext())
            {
                Score_History toBeUpdated = context.Score_Histories.Find(score_History.ID);

                if (toBeUpdated == null)
                {
                    return;
                }

                context.Entry(toBeUpdated).CurrentValues.SetValues(score_History);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// The GetScore_HistoryById.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The Score_History.</returns>
        public Score_History GetScore_HistoryById(int id)
        {
            using (var context = new ApplicationContext())
            {
                return context.Score_Histories.Where(Score_History => Score_History.ID == id).SingleOrDefault();
            }
        }
    }
}
