// <copyright file="CategoryDataServiceTests.cs" company="Transilvania University of Brasov">
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
    /// Defines the <see cref="CategoryDataServiceTests" />.
    /// </summary>
    public class CategoryDataServiceTests
    {
        /// <summary>
        /// The AddCategoryTest.
        /// </summary>
        [Test]
        public void AddCategoryTest()
        {
            Category category = new Mock<Category>().Object;

            Mock<ICategoryDataService> mock = new Mock<ICategoryDataService>();
            mock.Setup(m => m.AddCategory(category));

            ICategoryDataService obj = mock.Object;
            obj.AddCategory(category);

            mock.Verify(o => o.AddCategory(category), Times.Once());
        }

        /// <summary>
        /// The DeleteCategoryTest.
        /// </summary>
        [Test]
        public void DeleteCategoryTest()
        {
            Category category = new Mock<Category>().Object;

            Mock<ICategoryDataService> mock = new Mock<ICategoryDataService>();
            mock.Setup(m => m.DeleteCategory(category));

            ICategoryDataService obj = mock.Object;
            obj.DeleteCategory(category);

            mock.Verify(o => o.DeleteCategory(category), Times.Once());
        }

        /// <summary>
        /// The UpdateCategoryTest.
        /// </summary>
        [Test]
        public void UpdateCategoryTest()
        {
            Category category = new Mock<Category>().Object;

            Mock<ICategoryDataService> mock = new Mock<ICategoryDataService>();
            mock.Setup(m => m.UpdateCategory(category));

            ICategoryDataService obj = mock.Object;
            obj.UpdateCategory(category);

            mock.Verify(o => o.UpdateCategory(category), Times.Once());
        }

        /// <summary>
        /// The GetAllCategoriesTest.
        /// </summary>
        [Test]
        public void GetAllCategoriesTest()
        {
            Mock<ICategoryDataService> mock = new Mock<ICategoryDataService>();
            mock.Setup(m => m.GetAllCategories());

            ICategoryDataService obj = mock.Object;
            obj.GetAllCategories();

            mock.Verify(o => o.GetAllCategories(), Times.Once());
        }

        /// <summary>
        /// The GetCategoryByIdTest.
        /// </summary>
        [Test]
        public void GetCategoryByIdTest()
        {
            Mock<ICategoryDataService> mock = new Mock<ICategoryDataService>();
            mock.Setup(m => m.GetCategoryById(1));

            ICategoryDataService obj = mock.Object;
            obj.GetCategoryById(1);

            mock.Verify(o => o.GetCategoryById(1), Times.Once());
        }

        /// <summary>
        /// The AddCategoryImplementationTest.
        /// </summary>
        [Test]
        public void AddCategoryImplementationTest()
        {
            Category category = new Category
            {
                NAME = "Computers",
            };

            CategoryDataService service = new CategoryDataService();
            try
            {
                service.AddCategory(category);
                category.NAME = "Laptops";
                service.UpdateCategory(category);
                var people = service.GetAllCategories();
                var sameCategory = service.GetCategoryById(category.ID);
                service.DeleteCategory(category);
            }
            catch
            {
                throw;
            }
        }
    }
}
