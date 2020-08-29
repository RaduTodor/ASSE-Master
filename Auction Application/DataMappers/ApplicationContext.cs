// <copyright file="ApplicationContext.cs" company="Transilvania University of Brasov">
// Todor Radu Constantin
// </copyright>

namespace Auction_Application.DataMappers
{
    using Auction_Application.DomainModels;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// Defines the <see cref="ApplicationContext" />.
    /// </summary>
    public class ApplicationContext : System.Data.Entity.DbContext
    {
        /// <summary>
        /// Defines the Log.
        /// </summary>
        private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(typeof(ApplicationContext));

        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationContext"/> class.
        /// </summary>
        public ApplicationContext() : base("FinalModel")
        {
            Log.Info("ApplicationContext instance created!");
        }

        /// <summary>
        /// Gets or sets the Auctions.
        /// </summary>
        public DbSet<Auction> Auctions { get; set; }

        /// <summary>
        /// Gets or sets the Auction_Histories.
        /// </summary>
        public DbSet<Auction_History> Auction_Histories { get; set; }

        /// <summary>
        /// Gets or sets the Categories.
        /// </summary>
        public DbSet<Category> Categories { get; set; }

        /// <summary>
        /// Gets or sets the Configurations.
        /// </summary>
        public DbSet<Configuration> Configurations { get; set; }

        /// <summary>
        /// Gets or sets the People.
        /// </summary>
        public DbSet<Person> People { get; set; }

        /// <summary>
        /// Gets or sets the Products.
        /// </summary>
        public DbSet<Product> Products { get; set; }

        /// <summary>
        /// Gets or sets the Roles.
        /// </summary>
        public DbSet<Role> Roles { get; set; }

        /// <summary>
        /// Gets or sets the Score_Histories.
        /// </summary>
        public DbSet<Score_History> Score_Histories { get; set; }
    }
}
