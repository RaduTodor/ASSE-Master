// <copyright file="ProductDataService.cs" company="Transilvania University of Brasov">
// Todor Radu Constantin
// </copyright>

namespace Auction_Application.DataMappers.ServiceImplementations
{
    using System.Collections.Generic;
    using System.Linq;
    using Auction_Application.DataMappers.Interfaces;
    using Auction_Application.DomainModels;

    /// <summary>
    /// Defines the <see cref="ProductDataService" />.
    /// </summary>
    public class ProductDataService : IProductDataService
    {
        /// <summary>
        /// The AddProduct.
        /// </summary>
        /// <param name="product">The Product<see cref="Product"/>.</param>
        public void AddProduct(Product product)
        {
            using (ApplicationContext context = new ApplicationContext())
            {
                context.Products.Add(product);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// The DeleteProduct.
        /// </summary>
        /// <param name="product">The Product.</param>
        public void DeleteProduct(Product product)
        {
            using (ApplicationContext context = new ApplicationContext())
            {
                Product toBeDeleted = new Product { ID = product.ID };
                context.Products.Attach(toBeDeleted);
                context.Products.Remove(toBeDeleted);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// The GetAllProducts.
        /// </summary>
        /// <returns>All Products.</returns>
        public IList<Product> GetAllProducts()
        {
            using (ApplicationContext context = new ApplicationContext())
            {
                return context.Products.Select(Product => Product).ToList();
            }
        }

        /// <summary>
        /// The UpdateProduct.
        /// </summary>
        /// <param name="product">The Product.</param>
        public void UpdateProduct(Product product)
        {
            using (ApplicationContext context = new ApplicationContext())
            {
                Product toBeUpdated = context.Products.Find(product.ID);

                if (toBeUpdated == null)
                {
                    return;
                }

                context.Entry(toBeUpdated).CurrentValues.SetValues(product);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// The GetProductById.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The Product.</returns>
        public Product GetProductById(int id)
        {
            using (var context = new ApplicationContext())
            {
                return context.Products.Where(Product => Product.ID == id).SingleOrDefault();
            }
        }
    }
}
