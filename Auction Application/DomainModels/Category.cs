// <copyright file="Category.cs" company="Transilvania University of Brasov">
// Todor Radu Constantin
// </copyright>

namespace Auction_Application.DomainModels
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Defines the <see cref="Category" />.
    /// </summary>
    [Table("Category")]
    public partial class Category
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Category"/> class.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Category()
        {
            this.Category1 = new HashSet<Category>();
            this.Products = new HashSet<Product>();
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
        /// Gets or sets the Category1.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Category> Category1 { get; set; }

        /// <summary>
        /// Gets or sets the Category2.
        /// </summary>
        public virtual Category Category2 { get; set; }

        /// <summary>
        /// Gets or sets the Products.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Product> Products { get; set; }
    }
}
