// <copyright file="ProductServiceTests.cs" company="Transilvania University of Brasov">
// Todor Radu Constantin
// </copyright>

namespace ASSE_Restanta.Tests.ServiceTests
{
    using System;
    using System.Collections.Generic;
    using Auction_Application.DataMappers.Interfaces;
    using Auction_Application.DomainModels;
    using Auction_Application.Services.Implementation;
    using Auction_Application.Services.Interfaces;
    using Moq;
    using NUnit.Framework;

    /// <summary>
    /// Defines the <see cref="ProductServiceTests" />.
    /// </summary>
    public class ProductServiceTests
    {
        /// <summary>
        /// The TestAddProductWithValidData.
        /// </summary>
        [Test]
        public void TestAddProductWithValidData()
        {
            Product product = new Product()
            {
                NAME = "Photocamera",
                Category = new Category { ID = 2, NAME = "Dispozitive mici" },
            };

            IProductService productServices = new ProductService();
            bool result = productServices.AddProduct(product);

            Assert.IsTrue(result);
        }

        /// <summary>
        /// The TestAddProductWithInvalidData.
        /// </summary>
        [Test]
        public void TestAddProductWithInvalidData()
        {
            Product product = new Product();

            IProductService readerServices = new ProductService();
            bool result = readerServices.AddProduct(product);

            Assert.IsFalse(result);
        }

        /// <summary>
        /// The TestDeleteProductWithValidData.
        /// </summary>
        [Test]
        public void TestDeleteProductWithValidData()
        {
            Product product = new Product()
            {
                NAME = "Photocamera",
                Category = new Category { ID = 2, NAME = "Dispozitive mici" },
            };

            IProductService productServices = new ProductService();
            Mock<IProductDataService> mock = new Mock<IProductDataService>();
            mock.Setup(m => m.DeleteProduct(product));

            ProductService.DataServices = mock.Object;
            bool result = productServices.DeleteProduct(product);

            Assert.IsTrue(result);
        }

        /// <summary>
        /// The TestDeleteProductWithInvalidData.
        /// </summary>
        [Test]
        public void TestDeleteProductWithInvalidData()
        {
            Product product = new Product();

            IProductService productServices = new ProductService();
            bool result = productServices.DeleteProduct(product);

            Assert.IsFalse(result);
        }

        /// <summary>
        /// The TestUpdateReaderWithValidData.
        /// </summary>
        [Test]
        public void TestUpdateReaderWithValidData()
        {
            Product product = new Product()
            {
                NAME = "Photocamera",
                Category = new Category { ID = 2, NAME = "Dispozitive mici" },
            };

            IProductService productServices = new ProductService();
            bool result = productServices.UpdateProduct(product);

            Assert.IsTrue(result);
        }

        /// <summary>
        /// The TestUpdateProductWithInvalidData.
        /// </summary>
        [Test]
        public void TestUpdateProductWithInvalidData()
        {
            Product product = new Product();

            IProductService productServices = new ProductService();
            bool result = productServices.UpdateProduct(product);

            Assert.IsFalse(result);
        }

        /// <summary>
        /// The TestGetListOfProducts.
        /// </summary>
        [Test]
        public void TestGetListOfProducts()
        {
            IProductService productServices = new ProductService();
            Mock<IProductDataService> mock = new Mock<IProductDataService>();
            mock.Setup(m => m.GetAllProducts()).Returns(
                new List<Product>()
                {
                    new Product()
                    {
NAME = "Photocamera",
                    }
                });

            ProductService.DataServices = mock.Object;
            var result = productServices.GetListOfProducts();

            Assert.AreNotEqual(result, null);
            Assert.AreEqual((result as List<Product>).Count, 1);
        }

        /// <summary>
        /// The TestGetProductById.
        /// </summary>
        [Test]
        public void TestGetProductById()
        {
            IProductService productServices = new ProductService();
            Mock<IProductDataService> mock = new Mock<IProductDataService>();
            mock.Setup(m => m.GetProductById(2)).Returns(
                    new Product()
                    {
                        ID = 2,
                        NAME = "Photocamera",
                    });

            ProductService.DataServices = mock.Object;
            var result = productServices.GetProductById(2);

            Assert.AreNotEqual(result, null);
            Assert.AreEqual((result as Product).ID, 2);
        }

        /// <summary>
        /// The TestGetProductByIdWithInvalidId.
        /// </summary>
        [Test]
        public void TestGetProductByIdWithInvalidId()
        {
            IProductService productServices = new ProductService();
            Mock<IProductDataService> mock = new Mock<IProductDataService>();
            mock.Setup(m => m.GetProductById(10)).Returns(
                    new Product()
                    {
                        NAME = "Photocamera",
                    });

            ProductService.DataServices = mock.Object;
            var result = productServices.GetProductById(1);

            Assert.AreEqual(result, null);
        }

        /// <summary>
        /// The TestAddNullProduct.
        /// </summary>
        [Test]
        public void TestAddNullProduct()
        {
            Product product = null;

            IProductService productServices = new ProductService();
            Assert.Throws<ArgumentNullException>(() => productServices.AddProduct(product));
        }

        /// <summary>
        /// The TestDeleteNullProduct.
        /// </summary>
        [Test]
        public void TestDeleteNullProduct()
        {
            Product product = null;

            IProductService productServices = new ProductService();
            Assert.Throws<ArgumentNullException>(() => productServices.DeleteProduct(product));
        }

        /// <summary>
        /// The TestUpdateNullProduct.
        /// </summary>
        [Test]
        public void TestUpdateNullProduct()
        {
            Product product = null;

            IProductService productServices = new ProductService();
            Assert.Throws<ArgumentNullException>(() => productServices.UpdateProduct(product));
        }
    }
}
