// <copyright file="Person.cs" company="Transilvania University of Brasov">
// Todor Radu Constantin
// </copyright>

namespace Auction_Application.DomainModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Defines the <see cref="Person" />.
    /// </summary>
    [Table("Person")]
    public partial class Person
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Person"/> class.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Person()
        {
            this.Auctions = new HashSet<Auction>();
            this.Auction_History = new HashSet<Auction_History>();
            this.Score_History = new HashSet<Score_History>();
        }

        /// <summary>
        /// Gets or sets the ID.
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Gets or sets the FIRST_NAME.
        /// </summary>
        [Required]
        [StringLength(50)]
        public string FIRST_NAME { get; set; }

        /// <summary>
        /// Gets or sets the LAST_NAME.
        /// </summary>
        [Required]
        [StringLength(50)]
        public string LAST_NAME { get; set; }

        /// <summary>
        /// Gets or sets the ROLE_ID.
        /// </summary>
        public int ROLE_ID { get; set; }

        /// <summary>
        /// Gets or sets the SCORE.
        /// </summary>
        public decimal SCORE { get; set; }

        /// <summary>
        /// Gets or sets the DATE_BAN.
        /// </summary>
        public DateTime? DATE_BAN { get; set; }

        /// <summary>
        /// Gets or sets the Auctions.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Auction> Auctions { get; set; }

        /// <summary>
        /// Gets or sets the Auction_History.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Auction_History> Auction_History { get; set; }

        /// <summary>
        /// Gets or sets the Role.
        /// </summary>
        public virtual Role Role { get; set; }

        /// <summary>
        /// Gets or sets the Score_History.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Score_History> Score_History { get; set; }
    }
}
