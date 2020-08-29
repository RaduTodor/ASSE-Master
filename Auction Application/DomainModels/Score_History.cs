// <copyright file="Score_History.cs" company="Transilvania University of Brasov">
// Todor Radu Constantin
// </copyright>

namespace Auction_Application.DomainModels
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Defines the <see cref="Score_History" />.
    /// </summary>
    [Table("Score History")]
    public partial class Score_History
    {
        /// <summary>
        /// Gets or sets the ID.
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Gets or sets the PERSON_ID.
        /// </summary>
        public int PERSON_ID { get; set; }

        /// <summary>
        /// Gets or sets the SCORE.
        /// </summary>
        public decimal SCORE { get; set; }

        /// <summary>
        /// Gets or sets the DATE.
        /// </summary>
        public DateTime DATE { get; set; }

        /// <summary>
        /// Gets or sets the Person.
        /// </summary>
        public virtual Person Person { get; set; }
    }
}
