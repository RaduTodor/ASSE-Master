// <copyright file="IPersonDataService.cs" company="Transilvania University of Brasov">
// Todor Radu Constantin
// </copyright>

namespace Auction_Application.DataMappers.Interfaces
{
    using System.Collections.Generic;
    using Auction_Application.DomainModels;

    /// <summary>
    /// Defines the <see cref="IPersonDataService" />.
    /// </summary>
    public interface IPersonDataService
    {
        /// <summary>
        /// The GetAllPeople.
        /// </summary>
        /// <returns>All People.</returns>
        IList<Person> GetAllPeople();

        /// <summary>
        /// The AddPerson.
        /// </summary>
        /// <param name="person">The Person.</param>
        void AddPerson(Person person);

        /// <summary>
        /// The DeletePerson.
        /// </summary>
        /// <param name="person">The Person.</param>
        void DeletePerson(Person person);

        /// <summary>
        /// The UpdatePerson.
        /// </summary>
        /// <param name="person">The Person.</param>
        void UpdatePerson(Person person);

        /// <summary>
        /// The GetPersonById.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The <see cref="Person"/>.</returns>
        Person GetPersonById(int id);
    }
}
