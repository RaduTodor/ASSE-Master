// <copyright file="AuctionValidator.cs" company="Transilvania University of Brasov">
// Todor Radu Constantin
// </copyright>

namespace Auction_Application.DomainModels.Validators
{
    using System;
    using System.Linq;
    using Auction_Application.Constants;
    using Auction_Application.Services.Implementation;
    using Auction_Application.Services.Interfaces;
    using FluentValidation;

    /// <summary>
    /// Defines the <see cref="AuctionValidator" />.
    /// </summary>
    public class AuctionValidator : AbstractValidator<Auction>
    {
        /// <summary>
        /// Defines the ConfigurationService.
        /// </summary>
        private IConfigurationService configurationService;

        /// <summary>
        /// Defines the AuctionService.
        /// </summary>
        private IAuctionService auctionService;

        /// <summary>
        /// Defines the CategoryService.
        /// </summary>
        private ICategoryService categoryService;

        /// <summary>
        /// Initializes a new instance of the <see cref="AuctionValidator"/> class.
        /// </summary>
        public AuctionValidator()
        {
            this.configurationService = new ConfigurationService();
            this.auctionService = new AuctionService();
            this.categoryService = new CategoryService();

            RuleFor(x => x.CURRENCY).NotEmpty().WithErrorCode("This field is required.");
            RuleFor(x => x.Product).NotEmpty().WithErrorCode("This field is required.");
            RuleFor(x => x.Person).NotEmpty().WithErrorCode("This field is required.");
            RuleFor(x => x.DATE_START).NotEmpty().WithErrorCode("This field is required.");
            RuleFor(x => x.DATE_END).NotEmpty().WithErrorCode("This field is required.");
            RuleFor(x => x.START_PRICE).NotEmpty().WithErrorCode("This field is required.");
            RuleFor(x => x.CURRENCY).Length(2, 50).WithErrorCode("The name size of currency is not correct.");
            RuleFor(x => x.DATE_END).GreaterThan(DateTime.Now).WithErrorCode("The auction has been finished and cannot be modified anymore.");
        }

        /// <summary>
        /// The InsertValidator.
        /// </summary>
        public void InsertValidator()
        {
            RuleFor(x => x.Person).Must(this.IsPersonAllowedToAdd).WithErrorCode("The user is not allwed to add an auction.");
            RuleFor(x => x.Person).Must(this.AuctionsUnfinished).WithErrorCode("The user has too many auctions not yet finished.");
            RuleFor(x => x).Must(args => this.IsEndDateValid(args.DATE_END, args.DATE_START)).WithErrorCode("The date range is not correct.");
            RuleFor(x => x.START_PRICE).Must(this.IsStartPriceValid).WithErrorCode("The price set is too low.");
        }

        /// <summary>
        /// The IsStartPriceValid.
        /// </summary>
        /// <param name="price">The price<see cref="decimal"/>.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        private bool IsStartPriceValid(decimal price)
        {
            if (price >= this.configurationService.GetConfigurationById(ConfigurationIdentifiers.LowestAuctionValue).VALUE)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// The IsEndDateValid.
        /// </summary>
        /// <param name="dateEnd">The dateEnd<see cref="DateTime"/>.</param>
        /// <param name="dateStart">The dateStart<see cref="DateTime"/>.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        private bool IsEndDateValid(DateTime dateEnd, DateTime dateStart)
        {
            if (dateStart > DateTime.Now.AddHours(-1) && dateStart < dateEnd && dateStart > dateEnd.AddMonths(-4))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// The IsPersonAllowedToAdd.
        /// </summary>
        /// <param name="person">The person<see cref="Person"/>.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        private bool IsPersonAllowedToAdd(Person person)
        {
            if (person.Role.NAME != RolesIdentifiers.SellerTitle)
            {
                return false;
            }

            if (person.SCORE < this.configurationService.GetConfigurationById(ConfigurationIdentifiers.LowestScoreLimit).VALUE)
            {
                if (person.Score_History.LastOrDefault().DATE >= DateTime.Now.AddDays(-this.configurationService.GetConfigurationById(ConfigurationIdentifiers.DaysAuctionBan).VALUE))
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// The AuctionsUnfinished.
        /// </summary>
        /// <param name="person">The person<see cref="Person"/>.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        private bool AuctionsUnfinished(Person person)
        {
            var auctions = this.auctionService.GetListOfAuctionsSoldBy(person);
            if (auctions.Count(a => a.DATE_END > DateTime.Now) > this.configurationService.GetConfigurationById(ConfigurationIdentifiers.MaxAuctionsUnfinished).VALUE)
            {
                return false;
            }

            var auctionsForCategory = auctions.ToLookup(a => a.Product.Category, a => a);
            foreach (var category in this.categoryService.GetListOfCategories())
            {
                if (auctionsForCategory[category].Count(a => a.DATE_END > DateTime.Now) > this.configurationService.GetConfigurationById(ConfigurationIdentifiers.MaxAuctionsUnfinishedPerCategory).VALUE)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
