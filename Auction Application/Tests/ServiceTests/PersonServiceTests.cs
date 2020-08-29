// <copyright file="PersonServiceTests.cs" company="Transilvania University of Brasov">
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
    /// Defines the <see cref="PersonServiceTests" />.
    /// </summary>
    public class PersonServiceTests
    {
        /// <summary>
        /// The TestAddPersonWithValidData.
        /// </summary>
        [Test]
        public void TestAddPersonWithValidData()
        {
            Person person = new Person()
            {
                FIRST_NAME = "Radu",
                LAST_NAME = "Todor",
                Role = new Role { ID = 2 },
                SCORE = 2.5m,
            };

            IPersonService personServices = new PersonService();
            bool result = personServices.AddPerson(person);

            Assert.IsTrue(result);
        }

        /// <summary>
        /// The TestAddPersonWithInvalidData.
        /// </summary>
        [Test]
        public void TestAddPersonWithInvalidData()
        {
            Person person = new Person();

            IPersonService readerServices = new PersonService();
            bool result = readerServices.AddPerson(person);

            Assert.IsFalse(result);
        }

        /// <summary>
        /// The TestDeletePersonWithValidData.
        /// </summary>
        [Test]
        public void TestDeletePersonWithValidData()
        {
            Person person = new Person()
            {
                FIRST_NAME = "Radu",
                LAST_NAME = "Todor",
                Role = new Role { ID = 2 },
                SCORE = 2.5m,
            };

            IPersonService personServices = new PersonService();
            Mock<IPersonDataService> mock = new Mock<IPersonDataService>();
            mock.Setup(m => m.DeletePerson(person));

            PersonService.DataServices = mock.Object;
            bool result = personServices.DeletePerson(person);

            Assert.IsTrue(result);
        }

        /// <summary>
        /// The TestDeletePersonWithInvalidData.
        /// </summary>
        [Test]
        public void TestDeletePersonWithInvalidData()
        {
            Person person = new Person();

            IPersonService personServices = new PersonService();
            bool result = personServices.DeletePerson(person);

            Assert.IsFalse(result);
        }

        /// <summary>
        /// The TestUpdateReaderWithValidData.
        /// </summary>
        [Test]
        public void TestUpdateReaderWithValidData()
        {
            Person person = new Person()
            {
                FIRST_NAME = "Radu",
                LAST_NAME = "Todor",
                Role = new Role { ID = 2 },
                SCORE = 2.5m,
            };

            IPersonService personServices = new PersonService();
            bool result = personServices.UpdatePerson(person);

            Assert.IsTrue(result);
        }

        /// <summary>
        /// The TestUpdatePersonWithInvalidData.
        /// </summary>
        [Test]
        public void TestUpdatePersonWithInvalidData()
        {
            Person person = new Person();

            IPersonService personServices = new PersonService();
            bool result = personServices.UpdatePerson(person);

            Assert.IsFalse(result);
        }

        /// <summary>
        /// The TestGetListOfPeople.
        /// </summary>
        [Test]
        public void TestGetListOfPeople()
        {
            IPersonService personServices = new PersonService();
            Mock<IPersonDataService> mock = new Mock<IPersonDataService>();
            mock.Setup(m => m.GetAllPeople()).Returns(
                new List<Person>()
                {
                    new Person()
                    {
                FIRST_NAME = "Radu",
                LAST_NAME = "Todor",
                Role = new Role { ID = 2 },
                SCORE = 2.5m,
                    }
                });

            PersonService.DataServices = mock.Object;
            var result = personServices.GetListOfPersons();

            Assert.AreNotEqual(result, null);
            Assert.AreEqual((result as List<Person>).Count, 1);
        }

        /// <summary>
        /// The TestGetPersonById.
        /// </summary>
        [Test]
        public void TestGetPersonById()
        {
            IPersonService personServices = new PersonService();
            Mock<IPersonDataService> mock = new Mock<IPersonDataService>();
            mock.Setup(m => m.GetPersonById(2)).Returns(
                    new Person()
                    {
                        ID = 2,
                        FIRST_NAME = "Radu",
                        LAST_NAME = "Todor",
                        Role = new Role { ID = 2 },
                        SCORE = 2.5m,
                    });

            PersonService.DataServices = mock.Object;
            var result = personServices.GetPersonById(2);

            Assert.AreNotEqual(result, null);
            Assert.AreEqual((result as Person).ID, 2);
        }

        /// <summary>
        /// The TestGetPersonByIdWithInvalidId.
        /// </summary>
        [Test]
        public void TestGetPersonByIdWithInvalidId()
        {
            IPersonService personServices = new PersonService();
            Mock<IPersonDataService> mock = new Mock<IPersonDataService>();
            mock.Setup(m => m.GetPersonById(10)).Returns(
                    new Person()
                    {
                        FIRST_NAME = "Radu",
                        LAST_NAME = "Todor",
                        Role = new Role { ID = 2 },
                        SCORE = 2.5m,
                    });

            PersonService.DataServices = mock.Object;
            var result = personServices.GetPersonById(1);

            Assert.AreEqual(result, null);
        }

        /// <summary>
        /// The TestAddNullPerson.
        /// </summary>
        [Test]
        public void TestAddNullPerson()
        {
            Person person = null;

            IPersonService personServices = new PersonService();
            Assert.Throws<NullReferenceException>(() => personServices.AddPerson(person));
        }

        /// <summary>
        /// The TestDeleteNullPerson.
        /// </summary>
        [Test]
        public void TestDeleteNullPerson()
        {
            Person person = null;

            IPersonService personServices = new PersonService();
            Assert.Throws<ArgumentNullException>(() => personServices.DeletePerson(person));
        }

        /// <summary>
        /// The TestUpdateNullPerson.
        /// </summary>
        [Test]
        public void TestUpdateNullPerson()
        {
            Person person = null;

            IPersonService personServices = new PersonService();
            Assert.Throws<ArgumentNullException>(() => personServices.UpdatePerson(person));
        }
    }
}
