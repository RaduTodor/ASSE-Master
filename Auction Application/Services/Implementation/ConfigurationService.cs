// <copyright file="ConfigurationService.cs" company="Transilvania University of Brasov">
// Todor Radu Constantin
// </copyright>

namespace Auction_Application.Services.Implementation
{
    using System.Collections.Generic;
    using Auction_Application.DataMappers.Interfaces;
    using Auction_Application.DataMappers.ServiceImplementations;
    using Auction_Application.DomainModels;
    using Auction_Application.DomainModels.Validators;
    using Auction_Application.Services.Interfaces;
    using FluentValidation.Results;

    /// <summary>
    /// Defines the <see cref="ConfigurationService" />.
    /// </summary>
    public class ConfigurationService : IConfigurationService
    {
        /// <summary>
        /// Defines the Log.
        /// </summary>
        private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(typeof(ConfigurationService));

        /// <summary>
        /// Gets or sets the DataServices.
        /// </summary>
        public static IConfigurationDataService DataServices { get; set; } = new DaoFactory().ConfigurationDataService;

        /// <summary>
        /// The AddConfiguration.
        /// </summary>
        /// <param name="configuration">The configuration parameter.</param>
        /// <returns>The configuration.</returns>
        public bool AddConfiguration(Configuration configuration)
        {
            var validator = new ConfigurationValidator();
            ValidationResult results = validator.Validate(configuration);

            bool isValid = results.IsValid;

            if (isValid)
            {
                Log.Info("The configuration is valid!");
                DataServices.AddConfiguration(configuration);
                Log.Info("The configuration was added to the database!");
            }
            else
            {
                IList<ValidationFailure> failures = results.Errors;
                Log.Error($"The configuration is not valid. The following errors occurred: {failures}");
            }

            return isValid;
        }

        /// <summary>
        /// The DeleteConfiguration.
        /// </summary>
        /// <param name="configuration">The configuration parameter.</param>
        /// <returns>The configuration.</returns>
        public bool DeleteConfiguration(Configuration configuration)
        {
            var validator = new ConfigurationValidator();
            ValidationResult results = validator.Validate(configuration);

            bool isValid = results.IsValid;

            if (isValid)
            {
                Log.Info("The configuration is valid!");
                DataServices.DeleteConfiguration(configuration);
                Log.Info("The configuration was deleted from the database!");
            }
            else
            {
                IList<ValidationFailure> failures = results.Errors;
                Log.Error($"The configuration is not valid. The following errors occurred: {failures}");
            }

            return isValid;
        }

        /// <summary>
        /// The GetListOfConfigurations.
        /// </summary>
        /// <returns>List of configurations.</returns>
        public IList<Configuration> GetListOfConfigurations()
        {
            return DataServices.GetAllConfigurations();
        }

        /// <summary>
        /// The GetConfigurationById.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The configuration.</returns>
        public Configuration GetConfigurationById(string id)
        {
            return DataServices.GetConfigurationById(id);
        }

        /// <summary>
        /// The UpdateConfiguration.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        /// <returns>Successful operation or not.</returns>
        public bool UpdateConfiguration(Configuration configuration)
        {
            var validator = new ConfigurationValidator();
            ValidationResult results = validator.Validate(configuration);

            bool isValid = results.IsValid;

            if (isValid)
            {
                Log.Info("The configuration is valid!");
                DataServices.UpdateConfiguration(configuration);
                Log.Info("The configuration was updated in the database!");
            }
            else
            {
                IList<ValidationFailure> failures = results.Errors;
                Log.Error($"The configuration is not valid. The following errors occurred: {failures}");
            }

            return isValid;
        }
    }
}
