// <copyright file="AuctionHistoryDataServiceTests.cs" company="Transilvania University of Brasov">
// Todor Radu Constantin
// </copyright>

namespace ASSE_Restanta.DataMapperTests
{
    using System;
    using Auction_Application.DataMappers.Interfaces;
    using Auction_Application.DataMappers.ServiceImplementations;
    using Auction_Application.DomainModels;
    using Moq;
    using NUnit.Framework;

    /// <summary>
    /// Defines the <see cref="AuctionHistoryDataServiceTests" />.
    /// </summary>
    public class AuctionHistoryDataServiceTests
    {
        /// <summary>
        /// The AddAuctionHistoryTest.
        /// </summary>
        [Test]
        public void AddAuctionHistoryTest()
        {
            Auction_History auctionHistory = new Mock<Auction_History>().Object;

            Mock<IAuction_HistoryDataService> mock = new Mock<IAuction_HistoryDataService>();
            mock.Setup(m => m.AddAuction_History(auctionHistory));

            IAuction_HistoryDataService obj = mock.Object;
            obj.AddAuction_History(auctionHistory);

            mock.Verify(o => o.AddAuction_History(auctionHistory), Times.Once());
        }

        /// <summary>
        /// The DeleteAuctionHistoryTest.
        /// </summary>
        [Test]
        public void DeleteAuctionHistoryTest()
        {
            Auction_History auctionHistory = new Mock<Auction_History>().Object;

            Mock<IAuction_HistoryDataService> mock = new Mock<IAuction_HistoryDataService>();
            mock.Setup(m => m.DeleteAuction_History(auctionHistory));

            IAuction_HistoryDataService obj = mock.Object;
            obj.DeleteAuction_History(auctionHistory);

            mock.Verify(o => o.DeleteAuction_History(auctionHistory), Times.Once());
        }

        /// <summary>
        /// The UpdateAuctionHistoryTest.
        /// </summary>
        [Test]
        public void UpdateAuctionHistoryTest()
        {
            Auction_History auctionHistory = new Mock<Auction_History>().Object;

            Mock<IAuction_HistoryDataService> mock = new Mock<IAuction_HistoryDataService>();
            mock.Setup(m => m.UpdateAuction_History(auctionHistory));

            IAuction_HistoryDataService obj = mock.Object;
            obj.UpdateAuction_History(auctionHistory);

            mock.Verify(o => o.UpdateAuction_History(auctionHistory), Times.Once());
        }

        /// <summary>
        /// The GetAllAuctionHistoriesTest.
        /// </summary>
        [Test]
        public void GetAllAuctionHistoriesTest()
        {
            Mock<IAuction_HistoryDataService> mock = new Mock<IAuction_HistoryDataService>();
            mock.Setup(m => m.GetAllAuction_Histories());

            IAuction_HistoryDataService obj = mock.Object;
            obj.GetAllAuction_Histories();

            mock.Verify(o => o.GetAllAuction_Histories(), Times.Once());
        }

        /// <summary>
        /// The GetAuctionHistoryByIdTest.
        /// </summary>
        [Test]
        public void GetAuctionHistoryByIdTest()
        {
            Mock<IAuction_HistoryDataService> mock = new Mock<IAuction_HistoryDataService>();
            mock.Setup(m => m.GetAuction_HistoryById(1));

            IAuction_HistoryDataService obj = mock.Object;
            obj.GetAuction_HistoryById(1);

            mock.Verify(o => o.GetAuction_HistoryById(1), Times.Once());
        }

        /// <summary>
        /// The AddAuction_HistoryImplementationTest.
        /// </summary>
        [Test]
        public void AddAuction_HistoryImplementationTest()
        {
            Auction_History auction_History = new Auction_History
            {
                CURRENCY = "Euro",
                Person = new Person { ID = 1, FIRST_NAME = "Radu", LAST_NAME = "Todor", Role = new Role { ID = 2, NAME = "Buyer" }, SCORE = 9.00m, ROLE_ID = 2 },
                Auction = new Auction
                {
                    CURRENCY = "Euro",
                    Person = new Person { ID = 1, FIRST_NAME = "Radu", LAST_NAME = "Todor", Role = new Role { ID = 1, NAME = "Seller" }, SCORE = 9.00m, ROLE_ID = 1 },
                    Product = new Product { ID = 2, NAME = "Telefon", Category = new Category { ID = 2, NAME = "Dispozitive mici", PARENT_CATEGORY_ID = 1 }, PARENT_CATEGORY_ID = 2 },
                    DATE_START = DateTime.Now,
                    DATE_END = DateTime.Now.AddDays(20),
                    START_PRICE = 490,
                    OWNER_ID = 1,
                    PRODUCT_ID = 2,
                },
                DATE_CREATION = DateTime.Now,
                OFFER = 500,
            };

            Auction_HistoryDataService service = new Auction_HistoryDataService();
            try
            {
                service.AddAuction_History(auction_History);
                auction_History.OFFER = 600;
                service.UpdateAuction_History(auction_History);
                var people = service.GetAllAuction_Histories();
                var sameAuction_History = service.GetAuction_HistoryById(auction_History.ID);
                service.DeleteAuction_History(auction_History);
            }
            catch
            {
                throw;
            }
        }
    }
}
