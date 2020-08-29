// <copyright file="RoleDataService.cs" company="Transilvania University of Brasov">
// Todor Radu Constantin
// </copyright>

namespace Auction_Application.DataMappers.ServiceImplementations
{
    using System.Collections.Generic;
    using System.Linq;
    using Auction_Application.DataMappers.Interfaces;
    using Auction_Application.DomainModels;

    /// <summary>
    /// Defines the <see cref="RoleDataService" />.
    /// </summary>
    public class RoleDataService : IRoleDataService
    {
        /// <summary>
        /// The AddRole.
        /// </summary>
        /// <param name="role">The Role<see cref="Role"/>.</param>
        public void AddRole(Role role)
        {
            using (ApplicationContext context = new ApplicationContext())
            {
                context.Roles.Add(role);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// The DeleteRole.
        /// </summary>
        /// <param name="role">The Role.</param>
        public void DeleteRole(Role role)
        {
            using (ApplicationContext context = new ApplicationContext())
            {
                Role toBeDeleted = new Role { ID = role.ID };
                context.Roles.Attach(toBeDeleted);
                context.Roles.Remove(toBeDeleted);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// The GetAllRoles.
        /// </summary>
        /// <returns>All Roles.</returns>
        public IList<Role> GetAllRoles()
        {
            using (ApplicationContext context = new ApplicationContext())
            {
                return context.Roles.Select(Role => Role).ToList();
            }
        }

        /// <summary>
        /// The UpdateRole.
        /// </summary>
        /// <param name="role">The Role.</param>
        public void UpdateRole(Role role)
        {
            using (ApplicationContext context = new ApplicationContext())
            {
                Role toBeUpdated = context.Roles.Find(role.ID);

                if (toBeUpdated == null)
                {
                    return;
                }

                context.Entry(toBeUpdated).CurrentValues.SetValues(role);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// The GetRoleById.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The Role.</returns>
        public Role GetRoleById(int id)
        {
            using (var context = new ApplicationContext())
            {
                return context.Roles.Where(Role => Role.ID == id).SingleOrDefault();
            }
        }
    }
}
