// <copyright file="IProductDataService.cs" company="Transilvania University of Brasov">
// Todor Radu Constantin
// </copyright>

namespace Auction_Application.DataMappers.Interfaces
{
    using System.Collections.Generic;
    using Auction_Application.DomainModels;

    /// <summary>
    /// Defines the <see cref="IProductDataService" />.
    /// </summary>
    public interface IProductDataService
    {
        /// <summary>
        /// The GetAllProducts.
        /// </summary>
        /// <returns>All Products.</returns>
        IList<Product> GetAllProducts();

        /// <summary>
        /// The AddProduct.
        /// </summary>
        /// <param name="product">The Product.</param>
        void AddProduct(Product product);

        /// <summary>
        /// The DeleteProduct.
        /// </summary>
        /// <param name="product">The Product.</param>
        void DeleteProduct(Product product);

        /// <summary>
        /// The UpdateProduct.
        /// </summary>
        /// <param name="product">The Product.</param>
        void UpdateProduct(Product product);

        /// <summary>
        /// The GetProductById.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The <see cref="Product"/>.</returns>
        Product GetProductById(int id);
    }
}
