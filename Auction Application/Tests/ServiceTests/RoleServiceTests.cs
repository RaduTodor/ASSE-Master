// <copyright file="RoleServiceTests.cs" company="Transilvania University of Brasov">
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
    /// Defines the <see cref="RoleServiceTests" />.
    /// </summary>
    public class RoleServiceTests
    {
        /// <summary>
        /// The TestAddRoleWithValidData.
        /// </summary>
        [Test]
        public void TestAddRoleWithValidData()
        {
            Role role = new Role()
            {
                NAME = "Buyer",
            };

            IRoleService roleServices = new RoleService();
            bool result = roleServices.AddRole(role);

            Assert.IsTrue(result);
        }

        /// <summary>
        /// The TestAddRoleWithInvalidData.
        /// </summary>
        [Test]
        public void TestAddRoleWithInvalidData()
        {
            Role role = new Role();

            IRoleService readerServices = new RoleService();
            bool result = readerServices.AddRole(role);

            Assert.IsFalse(result);
        }

        /// <summary>
        /// The TestDeleteRoleWithValidData.
        /// </summary>
        [Test]
        public void TestDeleteRoleWithValidData()
        {
            Role role = new Role()
            {
                NAME = "Buyer",
            };

            IRoleService roleServices = new RoleService();
            Mock<IRoleDataService> mock = new Mock<IRoleDataService>();
            mock.Setup(m => m.DeleteRole(role));

            RoleService.DataServices = mock.Object;
            bool result = roleServices.DeleteRole(role);

            Assert.IsTrue(result);
        }

        /// <summary>
        /// The TestDeleteRoleWithInvalidData.
        /// </summary>
        [Test]
        public void TestDeleteRoleWithInvalidData()
        {
            Role role = new Role();

            IRoleService roleServices = new RoleService();
            bool result = roleServices.DeleteRole(role);

            Assert.IsFalse(result);
        }

        /// <summary>
        /// The TestUpdateReaderWithValidData.
        /// </summary>
        [Test]
        public void TestUpdateReaderWithValidData()
        {
            Role role = new Role()
            {
                NAME = "Buyer",
            };

            IRoleService roleServices = new RoleService();
            bool result = roleServices.UpdateRole(role);

            Assert.IsTrue(result);
        }

        /// <summary>
        /// The TestUpdateRoleWithInvalidData.
        /// </summary>
        [Test]
        public void TestUpdateRoleWithInvalidData()
        {
            Role role = new Role();

            IRoleService roleServices = new RoleService();
            bool result = roleServices.UpdateRole(role);

            Assert.IsFalse(result);
        }

        /// <summary>
        /// The TestGetListOfRoles.
        /// </summary>
        [Test]
        public void TestGetListOfRoles()
        {
            IRoleService roleServices = new RoleService();
            Mock<IRoleDataService> mock = new Mock<IRoleDataService>();
            mock.Setup(m => m.GetAllRoles()).Returns(
                new List<Role>()
                {
                    new Role()
                    {
                NAME = "Buyer",
                    }
                });

            RoleService.DataServices = mock.Object;
            var result = roleServices.GetListOfRoles();

            Assert.AreNotEqual(result, null);
            Assert.AreEqual((result as List<Role>).Count, 1);
        }

        /// <summary>
        /// The TestGetRoleById.
        /// </summary>
        [Test]
        public void TestGetRoleById()
        {
            IRoleService roleServices = new RoleService();
            Mock<IRoleDataService> mock = new Mock<IRoleDataService>();
            mock.Setup(m => m.GetRoleById(2)).Returns(
                    new Role()
                    {
                        ID = 2,
                        NAME = "Buyer",
                    });

            RoleService.DataServices = mock.Object;
            var result = roleServices.GetRoleById(2);

            Assert.AreNotEqual(result, null);
            Assert.AreEqual((result as Role).ID, 2);
        }

        /// <summary>
        /// The TestGetRoleByIdWithInvalidId.
        /// </summary>
        [Test]
        public void TestGetRoleByIdWithInvalidId()
        {
            IRoleService roleServices = new RoleService();
            Mock<IRoleDataService> mock = new Mock<IRoleDataService>();
            mock.Setup(m => m.GetRoleById(10)).Returns(
                    new Role()
                    {
                        NAME = "Buyer",
                    });

            RoleService.DataServices = mock.Object;
            var result = roleServices.GetRoleById(1);

            Assert.AreEqual(result, null);
        }

        /// <summary>
        /// The TestAddNullRole.
        /// </summary>
        [Test]
        public void TestAddNullRole()
        {
            Role role = null;

            IRoleService roleServices = new RoleService();
            Assert.Throws<ArgumentNullException>(() => roleServices.AddRole(role));
        }

        /// <summary>
        /// The TestDeleteNullRole.
        /// </summary>
        [Test]
        public void TestDeleteNullRole()
        {
            Role role = null;

            IRoleService roleServices = new RoleService();
            Assert.Throws<ArgumentNullException>(() => roleServices.DeleteRole(role));
        }

        /// <summary>
        /// The TestUpdateNullRole.
        /// </summary>
        [Test]
        public void TestUpdateNullRole()
        {
            Role role = null;

            IRoleService roleServices = new RoleService();
            Assert.Throws<ArgumentNullException>(() => roleServices.UpdateRole(role));
        }
    }
}
