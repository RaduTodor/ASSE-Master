// <copyright file="ProductDataServiceTests.cs" company="Transilvania University of Brasov">
// Todor Radu Constantin
// </copyright>

namespace ASSE_Restanta.DataMapperTests
{
    using Auction_Application.DataMappers.Interfaces;
    using Auction_Application.DataMappers.ServiceImplementations;
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

        /// <summary>
        /// The AddProductImplementationTest.
        /// </summary>
        [Test]
        public void AddProductImplementationTest()
        {
            Product product = new Product
            {
                NAME = "Photocamera",
                Category = new Category { ID = 2, NAME = "Dispozitive mici" },
            };

            ProductDataService service = new ProductDataService();
            try
            {
                service.AddProduct(product);
                product.NAME = "Phone";
                service.UpdateProduct(product);
                var people = service.GetAllProducts();
                var sameProduct = service.GetProductById(product.ID);
                service.DeleteProduct(product);
            }
            catch
            {
                throw;
            }
        }
    }
}
