// <copyright file="Configuration.cs" company="Transilvania University of Brasov">
// Todor Radu Constantin
// </copyright>

namespace Auction_Application.DomainModels
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Defines the <see cref="Configuration" />.
    /// </summary>
    public partial class Configuration
    {
        /// <summary>
        /// Gets or sets the ID.
        /// </summary>
        [StringLength(50)]
        public string ID { get; set; }

        /// <summary>
        /// Gets or sets the VALUE.
        /// </summary>
        public int VALUE { get; set; }
    }
}
