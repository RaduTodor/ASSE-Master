// <copyright file="ProductTests.cs" company="Transilvania University of Brasov">
// Todor Radu Constantin
// </copyright>

namespace ASSE_Restanta.DomainModelTests
{
    using Auction_Application.DomainModels;
    using Auction_Application.DomainModels.Validators;
    using NUnit.Framework;

    /// <summary>
    /// Defines the <see cref="ProductTests" />.
    /// </summary>
    public class ProductTests
    {
        /// <summary>
        /// The TestProductValidatorWithValidValues.
        /// </summary>
        [Test]
        public void TestProductValidatorWithValidValues()
        {
            Product test = new Product()
            {
                NAME = "Photocamera",
                Category = new Category { ID = 2, NAME = "Electronics" },
            };

            ProductValidator validator = new ProductValidator();
            var results = validator.Validate(test);

            bool isValid = results.IsValid;
            Assert.IsTrue(isValid);
        }

        /// <summary>
        /// The TestProductValidatorWithValidValues2.
        /// </summary>
        [Test]
        public void TestProductValidatorWithValidValues2()
        {
            Product test = new Product()
            {
                NAME = "Phone",
                Category = new Category { ID = 2, NAME = "Electronics" },
                ID = 7,
            };

            ProductValidator validator = new ProductValidator();
            var results = validator.Validate(test);

            bool isValid = results.IsValid;
            Assert.IsTrue(isValid);
        }

        /// <summary>
        /// The TestProductValidatorWithValidValues3.
        /// </summary>
        [Test]
        public void TestProductValidatorWithValidValues3()
        {
            Product test = new Product()
            {
                NAME = "Fridge",
                Category = new Category { ID = 5 },
            };

            ProductValidator validator = new ProductValidator();
            var results = validator.Validate(test);

            bool isValid = results.IsValid;
            Assert.IsTrue(isValid);
        }

        /// <summary>
        /// The TestProductValidatorWithInvalidValues.
        /// </summary>
        [Test]
        public void TestProductValidatorWithInvalidValues()
        {
            Product test = new Product()
            {
                Category = new Category { ID = 5 },
            };

            ProductValidator validator = new ProductValidator();
            var results = validator.Validate(test);

            bool isValid = results.IsValid;
            Assert.IsFalse(isValid);
        }

        /// <summary>
        /// The TestProductValidatorWithInvalidValues2.
        /// </summary>
        [Test]
        public void TestProductValidatorWithInvalidValues2()
        {
            Product test = new Product()
            {
                NAME = "Fridge",
            };

            ProductValidator validator = new ProductValidator();
            var results = validator.Validate(test);

            bool isValid = results.IsValid;
            Assert.IsFalse(isValid);
        }

        /// <summary>
        /// The TestProductValidatorWithInvalidValues3.
        /// </summary>
        [Test]
        public void TestProductValidatorWithInvalidValues3()
        {
            Product test = new Product()
            {
                NAME = "F",
                Category = new Category { ID = 5 },
            };

            ProductValidator validator = new ProductValidator();
            var results = validator.Validate(test);

            bool isValid = results.IsValid;
            Assert.IsFalse(isValid);
        }

        /// <summary>
        /// The TestProductValidatorWithInvalidValues4.
        /// </summary>
        [Test]
        public void TestProductValidatorWithInvalidValues4()
        {
            Product test = new Product()
            {
                NAME = "FridgeFridgeFridgeFridgeFridgeFridgeFridgeFridgeFridgeFridge",
                Category = new Category { ID = 5 },
            };

            ProductValidator validator = new ProductValidator();
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
            Product test = new Product
            {
                ID = 1,
                NAME = "Phone",
                Category = new Category { ID = 2, NAME = "Electronics" },
            };

            Assert.AreEqual(test.ID, 1);
            Assert.AreEqual(test.NAME, "Phone");
            Assert.AreEqual(test.Category.NAME, "Electronics");
            Assert.AreEqual(test.Category.ID, 2);
        }
    }
}
