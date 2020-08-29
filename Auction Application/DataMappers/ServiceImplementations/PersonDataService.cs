// <copyright file="PersonDataService.cs" company="Transilvania University of Brasov">
// Todor Radu Constantin
// </copyright>

namespace Auction_Application.DataMappers.ServiceImplementations
{
    using System.Collections.Generic;
    using System.Linq;
    using Auction_Application.DataMappers.Interfaces;
    using Auction_Application.DomainModels;

    /// <summary>
    /// Defines the <see cref="PersonDataService" />.
    /// </summary>
    public class PersonDataService : IPersonDataService
    {
        /// <summary>
        /// The AddPerson.
        /// </summary>
        /// <param name="person">The Person<see cref="Person"/>.</param>
        public void AddPerson(Person person)
        {
            using (ApplicationContext context = new ApplicationContext())
            {
                context.People.Add(person);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// The DeletePerson.
        /// </summary>
        /// <param name="person">The Person.</param>
        public void DeletePerson(Person person)
        {
            using (ApplicationContext context = new ApplicationContext())
            {
                Person toBeDeleted = new Person { ID = person.ID };
                context.People.Attach(toBeDeleted);
                context.People.Remove(toBeDeleted);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// The GetAllPeople.
        /// </summary>
        /// <returns>All People.</returns>
        public IList<Person> GetAllPeople()
        {
            using (ApplicationContext context = new ApplicationContext())
            {
                return context.People.Select(Person => Person).ToList();
            }
        }

        /// <summary>
        /// The UpdatePerson.
        /// </summary>
        /// <param name="person">The Person.</param>
        public void UpdatePerson(Person person)
        {
            using (ApplicationContext context = new ApplicationContext())
            {
                Person toBeUpdated = context.People.Find(person.ID);

                if (toBeUpdated == null)
                {
                    return;
                }

                context.Entry(toBeUpdated).CurrentValues.SetValues(person);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// The GetPersonById.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The Person.</returns>
        public Person GetPersonById(int id)
        {
            using (var context = new ApplicationContext())
            {
                return context.People.Where(Person => Person.ID == id).SingleOrDefault();
            }
        }
    }
}
