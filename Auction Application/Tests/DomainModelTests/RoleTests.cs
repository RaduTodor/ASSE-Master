// <copyright file="RoleTests.cs" company="Transilvania University of Brasov">
// Todor Radu Constantin
// </copyright>

namespace ASSE_Restanta.DomainModelTests
{
    using Auction_Application.DomainModels;
    using Auction_Application.DomainModels.Validators;
    using NUnit.Framework;

    /// <summary>
    /// Defines the <see cref="RoleTests" />.
    /// </summary>
    public class RoleTests
    {
        /// <summary>
        /// The TestRoleValidatorWithValidValues.
        /// </summary>
        [Test]
        public void TestRoleValidatorWithValidValues()
        {
            Role test = new Role()
            {
                NAME = "Buyer",
            };

            RoleValidator validator = new RoleValidator();
            var results = validator.Validate(test);

            bool isValid = results.IsValid;
            Assert.IsTrue(isValid);
        }

        /// <summary>
        /// The TestRoleValidatorWithValidValues2.
        /// </summary>
        [Test]
        public void TestRoleValidatorWithValidValues2()
        {
            Role test = new Role()
            {
                NAME = "Seller",
            };

            RoleValidator validator = new RoleValidator();
            var results = validator.Validate(test);

            bool isValid = results.IsValid;
            Assert.IsTrue(isValid);
        }

        /// <summary>
        /// The TestRoleValidatorWithValidValues3.
        /// </summary>
        [Test]
        public void TestRoleValidatorWithValidValues3()
        {
            Role test = new Role()
            {
                ID = 3,
                NAME = "Host",
            };

            RoleValidator validator = new RoleValidator();
            var results = validator.Validate(test);

            bool isValid = results.IsValid;
            Assert.IsTrue(isValid);
        }

        /// <summary>
        /// The TestRoleValidatorWithInvalidValues.
        /// </summary>
        [Test]
        public void TestRoleValidatorWithInvalidValues()
        {
            Role test = new Role()
            {
                NAME = "H",
            };

            RoleValidator validator = new RoleValidator();
            var results = validator.Validate(test);

            bool isValid = results.IsValid;
            Assert.IsFalse(isValid);
        }

        /// <summary>
        /// The TestRoleValidatorWithInvalidValues2.
        /// </summary>
        [Test]
        public void TestRoleValidatorWithInvalidValues2()
        {
            Role test = new Role()
            {
                NAME = "HostHostHostHostHostHostHostHostHostHostHostHostHostHostHost",
            };

            RoleValidator validator = new RoleValidator();
            var results = validator.Validate(test);

            bool isValid = results.IsValid;
            Assert.IsFalse(isValid);
        }

        /// <summary>
        /// The TestRoleValidatorWithInvalidValues3.
        /// </summary>
        [Test]
        public void TestRoleValidatorWithInvalidValues3()
        {
            Role test = new Role();
            RoleValidator validator = new RoleValidator();
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
            Role test = new Role
            {
                ID = 3,
                NAME = "Host",
            };

            Assert.AreEqual(test.ID, 3);
            Assert.AreEqual(test.NAME, "Host");
        }
    }
}
