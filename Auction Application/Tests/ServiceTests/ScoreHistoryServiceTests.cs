// <copyright file="ScoreHistoryServiceTests.cs" company="Transilvania University of Brasov">
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
    /// Defines the <see cref="ScoreHistoryServiceTests" />.
    /// </summary>
    public class ScoreHistoryServiceTests
    {
        /// <summary>
        /// The TestAddScoreHistoryWithValidData.
        /// </summary>
        [Test]
        public void TestAddScoreHistoryWithValidData()
        {
            Score_History scoreHistory = new Score_History()
            {
                Person = new Person { ID = 1, FIRST_NAME = "Radu", LAST_NAME = "Todor", Role = new Role { ID = 3 }, SCORE = 11.00m, ROLE_ID = 3 },
                SCORE = 5.3m,
                DATE = DateTime.Now,
                PERSON_ID = 1,
            };

            IScoreHistoryService scoreHistoryServices = new ScoreHistoryService();
            bool result = scoreHistoryServices.AddScoreHistory(scoreHistory);

            Assert.IsTrue(result);
        }

        /// <summary>
        /// The TestAddScoreHistoryWithInvalidData.
        /// </summary>
        [Test]
        public void TestAddScoreHistoryWithInvalidData()
        {
            Score_History scoreHistory = new Score_History();

            IScoreHistoryService readerServices = new ScoreHistoryService();
            bool result = readerServices.AddScoreHistory(scoreHistory);

            Assert.IsFalse(result);
        }

        /// <summary>
        /// The TestDeleteScoreHistoryWithValidData.
        /// </summary>
        [Test]
        public void TestDeleteScoreHistoryWithValidData()
        {
            Score_History scoreHistory = new Score_History()
            {
                Person = new Person { FIRST_NAME = "Radu" },
                SCORE = 5.3m,
                DATE = DateTime.Now,
            };

            IScoreHistoryService scoreHistoryServices = new ScoreHistoryService();
            Mock<IScore_HistoryDataService> mock = new Mock<IScore_HistoryDataService>();
            mock.Setup(m => m.DeleteScore_History(scoreHistory));

            ScoreHistoryService.DataServices = mock.Object;
            bool result = scoreHistoryServices.DeleteScoreHistory(scoreHistory);

            Assert.IsTrue(result);
        }

        /// <summary>
        /// The TestDeleteScoreHistoryWithInvalidData.
        /// </summary>
        [Test]
        public void TestDeleteScoreHistoryWithInvalidData()
        {
            Score_History scoreHistory = new Score_History();

            IScoreHistoryService scoreHistoryServices = new ScoreHistoryService();
            bool result = scoreHistoryServices.DeleteScoreHistory(scoreHistory);

            Assert.IsFalse(result);
        }

        /// <summary>
        /// The TestUpdateReaderWithValidData.
        /// </summary>
        [Test]
        public void TestUpdateReaderWithValidData()
        {
            Score_History scoreHistory = new Score_History()
            {
                Person = new Person { FIRST_NAME = "Radu" },
                SCORE = 5.3m,
                DATE = DateTime.Now,
            };

            IScoreHistoryService scoreHistoryServices = new ScoreHistoryService();
            bool result = scoreHistoryServices.UpdateScoreHistory(scoreHistory);

            Assert.IsTrue(result);
        }

        /// <summary>
        /// The TestUpdateScoreHistoryWithInvalidData.
        /// </summary>
        [Test]
        public void TestUpdateScoreHistoryWithInvalidData()
        {
            Score_History scoreHistory = new Score_History();

            IScoreHistoryService scoreHistoryServices = new ScoreHistoryService();
            bool result = scoreHistoryServices.UpdateScoreHistory(scoreHistory);

            Assert.IsFalse(result);
        }

        /// <summary>
        /// The TestGetListOfScoreHistories.
        /// </summary>
        [Test]
        public void TestGetListOfScoreHistories()
        {
            IScoreHistoryService scoreHistoryServices = new ScoreHistoryService();
            Mock<IScore_HistoryDataService> mock = new Mock<IScore_HistoryDataService>();
            mock.Setup(m => m.GetAllScore_Histories()).Returns(
                new List<Score_History>()
                {
                    new Score_History()
                    {
                Person = new Person { FIRST_NAME = "Radu" },
                SCORE = 5.3m,
                DATE = DateTime.Now,
                    }
                });

            ScoreHistoryService.DataServices = mock.Object;
            var result = scoreHistoryServices.GetListOfScoreHistories();

            Assert.AreNotEqual(result, null);
            Assert.AreEqual((result as List<Score_History>).Count, 1);
        }

        /// <summary>
        /// The TestGetScoreHistoryById.
        /// </summary>
        [Test]
        public void TestGetScoreHistoryById()
        {
            IScoreHistoryService scoreHistoryServices = new ScoreHistoryService();
            Mock<IScore_HistoryDataService> mock = new Mock<IScore_HistoryDataService>();
            mock.Setup(m => m.GetScore_HistoryById(2)).Returns(
                    new Score_History()
                    {
                        ID = 2,
                        Person = new Person { FIRST_NAME = "Radu" },
                        SCORE = 5.3m,
                        DATE = DateTime.Now,
                    });

            ScoreHistoryService.DataServices = mock.Object;
            var result = scoreHistoryServices.GetScoreHistoryById(2);

            Assert.AreNotEqual(result, null);
            Assert.AreEqual((result as Score_History).ID, 2);
        }

        /// <summary>
        /// The TestGetScoreHistoryByIdWithInvalidId.
        /// </summary>
        [Test]
        public void TestGetScoreHistoryByIdWithInvalidId()
        {
            IScoreHistoryService scoreHistoryServices = new ScoreHistoryService();
            Mock<IScore_HistoryDataService> mock = new Mock<IScore_HistoryDataService>();
            mock.Setup(m => m.GetScore_HistoryById(10)).Returns(
                    new Score_History()
                    {
                        Person = new Person { FIRST_NAME = "Radu" },
                        SCORE = 5.3m,
                        DATE = DateTime.Now,
                    });

            ScoreHistoryService.DataServices = mock.Object;
            var result = scoreHistoryServices.GetScoreHistoryById(1);

            Assert.AreEqual(result, null);
        }

        /// <summary>
        /// The TestAddNullScoreHistory.
        /// </summary>
        [Test]
        public void TestAddNullScoreHistory()
        {
            Score_History scoreHistory = null;

            IScoreHistoryService scoreHistoryServices = new ScoreHistoryService();
            Assert.Throws<ArgumentNullException>(() => scoreHistoryServices.AddScoreHistory(scoreHistory));
        }

        /// <summary>
        /// The TestDeleteNullScoreHistory.
        /// </summary>
        [Test]
        public void TestDeleteNullScoreHistory()
        {
            Score_History scoreHistory = null;

            IScoreHistoryService scoreHistoryServices = new ScoreHistoryService();
            Assert.Throws<ArgumentNullException>(() => scoreHistoryServices.DeleteScoreHistory(scoreHistory));
        }

        /// <summary>
        /// The TestUpdateNullScoreHistory.
        /// </summary>
        [Test]
        public void TestUpdateNullScoreHistory()
        {
            Score_History scoreHistory = null;

            IScoreHistoryService scoreHistoryServices = new ScoreHistoryService();
            Assert.Throws<ArgumentNullException>(() => scoreHistoryServices.UpdateScoreHistory(scoreHistory));
        }
    }
}
