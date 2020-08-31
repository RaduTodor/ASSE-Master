// <copyright file="ConfigurationServiceTests.cs" company="Transilvania University of Brasov">
// Todor Radu Constantin
// </copyright>

namespace ASSE_Restanta.Tests.ServiceTests
{
    using System;
    using System.Collections.Generic;
    using Auction_Application.DataMappers.Interfaces;
    using Auction_Application.DomainModels;
    using Auction_Application.Services.Implementation;
    using Auction_Application.Services.Interfaces;
    using Auction_Application.Utility;
    using Moq;
    using NUnit.Framework;

    /// <summary>
    /// Defines the <see cref="ConfigurationServiceTests" />.
    /// </summary>
    public class ConfigurationServiceTests
    {
        /// <summary>
        /// The TestAddConfigurationWithValidData.
        /// </summary>
        [Test]
        public void TestAddConfigurationWithValidData()
        {
            var randomConfigIdValue = RandomGenerators.RandomString(10);
            Configuration configuration = new Configuration()
            {
                ID = randomConfigIdValue,
                VALUE = 5000,
            };

            IConfigurationService configurationServices = new ConfigurationService();
            bool result = configurationServices.AddConfiguration(configuration);

            Assert.IsTrue(result);
        }

        /// <summary>
        /// The TestAddConfigurationWithInvalidData.
        /// </summary>
        [Test]
        public void TestAddConfigurationWithInvalidData()
        {
            Configuration configuration = new Configuration();

            IConfigurationService readerServices = new ConfigurationService();
            bool result = readerServices.AddConfiguration(configuration);

            Assert.IsFalse(result);
        }

        /// <summary>
        /// The TestDeleteConfigurationWithValidData.
        /// </summary>
        [Test]
        public void TestDeleteConfigurationWithValidData()
        {
            Configuration configuration = new Configuration()
            {
                ID = "Config",
                VALUE = 5000,
            };

            IConfigurationService configurationServices = new ConfigurationService();
            Mock<IConfigurationDataService> mock = new Mock<IConfigurationDataService>();
            mock.Setup(m => m.DeleteConfiguration(configuration));

            ConfigurationService.DataServices = mock.Object;
            bool result = configurationServices.DeleteConfiguration(configuration);

            Assert.IsTrue(result);
        }

        /// <summary>
        /// The TestDeleteConfigurationWithInvalidData.
        /// </summary>
        [Test]
        public void TestDeleteConfigurationWithInvalidData()
        {
            Configuration configuration = new Configuration();

            IConfigurationService configurationServices = new ConfigurationService();
            bool result = configurationServices.DeleteConfiguration(configuration);

            Assert.IsFalse(result);
        }

        /// <summary>
        /// The TestUpdateReaderWithValidData.
        /// </summary>
        [Test]
        public void TestUpdateReaderWithValidData()
        {
            Configuration configuration = new Configuration()
            {
                ID = "Config",
                VALUE = 5000,
            };

            IConfigurationService configurationServices = new ConfigurationService();
            bool result = configurationServices.UpdateConfiguration(configuration);

            Assert.IsTrue(result);
        }

        /// <summary>
        /// The TestUpdateConfigurationWithInvalidData.
        /// </summary>
        [Test]
        public void TestUpdateConfigurationWithInvalidData()
        {
            Configuration configuration = new Configuration();

            IConfigurationService configurationServices = new ConfigurationService();
            bool result = configurationServices.UpdateConfiguration(configuration);

            Assert.IsFalse(result);
        }

        /// <summary>
        /// The TestGetListOfConfigurations.
        /// </summary>
        [Test]
        public void TestGetListOfConfigurations()
        {
            IConfigurationService configurationServices = new ConfigurationService();
            Mock<IConfigurationDataService> mock = new Mock<IConfigurationDataService>();
            mock.Setup(m => m.GetAllConfigurations()).Returns(
                new List<Configuration>()
                {
                    new Configuration()
                    {
                ID = "Config",
                VALUE = 5000,
                    }
                });

            ConfigurationService.DataServices = mock.Object;
            var result = configurationServices.GetListOfConfigurations();

            Assert.AreNotEqual(result, null);
            Assert.AreEqual((result as List<Configuration>).Count, 1);
        }

        /// <summary>
        /// The TestGetConfigurationById.
        /// </summary>
        [Test]
        public void TestGetConfigurationById()
        {
            IConfigurationService configurationServices = new ConfigurationService();
            Mock<IConfigurationDataService> mock = new Mock<IConfigurationDataService>();
            mock.Setup(m => m.GetConfigurationById("Config")).Returns(
                    new Configuration()
                    {
                        ID = "Config",
                        VALUE = 5000,
                    });

            ConfigurationService.DataServices = mock.Object;
            var result = configurationServices.GetConfigurationById("Config");

            Assert.AreNotEqual(result, null);
            Assert.AreEqual((result as Configuration).ID, "Config");
        }

        /// <summary>
        /// The TestGetConfigurationByIdWithInvalidId.
        /// </summary>
        [Test]
        public void TestGetConfigurationByIdWithInvalidId()
        {
            IConfigurationService configurationServices = new ConfigurationService();
            Mock<IConfigurationDataService> mock = new Mock<IConfigurationDataService>();
            mock.Setup(m => m.GetConfigurationById("Config")).Returns(
                    new Configuration()
                    {
                        ID = "Config",
                        VALUE = 5000,
                    });

            ConfigurationService.DataServices = mock.Object;
            var result = configurationServices.GetConfigurationById("Config2");

            Assert.AreEqual(result, null);
        }

        /// <summary>
        /// The TestAddNullConfiguration.
        /// </summary>
        [Test]
        public void TestAddNullConfiguration()
        {
            Configuration configuration = null;

            IConfigurationService configurationServices = new ConfigurationService();
            Assert.Throws<ArgumentNullException>(() => configurationServices.AddConfiguration(configuration));
        }

        /// <summary>
        /// The TestDeleteNullConfiguration.
        /// </summary>
        [Test]
        public void TestDeleteNullConfiguration()
        {
            Configuration configuration = null;

            IConfigurationService configurationServices = new ConfigurationService();
            Assert.Throws<ArgumentNullException>(() => configurationServices.DeleteConfiguration(configuration));
        }

        /// <summary>
        /// The TestUpdateNullConfiguration.
        /// </summary>
        [Test]
        public void TestUpdateNullConfiguration()
        {
            Configuration configuration = null;

            IConfigurationService configurationServices = new ConfigurationService();
            Assert.Throws<ArgumentNullException>(() => configurationServices.UpdateConfiguration(configuration));
        }
    }
}
