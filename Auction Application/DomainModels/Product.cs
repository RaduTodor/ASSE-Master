// <copyright file="Product.cs" company="Transilvania University of Brasov">
// Todor Radu Constantin
// </copyright>

namespace Auction_Application.DomainModels
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Defines the <see cref="Product" />.
    /// </summary>
    [Table("Product")]
    public partial class Product
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Product"/> class.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            this.Auctions = new HashSet<Auction>();
        }

        /// <summary>
        /// Gets or sets the ID.
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Gets or sets the NAME.
        /// </summary>
        [Required]
        [StringLength(50)]
        public string NAME { get; set; }

        /// <summary>
        /// Gets or sets the PARENT_CATEGORY_ID.
        /// </summary>
        public int? PARENT_CATEGORY_ID { get; set; }

        /// <summary>
        /// Gets or sets the Auctions.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Auction> Auctions { get; set; }

        /// <summary>
        /// Gets or sets the Category.
        /// </summary>
        public virtual Category Category { get; set; }
    }
}
