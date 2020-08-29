// <copyright file="IRoleService.cs" company="Transilvania University of Brasov">
// Todor Radu Constantin
// </copyright>

namespace Auction_Application.Services.Interfaces
{
    using System.Collections.Generic;
    using Auction_Application.DomainModels;

    /// <summary>
    /// Defines the <see cref="IRoleService" />.
    /// </summary>
    public interface IRoleService
    {
        /// <summary>
        /// The GetListOfRoles.
        /// </summary>
        /// <returns>The list of roles.</returns>
        IList<Role> GetListOfRoles();

        /// <summary>
        /// The DeleteRole.
        /// </summary>
        /// <param name="role">The role.</param>
        /// <returns>Success or not.</returns>
        bool DeleteRole(Role role);

        /// <summary>
        /// The UpdateRole.
        /// </summary>
        /// <param name="role">The role.</param>
        /// <returns>Success or not.</returns>
        bool UpdateRole(Role role);

        /// <summary>
        /// The GetRoleById.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The role.</returns>
        Role GetRoleById(int id);

        /// <summary>
        /// The AddRole.
        /// </summary>
        /// <param name="role">The role parameter.</param>
        /// <returns>The role.</returns>
        bool AddRole(Role role);
    }
}
