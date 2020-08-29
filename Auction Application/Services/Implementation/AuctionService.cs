// <copyright file="AuctionService.cs" company="Transilvania University of Brasov">
// Todor Radu Constantin
// </copyright>

namespace Auction_Application.Services.Implementation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Auction_Application.DataMappers.Interfaces;
    using Auction_Application.DataMappers.ServiceImplementations;
    using Auction_Application.DomainModels;
    using Auction_Application.DomainModels.Validators;
    using Auction_Application.Services.Interfaces;
    using FluentValidation.Results;

    /// <summary>
    /// Defines the <see cref="AuctionService" />.
    /// </summary>
    public class AuctionService : IAuctionService
    {
        /// <summary>
        /// Defines the Log.
        /// </summary>
        private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(typeof(AuctionService));

        /// <summary>
        /// Gets or sets the DataServices.
        /// </summary>
        public static IAuctionDataService DataServices { get; set; } = new DaoFactory().AuctionDataService;

        /// <summary>
        /// The AddAuction.
        /// </summary>
        /// <param name="auction">The auction parameter.</param>
        /// <returns>The auction.</returns>
        public bool AddAuction(Auction auction)
        {
            var validator = new AuctionValidator();
            validator.InsertValidator();
            ValidationResult results = validator.Validate(auction);

            bool isValid = results.IsValid;

            if (isValid)
            {
                Log.Info("The auction is valid!");
                DataServices.AddAuction(auction);
                Log.Info("The auction was added to the database!");
            }
            else
            {
                IList<ValidationFailure> failures = results.Errors;
                Log.Error($"The auction is not valid. The following errors occurred: {failures}");
            }

            return isValid;
        }

        /// <summary>
        /// The DeleteAuction.
        /// </summary>
        /// <param name="auction">The auction parameter.</param>
        /// <returns>The auction.</returns>
        public bool DeleteAuction(Auction auction)
        {
            var validator = new AuctionValidator();
            ValidationResult results = validator.Validate(auction);

            bool isValid = results.IsValid;

            if (isValid)
            {
                Log.Info("The auction is valid!");
                DataServices.DeleteAuction(auction);
                Log.Info("The auction was deleted from the database!");
            }
            else
            {
                IList<ValidationFailure> failures = results.Errors;
                Log.Error($"The auction is not valid. The following errors occurred: {failures}");
            }

            return isValid;
        }

        /// <summary>
        /// The GetListOfAuctions.
        /// </summary>
        /// <returns>List of auctions.</returns>
        public IList<Auction> GetListOfAuctions()
        {
            return DataServices.GetAllAuctions();
        }

        /// <summary>
        /// The GetAuctionById.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The auction.</returns>
        public Auction GetAuctionById(int id)
        {
            return DataServices.GetAuctionById(id);
        }

        /// <summary>
        /// The UpdateAuction.
        /// </summary>
        /// <param name="auction">The auction.</param>
        /// <returns>Successful operation or not.</returns>
        public bool UpdateAuction(Auction auction)
        {
            var validator = new AuctionValidator();
            ValidationResult results = validator.Validate(auction);

            bool isValid = results.IsValid;

            if (isValid)
            {
                Log.Info("The auction is valid!");
                DataServices.UpdateAuction(auction);
                Log.Info("The auction was updated in the database!");
            }
            else
            {
                IList<ValidationFailure> failures = results.Errors;
                Log.Error($"The auction is not valid. The following errors occurred: {failures}");
            }

            return isValid;
        }

        /// <summary>
        /// The GetListOfAuctionsSoldBy.
        /// </summary>
        /// <param name="person">The person<see cref="Person"/>.</param>
        /// <returns>List of auctions.</returns>
        public IList<Auction> GetListOfAuctionsSoldBy(Person person)
        {
            return DataServices.GetAllAuctions().Where(a => a.Person.ID == person.ID).ToList();
        }

        /// <summary>
        /// The EndAuctionManually.
        /// </summary>
        /// <param name="auction">The auction<see cref="Auction"/>.</param>
        /// <param name="person">The person<see cref="Person"/>.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        public bool EndAuctionManually(Auction auction, Person person)
        {
            if (auction.Person.ID == person.ID)
            {
                auction.DATE_END = DateTime.Now;
                return this.UpdateAuction(auction);
            }

            Log.Error($"The stop of auction was not possible because only the owner of an auction is allowed to manually stop it.");
            return false;
        }
    }
}
