// <copyright file="DaoFactory.cs" company="Transilvania University of Brasov">
// Todor Radu Constantin
// </copyright>

namespace Auction_Application.DataMappers.ServiceImplementations
{
    using Auction_Application.DataMappers.Interfaces;

    /// <summary>
    /// Defines the <see cref="DaoFactory" />.
    /// </summary>
    public class DaoFactory : IDaoFactory
    {
        /// <summary>
        /// Gets the Auction_HistoryDataService.
        /// </summary>
        public IAuction_HistoryDataService Auction_HistoryDataService { get => new Auction_HistoryDataService(); }

        /// <summary>
        /// Gets the AuctionDataService.
        /// </summary>
        public IAuctionDataService AuctionDataService { get => new AuctionDataService(); }

        /// <summary>
        /// Gets the CategoryDataService.
        /// </summary>
        public ICategoryDataService CategoryDataService { get => new CategoryDataService(); }

        /// <summary>
        /// Gets the ConfigurationDataService.
        /// </summary>
        public IConfigurationDataService ConfigurationDataService { get => new ConfigurationDataService(); }

        /// <summary>
        /// Gets the PersonDataService.
        /// </summary>
        public IPersonDataService PersonDataService { get => new PersonDataService(); }

        /// <summary>
        /// Gets the ProductDataService.
        /// </summary>
        public IProductDataService ProductDataService { get => new ProductDataService(); }

        /// <summary>
        /// Gets the RoleDataService.
        /// </summary>
        public IRoleDataService RoleDataService { get => new RoleDataService(); }

        /// <summary>
        /// Gets the Score_HistoryDataService.
        /// </summary>
        public IScore_HistoryDataService Score_HistoryDataService { get => new Score_HistoryDataService(); }
    }
}
