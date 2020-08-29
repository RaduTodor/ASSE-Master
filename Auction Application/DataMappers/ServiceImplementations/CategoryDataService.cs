// <copyright file="CategoryDataService.cs" company="Transilvania University of Brasov">
// Todor Radu Constantin
// </copyright>

namespace Auction_Application.DataMappers.ServiceImplementations
{
    using System.Collections.Generic;
    using System.Linq;
    using Auction_Application.DataMappers.Interfaces;
    using Auction_Application.DomainModels;

    /// <summary>
    /// Defines the <see cref="CategoryDataService" />.
    /// </summary>
    public class CategoryDataService : ICategoryDataService
    {
        /// <summary>
        /// The AddCategory.
        /// </summary>
        /// <param name="category">The Category<see cref="Category"/>.</param>
        public void AddCategory(Category category)
        {
            using (ApplicationContext context = new ApplicationContext())
            {
                context.Categories.Add(category);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// The DeleteCategory.
        /// </summary>
        /// <param name="category">The Category.</param>
        public void DeleteCategory(Category category)
        {
            using (ApplicationContext context = new ApplicationContext())
            {
                Category toBeDeleted = new Category { ID = category.ID };
                context.Categories.Attach(toBeDeleted);
                context.Categories.Remove(toBeDeleted);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// The GetAllCategories.
        /// </summary>
        /// <returns>All Categories.</returns>
        public IList<Category> GetAllCategories()
        {
            using (ApplicationContext context = new ApplicationContext())
            {
                return context.Categories.Select(Category => Category).ToList();
            }
        }

        /// <summary>
        /// The UpdateCategory.
        /// </summary>
        /// <param name="category">The Category.</param>
        public void UpdateCategory(Category category)
        {
            using (ApplicationContext context = new ApplicationContext())
            {
                Category toBeUpdated = context.Categories.Find(category.ID);

                if (toBeUpdated == null)
                {
                    return;
                }

                context.Entry(toBeUpdated).CurrentValues.SetValues(category);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// The GetCategoryById.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The Category.</returns>
        public Category GetCategoryById(int id)
        {
            using (var context = new ApplicationContext())
            {
                return context.Categories.Where(Category => Category.ID == id).SingleOrDefault();
            }
        }
    }
}
