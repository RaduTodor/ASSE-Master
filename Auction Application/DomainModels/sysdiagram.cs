// <copyright file="sysdiagram.cs" company="Transilvania University of Brasov">
// Todor Radu Constantin
// </copyright>

namespace Auction_Application.DomainModels
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Defines the <see cref="sysdiagram" />.
    /// </summary>
    public partial class sysdiagram
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        [Required]
        [StringLength(128)]
        public string name { get; set; }

        /// <summary>
        /// Gets or sets the principal_id.
        /// </summary>
        public int principal_id { get; set; }

        /// <summary>
        /// Gets or sets the diagram_id.
        /// </summary>
        [Key]
        public int diagram_id { get; set; }

        /// <summary>
        /// Gets or sets the version.
        /// </summary>
        public int? version { get; set; }

        /// <summary>
        /// Gets or sets the definition.
        /// </summary>
        public byte[] definition { get; set; }
    }
}
