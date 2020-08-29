// <copyright file="AuctionServiceTests.cs" company="Transilvania University of Brasov">
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
    /// Defines the <see cref="AuctionServiceTests" />.
    /// </summary>
    public class AuctionServiceTests
    {
        /// <summary>
        /// The TestAddAuctionWithValidData.
        /// </summary>
        [Test]
        public void TestAddAuctionWithValidData()
        {
            Auction auction = new Auction()
            {
                CURRENCY = "Euro",
                Person = new Person { ID = 1, FIRST_NAME = "Radu", LAST_NAME = "Todor", Role = new Role { ID = 1 }, SCORE = 9.00m, ROLE_ID = 1 },
                Product = new Product { ID = 2, NAME = "Telefon", Category = new Category { ID = 2 }, PARENT_CATEGORY_ID = 2 },
                DATE_START = DateTime.Now,
                DATE_END = DateTime.Now.AddDays(20),
                START_PRICE = 12,
                OWNER_ID = 1,
                PRODUCT_ID = 2,
            };

            IAuctionService auctionServices = new AuctionService();
            bool result = auctionServices.AddAuction(auction);

            Assert.IsTrue(result);
        }

        /// <summary>
        /// The TestAddAuctionWithInvalidData.
        /// </summary>
        [Test]
        public void TestAddAuctionWithInvalidData()
        {
            Auction auction = new Auction();

            IAuctionService readerServices = new AuctionService();
            bool result = readerServices.AddAuction(auction);

            Assert.IsFalse(result);
        }

        /// <summary>
        /// The TestDeleteAuctionWithValidData.
        /// </summary>
        [Test]
        public void TestDeleteAuctionWithValidData()
        {
            Auction auction = new Auction()
            {
                ID = 2,
                CURRENCY = "Euro",
                Person = new Person { ID = 1 },
                Product = new Product { ID = 1 },
                DATE_START = DateTime.Now,
                DATE_END = DateTime.Now.AddDays(20),
                START_PRICE = 12,
            };

            IAuctionService auctionServices = new AuctionService();
            Mock<IAuctionDataService> mock = new Mock<IAuctionDataService>();
            mock.Setup(m => m.DeleteAuction(auction));

            AuctionService.DataServices = mock.Object;
            bool result = auctionServices.DeleteAuction(auction);

            Assert.IsTrue(result);
        }

        /// <summary>
        /// The TestDeleteAuctionWithInvalidData.
        /// </summary>
        [Test]
        public void TestDeleteAuctionWithInvalidData()
        {
            Auction auction = new Auction();

            IAuctionService auctionServices = new AuctionService();
            bool result = auctionServices.DeleteAuction(auction);

            Assert.IsFalse(result);
        }

        /// <summary>
        /// The TestUpdateReaderWithValidData.
        /// </summary>
        [Test]
        public void TestUpdateReaderWithValidData()
        {
            Auction auction = new Auction()
            {
                ID = 2,
                CURRENCY = "Euro",
                Person = new Person { ID = 1 },
                Product = new Product { ID = 1 },
                DATE_START = DateTime.Now,
                DATE_END = DateTime.Now.AddDays(20),
                START_PRICE = 12,
            };

            IAuctionService auctionServices = new AuctionService();
            bool result = auctionServices.UpdateAuction(auction);

            Assert.IsTrue(result);
        }

        /// <summary>
        /// The TestUpdateAuctionWithInvalidData.
        /// </summary>
        [Test]
        public void TestUpdateAuctionWithInvalidData()
        {
            Auction auction = new Auction();

            IAuctionService auctionServices = new AuctionService();
            bool result = auctionServices.UpdateAuction(auction);

            Assert.IsFalse(result);
        }

        /// <summary>
        /// The TestGetListOfAuctions.
        /// </summary>
        [Test]
        public void TestGetListOfAuctions()
        {
            IAuctionService auctionServices = new AuctionService();
            Mock<IAuctionDataService> mock = new Mock<IAuctionDataService>();
            mock.Setup(m => m.GetAllAuctions()).Returns(
                new List<Auction>()
                {
                    new Auction()
                    {
                        ID = 2,
                        CURRENCY = "Euro",
                        Person = new Person { ID = 1 },
                        Product = new Product { ID = 1 },
                        DATE_START = DateTime.Now,
                        DATE_END = DateTime.Now.AddDays(20),
                        START_PRICE = 12,
                    }
                });

            AuctionService.DataServices = mock.Object;
            var result = auctionServices.GetListOfAuctions();

            Assert.AreNotEqual(result, null);
            Assert.AreEqual((result as List<Auction>).Count, 1);
        }

        /// <summary>
        /// The TestGetAuctionById.
        /// </summary>
        [Test]
        public void TestGetAuctionById()
        {
            IAuctionService auctionServices = new AuctionService();
            Mock<IAuctionDataService> mock = new Mock<IAuctionDataService>();
            mock.Setup(m => m.GetAuctionById(2)).Returns(
                    new Auction()
                    {
                        ID = 2,
                        CURRENCY = "Euro",
                        Person = new Person { ID = 1 },
                        Product = new Product { ID = 1 },
                        DATE_START = DateTime.Now,
                        DATE_END = DateTime.Now.AddDays(20),
                        START_PRICE = 12,
                    });

            AuctionService.DataServices = mock.Object;
            var result = auctionServices.GetAuctionById(2);

            Assert.AreNotEqual(result, null);
            Assert.AreEqual((result as Auction).ID, 2);
        }

        /// <summary>
        /// The TestGetAuctionByIdWithInvalidId.
        /// </summary>
        [Test]
        public void TestGetAuctionByIdWithInvalidId()
        {
            IAuctionService auctionServices = new AuctionService();
            Mock<IAuctionDataService> mock = new Mock<IAuctionDataService>();
            mock.Setup(m => m.GetAuctionById(10)).Returns(
                    new Auction()
                    {
                        ID = 2,
                        CURRENCY = "Euro",
                        Person = new Person { ID = 1 },
                        Product = new Product { ID = 1 },
                        DATE_START = DateTime.Now,
                        DATE_END = DateTime.Now.AddDays(20),
                        START_PRICE = 12,
                    });

            AuctionService.DataServices = mock.Object;
            var result = auctionServices.GetAuctionById(1);

            Assert.AreEqual(result, null);
        }

        /// <summary>
        /// The TestAddNullAuction.
        /// </summary>
        [Test]
        public void TestAddNullAuction()
        {
            Auction auction = null;

            IAuctionService auctionServices = new AuctionService();
            Assert.Throws<ArgumentNullException>(() => auctionServices.AddAuction(auction));
        }

        /// <summary>
        /// The TestDeleteNullAuction.
        /// </summary>
        [Test]
        public void TestDeleteNullAuction()
        {
            Auction auction = null;

            IAuctionService auctionServices = new AuctionService();
            Assert.Throws<ArgumentNullException>(() => auctionServices.DeleteAuction(auction));
        }

        /// <summary>
        /// The TestUpdateNullAuction.
        /// </summary>
        [Test]
        public void TestUpdateNullAuction()
        {
            Auction auction = null;

            IAuctionService auctionServices = new AuctionService();
            Assert.Throws<ArgumentNullException>(() => auctionServices.UpdateAuction(auction));
        }
    }
}
