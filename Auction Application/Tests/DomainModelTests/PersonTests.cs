// <copyright file="PersonTests.cs" company="Transilvania University of Brasov">
// Todor Radu Constantin
// </copyright>

namespace ASSE_Restanta.DomainModelTests
{
    using Auction_Application.DomainModels;
    using Auction_Application.DomainModels.Validators;
    using NUnit.Framework;

    /// <summary>
    /// Defines the <see cref="PersonTests" />.
    /// </summary>
    public class PersonTests
    {
        /// <summary>
        /// The TestPersonValidatorWithValidValues.
        /// </summary>
        [Test]
        public void TestPersonValidatorWithValidValues()
        {
            Person test = new Person()
            {
                FIRST_NAME = "Radu",
                LAST_NAME = "Todor",
                Role = new Role { ID = 2 },
                SCORE = 2.5m,
            };

            PersonValidator validator = new PersonValidator();
            var results = validator.Validate(test);

            bool isValid = results.IsValid;
            Assert.IsTrue(isValid);
        }

        /// <summary>
        /// The TestPersonValidatorWithValidValues2.
        /// </summary>
        [Test]
        public void TestPersonValidatorWithValidValues2()
        {
            Person test = new Person()
            {
                FIRST_NAME = "Roxana",
                LAST_NAME = "Sacarea",
                Role = new Role { ID = 1 },
                SCORE = 7.3m,
            };

            PersonValidator validator = new PersonValidator();
            var results = validator.Validate(test);

            bool isValid = results.IsValid;
            Assert.IsTrue(isValid);
        }

        /// <summary>
        /// The TestPersonValidatorWithValidValues3.
        /// </summary>
        [Test]
        public void TestPersonValidatorWithValidValues3()
        {
            Person test = new Person()
            {
                FIRST_NAME = "Iulian",
                LAST_NAME = "Popa",
                Role = new Role { ID = 2 },
                SCORE = 8,
            };

            PersonValidator validator = new PersonValidator();
            var results = validator.Validate(test);

            bool isValid = results.IsValid;
            Assert.IsTrue(isValid);
        }

        /// <summary>
        /// The TestPersonValidatorWithInvalidValues.
        /// </summary>
        [Test]
        public void TestPersonValidatorWithInvalidValues()
        {
            Person test = new Person()
            {
                LAST_NAME = "Todor",
                Role = new Role { ID = 2 },
                SCORE = 2.5m,
            };

            PersonValidator validator = new PersonValidator();
            var results = validator.Validate(test);

            bool isValid = results.IsValid;
            Assert.IsFalse(isValid);
        }

        /// <summary>
        /// The TestPersonValidatorWithInvalidValues2.
        /// </summary>
        [Test]
        public void TestPersonValidatorWithInvalidValues2()
        {
            Person test = new Person()
            {
                FIRST_NAME = "Radu",
                Role = new Role { ID = 2 },
                SCORE = 2.5m,
            };

            PersonValidator validator = new PersonValidator();
            var results = validator.Validate(test);

            bool isValid = results.IsValid;
            Assert.IsFalse(isValid);
        }

        /// <summary>
        /// The TestPersonValidatorWithInvalidValues3.
        /// </summary>
        [Test]
        public void TestPersonValidatorWithInvalidValues3()
        {
            Person test = new Person()
            {
                FIRST_NAME = "Radu",
                LAST_NAME = "Todor",
                SCORE = 2.5m,
            };

            PersonValidator validator = new PersonValidator();
            var results = validator.Validate(test);

            bool isValid = results.IsValid;
            Assert.IsFalse(isValid);
        }

        /// <summary>
        /// The TestPersonValidatorWithInvalidValues4.
        /// </summary>
        [Test]
        public void TestPersonValidatorWithInvalidValues4()
        {
            Person test = new Person()
            {
                FIRST_NAME = "Radu",
                LAST_NAME = "Todor",
                Role = new Role { ID = 2 },
            };

            PersonValidator validator = new PersonValidator();
            var results = validator.Validate(test);

            bool isValid = results.IsValid;
            Assert.IsFalse(isValid);
        }

        /// <summary>
        /// The TestPersonValidatorWithInvalidValues5.
        /// </summary>
        [Test]
        public void TestPersonValidatorWithInvalidValues5()
        {
            Person test = new Person()
            {
                FIRST_NAME = "R",
                LAST_NAME = "Todor",
                Role = new Role { ID = 2 },
                SCORE = 2.5m,
            };

            PersonValidator validator = new PersonValidator();
            var results = validator.Validate(test);

            bool isValid = results.IsValid;
            Assert.IsFalse(isValid);
        }

