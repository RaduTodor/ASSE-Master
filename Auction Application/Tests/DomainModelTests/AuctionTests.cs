// <copyright file="AuctionTests.cs" company="Transilvania University of Brasov">
// Todor Radu Constantin
// </copyright>

namespace ASSE_Restanta.DomainModelTests
{
    using System;
    using Auction_Application.DomainModels;
    using Auction_Application.DomainModels.Validators;
    using NUnit.Framework;

    /// <summary>
    /// Defines the <see cref="AuctionTests" />.
    /// </summary>
    public class AuctionTests
    {
        /// <summary>
        /// The TestAuctionValidatorWithValidValues.
        /// </summary>
        [Test]
        public void TestAuctionValidatorWithValidValues()
        {
            Auction test = new Auction()
            {
                CURRENCY = "Euro",
                Person = new Person { ID = 1 },
                Product = new Product { ID = 1 },
                DATE_START = DateTime.Now,
                DATE_END = DateTime.Now.AddDays(20),
                START_PRICE = 12,
            };

            AuctionValidator validator = new AuctionValidator();
            var results = validator.Validate(test);

            bool isValid = results.IsValid;
            Assert.IsTrue(isValid);
        }

        /// <summary>
        /// The TestAuctionValidatorWithValidValues2.
        /// </summary>
        [Test]
        public void TestAuctionValidatorWithValidValues2()
        {
            Auction test = new Auction()
            {
                CURRENCY = "Dollar",
                Person = new Person { ID = 0 },
                Product = new Product { ID = 0 },
                DATE_START = DateTime.Now,
                DATE_END = DateTime.Now.AddDays(1),
                START_PRICE = 30,
            };

            AuctionValidator validator = new AuctionValidator();
            var results = validator.Validate(test);

            bool isValid = results.IsValid;
            Assert.IsTrue(isValid);
        }

        /// <summary>
        /// The TestAuctionValidatorWithValidValues3.
        /// </summary>
        [Test]
        public void TestAuctionValidatorWithValidValues3()
        {
            Auction test = new Auction()
            {
                CURRENCY = "Ron",
                Person = new Person { ID = 5 },
                Product = new Product { ID = 50 },
                DATE_START = DateTime.Now.AddMinutes(-59),
                DATE_END = DateTime.Now.AddMonths(3),
                START_PRICE = 10,
            };

            AuctionValidator validator = new AuctionValidator();
            var results = validator.Validate(test);

            bool isValid = results.IsValid;
            Assert.IsTrue(isValid);
        }

        /// <summary>
        /// The TestAuctionValidatorWithInvalidValues.
        /// </summary>
        [Test]
        public void TestAuctionValidatorWithInvalidValues()
        {
            Auction test = new Auction()
            {
                CURRENCY = "Euro",
                Person = new Person { ID = 1 },
                Product = new Product { ID = 1 },
                DATE_START = DateTime.Now.AddDays(-1),
                DATE_END = DateTime.Now.AddDays(20),
                START_PRICE = 12,
            };

            AuctionValidator validator = new AuctionValidator();
            var results = validator.Validate(test);

            bool isValid = results.IsValid;
            Assert.IsFalse(isValid);
        }

        /// <summary>
        /// The TestAuctionValidatorWithInvalidValues2.
        /// </summary>
        [Test]
        public void TestAuctionValidatorWithInvalidValues2()
        {
            Auction test = new Auction()
            {
                CURRENCY = "Euro",
                Person = new Person { ID = 1 },
                Product = new Product { ID = 1 },
                DATE_START = DateTime.Now,
                DATE_END = DateTime.Now.AddMonths(5),
                START_PRICE = 12,
            };

            AuctionValidator validator = new AuctionValidator();
            var results = validator.Validate(test);

            bool isValid = results.IsValid;
            Assert.IsFalse(isValid);
        }

        /// <summary>
        /// The TestAuctionValidatorWithInvalidValues3.
        /// </summary>
        [Test]
        public void TestAuctionValidatorWithInvalidValues3()
        {
            Auction test = new Auction()
            {
                CURRENCY = "Euro",
                Person = new Person { ID = 1 },
                Product = new Product { ID = 1 },
                DATE_START = DateTime.Now,
                DATE_END = DateTime.Now.AddDays(20),
                START_PRICE = 5,
            };

            AuctionValidator validator = new AuctionValidator();
            var results = validator.Validate(test);

            bool isValid = results.IsValid;
            Assert.IsFalse(isValid);
        }

        /// <summary>
        /// The TestAuctionValidatorWithInvalidValues4.
        /// </summary>
        [Test]
        public void TestAuctionValidatorWithInvalidValues4()
        {
            Auction test = new Auction()
            {
                Person = new Person { ID = 1 },
                Product = new Product { ID = 1 },
                DATE_START = DateTime.Now,
                DATE_END = DateTime.Now.AddDays(20),
                START_PRICE = 12,
            };

            AuctionValidator validator = new AuctionValidator();
            var results = validator.Validate(test);

            bool isValid = results.IsValid;
            Assert.IsFalse(isValid);
        }

