// <copyright file="Auction_History.cs" company="Transilvania University of Brasov">
// Todor Radu Constantin
// </copyright>

namespace Auction_Application.DomainModels
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Defines the <see cref="Auction_History" />.
    /// </summary>
    [Table("Auction History")]
    public partial class Auction_History
    {
        /// <summary>
        /// Gets or sets the ID.
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Gets or sets the AUCTION_ID.
        /// </summary>
        public int AUCTION_ID { get; set; }

        /// <summary>
        /// Gets or sets the PERSON_ID.
        /// </summary>
        public int PERSON_ID { get; set; }

        /// <summary>
        /// Gets or sets the DATE_CREATION.
        /// </summary>
        public DateTime DATE_CREATION { get; set; }

        /// <summary>
        /// Gets or sets the OFFER.
        /// </summary>
        public decimal OFFER { get; set; }

        /// <summary>
        /// Gets or sets the CURRENCY.
        /// </summary>
        public string CURRENCY { get; set; }

        /// <summary>
        /// Gets or sets the Auction.
        /// </summary>
        public virtual Auction Auction { get; set; }

        /// <summary>
        /// Gets or sets the Person.
        /// </summary>
        public virtual Person Person { get; set; }
    }
}
