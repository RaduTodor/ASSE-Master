// <copyright file="AuctionHistoryValidator.cs" company="Transilvania University of Brasov">
// Todor Radu Constantin
// </copyright>

namespace Auction_Application.DomainModels.Validators
{
    using System.Linq;
    using Auction_Application.Constants;
    using Auction_Application.Services.Implementation;
    using Auction_Application.Services.Interfaces;
    using FluentValidation;

    /// <summary>
    /// Defines the <see cref="AuctionValidator" />.
    /// </summary>
    public class AuctionHistoryValidator : AbstractValidator<Auction_History>
    {
        /// <summary>
        /// Defines the auctionHistoryService.
        /// </summary>
        private IAuctionHistoryService auctionHistoryService;

        /// <summary>
        /// Initializes a new instance of the <see cref="AuctionHistoryValidator"/> class.
        /// </summary>
        public AuctionHistoryValidator()
        {
            this.auctionHistoryService = new AuctionHistoryService();

            RuleFor(x => x.Auction).NotEmpty().WithErrorCode("This field is required.");
            RuleFor(x => x.Person).NotEmpty().WithErrorCode("This field is required.");
            RuleFor(x => x.DATE_CREATION).NotEmpty().WithErrorCode("This field is required.");
            RuleFor(x => x.OFFER).NotEmpty().WithErrorCode("This field is required.");
        }

        /// <summary>
        /// The InsertValidator.
        /// </summary>
        public void InsertValidator()
        {
            RuleFor(x => x.CURRENCY).Equal(x => x.Auction.CURRENCY).WithErrorCode("The currency must be the same as the auction currency.");
            RuleFor(x => x.Person).Must(this.IsUserBuyer).WithErrorCode("The user must be a buyer.");
            RuleFor(x => x).Must(x => this.IsOfferValid(x.OFFER, x.Auction)).WithErrorCode("The offer was invalid.");
        }

        /// <summary>
        /// The IsOfferValid.
        /// </summary>
        /// <param name="offer">The offer<see cref="decimal"/>.</param>
        /// <param name="auction">The auction<see cref="Auction"/>.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        private bool IsOfferValid(decimal offer, Auction auction)
        {
            var lastOffer = this.auctionHistoryService.GetListOfAuctionHistories().LastOrDefault(a => a.AUCTION_ID == auction.ID).OFFER;
            if (offer > lastOffer && offer < (lastOffer * 11) / 10)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// The IsUserBuyer.
        /// </summary>
        /// <param name="person">The person<see cref="Person"/>.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        private bool IsUserBuyer(Person person)
        {
            if (person.Role.NAME != RolesIdentifiers.BuyerTitle)
            {
                return false;
            }

            return true;
        }
    }
}
