// <copyright file="PersonService.cs" company="Transilvania University of Brasov">
// Todor Radu Constantin
// </copyright>

namespace Auction_Application.Services.Implementation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Auction_Application.Constants;
    using Auction_Application.DataMappers.Interfaces;
    using Auction_Application.DataMappers.ServiceImplementations;
    using Auction_Application.DomainModels;
    using Auction_Application.DomainModels.Validators;
    using Auction_Application.Services.Interfaces;
    using Auction_Application.Utility;
    using FluentValidation.Results;

    /// <summary>
    /// Defines the <see cref="PersonService" />.
    /// </summary>
    public class PersonService : IPersonService
    {
        /// <summary>
        /// Defines the Log.
        /// </summary>
        private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(typeof(PersonService));

        /// <summary>
        /// Defines the scoreHistoryService.
        /// </summary>
        private IScoreHistoryService scoreHistoryService;

        /// <summary>
        /// Defines the configurationService.
        /// </summary>
        private IConfigurationService configurationService;

        /// <summary>
        /// Initializes a new instance of the <see cref="PersonService"/> class.
        /// </summary>
        public PersonService()
        {
            this.scoreHistoryService = new ScoreHistoryService();
            this.configurationService = new ConfigurationService();
        }

        /// <summary>
        /// Gets or sets the DataServices.
        /// </summary>
        public static IPersonDataService DataServices { get; set; } = new DaoFactory().PersonDataService;

        /// <summary>
        /// The AddPerson.
        /// </summary>
        /// <param name="person">The person parameter.</param>
        /// <returns>The person.</returns>
        public bool AddPerson(Person person)
        {
            person.SCORE = this.configurationService.GetConfigurationById(ConfigurationIdentifiers.InitialScoreValue).VALUE;
            var validator = new PersonValidator();
            ValidationResult results = validator.Validate(person);

            bool isValid = results.IsValid;

            if (isValid)
            {
                Log.Info("The person is valid!");
                DataServices.AddPerson(person);
                Log.Info("The person was added to the database!");
            }
            else
            {
                IList<ValidationFailure> failures = results.Errors;
                Log.Error($"The person is not valid. The following errors occurred: {failures}");
            }

            return isValid;
        }

        /// <summary>
        /// The DeletePerson.
        /// </summary>
        /// <param name="person">The person parameter.</param>
        /// <returns>The person.</returns>
        public bool DeletePerson(Person person)
        {
            var validator = new PersonValidator();
            ValidationResult results = validator.Validate(person);

            bool isValid = results.IsValid;

            if (isValid)
            {
                Log.Info("The person is valid!");
                DataServices.DeletePerson(person);
                Log.Info("The person was deleted from the database!");
            }
            else
            {
                IList<ValidationFailure> failures = results.Errors;
                Log.Error($"The person is not valid. The following errors occurred: {failures}");
            }

            return isValid;
        }

        /// <summary>
        /// The GetListOfPersons.
        /// </summary>
        /// <returns>List of persons.</returns>
        public IList<Person> GetListOfPersons()
        {
            return DataServices.GetAllPeople();
        }

        /// <summary>
        /// The GetPersonById.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The person.</returns>
        public Person GetPersonById(int id)
        {
            return DataServices.GetPersonById(id);
        }

        /// <summary>
        /// The RatePerson.
        /// </summary>
        /// <param name="person">The person<see cref="Person"/>.</param>
        /// <param name="score">The score<see cref="int"/>.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        public bool RatePerson(Person person, int score)
        {
            if (score >= 0 && score <= 10)
            {
                var newScore = Convert.ToDecimal(score);
                if (person.SCORE != 11)
                {
                    var scores = this.scoreHistoryService.GetListOfScoreHistories().Where(s => s.PERSON_ID == person.ID);
                    var range = this.configurationService.GetConfigurationById(ConfigurationIdentifiers.ScoreAverageRangeValue).VALUE;
                    newScore = scores.TakeLast(Math.Min(scores.Count(), range)).Average(a => a.SCORE);
                }

                this.scoreHistoryService.AddScoreHistory(new Score_History { SCORE = newScore, DATE = DateTime.Now, PERSON_ID = person.ID });
                person.SCORE = newScore;
                return this.UpdatePerson(person);
            }

            Log.Error("The score is not valid.");
            return false;
        }

        /// <summary>
        /// The UpdatePerson.
        /// </summary>
        /// <param name="person">The person.</param>
        /// <returns>Successful operation or not.</returns>
        public bool UpdatePerson(Person person)
        {
            var validator = new PersonValidator();
            ValidationResult results = validator.Validate(person);

            bool isValid = results.IsValid;

            if (isValid)
            {
                Log.Info("The person is valid!");
                DataServices.UpdatePerson(person);
                Log.Info("The person was updated in the database!");
            }
            else
            {
                IList<ValidationFailure> failures = results.Errors;
                Log.Error($"The person is not valid. The following errors occurred: {failures}");
            }

            return isValid;
        }
    }
}
