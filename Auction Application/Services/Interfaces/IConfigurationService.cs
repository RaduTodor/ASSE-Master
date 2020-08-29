// <copyright file="IConfigurationService.cs" company="Transilvania University of Brasov">
// Todor Radu Constantin
// </copyright>

namespace Auction_Application.Services.Interfaces
{
    using System.Collections.Generic;
    using Auction_Application.DomainModels;

    /// <summary>
    /// Defines the <see cref="IConfigurationService" />.
    /// </summary>
    public interface IConfigurationService
    {
        /// <summary>
        /// The GetListOfConfigurations.
        /// </summary>
        /// <returns>The list of configurations.</returns>
        IList<Configuration> GetListOfConfigurations();

        /// <summary>
        /// The DeleteConfiguration.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        /// <returns>Success or not.</returns>
        bool DeleteConfiguration(Configuration configuration);

        /// <summary>
        /// The UpdateConfiguration.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        /// <returns>Success or not.</returns>
        bool UpdateConfiguration(Configuration configuration);

        /// <summary>
        /// The GetConfigurationById.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The configuration.</returns>
        Configuration GetConfigurationById(string id);

        /// <summary>
        /// The AddConfiguration.
        /// </summary>
        /// <param name="configuration">The configuration parameter.</param>
        /// <returns>The configuration.</returns>
        bool AddConfiguration(Configuration configuration);
    }
}
