// <copyright file="ScoreHistoryDataServiceTests.cs" company="Transilvania University of Brasov">
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
    /// Defines the <see cref="ScoreHistoryDataServiceTests" />.
    /// </summary>
    public class ScoreHistoryDataServiceTests
    {
        /// <summary>
        /// The AddScore_HistoryTest.
        /// </summary>
        [Test]
        public void AddScore_HistoryTest()
        {
            Score_History score_History = new Mock<Score_History>().Object;

            Mock<IScore_HistoryDataService> mock = new Mock<IScore_HistoryDataService>();
            mock.Setup(m => m.AddScore_History(score_History));

            IScore_HistoryDataService obj = mock.Object;
            obj.AddScore_History(score_History);

            mock.Verify(o => o.AddScore_History(score_History), Times.Once());
        }

        /// <summary>
        /// The DeleteScore_HistoryTest.
        /// </summary>
        [Test]
        public void DeleteScore_HistoryTest()
        {
            Score_History score_History = new Mock<Score_History>().Object;

            Mock<IScore_HistoryDataService> mock = new Mock<IScore_HistoryDataService>();
            mock.Setup(m => m.DeleteScore_History(score_History));

            IScore_HistoryDataService obj = mock.Object;
            obj.DeleteScore_History(score_History);

            mock.Verify(o => o.DeleteScore_History(score_History), Times.Once());
        }

        /// <summary>
        /// The UpdateScore_HistoryTest.
        /// </summary>
        [Test]
        public void UpdateScore_HistoryTest()
        {
            Score_History score_History = new Mock<Score_History>().Object;

            Mock<IScore_HistoryDataService> mock = new Mock<IScore_HistoryDataService>();
            mock.Setup(m => m.UpdateScore_History(score_History));

            IScore_HistoryDataService obj = mock.Object;
            obj.UpdateScore_History(score_History);

            mock.Verify(o => o.UpdateScore_History(score_History), Times.Once());
        }

        /// <summary>
        /// The GetAllScore_HistoriesTest.
        /// </summary>
        [Test]
        public void GetAllScore_HistoriesTest()
        {
            Mock<IScore_HistoryDataService> mock = new Mock<IScore_HistoryDataService>();
            mock.Setup(m => m.GetAllScore_Histories());

            IScore_HistoryDataService obj = mock.Object;
            obj.GetAllScore_Histories();

            mock.Verify(o => o.GetAllScore_Histories(), Times.Once());
        }

        /// <summary>
        /// The GetScore_HistoryByIdTest.
        /// </summary>
        [Test]
        public void GetScore_HistoryByIdTest()
        {
            Mock<IScore_HistoryDataService> mock = new Mock<IScore_HistoryDataService>();
            mock.Setup(m => m.GetScore_HistoryById(1));

            IScore_HistoryDataService obj = mock.Object;
            obj.GetScore_HistoryById(1);

            mock.Verify(o => o.GetScore_HistoryById(1), Times.Once());
        }

        /// <summary>
        /// The AddScore_HistoryImplementationTest.
        /// </summary>
        [Test]
        public void AddScore_HistoryImplementationTest()
        {
            Score_History score_History = new Score_History()
            {
                Person = new Person { ID = 1, FIRST_NAME = "Radu", LAST_NAME = "Todor", Role = new Role { ID = 3 }, SCORE = 11.00m, ROLE_ID = 3 },
                SCORE = 5.3m,
                DATE = DateTime.Now,
                PERSON_ID = 1,
            };

            Score_HistoryDataService service = new Score_HistoryDataService();
            try
            {
                service.AddScore_History(score_History);
                score_History.SCORE = 6.6m;
                service.UpdateScore_History(score_History);
                var people = service.GetAllScore_Histories();
                var sameScore_History = service.GetScore_HistoryById(score_History.ID);
                service.DeleteScore_History(score_History);
            }
            catch
            {
                throw;
            }
        }
    }
}
