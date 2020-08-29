// <copyright file="CategoryService.cs" company="Transilvania University of Brasov">
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
    /// Defines the <see cref="CategoryService" />.
    /// </summary>
    public class CategoryService : ICategoryService
    {
        /// <summary>
        /// Defines the Log.
        /// </summary>
        private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(typeof(CategoryService));

        /// <summary>
        /// Gets or sets the DataServices.
        /// </summary>
        public static ICategoryDataService DataServices { get; set; } = new DaoFactory().CategoryDataService;

        /// <summary>
        /// The AddCategory.
        /// </summary>
        /// <param name="category">The category parameter.</param>
        /// <returns>The category.</returns>
        public bool AddCategory(Category category)
        {
            var validator = new CategoryValidator();
            ValidationResult results = validator.Validate(category);

            bool isValid = results.IsValid;

            if (isValid)
            {
                Log.Info("The category is valid!");
                DataServices.AddCategory(category);
                Log.Info("The category was added to the database!");
            }
            else
            {
                IList<ValidationFailure> failures = results.Errors;
                Log.Error($"The category is not valid. The following errors occurred: {failures}");
            }

            return isValid;
        }

        /// <summary>
        /// The DeleteCategory.
        /// </summary>
        /// <param name="category">The category parameter.</param>
        /// <returns>The category.</returns>
        public bool DeleteCategory(Category category)
        {
            var validator = new CategoryValidator();
            ValidationResult results = validator.Validate(category);

            bool isValid = results.IsValid;

            if (isValid)
            {
                Log.Info("The category is valid!");
                DataServices.DeleteCategory(category);
                Log.Info("The category was deleted from the database!");
            }
            else
            {
                IList<ValidationFailure> failures = results.Errors;
                Log.Error($"The category is not valid. The following errors occurred: {failures}");
            }

            return isValid;
        }

        /// <summary>
        /// The GetListOfCategories.
        /// </summary>
        /// <returns>List of categories.</returns>
        public IList<Category> GetListOfCategories()
        {
            return DataServices.GetAllCategories();
        }

        /// <summary>
        /// The GetCategoryById.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The category.</returns>
        public Category GetCategoryById(int id)
        {
            return DataServices.GetCategoryById(id);
        }

        /// <summary>
        /// The UpdateCategory.
        /// </summary>
        /// <param name="category">The category.</param>
        /// <returns>Successful operation or not.</returns>
        public bool UpdateCategory(Category category)
        {
            var validator = new CategoryValidator();
            ValidationResult results = validator.Validate(category);

            bool isValid = results.IsValid;

            if (isValid)
            {
                Log.Info("The category is valid!");
                DataServices.UpdateCategory(category);
                Log.Info("The category was updated in the database!");
            }
            else
            {
                IList<ValidationFailure> failures = results.Errors;
                Log.Error($"The category is not valid. The following errors occurred: {failures}");
            }

            return isValid;
        }
    }
}
