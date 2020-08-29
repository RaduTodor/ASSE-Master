// <copyright file="ScoreHistoryTests.cs" company="Transilvania University of Brasov">
// Todor Radu Constantin
// </copyright>

namespace ASSE_Restanta.DomainModelTests
{
    using System;
    using Auction_Application.DomainModels;
    using Auction_Application.DomainModels.Validators;
    using NUnit.Framework;

    /// <summary>
    /// Defines the <see cref="ScoreHistoryTests" />.
    /// </summary>
    public class ScoreHistoryTests
    {
        /// <summary>
        /// The TestScore_HistoryValidatorWithValidValues.
        /// </summary>
        [Test]
        public void TestScore_HistoryValidatorWithValidValues()
        {
            Score_History test = new Score_History()
            {
                Person = new Person { FIRST_NAME = "Radu" },
                SCORE = 5.3m,
                DATE = DateTime.Now,
            };

            ScoreHistoryValidator validator = new ScoreHistoryValidator();
            var results = validator.Validate(test);

            bool isValid = results.IsValid;
            Assert.IsTrue(isValid);
        }

        /// <summary>
        /// The TestScore_HistoryValidatorWithValidValues2.
        /// </summary>
        [Test]
        public void TestScore_HistoryValidatorWithValidValues2()
        {
            Score_History test = new Score_History()
            {
                Person = new Person { FIRST_NAME = "Iulian" },
                SCORE = 7.3m,
                DATE = DateTime.Now.AddDays(3),
            };

            ScoreHistoryValidator validator = new ScoreHistoryValidator();
            var results = validator.Validate(test);

            bool isValid = results.IsValid;
            Assert.IsTrue(isValid);
        }

        /// <summary>
        /// The TestScore_HistoryValidatorWithValidValues3.
        /// </summary>
        [Test]
        public void TestScore_HistoryValidatorWithValidValues3()
        {
            Score_History test = new Score_History()
            {
                ID = 3,
                Person = new Person { },
                SCORE = 7.3m,
                DATE = DateTime.Now,
            };

            ScoreHistoryValidator validator = new ScoreHistoryValidator();
            var results = validator.Validate(test);

            bool isValid = results.IsValid;
            Assert.IsTrue(isValid);
        }

        /// <summary>
        /// The TestScore_HistoryValidatorWithInvalidValues.
        /// </summary>
        [Test]
        public void TestScore_HistoryValidatorWithInvalidValues()
        {
            Score_History test = new Score_History()
            {
                SCORE = 7.34m,
                DATE = DateTime.Now,
            };

            ScoreHistoryValidator validator = new ScoreHistoryValidator();
            var results = validator.Validate(test);

            bool isValid = results.IsValid;
            Assert.IsFalse(isValid);
        }

        /// <summary>
        /// The TestScore_HistoryValidatorWithInvalidValues2.
        /// </summary>
        [Test]
        public void TestScore_HistoryValidatorWithInvalidValues2()
        {
            Score_History test = new Score_History()
            {
                Person = new Person { },
                DATE = DateTime.Now,
            };

            ScoreHistoryValidator validator = new ScoreHistoryValidator();
            var results = validator.Validate(test);

            bool isValid = results.IsValid;
            Assert.IsFalse(isValid);
        }

        /// <summary>
        /// The TestScore_HistoryValidatorWithInvalidValues3.
        /// </summary>
        [Test]
        public void TestScore_HistoryValidatorWithInvalidValues3()
        {
            Score_History test = new Score_History()
            {
                Person = new Person { },
                SCORE = 7.34m,
            };

            ScoreHistoryValidator validator = new ScoreHistoryValidator();
            var results = validator.Validate(test);

            bool isValid = results.IsValid;
            Assert.IsFalse(isValid);
        }

        /// <summary>
        /// The TestScore_HistoryValidatorWithInvalidValues4.
        /// </summary>
        [Test]
        public void TestScore_HistoryValidatorWithInvalidValues4()
        {
            Score_History test = new Score_History()
            {
                Person = new Person { },
                SCORE = 9.345m,
                DATE = DateTime.Now,
            };

            ScoreHistoryValidator validator = new ScoreHistoryValidator();
            var results = validator.Validate(test);

            bool isValid = results.IsValid;
            Assert.IsFalse(isValid);
        }

        /// <summary>
        /// The TestScore_HistoryValidatorWithInvalidValues5.
        /// </summary>
        [Test]
        public void TestScore_HistoryValidatorWithInvalidValues5()
        {
            Score_History test = new Score_History()
            {
                Person = new Person { },
                SCORE = -1.34m,
                DATE = DateTime.Now,
            };

            ScoreHistoryValidator validator = new ScoreHistoryValidator();
            var results = validator.Validate(test);

            bool isValid = results.IsValid;
            Assert.IsFalse(isValid);
        }

        /// <summary>
        /// The TestScore_HistoryValidatorWithInvalidValues6.
        /// </summary>
        [Test]
        public void TestScore_HistoryValidatorWithInvalidValues6()
        {
            Score_History test = new Score_History()
            {
                Person = new Person { },
                SCORE = 11.34m,
                DATE = DateTime.Now,
            };

            ScoreHistoryValidator validator = new ScoreHistoryValidator();
            var results = validator.Validate(test);

            bool isValid = results.IsValid;
            Assert.IsFalse(isValid);
        }

        /// <summary>
        /// The TestScore_HistoryValidatorWithInvalidValues7.
        /// </summary>
        [Test]
        public void TestScore_HistoryValidatorWithInvalidValues7()
        {
            Score_History test = new Score_History()
            {
                Person = new Person { },
                SCORE = 100.34m,
                DATE = DateTime.Now,
            };

            ScoreHistoryValidator validator = new ScoreHistoryValidator();
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
            Score_History test = new Score_History
            {
                ID = 3,
                Person = new Person { FIRST_NAME = "Radu" },
                SCORE = 7.3m,
                DATE = date,
            };

            Assert.AreEqual(test.ID, 3);
            Assert.AreEqual(test.Person.FIRST_NAME, "Radu");
            Assert.AreEqual(test.SCORE, 7.3m);
            Assert.AreEqual(test.DATE, date);
        }
    }
}
