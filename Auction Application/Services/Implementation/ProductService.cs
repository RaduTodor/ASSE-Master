// <copyright file="ProductService.cs" company="Transilvania University of Brasov">
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
    /// Defines the <see cref="ProductService" />.
    /// </summary>
    public class ProductService : IProductService
    {
        /// <summary>
        /// Defines the Log.
        /// </summary>
        private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(typeof(ProductService));

        /// <summary>
        /// Gets or sets the DataServices.
        /// </summary>
        public static IProductDataService DataServices { get; set; } = new DaoFactory().ProductDataService;

        /// <summary>
        /// The AddProduct.
        /// </summary>
        /// <param name="product">The product parameter.</param>
        /// <returns>The product.</returns>
        public bool AddProduct(Product product)
        {
            var validator = new ProductValidator();
            ValidationResult results = validator.Validate(product);

            bool isValid = results.IsValid;

            if (isValid)
            {
                Log.Info("The product is valid!");
                DataServices.AddProduct(product);
                Log.Info("The product was added to the database!");
            }
            else
            {
                IList<ValidationFailure> failures = results.Errors;
                Log.Error($"The product is not valid. The following errors occurred: {failures}");
            }

            return isValid;
        }

        /// <summary>
        /// The DeleteProduct.
        /// </summary>
        /// <param name="product">The product parameter.</param>
        /// <returns>The product.</returns>
        public bool DeleteProduct(Product product)
        {
            var validator = new ProductValidator();
            ValidationResult results = validator.Validate(product);

            bool isValid = results.IsValid;

            if (isValid)
            {
                Log.Info("The product is valid!");
                DataServices.DeleteProduct(product);
                Log.Info("The product was deleted from the database!");
            }
            else
            {
                IList<ValidationFailure> failures = results.Errors;
                Log.Error($"The product is not valid. The following errors occurred: {failures}");
            }

            return isValid;
        }

        /// <summary>
        /// The GetListOfProducts.
        /// </summary>
        /// <returns>List of products.</returns>
        public IList<Product> GetListOfProducts()
        {
            return DataServices.GetAllProducts();
        }

        /// <summary>
        /// The GetProductById.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The product.</returns>
        public Product GetProductById(int id)
        {
            return DataServices.GetProductById(id);
        }

        /// <summary>
        /// The UpdateProduct.
        /// </summary>
        /// <param name="product">The product.</param>
        /// <returns>Successful operation or not.</returns>
        public bool UpdateProduct(Product product)
        {
            var validator = new ProductValidator();
            ValidationResult results = validator.Validate(product);

            bool isValid = results.IsValid;

            if (isValid)
            {
                Log.Info("The product is valid!");
                DataServices.UpdateProduct(product);
                Log.Info("The product was updated in the database!");
            }
            else
            {
                IList<ValidationFailure> failures = results.Errors;
                Log.Error($"The product is not valid. The following errors occurred: {failures}");
            }

            return isValid;
        }
    }
}
