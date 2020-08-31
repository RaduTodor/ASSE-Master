// <copyright file="AuctionHistoryServiceTests.cs" company="Transilvania University of Brasov">
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
    using Moq;
    using NUnit.Framework;

    /// <summary>
    /// Defines the <see cref="AuctionHistoryServiceTests" />.
    /// </summary>
    public class AuctionHistoryServiceTests
    {
        /// <summary>
        /// The TestAddAuction_HistoryWithValidData.
        /// </summary>
        [Test]
        public void TestAddAuction_HistoryWithValidData()
        {
            Auction_History auctionHistory = new Auction_History()
            {
                CURRENCY = "Euro",
                Person = new Person { ID = 1, FIRST_NAME = "Radu", LAST_NAME = "Todor", Role = new Role { ID = 2, NAME = "Buyer" }, SCORE = 9.00m, ROLE_ID = 2 },
                Auction = new Auction
                {
                    CURRENCY = "Euro",
                    Person = new Person { ID = 2, FIRST_NAME = "Radu", LAST_NAME = "Todor", Role = new Role { ID = 1, NAME = "Seller" }, SCORE = 9.00m, ROLE_ID = 1 },
                    Product = new Product { ID = 2, NAME = "Telefon", Category = new Category { ID = 2, NAME = "Dispozitive mici", PARENT_CATEGORY_ID = 1 }, PARENT_CATEGORY_ID = 2 },
                    DATE_START = DateTime.Now,
                    DATE_END = DateTime.Now.AddDays(20),
                    START_PRICE = 490,
                    OWNER_ID = 2,
                    PRODUCT_ID = 2,
                },
                DATE_CREATION = DateTime.Now,
                OFFER = 500,
            };

            IAuctionHistoryService auctionHistoryServices = new AuctionHistoryService();
            bool result = auctionHistoryServices.AddAuctionHistory(auctionHistory);

            Assert.IsTrue(result);
        }

        /// <summary>
        /// The TestAddAuction_HistoryWithInvalidData.
        /// </summary>
        [Test]
        public void TestAddAuction_HistoryWithInvalidData()
        {
            Auction_History auctionHistory = new Auction_History();

            IAuctionHistoryService readerServices = new AuctionHistoryService();
            bool result = readerServices.AddAuctionHistory(auctionHistory);

            Assert.IsFalse(result);
        }

        /// <summary>
        /// The TestDeleteAuction_HistoryWithValidData.
        /// </summary>
        [Test]
        public void TestDeleteAuction_HistoryWithValidData()
        {
            Auction_History auctionHistory = new Auction_History()
            {
                ID = 2,
                CURRENCY = "Euro",
                Person = new Person { ID = 1 },
                Auction = new Auction { ID = 1 },
                DATE_CREATION = DateTime.Now,
                OFFER = 500,
            };

            IAuctionHistoryService auctionHistoryServices = new AuctionHistoryService();
            Mock<IAuction_HistoryDataService> mock = new Mock<IAuction_HistoryDataService>();
            mock.Setup(m => m.DeleteAuction_History(auctionHistory));

            AuctionHistoryService.DataServices = mock.Object;
            bool result = auctionHistoryServices.DeleteAuctionHistory(auctionHistory);

            Assert.IsTrue(result);
        }

        /// <summary>
        /// The TestDeleteAuction_HistoryWithInvalidData.
        /// </summary>
        [Test]
        public void TestDeleteAuction_HistoryWithInvalidData()
        {
            Auction_History auctionHistory = new Auction_History();

            IAuctionHistoryService auctionHistoryServices = new AuctionHistoryService();
            bool result = auctionHistoryServices.DeleteAuctionHistory(auctionHistory);

            Assert.IsFalse(result);
        }

        /// <summary>
        /// The TestUpdateReaderWithValidData.
        /// </summary>
        [Test]
        public void TestUpdateReaderWithValidData()
        {
            Auction_History auctionHistory = new Auction_History()
            {
                ID = 2,
                CURRENCY = "Euro",
                Person = new Person { ID = 1 },
                Auction = new Auction { ID = 1 },
                DATE_CREATION = DateTime.Now,
                OFFER = 500,
            };

            IAuctionHistoryService auctionHistoryServices = new AuctionHistoryService();
            bool result = auctionHistoryServices.UpdateAuctionHistory(auctionHistory);

            Assert.IsTrue(result);
        }

        /// <summary>
        /// The TestUpdateAuction_HistoryWithInvalidData.
        /// </summary>
        [Test]
        public void TestUpdateAuction_HistoryWithInvalidData()
        {
            Auction_History auctionHistory = new Auction_History();

            IAuctionHistoryService auctionHistoryServices = new AuctionHistoryService();
            bool result = auctionHistoryServices.UpdateAuctionHistory(auctionHistory);

            Assert.IsFalse(result);
        }

        /// <summary>
        /// The TestGetListOfAuction_Histories.
        /// </summary>
        [Test]
        public void TestGetListOfAuction_Histories()
        {
            IAuctionHistoryService auctionHistoryServices = new AuctionHistoryService();
            Mock<IAuction_HistoryDataService> mock = new Mock<IAuction_HistoryDataService>();
            mock.Setup(m => m.GetAllAuction_Histories()).Returns(
                new List<Auction_History>()
                {
                    new Auction_History()
                    {
                ID = 2,
                CURRENCY = "Euro",
                Person = new Person { ID = 1 },
                Auction = new Auction { ID = 1 },
                DATE_CREATION = DateTime.Now,
                OFFER = 500,
                    }
                });

            AuctionHistoryService.DataServices = mock.Object;
            var result = auctionHistoryServices.GetListOfAuctionHistories();

            Assert.AreNotEqual(result, null);
            Assert.AreEqual((result as List<Auction_History>).Count, 1);
        }

        /// <summary>
        /// The TestGetAuction_HistoryById.
        /// </summary>
        [Test]
        public void TestGetAuction_HistoryById()
        {
            IAuctionHistoryService auctionHistoryServices = new AuctionHistoryService();
            Mock<IAuction_HistoryDataService> mock = new Mock<IAuction_HistoryDataService>();
            mock.Setup(m => m.GetAuction_HistoryById(2)).Returns(
                    new Auction_History()
                    {
                        ID = 2,
                        CURRENCY = "Euro",
                        Person = new Person { ID = 1 },
                        Auction = new Auction { ID = 1 },
                        DATE_CREATION = DateTime.Now,
                        OFFER = 500,
                    });

            AuctionHistoryService.DataServices = mock.Object;
            var result = auctionHistoryServices.GetAuctionHistoryById(2);

            Assert.AreNotEqual(result, null);
            Assert.AreEqual((result as Auction_History).ID, 2);
        }

        /// <summary>
        /// The TestGetAuction_HistoryByIdWithInvalidId.
        /// </summary>
        [Test]
        public void TestGetAuction_HistoryByIdWithInvalidId()
        {
            IAuctionHistoryService auctionHistoryServices = new AuctionHistoryService();
            Mock<IAuction_HistoryDataService> mock = new Mock<IAuction_HistoryDataService>();
            mock.Setup(m => m.GetAuction_HistoryById(10)).Returns(
                    new Auction_History()
                    {
                        ID = 2,
                        CURRENCY = "Euro",
                        Person = new Person { ID = 1 },
                        Auction = new Auction { ID = 1 },
                        DATE_CREATION = DateTime.Now,
                        OFFER = 500,
                    });

            AuctionHistoryService.DataServices = mock.Object;
            var result = auctionHistoryServices.GetAuctionHistoryById(1);

            Assert.AreEqual(result, null);
        }

        /// <summary>
        /// The TestAddNullAuction_History.
        /// </summary>
        [Test]
        public void TestAddNullAuction_History()
        {
            Auction_History auctionHistory = null;

            IAuctionHistoryService auctionHistoryServices = new AuctionHistoryService();
            Assert.Throws<ArgumentNullException>(() => auctionHistoryServices.AddAuctionHistory(auctionHistory));
        }

        /// <summary>
        /// The TestDeleteNullAuction_History.
        /// </summary>
        [Test]
        public void TestDeleteNullAuction_History()
        {
            Auction_History auctionHistory = null;

            IAuctionHistoryService auctionHistoryServices = new AuctionHistoryService();
            Assert.Throws<ArgumentNullException>(() => auctionHistoryServices.DeleteAuctionHistory(auctionHistory));
        }

        /// <summary>
        /// The TestUpdateNullAuction_History.
        /// </summary>
        [Test]
        public void TestUpdateNullAuction_History()
        {
            Auction_History auctionHistory = null;

            IAuctionHistoryService auctionHistoryServices = new AuctionHistoryService();
            Assert.Throws<ArgumentNullException>(() => auctionHistoryServices.UpdateAuctionHistory(auctionHistory));
        }

        /// <summary>
        /// The TestPlaceOfferValid.
        /// </summary>
        [Test]
        public void TestPlaceOffer()
        {
            Person person = new Person()
            {
                ID = 1,
                FIRST_NAME = "Radu",
                LAST_NAME = "Todor",
                Role = new Role { ID = 2, NAME = "Buyer" },
                ROLE_ID = 2,
                SCORE = 2.5m,
            };

            var auctionOwner = new Person()
            {
                ID = 2,
                FIRST_NAME = "Radu",
                LAST_NAME = "Todor",
                Role = new Role { ID = 2, NAME = "Seller" },
                ROLE_ID = 1,
                SCORE = 2.5m,
            };

            Auction auction = new Auction()
            {
                CURRENCY = "Euro",
                Person = auctionOwner,
                Product = new Product { ID = 2, NAME = "Telefon", Category = new Category { ID = 2, NAME = "Dispozitive mici", PARENT_CATEGORY_ID = 1 }, PARENT_CATEGORY_ID = 2 },
                DATE_START = DateTime.Now,
                DATE_END = DateTime.Now.AddDays(20),
                START_PRICE = 12,
                OWNER_ID = 2,
                PRODUCT_ID = 2,
            };

            IAuctionHistoryService personServices = new AuctionHistoryService();
            var placeOfferResult = personServices.PlaceOffer(person, auction, "Euro", 13);
            var placeOfferInvalidResult = personServices.PlaceOffer(person, auction, "Euro", 30);
            Assert.IsTrue(placeOfferResult);
            auction.ID = 26;
            var placeOfferSameValueSameAuctionResult = personServices.PlaceOffer(person, auction, "Euro", 13);
            Assert.IsFalse(placeOfferSameValueSameAuctionResult);
            Assert.IsFalse(placeOfferInvalidResult);
            auction.DATE_END = DateTime.Now.AddMinutes(-1);
            var placeOfferInvalidResultExpiredAuction = personServices.PlaceOffer(person, auction, "Euro", 15);
            Assert.IsFalse(placeOfferInvalidResultExpiredAuction);
        }
    }
}
