// <copyright file="AuctionDataServiceTests.cs" company="Transilvania University of Brasov">
// Todor Radu Constantin
// </copyright>

namespace ASSE_Restanta.DataMapperTests
{
    using Auction_Application.DataMappers.Interfaces;
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
    }
}
