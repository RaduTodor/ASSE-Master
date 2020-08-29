// <copyright file="ICategoryDataService.cs" company="Transilvania University of Brasov">
// Todor Radu Constantin
// </copyright>

namespace Auction_Application.DataMappers.Interfaces
{
    using System.Collections.Generic;
    using Auction_Application.DomainModels;

    /// <summary>
    /// Defines the <see cref="ICategoryDataService" />.
    /// </summary>
    public interface ICategoryDataService
    {
        /// <summary>
        /// The GetAllCategories.
        /// </summary>
        /// <returns>All Categories.</returns>
        IList<Category> GetAllCategories();

        /// <summary>
        /// The AddCategory.
        /// </summary>
        /// <param name="category">The Category.</param>
        void AddCategory(Category category);

        /// <summary>
        /// The DeleteCategory.
        /// </summary>
        /// <param name="category">The Category.</param>
        void DeleteCategory(Category category);

        /// <summary>
        /// The UpdateCategory.
        /// </summary>
        /// <param name="category">The Category.</param>
        void UpdateCategory(Category category);

        /// <summary>
        /// The GetCategoryById.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The <see cref="Category"/>.</returns>
        Category GetCategoryById(int id);
    }
}