        /// <summary>
        /// The TestAuctionValidatorWithInvalidValues5.
        /// </summary>
        [Test]
        public void TestAuctionValidatorWithInvalidValues5()
        {
            Auction test = new Auction()
            {
                CURRENCY = "Euro",
                Product = new Product { ID = 1 },
                DATE_START = DateTime.Now,
                DATE_END = DateTime.Now.AddDays(20),
                START_PRICE = 12,
            };

            AuctionValidator validator = new AuctionValidator();
            var results = validator.Validate(test);

            bool isValid = results.IsValid;
            Assert.IsFalse(isValid);
        }

        /// <summary>
        /// The TestAuctionValidatorWithInvalidValues6.
        /// </summary>
        [Test]
        public void TestAuctionValidatorWithInvalidValues6()
        {
            Auction test = new Auction()
            {
                CURRENCY = "Euro",
                Person = new Person { ID = 1 },
                DATE_START = DateTime.Now,
                DATE_END = DateTime.Now.AddDays(20),
                START_PRICE = 12,
            };

            AuctionValidator validator = new AuctionValidator();
            var results = validator.Validate(test);

            bool isValid = results.IsValid;
            Assert.IsFalse(isValid);
        }

        /// <summary>
        /// The TestAuctionValidatorWithInvalidValues7.
        /// </summary>
        [Test]
        public void TestAuctionValidatorWithInvalidValues7()
        {
            Auction test = new Auction()
            {
                CURRENCY = "Euro",
                Person = new Person { ID = 1 },
                Product = new Product { ID = 1 },
                DATE_END = DateTime.Now.AddDays(20),
                START_PRICE = 12,
            };

            AuctionValidator validator = new AuctionValidator();
            var results = validator.Validate(test);

            bool isValid = results.IsValid;
            Assert.IsFalse(isValid);
        }

        /// <summary>
        /// The TestAuctionValidatorWithInvalidValues8.
        /// </summary>
        [Test]
        public void TestAuctionValidatorWithInvalidValues8()
        {
            Auction test = new Auction()
            {
                CURRENCY = "Euro",
                Person = new Person { ID = 1 },
                Product = new Product { ID = 1 },
                DATE_START = DateTime.Now,
                START_PRICE = 12,
            };

            AuctionValidator validator = new AuctionValidator();
            var results = validator.Validate(test);

            bool isValid = results.IsValid;
            Assert.IsFalse(isValid);
        }

        /// <summary>
        /// The TestAuctionValidatorWithInvalidValues9.
        /// </summary>
        [Test]
        public void TestAuctionValidatorWithInvalidValues9()
        {
            Auction test = new Auction()
            {
                CURRENCY = "Euro",
                Person = new Person { ID = 1 },
                Product = new Product { ID = 1 },
                DATE_START = DateTime.Now,
                DATE_END = DateTime.Now.AddDays(20),
            };

            AuctionValidator validator = new AuctionValidator();
            var results = validator.Validate(test);

            bool isValid = results.IsValid;
            Assert.IsFalse(isValid);
        }

        /// <summary>
        /// The TestAuctionValidatorWithInvalidValues10.
        /// </summary>
        [Test]
        public void TestAuctionValidatorWithInvalidValues10()
        {
            Auction test = new Auction()
            {
                CURRENCY = "TooLongTooLongTooLongTooLongTooLongTooLongTooLongTooLong",
                Person = new Person { ID = 1 },
                Product = new Product { ID = 1 },
                DATE_START = DateTime.Now,
                DATE_END = DateTime.Now.AddDays(20),
            };

            AuctionValidator validator = new AuctionValidator();
            var results = validator.Validate(test);

            bool isValid = results.IsValid;
            Assert.IsFalse(isValid);
        }

        /// <summary>
        /// The TestAuctionValidatorWithInvalidValues11.
        /// </summary>
        [Test]
        public void TestAuctionValidatorWithInvalidValues11()
        {
            Auction test = new Auction()
            {
                CURRENCY = "s",
                Person = new Person { ID = 1 },
                Product = new Product { ID = 1 },
                DATE_START = DateTime.Now,
                DATE_END = DateTime.Now.AddDays(20),
            };

            AuctionValidator validator = new AuctionValidator();
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
            var date = DateTime.Now;
            Auction test = new Auction
            {
                ID = 1,
                CURRENCY = "Euro",
                Person = new Person { ID = 1 },
                Product = new Product { ID = 1 },
                DATE_START = date,
                DATE_END = date.AddDays(20),
                START_PRICE = 12,
            };

            Assert.AreEqual(test.ID, 1);
            Assert.AreEqual(test.CURRENCY, "Euro");
            Assert.AreEqual(test.Person.ID, 1);
            Assert.AreEqual(test.Product.ID, 1);
            Assert.AreEqual(test.DATE_START, date);
            Assert.AreEqual(test.DATE_END, date.AddDays(20));
            Assert.AreEqual(test.START_PRICE, 12);
        }
    }
}
