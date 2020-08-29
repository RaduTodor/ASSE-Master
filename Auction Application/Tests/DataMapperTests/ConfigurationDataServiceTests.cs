// <copyright file="ConfigurationDataServiceTests.cs" company="Transilvania University of Brasov">
// Todor Radu Constantin
// </copyright>

namespace ASSE_Restanta.DataMapperTests
{
    using Auction_Application.DataMappers.Interfaces;
    using Auction_Application.DomainModels;
    using Moq;
    using NUnit.Framework;

    /// <summary>
    /// Defines the <see cref="ConfigurationDataServiceTests" />.
    /// </summary>
    public class ConfigurationDataServiceTests
    {
        /// <summary>
        /// The AddConfigurationTest.
        /// </summary>
        [Test]
        public void AddConfigurationTest()
        {
            Configuration configuration = new Mock<Configuration>().Object;

            Mock<IConfigurationDataService> mock = new Mock<IConfigurationDataService>();
            mock.Setup(m => m.AddConfiguration(configuration));

            IConfigurationDataService obj = mock.Object;
            obj.AddConfiguration(configuration);

            mock.Verify(o => o.AddConfiguration(configuration), Times.Once());
        }

        /// <summary>
        /// The DeleteConfigurationTest.
        /// </summary>
        [Test]
        public void DeleteConfigurationTest()
        {
            Configuration configuration = new Mock<Configuration>().Object;

            Mock<IConfigurationDataService> mock = new Mock<IConfigurationDataService>();
            mock.Setup(m => m.DeleteConfiguration(configuration));

            IConfigurationDataService obj = mock.Object;
            obj.DeleteConfiguration(configuration);

            mock.Verify(o => o.DeleteConfiguration(configuration), Times.Once());
        }

        /// <summary>
        /// The UpdateConfigurationTest.
        /// </summary>
        [Test]
        public void UpdateConfigurationTest()
        {
            Configuration configuration = new Mock<Configuration>().Object;

            Mock<IConfigurationDataService> mock = new Mock<IConfigurationDataService>();
            mock.Setup(m => m.UpdateConfiguration(configuration));

            IConfigurationDataService obj = mock.Object;
            obj.UpdateConfiguration(configuration);

            mock.Verify(o => o.UpdateConfiguration(configuration), Times.Once());
        }

        /// <summary>
        /// The GetAllConfigurationsTest.
        /// </summary>
        [Test]
        public void GetAllConfigurationsTest()
        {
            Mock<IConfigurationDataService> mock = new Mock<IConfigurationDataService>();
            mock.Setup(m => m.GetAllConfigurations());

            IConfigurationDataService obj = mock.Object;
            obj.GetAllConfigurations();

            mock.Verify(o => o.GetAllConfigurations(), Times.Once());
        }

        /// <summary>
        /// The GetConfigurationByIdTest.
        /// </summary>
        [Test]
        public void GetConfigurationByIdTest()
        {
            Mock<IConfigurationDataService> mock = new Mock<IConfigurationDataService>();
            mock.Setup(m => m.GetConfigurationById("test"));

            IConfigurationDataService obj = mock.Object;
            obj.GetConfigurationById("test");

            mock.Verify(o => o.GetConfigurationById("test"), Times.Once());
        }
    }
}
