// <copyright file="IRoleDataService.cs" company="Transilvania University of Brasov">
// Todor Radu Constantin
// </copyright>

namespace Auction_Application.DataMappers.Interfaces
{
    using System.Collections.Generic;
    using Auction_Application.DomainModels;

    /// <summary>
    /// Defines the <see cref="IRoleDataService" />.
    /// </summary>
    public interface IRoleDataService
    {
        /// <summary>
        /// The GetAllRoles.
        /// </summary>
        /// <returns>All Roles.</returns>
        IList<Role> GetAllRoles();

        /// <summary>
        /// The AddRole.
        /// </summary>
        /// <param name="role">The Role.</param>
        void AddRole(Role role);

        /// <summary>
        /// The DeleteRole.
        /// </summary>
        /// <param name="role">The Role.</param>
        void DeleteRole(Role role);

        /// <summary>
        /// The UpdateRole.
        /// </summary>
        /// <param name="role">The Role.</param>
        void UpdateRole(Role role);

        /// <summary>
        /// The GetRoleById.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The <see cref="Role"/>.</returns>
        Role GetRoleById(int id);
    }
}
