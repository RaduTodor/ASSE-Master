// <copyright file="AuctionDataServiceTests.cs" company="Transilvania University of Brasov">
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
    /// Defines the <see cref="AuctionDataServiceTests" />.
    /// </summary>
    public class AuctionDataServiceTests
    {
        /// <summary>
        /// The AddAuctionTest.
        /// </summary>
        [Test]
        public void AddAuctionTest()
        {
            Auction auction = new Mock<Auction>().Object;

            Mock<IAuctionDataService> mock = new Mock<IAuctionDataService>();
            mock.Setup(m => m.AddAuction(auction));

            IAuctionDataService obj = mock.Object;
            obj.AddAuction(auction);

            mock.Verify(o => o.AddAuction(auction), Times.Once());
        }

        /// <summary>
        /// The DeleteAuctionTest.
        /// </summary>
        [Test]
        public void DeleteAuctionTest()
        {
            Auction auction = new Mock<Auction>().Object;

            Mock<IAuctionDataService> mock = new Mock<IAuctionDataService>();
            mock.Setup(m => m.DeleteAuction(auction));

            IAuctionDataService obj = mock.Object;
            obj.DeleteAuction(auction);

            mock.Verify(o => o.DeleteAuction(auction), Times.Once());
        }

        /// <summary>
        /// The UpdateAuctionTest.
        /// </summary>
        [Test]
        public void UpdateAuctionTest()
        {
            Auction auction = new Mock<Auction>().Object;

            Mock<IAuctionDataService> mock = new Mock<IAuctionDataService>();
            mock.Setup(m => m.UpdateAuction(auction));

            IAuctionDataService obj = mock.Object;
            obj.UpdateAuction(auction);

            mock.Verify(o => o.UpdateAuction(auction), Times.Once());
        }

        /// <summary>
        /// The GetAllAuctionsTest.
        /// </summary>
        [Test]
        public void GetAllAuctionsTest()
        {
            Mock<IAuctionDataService> mock = new Mock<IAuctionDataService>();
            mock.Setup(m => m.GetAllAuctions());

            IAuctionDataService obj = mock.Object;
            obj.GetAllAuctions();

            mock.Verify(o => o.GetAllAuctions(), Times.Once());
        }

        /// <summary>
        /// The GetAuctionByIdTest.
        /// </summary>
        [Test]
        public void GetAuctionByIdTest()
        {
            Mock<IAuctionDataService> mock = new Mock<IAuctionDataService>();
            mock.Setup(m => m.GetAuctionById(1));

            IAuctionDataService obj = mock.Object;
            obj.GetAuctionById(1);

            mock.Verify(o => o.GetAuctionById(1), Times.Once());
        }

        /// <summary>
        /// The AddAuctionImplementationTest.
        /// </summary>
        [Test]
        public void AddAuctionImplementationTest()
        {
            Auction auction = new Auction()
            {
                CURRENCY = "Euro",
                Person = new Person { ID = 1, FIRST_NAME = "Radu", LAST_NAME = "Todor", Role = new Role { ID = 1, NAME = "Seller" }, SCORE = 9.00m, ROLE_ID = 1 },
                Product = new Product { ID = 2, NAME = "Telefon", Category = new Category { ID = 2, NAME = "Dispozitive mici", PARENT_CATEGORY_ID = 1 }, PARENT_CATEGORY_ID = 2 },
                DATE_START = DateTime.Now,
                DATE_END = DateTime.Now.AddDays(20),
                START_PRICE = 12,
                OWNER_ID = 1,
                PRODUCT_ID = 2,
            };

            AuctionDataService service = new AuctionDataService();
            try
            {
                service.AddAuction(auction);
                auction.CURRENCY = "USD";
                service.UpdateAuction(auction);
                var people = service.GetAllAuctions();
                var samePerson = service.GetAuctionById(auction.ID);
                service.DeleteAuction(auction);
            }
            catch
            {
                throw;
            }
        }
    }
}