        /// <summary>
        /// The TestPersonValidatorWithInvalidValues6.
        /// </summary>
        [Test]
        public void TestPersonValidatorWithInvalidValues6()
        {
            Person test = new Person()
            {
                FIRST_NAME = "RaduRaduRaduRaduRaduRaduRaduRaduRaduRaduRaduRaduRaduRaduRadu",
                LAST_NAME = "Todor",
                Role = new Role { ID = 2 },
                SCORE = 2.5m,
            };

            PersonValidator validator = new PersonValidator();
            var results = validator.Validate(test);

            bool isValid = results.IsValid;
            Assert.IsFalse(isValid);
        }

        /// <summary>
        /// The TestPersonValidatorWithInvalidValues7.
        /// </summary>
        [Test]
        public void TestPersonValidatorWithInvalidValues7()
        {
            Person test = new Person()
            {
                FIRST_NAME = "Radu",
                LAST_NAME = "T",
                Role = new Role { ID = 2 },
                SCORE = 2.5m,
            };

            PersonValidator validator = new PersonValidator();
            var results = validator.Validate(test);

            bool isValid = results.IsValid;
            Assert.IsFalse(isValid);
        }

        /// <summary>
        /// The TestPersonValidatorWithInvalidValues8.
        /// </summary>
        [Test]
        public void TestPersonValidatorWithInvalidValues8()
        {
            Person test = new Person()
            {
                FIRST_NAME = "Radu",
                LAST_NAME = "TodorTodorTodorTodorTodorTodorTodorTodorTodorTodorTodorTodor",
                Role = new Role { ID = 2 },
                SCORE = 2.5m,
            };

            PersonValidator validator = new PersonValidator();
            var results = validator.Validate(test);

            bool isValid = results.IsValid;
            Assert.IsFalse(isValid);
        }

        /// <summary>
        /// The TestPersonValidatorWithInvalidValues9.
        /// </summary>
        [Test]
        public void TestPersonValidatorWithInvalidValues9()
        {
            Person test = new Person()
            {
                FIRST_NAME = "Radu",
                LAST_NAME = "Todor",
                Role = new Role { ID = 2 },
                SCORE = 100.5m,
            };

            PersonValidator validator = new PersonValidator();
            var results = validator.Validate(test);

            bool isValid = results.IsValid;
            Assert.IsFalse(isValid);
        }

        /// <summary>
        /// The TestPersonValidatorWithInvalidValues10.
        /// </summary>
        [Test]
        public void TestPersonValidatorWithInvalidValues10()
        {
            Person test = new Person()
            {
                FIRST_NAME = "Radu",
                LAST_NAME = "Todor",
                Role = new Role { ID = 2 },
                SCORE = 2.515m,
            };

            PersonValidator validator = new PersonValidator();
            var results = validator.Validate(test);

            bool isValid = results.IsValid;
            Assert.IsFalse(isValid);
        }

        /// <summary>
        /// The TestPersonValidatorWithInvalidValues11.
        /// </summary>
        [Test]
        public void TestPersonValidatorWithInvalidValues11()
        {
            Person test = new Person()
            {
                FIRST_NAME = "Radu",
                LAST_NAME = "Todor",
                Role = new Role { ID = 2 },
                SCORE = 20.5m,
            };

            PersonValidator validator = new PersonValidator();
            var results = validator.Validate(test);

            bool isValid = results.IsValid;
            Assert.IsFalse(isValid);
        }

        /// <summary>
        /// The TestPersonValidatorWithInvalidValues12.
        /// </summary>
        [Test]
        public void TestPersonValidatorWithInvalidValues12()
        {
            Person test = new Person()
            {
                FIRST_NAME = "Radu",
                LAST_NAME = "Todor",
                Role = new Role { ID = 2 },
                SCORE = -1.5m,
            };

            PersonValidator validator = new PersonValidator();
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
            Person test = new Person
            {
                ID = 1,
                FIRST_NAME = "Radu",
                LAST_NAME = "Todor",
                Role = new Role { ID = 2 },
                SCORE = 2.5m,
            };

            Assert.AreEqual(test.ID, 1);
            Assert.AreEqual(test.FIRST_NAME, "Radu");
            Assert.AreEqual(test.LAST_NAME, "Todor");
            Assert.AreEqual(test.Role.ID, 2);
            Assert.AreEqual(test.SCORE, 2.5m);
        }
    }
}
