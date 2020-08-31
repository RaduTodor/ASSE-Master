// <copyright file="PersonDataServiceTests.cs" company="Transilvania University of Brasov">
// Todor Radu Constantin
// </copyright>

namespace ASSE_Restanta.DataMapperTests
{
    using Auction_Application.DataMappers.Interfaces;
    using Auction_Application.DataMappers.ServiceImplementations;
    using Auction_Application.DomainModels;
    using Moq;
    using NUnit.Framework;
    using NUnit.Framework.Internal;

    /// <summary>
    /// Defines the <see cref="PersonDataServiceTests" />.
    /// </summary>
    public class PersonDataServiceTests
    {
        /// <summary>
        /// The AddPersonTest.
        /// </summary>
        [Test]
        public void AddPersonTest()
        {
            Person person = new Mock<Person>().Object;

            Mock<IPersonDataService> mock = new Mock<IPersonDataService>();
            mock.Setup(m => m.AddPerson(person));

            IPersonDataService obj = mock.Object;
            obj.AddPerson(person);

            mock.Verify(o => o.AddPerson(person), Times.Once());
        }

        /// <summary>
        /// The AddPersonImplementationTest.
        /// </summary>
        [Test]
        public void AddPersonImplementationTest()
        {
            Person person = new Person
            {
                FIRST_NAME = "Radu",
                LAST_NAME = "Todor",
                Role = new Role { ID = 2 },
                SCORE = 2.5m,
            };

            PersonDataService service = new PersonDataService();
            try
            {
                service.AddPerson(person);
                person.FIRST_NAME = "Vlad";
                service.UpdatePerson(person);
                var people = service.GetAllPeople();
                var samePerson = service.GetPersonById(person.ID);
                service.DeletePerson(person);
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// The DeletePersonTest.
        /// </summary>
        [Test]
        public void DeletePersonTest()
        {
            Person person = new Mock<Person>().Object;

            Mock<IPersonDataService> mock = new Mock<IPersonDataService>();
            mock.Setup(m => m.DeletePerson(person));

            IPersonDataService obj = mock.Object;
            obj.DeletePerson(person);

            mock.Verify(o => o.DeletePerson(person), Times.Once());
        }

        /// <summary>
        /// The UpdatePersonTest.
        /// </summary>
        [Test]
        public void UpdatePersonTest()
        {
            Person person = new Mock<Person>().Object;

            Mock<IPersonDataService> mock = new Mock<IPersonDataService>();
            mock.Setup(m => m.UpdatePerson(person));

            IPersonDataService obj = mock.Object;
            obj.UpdatePerson(person);

            mock.Verify(o => o.UpdatePerson(person), Times.Once());
        }

        /// <summary>
        /// The GetAllPeopleTest.
        /// </summary>
        [Test]
        public void GetAllPeopleTest()
        {
            Mock<IPersonDataService> mock = new Mock<IPersonDataService>();
            mock.Setup(m => m.GetAllPeople());

            IPersonDataService obj = mock.Object;
            obj.GetAllPeople();

            mock.Verify(o => o.GetAllPeople(), Times.Once());
        }

        /// <summary>
        /// The GetPersonByIdTest.
        /// </summary>
        [Test]
        public void GetPersonByIdTest()
        {
            Mock<IPersonDataService> mock = new Mock<IPersonDataService>();
            mock.Setup(m => m.GetPersonById(1));

            IPersonDataService obj = mock.Object;
            obj.GetPersonById(1);

            mock.Verify(o => o.GetPersonById(1), Times.Once());
        }
    }
}
