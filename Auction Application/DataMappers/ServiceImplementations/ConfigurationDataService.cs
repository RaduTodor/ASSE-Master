// <copyright file="ConfigurationDataService.cs" company="Transilvania University of Brasov">
// Todor Radu Constantin
// </copyright>

namespace Auction_Application.DataMappers.ServiceImplementations
{
    using System.Collections.Generic;
    using System.Linq;
    using Auction_Application.DataMappers.Interfaces;
    using Auction_Application.DomainModels;

    /// <summary>
    /// Defines the <see cref="ConfigurationDataService" />.
    /// </summary>
    public class ConfigurationDataService : IConfigurationDataService
    {
        /// <summary>
        /// The AddConfiguration.
        /// </summary>
        /// <param name="configuration">The Configuration<see cref="Configuration"/>.</param>
        public void AddConfiguration(Configuration configuration)
        {
            using (ApplicationContext context = new ApplicationContext())
            {
                context.Configurations.Add(configuration);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// The DeleteConfiguration.
        /// </summary>
        /// <param name="configuration">The Configuration.</param>
        public void DeleteConfiguration(Configuration configuration)
        {
            using (ApplicationContext context = new ApplicationContext())
            {
                Configuration toBeDeleted = new Configuration { ID = configuration.ID };
                context.Configurations.Attach(toBeDeleted);
                context.Configurations.Remove(toBeDeleted);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// The GetAllConfigurations.
        /// </summary>
        /// <returns>All Configurations.</returns>
        public IList<Configuration> GetAllConfigurations()
        {
            using (ApplicationContext context = new ApplicationContext())
            {
                return context.Configurations.Select(Configuration => Configuration).ToList();
            }
        }

        /// <summary>
        /// The UpdateConfiguration.
        /// </summary>
        /// <param name="configuration">The Configuration.</param>
        public void UpdateConfiguration(Configuration configuration)
        {
            using (ApplicationContext context = new ApplicationContext())
            {
                Configuration toBeUpdated = context.Configurations.Find(configuration.ID);

                if (toBeUpdated == null)
                {
                    return;
                }

                context.Entry(toBeUpdated).CurrentValues.SetValues(configuration);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// The GetConfigurationById.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The Configuration.</returns>
        public Configuration GetConfigurationById(string id)
        {
            using (var context = new ApplicationContext())
            {
                return context.Configurations.Where(Configuration => Configuration.ID == id).SingleOrDefault();
            }
        }
    }
}
