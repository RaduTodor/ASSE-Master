// <copyright file="ConfigurationTests.cs" company="Transilvania University of Brasov">
// Todor Radu Constantin
// </copyright>

namespace ASSE_Restanta.DomainModelTests
{
    using Auction_Application.DomainModels;
    using Auction_Application.DomainModels.Validators;
    using NUnit.Framework;

    /// <summary>
    /// Defines the <see cref="ConfigurationTests" />.
    /// </summary>
    public class ConfigurationTests
    {
        /// <summary>
        /// The TestConfigurationValidatorWithValidValues.
        /// </summary>
        [Test]
        public void TestConfigurationValidatorWithValidValues()
        {
            Configuration test = new Configuration()
            {
                ID = "Config",
                VALUE = 5000,
            };

            ConfigurationValidator validator = new ConfigurationValidator();
            var results = validator.Validate(test);

            bool isValid = results.IsValid;
            Assert.IsTrue(isValid);
        }

        /// <summary>
        /// The TestConfigurationValidatorWithValidValues2.
        /// </summary>
        [Test]
        public void TestConfigurationValidatorWithValidValues2()
        {
            Configuration test = new Configuration()
            {
                ID = "Config2",
                VALUE = -1,
            };

            ConfigurationValidator validator = new ConfigurationValidator();
            var results = validator.Validate(test);

            bool isValid = results.IsValid;
            Assert.IsTrue(isValid);
        }

        /// <summary>
        /// The TestConfigurationValidatorWithValidValues3.
        /// </summary>
        [Test]
        public void TestConfigurationValidatorWithValidValues3()
        {
            Configuration test = new Configuration()
            {
                ID = "Config3",
                VALUE = 1,
            };

            ConfigurationValidator validator = new ConfigurationValidator();
            var results = validator.Validate(test);

            bool isValid = results.IsValid;
            Assert.IsTrue(isValid);
        }

        /// <summary>
        /// The TestConfigurationValidatorWithInvalidValues.
        /// </summary>
        [Test]
        public void TestConfigurationValidatorWithInvalidValues()
        {
            Configuration test = new Configuration()
            {
                ID = "Config",
            };

            ConfigurationValidator validator = new ConfigurationValidator();
            var results = validator.Validate(test);

            bool isValid = results.IsValid;
            Assert.IsFalse(isValid);
        }

        /// <summary>
        /// The TestConfigurationValidatorWithInvalidValues2.
        /// </summary>
        [Test]
        public void TestConfigurationValidatorWithInvalidValues2()
        {
            Configuration test = new Configuration()
            {
                ID = "TooLongTooLongTooLongTooLongTooLongTooLongTooLongTooLong",
                VALUE = 2,
            };

            ConfigurationValidator validator = new ConfigurationValidator();
            var results = validator.Validate(test);

            bool isValid = results.IsValid;
            Assert.IsFalse(isValid);
        }

        /// <summary>
        /// The TestConfigurationValidatorWithInvalidValues3.
        /// </summary>
        [Test]
        public void TestConfigurationValidatorWithInvalidValues3()
        {
            Configuration test = new Configuration()
            {
                ID = "C",
                VALUE = 2,
            };

            ConfigurationValidator validator = new ConfigurationValidator();
            var results = validator.Validate(test);

            bool isValid = results.IsValid;
            Assert.IsFalse(isValid);
        }

        /// <summary>
        /// The TestConfigurationValidatorWithInvalidValues4.
        /// </summary>
        [Test]
        public void TestConfigurationValidatorWithInvalidValues4()
        {
            Configuration test = new Configuration()
            {
                VALUE = 2,
            };

            ConfigurationValidator validator = new ConfigurationValidator();
            var results = validator.Validate(test);

            bool isValid = results.IsValid;
            Assert.IsFalse(isValid);
        }

        /// <summary>
        /// The TestProperties.
        /// </summary>
        [Test]
        public void TestProperties()
        {
            Configuration test = new Configuration
            {
                ID = "Config",
                VALUE = 5000,
            };

            Assert.AreEqual(test.VALUE, 5000);
            Assert.AreEqual(test.ID, "Config");
        }
    }
}
