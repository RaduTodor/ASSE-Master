// <copyright file="ProductDataServiceTests.cs" company="Transilvania University of Brasov">
// Todor Radu Constantin
// </copyright>

namespace ASSE_Restanta.DataMapperTests
{
    using Auction_Application.DataMappers.Interfaces;
    using Auction_Application.DomainModels;
    using Moq;
    using NUnit.Framework;

    /// <summary>
    /// Defines the <see cref="ProductDataServiceTests" />.
    /// </summary>
    public class ProductDataServiceTests
    {
        /// <summary>
        /// The AddProductTest.
        /// </summary>
        [Test]
        public void AddProductTest()
        {
            Product product = new Mock<Product>().Object;

            Mock<IProductDataService> mock = new Mock<IProductDataService>();
            mock.Setup(m => m.AddProduct(product));

            IProductDataService obj = mock.Object;
            obj.AddProduct(product);

            mock.Verify(o => o.AddProduct(product), Times.Once());
        }

        /// <summary>
        /// The DeleteProductTest.
        /// </summary>
        [Test]
        public void DeleteProductTest()
        {
            Product product = new Mock<Product>().Object;

            Mock<IProductDataService> mock = new Mock<IProductDataService>();
            mock.Setup(m => m.DeleteProduct(product));

            IProductDataService obj = mock.Object;
            obj.DeleteProduct(product);

            mock.Verify(o => o.DeleteProduct(product), Times.Once());
        }

        /// <summary>
        /// The UpdateProductTest.
        /// </summary>
        [Test]
        public void UpdateProductTest()
        {
            Product product = new Mock<Product>().Object;

            Mock<IProductDataService> mock = new Mock<IProductDataService>();
            mock.Setup(m => m.UpdateProduct(product));

            IProductDataService obj = mock.Object;
            obj.UpdateProduct(product);

            mock.Verify(o => o.UpdateProduct(product), Times.Once());
        }

        /// <summary>
        /// The GetAllProductsTest.
        /// </summary>
        [Test]
        public void GetAllProductsTest()
        {
            Mock<IProductDataService> mock = new Mock<IProductDataService>();
            mock.Setup(m => m.GetAllProducts());

            IProductDataService obj = mock.Object;
            obj.GetAllProducts();

            mock.Verify(o => o.GetAllProducts(), Times.Once());
        }

        /// <summary>
        /// The GetProductByIdTest.
        /// </summary>
        [Test]
        public void GetProductByIdTest()
        {
            Mock<IProductDataService> mock = new Mock<IProductDataService>();
            mock.Setup(m => m.GetProductById(1));

            IProductDataService obj = mock.Object;
            obj.GetProductById(1);

            mock.Verify(o => o.GetProductById(1), Times.Once());
        }
    }
}
