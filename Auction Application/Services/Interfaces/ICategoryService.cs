// <copyright file="ICategoryService.cs" company="Transilvania University of Brasov">
// Todor Radu Constantin
// </copyright>

namespace Auction_Application.Services.Interfaces
{
    using System.Collections.Generic;
    using Auction_Application.DomainModels;

    /// <summary>
    /// Defines the <see cref="ICategoryService" />.
    /// </summary>
    public interface ICategoryService
    {
        /// <summary>
        /// The GetListOfCategories.
        /// </summary>
        /// <returns>The list of categories.</returns>
        IList<Category> GetListOfCategories();

        /// <summary>
        /// The DeleteCategory.
        /// </summary>
        /// <param name="category">The category.</param>
        /// <returns>Success or not.</returns>
        bool DeleteCategory(Category category);

        /// <summary>
        /// The UpdateCategory.
        /// </summary>
        /// <param name="category">The category.</param>
        /// <returns>Success or not.</returns>
        bool UpdateCategory(Category category);

        /// <summary>
        /// The GetCategoryById.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The category.</returns>
        Category GetCategoryById(int id);

        /// <summary>
        /// The AddCategory.
        /// </summary>
        /// <param name="category">The category parameter.</param>
        /// <returns>The category.</returns>
        bool AddCategory(Category category);
    }
}
