// <copyright file="IProductService.cs" company="Transilvania University of Brasov">
// Todor Radu Constantin
// </copyright>

namespace Auction_Application.Services.Interfaces
{
    using System.Collections.Generic;
    using Auction_Application.DomainModels;

    /// <summary>
    /// Defines the <see cref="IProductService" />.
    /// </summary>
    public interface IProductService
    {
        /// <summary>
        /// The GetListOfProducts.
        /// </summary>
        /// <returns>The list of products.</returns>
        IList<Product> GetListOfProducts();

        /// <summary>
        /// The DeleteProduct.
        /// </summary>
        /// <param name="product">The product.</param>
        /// <returns>Success or not.</returns>
        bool DeleteProduct(Product product);

        /// <summary>
        /// The UpdateProduct.
        /// </summary>
        /// <param name="product">The product.</param>
        /// <returns>Success or not.</returns>
        bool UpdateProduct(Product product);

        /// <summary>
        /// The GetProductById.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The product.</returns>
        Product GetProductById(int id);

        /// <summary>
        /// The AddProduct.
        /// </summary>
        /// <param name="product">The product parameter.</param>
        /// <returns>The product.</returns>
        bool AddProduct(Product product);
    }
}
