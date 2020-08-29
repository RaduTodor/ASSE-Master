// <copyright file="CategoryServiceTests.cs" company="Transilvania University of Brasov">
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
    /// Defines the <see cref="CategoryServiceTests" />.
    /// </summary>
    public class CategoryServiceTests
    {
        /// <summary>
        /// The TestAddCategoryWithValidData.
        /// </summary>
        [Test]
        public void TestAddCategoryWithValidData()
        {
            Category category = new Category()
            {
                NAME = "Computers",
            };

            ICategoryService categoryServices = new CategoryService();
            bool result = categoryServices.AddCategory(category);

            Assert.IsTrue(result);
        }

        /// <summary>
        /// The TestAddCategoryWithInvalidData.
        /// </summary>
        [Test]
        public void TestAddCategoryWithInvalidData()
        {
            Category category = new Category();

            ICategoryService readerServices = new CategoryService();
            bool result = readerServices.AddCategory(category);

            Assert.IsFalse(result);
        }

        /// <summary>
        /// The TestDeleteCategoryWithValidData.
        /// </summary>
        [Test]
        public void TestDeleteCategoryWithValidData()
        {
            Category category = new Category()
            {
                NAME = "Computers",
            };

            ICategoryService categoryServices = new CategoryService();
            Mock<ICategoryDataService> mock = new Mock<ICategoryDataService>();
            mock.Setup(m => m.DeleteCategory(category));

            CategoryService.DataServices = mock.Object;
            bool result = categoryServices.DeleteCategory(category);

            Assert.IsTrue(result);
        }

        /// <summary>
        /// The TestDeleteCategoryWithInvalidData.
        /// </summary>
        [Test]
        public void TestDeleteCategoryWithInvalidData()
        {
            Category category = new Category();

            ICategoryService categoryServices = new CategoryService();
            bool result = categoryServices.DeleteCategory(category);

            Assert.IsFalse(result);
        }

        /// <summary>
        /// The TestUpdateReaderWithValidData.
        /// </summary>
        [Test]
        public void TestUpdateReaderWithValidData()
        {
            Category category = new Category()
            {
                NAME = "Computers",
            };

            ICategoryService categoryServices = new CategoryService();
            bool result = categoryServices.UpdateCategory(category);

            Assert.IsTrue(result);
        }

        /// <summary>
        /// The TestUpdateCategoryWithInvalidData.
        /// </summary>
        [Test]
        public void TestUpdateCategoryWithInvalidData()
        {
            Category category = new Category();

            ICategoryService categoryServices = new CategoryService();
            bool result = categoryServices.UpdateCategory(category);

            Assert.IsFalse(result);
        }

        /// <summary>
        /// The TestGetListOfCategories.
        /// </summary>
        [Test]
        public void TestGetListOfCategories()
        {
            ICategoryService categoryServices = new CategoryService();
            Mock<ICategoryDataService> mock = new Mock<ICategoryDataService>();
            mock.Setup(m => m.GetAllCategories()).Returns(
                new List<Category>()
                {
                    new Category()
                    {
                NAME = "Computers",
                    }
                });

            CategoryService.DataServices = mock.Object;
            var result = categoryServices.GetListOfCategories();

            Assert.AreNotEqual(result, null);
            Assert.AreEqual((result as List<Category>).Count, 1);
        }

        /// <summary>
        /// The TestGetCategoryById.
        /// </summary>
        [Test]
        public void TestGetCategoryById()
        {
            ICategoryService categoryServices = new CategoryService();
            Mock<ICategoryDataService> mock = new Mock<ICategoryDataService>();
            mock.Setup(m => m.GetCategoryById(2)).Returns(
                    new Category()
                    {
                        ID = 2,
                        NAME = "Computers",
                    });

            CategoryService.DataServices = mock.Object;
            var result = categoryServices.GetCategoryById(2);

            Assert.AreNotEqual(result, null);
            Assert.AreEqual((result as Category).ID, 2);
        }

        /// <summary>
        /// The TestGetCategoryByIdWithInvalidId.
        /// </summary>
        [Test]
        public void TestGetCategoryByIdWithInvalidId()
        {
            ICategoryService categoryServices = new CategoryService();
            Mock<ICategoryDataService> mock = new Mock<ICategoryDataService>();
            mock.Setup(m => m.GetCategoryById(10)).Returns(
                    new Category()
                    {
                        NAME = "Computers",
                    });

            CategoryService.DataServices = mock.Object;
            var result = categoryServices.GetCategoryById(1);

            Assert.AreEqual(result, null);
        }

        /// <summary>
        /// The TestAddNullCategory.
        /// </summary>
        [Test]
        public void TestAddNullCategory()
        {
            Category category = null;

            ICategoryService categoryServices = new CategoryService();
            Assert.Throws<ArgumentNullException>(() => categoryServices.AddCategory(category));
        }

        /// <summary>
        /// The TestDeleteNullCategory.
        /// </summary>
        [Test]
        public void TestDeleteNullCategory()
        {
            Category category = null;

            ICategoryService categoryServices = new CategoryService();
            Assert.Throws<ArgumentNullException>(() => categoryServices.DeleteCategory(category));
        }

        /// <summary>
        /// The TestUpdateNullCategory.
        /// </summary>
        [Test]
        public void TestUpdateNullCategory()
        {
            Category category = null;

            ICategoryService categoryServices = new CategoryService();
            Assert.Throws<ArgumentNullException>(() => categoryServices.UpdateCategory(category));
        }
    }
}
