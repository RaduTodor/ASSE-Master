// <copyright file="CategoryTests.cs" company="Transilvania University of Brasov">
// Todor Radu Constantin
// </copyright>

namespace ASSE_Restanta.DomainModelTests
{
    using System.Collections.Generic;
    using Auction_Application.DomainModels;
    using Auction_Application.DomainModels.Validators;
    using NUnit.Framework;

    /// <summary>
    /// Defines the <see cref="CategoryTests" />.
    /// </summary>
    public class CategoryTests
    {
        /// <summary>
        /// The TestCategoryValidatorWithValidValues.
        /// </summary>
        [Test]
        public void TestCategoryValidatorWithValidValues()
        {
            Category test = new Category()
            {
                NAME = "Computers",
            };

            CategoryValidator validator = new CategoryValidator();
            var results = validator.Validate(test);

            bool isValid = results.IsValid;
            Assert.IsTrue(isValid);
        }

        /// <summary>
        /// The TestCategoryValidatorWithValidValues2.
        /// </summary>
        [Test]
        public void TestCategoryValidatorWithValidValues2()
        {
            Category test = new Category()
            {
                NAME = "Computers",
                Category2 = new Category { NAME = "Electronics", Category2 = new Category { NAME = "Home Appliances" } },
            };

            CategoryValidator validator = new CategoryValidator();
            var results = validator.Validate(test);

            bool isValid = results.IsValid;
            Assert.IsTrue(isValid);
        }

        /// <summary>
        /// The TestCategoryValidatorWithValidValues3.
        /// </summary>
        [Test]
        public void TestCategoryValidatorWithValidValues3()
        {
            Category test = new Category()
            {
                NAME = "Computers",
                Category2 = new Category { NAME = "Electronics" },
                Products = new List<Product> { new Product { NAME = "Laptop" } }
            };

            CategoryValidator validator = new CategoryValidator();
            var results = validator.Validate(test);

            bool isValid = results.IsValid;
            Assert.IsTrue(isValid);
        }

        /// <summary>
        /// The TestCategoryValidatorWithInvalidValues.
        /// </summary>
        [Test]
        public void TestCategoryValidatorWithInvalidValues()
        {
            Category test = new Category()
            {
            };

            CategoryValidator validator = new CategoryValidator();
            var results = validator.Validate(test);

            bool isValid = results.IsValid;
            Assert.IsFalse(isValid);
        }

        /// <summary>
        /// The TestCategoryValidatorWithInvalidValues2.
        /// </summary>
        [Test]
        public void TestCategoryValidatorWithInvalidValues2()
        {
            Category test = new Category()
            {
                NAME = "TooLongTooLongTooLongTooLongTooLongTooLongTooLongTooLong",
            };

            CategoryValidator validator = new CategoryValidator();
            var results = validator.Validate(test);

            bool isValid = results.IsValid;
            Assert.IsFalse(isValid);
        }

        /// <summary>
        /// The TestCategoryValidatorWithInvalidValues3.
        /// </summary>
        [Test]
        public void TestCategoryValidatorWithInvalidValues3()
        {
            Category test = new Category()
            {
                NAME = "C",
            };

            CategoryValidator validator = new CategoryValidator();
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
            Category test = new Category
            {
                ID = 1,
                NAME = "Computers",
                Category2 = new Category { NAME = "Electronics" },
            };

            Assert.AreEqual(test.ID, 1);
            Assert.AreEqual(test.NAME, "Computers");
            Assert.AreEqual(test.Category2.NAME, "Electronics");
        }
    }
}
