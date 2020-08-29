// <copyright file="RoleService.cs" company="Transilvania University of Brasov">
// Todor Radu Constantin
// </copyright>

namespace Auction_Application.Services.Implementation
{
    using System.Collections.Generic;
    using Auction_Application.DataMappers.Interfaces;
    using Auction_Application.DataMappers.ServiceImplementations;
    using Auction_Application.DomainModels;
    using Auction_Application.DomainModels.Validators;
    using Auction_Application.Services.Interfaces;
    using FluentValidation.Results;

    /// <summary>
    /// Defines the <see cref="RoleService" />.
    /// </summary>
    public class RoleService : IRoleService
    {
        /// <summary>
        /// Defines the Log.
        /// </summary>
        private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(typeof(RoleService));

        /// <summary>
        /// Gets or sets the DataServices.
        /// </summary>
        public static IRoleDataService DataServices { get; set; } = new DaoFactory().RoleDataService;

        /// <summary>
        /// The AddRole.
        /// </summary>
        /// <param name="role">The role parameter.</param>
        /// <returns>The role.</returns>
        public bool AddRole(Role role)
        {
            var validator = new RoleValidator();
            ValidationResult results = validator.Validate(role);

            bool isValid = results.IsValid;

            if (isValid)
            {
                Log.Info("The role is valid!");
                DataServices.AddRole(role);
                Log.Info("The role was added to the database!");
            }
            else
            {
                IList<ValidationFailure> failures = results.Errors;
                Log.Error($"The role is not valid. The following errors occurred: {failures}");
            }

            return isValid;
        }

        /// <summary>
        /// The DeleteRole.
        /// </summary>
        /// <param name="role">The role parameter.</param>
        /// <returns>The role.</returns>
        public bool DeleteRole(Role role)
        {
            var validator = new RoleValidator();
            ValidationResult results = validator.Validate(role);

            bool isValid = results.IsValid;

            if (isValid)
            {
                Log.Info("The role is valid!");
                DataServices.DeleteRole(role);
                Log.Info("The role was deleted from the database!");
            }
            else
            {
                IList<ValidationFailure> failures = results.Errors;
                Log.Error($"The role is not valid. The following errors occurred: {failures}");
            }

            return isValid;
        }

        /// <summary>
        /// The GetListOfRoles.
        /// </summary>
        /// <returns>List of roles.</returns>
        public IList<Role> GetListOfRoles()
        {
            return DataServices.GetAllRoles();
        }

        /// <summary>
        /// The GetRoleById.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The role.</returns>
        public Role GetRoleById(int id)
        {
            return DataServices.GetRoleById(id);
        }

        /// <summary>
        /// The UpdateRole.
        /// </summary>
        /// <param name="role">The role.</param>
        /// <returns>Successful operation or not.</returns>
        public bool UpdateRole(Role role)
        {
            var validator = new RoleValidator();
            ValidationResult results = validator.Validate(role);

            bool isValid = results.IsValid;

            if (isValid)
            {
                Log.Info("The role is valid!");
                DataServices.UpdateRole(role);
                Log.Info("The role was updated in the database!");
            }
            else
            {
                IList<ValidationFailure> failures = results.Errors;
                Log.Error($"The role is not valid. The following errors occurred: {failures}");
            }

            return isValid;
        }
    }
}
