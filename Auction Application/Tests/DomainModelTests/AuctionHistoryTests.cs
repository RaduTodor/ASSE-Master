// <copyright file="AuctionHistoryTests.cs" company="Transilvania University of Brasov">
// Todor Radu Constantin
// </copyright>

namespace ASSE_Restanta.DomainModelTests
{
    using System;
    using Auction_Application.DomainModels;
    using Auction_Application.DomainModels.Validators;
    using NUnit.Framework;

    /// <summary>
    /// Defines the <see cref="Auction_HistoryTests" />.
    /// </summary>
    public class AuctionHistoryTests
    {
        /// <summary>
        /// The TestAuctionHistoryValidatorWithValidValues.
        /// </summary>
        [Test]
        public void TestAuctionHistoryValidatorWithValidValues()
        {
            Auction_History test = new Auction_History()
            {
                CURRENCY = "Euro",
                Person = new Person { ID = 1 },
                Auction = new Auction { ID = 1 },
                DATE_CREATION = DateTime.Now,
                OFFER = 500,
            };

            AuctionHistoryValidator validator = new AuctionHistoryValidator();
            var results = validator.Validate(test);

            bool isValid = results.IsValid;
            Assert.IsTrue(isValid);
        }

        /// <summary>
        /// The TestAuctionHistoryValidatorWithValidValues2.
        /// </summary>
        [Test]
        public void TestAuctionHistoryValidatorWithValidValues2()
        {
            Auction_History test = new Auction_History()
            {
                CURRENCY = "Dollar",
                Person = new Person { ID = 2 },
                Auction = new Auction { ID = 1 },
                DATE_CREATION = DateTime.Now.AddDays(2),
                OFFER = 1,
            };

            AuctionHistoryValidator validator = new AuctionHistoryValidator();
            var results = validator.Validate(test);

            bool isValid = results.IsValid;
            Assert.IsTrue(isValid);
        }

        /// <summary>
        /// The TestAuctionHistoryValidatorWithValidValues3.
        /// </summary>
        [Test]
        public void TestAuctionHistoryValidatorWithValidValues3()
        {
            Auction_History test = new Auction_History()
            {
                CURRENCY = "Ron",
                Person = new Person { ID = 5 },
                Auction = new Auction { ID = 0 },
                DATE_CREATION = DateTime.Now.AddDays(-2),
                OFFER = 600,
            };

            AuctionHistoryValidator validator = new AuctionHistoryValidator();
            var results = validator.Validate(test);

            bool isValid = results.IsValid;
            Assert.IsTrue(isValid);
        }

        /// <summary>
        /// The TestAuctionHistoryValidatorWithValidValues.
        /// </summary>
        [Test]
        public void TestAuctionHistoryValidatorWithInvalidValues()
        {
            Auction_History test = new Auction_History()
            {
                CURRENCY = "Ron",
                Person = new Person { ID = 5 },
                DATE_CREATION = DateTime.Now.AddDays(-2),
                OFFER = 600,
            };

            AuctionHistoryValidator validator = new AuctionHistoryValidator();
            var results = validator.Validate(test);

            bool isValid = results.IsValid;
            Assert.IsFalse(isValid);
        }

        /// <summary>
        /// The TestAuctionHistoryValidatorWithInvalidValues2.
        /// </summary>
        [Test]
        public void TestAuctionHistoryValidatorWithInvalidValues2()
        {
            Auction_History test = new Auction_History()
            {
                CURRENCY = "Ron",
                Auction = new Auction { ID = 0 },
                DATE_CREATION = DateTime.Now.AddDays(-2),
                OFFER = 600,
            };

            AuctionHistoryValidator validator = new AuctionHistoryValidator();
            var results = validator.Validate(test);

            bool isValid = results.IsValid;
            Assert.IsFalse(isValid);
        }

        /// <summary>
        /// The TestAuctionHistoryValidatorWithInvalidValues3.
        /// </summary>
        [Test]
        public void TestAuctionHistoryValidatorWithInvalidValues3()
        {
            Auction_History test = new Auction_History()
            {
                CURRENCY = "Ron",
                Person = new Person { ID = 5 },
                Auction = new Auction { ID = 0 },
                OFFER = 600,
            };

            AuctionHistoryValidator validator = new AuctionHistoryValidator();
            var results = validator.Validate(test);

            bool isValid = results.IsValid;
            Assert.IsFalse(isValid);
        }

        /// <summary>
        /// The TestAuctionHistoryValidatorWithInvalidValues4.
        /// </summary>
        [Test]
        public void TestAuctionHistoryValidatorWithInvalidValues4()
        {
            Auction_History test = new Auction_History()
            {
                CURRENCY = "Ron",
                Person = new Person { ID = 5 },
                Auction = new Auction { ID = 0 },
                DATE_CREATION = DateTime.Now.AddDays(-2),
            };

            AuctionHistoryValidator validator = new AuctionHistoryValidator();
            var results = validator.Validate(test);

            bool isValid = results.IsValid;
            Assert.IsFalse(isValid);
        }

        /// <summary>
        /// The TestAuctionHistoryValidatorWithInvalidValues5.
        /// </summary>
        [Test]
        public void TestAuctionHistoryValidatorWithInvalidValues5()
        {
            Auction_History test = new Auction_History()
            {
                CURRENCY = "Ron",
                Person = new Person { ID = 5 },
                Auction = new Auction { ID = 0 },
                OFFER = -1,
            };

            AuctionHistoryValidator validator = new AuctionHistoryValidator();
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
            Auction_History test = new Auction_History
            {
                ID = 1,
                CURRENCY = "Euro",
                Person = new Person { ID = 1 },
                Auction = new Auction { ID = 1 },
                DATE_CREATION = date,
                OFFER = 500
            };

            Assert.AreEqual(test.ID, 1);
            Assert.AreEqual(test.CURRENCY, "Euro");
            Assert.AreEqual(test.Person.ID, 1);
            Assert.AreEqual(test.Auction.ID, 1);
            Assert.AreEqual(test.DATE_CREATION, date);
            Assert.AreEqual(test.OFFER, 500);
        }
    }
}
