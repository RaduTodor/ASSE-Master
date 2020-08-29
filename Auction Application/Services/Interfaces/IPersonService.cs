// <copyright file="IPersonService.cs" company="Transilvania University of Brasov">
// Todor Radu Constantin
// </copyright>

namespace Auction_Application.Services.Interfaces
{
    using System.Collections.Generic;
    using Auction_Application.DomainModels;

    /// <summary>
    /// Defines the <see cref="IPersonService" />.
    /// </summary>
    public interface IPersonService
    {
        /// <summary>
        /// The GetListOfPersons.
        /// </summary>
        /// <returns>The list of persons.</returns>
        IList<Person> GetListOfPersons();

        /// <summary>
        /// The DeletePerson.
        /// </summary>
        /// <param name="person">The person.</param>
        /// <returns>Success or not.</returns>
        bool DeletePerson(Person person);

        /// <summary>
        /// The UpdatePerson.
        /// </summary>
        /// <param name="person">The person.</param>
        /// <returns>Success or not.</returns>
        bool UpdatePerson(Person person);

        /// <summary>
        /// The GetPersonById.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The person.</returns>
        Person GetPersonById(int id);

        /// <summary>
        /// The AddPerson.
        /// </summary>
        /// <param name="person">The person parameter.</param>
        /// <returns>The person.</returns>
        bool AddPerson(Person person);

        /// <summary>
        /// The RatePerson.
        /// </summary>
        /// <param name="person">The person<see cref="Person"/>.</param>
        /// <param name="score">The score<see cref="int"/>.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        bool RatePerson(Person person, int score);
    }
}
