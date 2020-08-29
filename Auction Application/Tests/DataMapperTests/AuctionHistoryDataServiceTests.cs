// <copyright file="AuctionHistoryDataServiceTests.cs" company="Transilvania University of Brasov">
// Todor Radu Constantin
// </copyright>

namespace ASSE_Restanta.DataMapperTests
{
    using Auction_Application.DataMappers.Interfaces;
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
    }
}
