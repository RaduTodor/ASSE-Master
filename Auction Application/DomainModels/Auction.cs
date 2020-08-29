// <copyright file="Auction.cs" company="Transilvania University of Brasov">
// Todor Radu Constantin
// </copyright>

namespace Auction_Application.DomainModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Defines the <see cref="Auction" />.
    /// </summary>
    [Table("Auction")]
    public partial class Auction
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Auction"/> class.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Auction()
        {
            this.Auction_History = new HashSet<Auction_History>();
        }

        /// <summary>
        /// Gets or sets the ID.
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Gets or sets the CURRENCY.
        /// </summary>
        [Required]
        [StringLength(50)]
        public string CURRENCY { get; set; }

        /// <summary>
        /// Gets or sets the PRODUCT_ID.
        /// </summary>
        public int PRODUCT_ID { get; set; }

        /// <summary>
        /// Gets or sets the OWNER_ID.
        /// </summary>
        public int OWNER_ID { get; set; }

        /// <summary>
        /// Gets or sets the DATE_START.
        /// </summary>
        public DateTime DATE_START { get; set; }

        /// <summary>
        /// Gets or sets the DATE_END.
        /// </summary>
        public DateTime DATE_END { get; set; }

        /// <summary>
        /// Gets or sets the START_PRICE.
        /// </summary>
        public decimal START_PRICE { get; set; }

        /// <summary>
        /// Gets or sets the Auction_History.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Auction_History> Auction_History { get; set; }

        /// <summary>
        /// Gets or sets the Person.
        /// </summary>
        public virtual Person Person { get; set; }

        /// <summary>
        /// Gets or sets the Product.
        /// </summary>
        public virtual Product Product { get; set; }
    }
}
