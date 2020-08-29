// <copyright file="IDaoFactory.cs" company="Transilvania University of Brasov">
// Todor Radu Constantin
// </copyright>

namespace Auction_Application.DataMappers.Interfaces
{
    /// <summary>
    /// Defines the <see cref="IDaoFactory" />.
    /// </summary>
    public interface IDaoFactory
    {
        /// <summary>
        /// Gets the Auction_HistoryDataService.
        /// </summary>
        IAuction_HistoryDataService Auction_HistoryDataService { get; }

        /// <summary>
        /// Gets the AuctionDataService.
        /// </summary>
        IAuctionDataService AuctionDataService { get; }

        /// <summary>
        /// Gets the CategoryDataService.
        /// </summary>
        ICategoryDataService CategoryDataService { get; }

        /// <summary>
        /// Gets the ConfigurationDataService.
        /// </summary>
        IConfigurationDataService ConfigurationDataService { get; }

        /// <summary>
        /// Gets the PersonDataService.
        /// </summary>
        IPersonDataService PersonDataService { get; }

        /// <summary>
        /// Gets the ProductDataService.
        /// </summary>
        IProductDataService ProductDataService { get; }

        /// <summary>
        /// Gets the RoleDataService.
        /// </summary>
        IRoleDataService RoleDataService { get; }

        /// <summary>
        /// Gets the Score_HistoryDataService.
        /// </summary>
        IScore_HistoryDataService Score_HistoryDataService { get; }
    }
}
