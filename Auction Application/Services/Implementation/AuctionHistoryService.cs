// <copyright file="AuctionHistoryService.cs" company="Transilvania University of Brasov">
// Todor Radu Constantin
// </copyright>

namespace Auction_Application.Services.Implementation
{
    using System;
    using System.Collections.Generic;
    using Auction_Application.DataMappers.Interfaces;
    using Auction_Application.DataMappers.ServiceImplementations;
    using Auction_Application.DomainModels;
    using Auction_Application.DomainModels.Validators;
    using Auction_Application.Services.Interfaces;
    using FluentValidation.Results;

    /// <summary>
    /// Defines the <see cref="AuctionHistoryService" />.
    /// </summary>
    public class AuctionHistoryService : IAuctionHistoryService
    {
        /// <summary>
        /// Defines the Log.
        /// </summary>
        private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(typeof(AuctionHistoryService));

        /// <summary>
        /// Gets or sets the DataServices.
        /// </summary>
        public static IAuction_HistoryDataService DataServices { get; set; } = new DaoFactory().Auction_HistoryDataService;

        /// <summary>
        /// The AddAuctionHistory.
        /// </summary>
        /// <param name="auctionHistory">The auctionHistory parameter.</param>
        /// <returns>The auctionHistory.</returns>
        public bool AddAuctionHistory(Auction_History auctionHistory)
        {
            var validator = new AuctionHistoryValidator();
            validator.InsertValidator();
            ValidationResult results = validator.Validate(auctionHistory);

            bool isValid = results.IsValid;

            if (isValid)
            {
                Log.Info("The auctionHistory is valid!");
                DataServices.AddAuction_History(auctionHistory);
                Log.Info("The auctionHistory was added to the database!");
            }
            else
            {
                IList<ValidationFailure> failures = results.Errors;
                Log.Error($"The auctionHistory is not valid. The following errors occurred: {failures}");
            }

            return isValid;
        }

        /// <summary>
        /// The DeleteAuctionHistory.
        /// </summary>
        /// <param name="auctionHistory">The auctionHistory parameter.</param>
        /// <returns>The auctionHistory.</returns>
        public bool DeleteAuctionHistory(Auction_History auctionHistory)
        {
            var validator = new AuctionHistoryValidator();
            ValidationResult results = validator.Validate(auctionHistory);

            bool isValid = results.IsValid;

            if (isValid)
            {
                Log.Info("The auctionHistory is valid!");
                DataServices.DeleteAuction_History(auctionHistory);
                Log.Info("The auctionHistory was deleted from the database!");
            }
            else
            {
                IList<ValidationFailure> failures = results.Errors;
                Log.Error($"The auctionHistory is not valid. The following errors occurred: {failures}");
            }

            return isValid;
        }

        /// <summary>
        /// The GetListOfAuctionHistories.
        /// </summary>
        /// <returns>List of auctionHistories.</returns>
        public IList<Auction_History> GetListOfAuctionHistories()
        {
            return DataServices.GetAllAuction_Histories();
        }

        /// <summary>
        /// The GetAuctionHistoryById.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The auctionHistory.</returns>
        public Auction_History GetAuctionHistoryById(int id)
        {
            return DataServices.GetAuction_HistoryById(id);
        }

        /// <summary>
        /// The UpdateAuctionHistory.
        /// </summary>
        /// <param name="auctionHistory">The auctionHistory.</param>
        /// <returns>Successful operation or not.</returns>
        public bool UpdateAuctionHistory(Auction_History auctionHistory)
        {
            var validator = new AuctionHistoryValidator();
            ValidationResult results = validator.Validate(auctionHistory);

            bool isValid = results.IsValid;

            if (isValid)
            {
                Log.Info("The auctionHistory is valid!");
                DataServices.UpdateAuction_History(auctionHistory);
                Log.Info("The auctionHistory was updated in the database!");
            }
            else
            {
                IList<ValidationFailure> failures = results.Errors;
                Log.Error($"The auctionHistory is not valid. The following errors occurred: {failures}");
            }

            return isValid;
        }

        /// <summary>
        /// The PlaceOffer.
        /// </summary>
        /// <param name="person">The person<see cref="Person"/>.</param>
        /// <param name="auction">The auction<see cref="Auction"/>.</param>
        /// <param name="currency">The currency<see cref="string"/>.</param>
        /// <param name="offer">The offer<see cref="decimal"/>.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        public bool PlaceOffer(Person person, Auction auction, string currency, decimal offer)
        {
            var validator = new PersonValidator();
            ValidationResult results = validator.Validate(person);
            bool isValid = results.IsValid;
            if (!isValid)
            {
                IList<ValidationFailure> failures = results.Errors;
                Log.Error($"The person is not valid. The following errors occurred: {failures}");
                return false;
            }

            var auctionValidator = new AuctionValidator();
            results = auctionValidator.Validate(auction);
            isValid = results.IsValid;
            if (!isValid)
            {
                IList<ValidationFailure> failures = results.Errors;
                Log.Error($"The auction is not valid. The following errors occurred: {failures}");
                return false;
            }

            return this.AddAuctionHistory(new Auction_History { Auction = auction, CURRENCY = currency, OFFER = offer, DATE_CREATION = DateTime.Now, Person = person, AUCTION_ID = auction.ID, PERSON_ID = person.ID });
        }
    }
}
