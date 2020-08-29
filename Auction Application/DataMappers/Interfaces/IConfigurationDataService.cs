// <copyright file="IConfigurationDataService.cs" company="Transilvania University of Brasov">
// Todor Radu Constantin
// </copyright>

namespace Auction_Application.DataMappers.Interfaces
{
    using System.Collections.Generic;
    using Auction_Application.DomainModels;

    /// <summary>
    /// Defines the <see cref="IConfigurationDataService" />.
    /// </summary>
    public interface IConfigurationDataService
    {
        /// <summary>
        /// The GetAllConfigurations.
        /// </summary>
        /// <returns>All Configurations.</returns>
        IList<Configuration> GetAllConfigurations();

        /// <summary>
        /// The AddConfiguration.
        /// </summary>
        /// <param name="configuration">The Configuration.</param>
        void AddConfiguration(Configuration configuration);

        /// <summary>
        /// The DeleteConfiguration.
        /// </summary>
        /// <param name="configuration">The Configuration.</param>
        void DeleteConfiguration(Configuration configuration);

        /// <summary>
        /// The UpdateConfiguration.
        /// </summary>
        /// <param name="configuration">The Configuration.</param>
        void UpdateConfiguration(Configuration configuration);

        /// <summary>
        /// The GetConfigurationById.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The <see cref="Configuration"/>.</returns>
        Configuration GetConfigurationById(string id);
    }
}
