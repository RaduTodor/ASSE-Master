// <copyright file="RoleDataServiceTests.cs" company="Transilvania University of Brasov">
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
    /// Defines the <see cref="RoleDataServiceTests" />.
    /// </summary>
    public class RoleDataServiceTests
    {
        /// <summary>
        /// The AddRoleTest.
        /// </summary>
        [Test]
        public void AddRoleTest()
        {
            Role role = new Mock<Role>().Object;

            Mock<IRoleDataService> mock = new Mock<IRoleDataService>();
            mock.Setup(m => m.AddRole(role));

            IRoleDataService obj = mock.Object;
            obj.AddRole(role);

            mock.Verify(o => o.AddRole(role), Times.Once());
        }

        /// <summary>
        /// The DeleteRoleTest.
        /// </summary>
        [Test]
        public void DeleteRoleTest()
        {
            Role role = new Mock<Role>().Object;

            Mock<IRoleDataService> mock = new Mock<IRoleDataService>();
            mock.Setup(m => m.DeleteRole(role));

            IRoleDataService obj = mock.Object;
            obj.DeleteRole(role);

            mock.Verify(o => o.DeleteRole(role), Times.Once());
        }

        /// <summary>
        /// The UpdateRoleTest.
        /// </summary>
        [Test]
        public void UpdateRoleTest()
        {
            Role role = new Mock<Role>().Object;

            Mock<IRoleDataService> mock = new Mock<IRoleDataService>();
            mock.Setup(m => m.UpdateRole(role));

            IRoleDataService obj = mock.Object;
            obj.UpdateRole(role);

            mock.Verify(o => o.UpdateRole(role), Times.Once());
        }

        /// <summary>
        /// The GetAllRolesTest.
        /// </summary>
        [Test]
        public void GetAllRolesTest()
        {
            Mock<IRoleDataService> mock = new Mock<IRoleDataService>();
            mock.Setup(m => m.GetAllRoles());

            IRoleDataService obj = mock.Object;
            obj.GetAllRoles();

            mock.Verify(o => o.GetAllRoles(), Times.Once());
        }

        /// <summary>
        /// The GetRoleByIdTest.
        /// </summary>
        [Test]
        public void GetRoleByIdTest()
        {
            Mock<IRoleDataService> mock = new Mock<IRoleDataService>();
            mock.Setup(m => m.GetRoleById(1));

            IRoleDataService obj = mock.Object;
            obj.GetRoleById(1);

            mock.Verify(o => o.GetRoleById(1), Times.Once());
        }

        /// <summary>
        /// The AddRoleImplementationTest.
        /// </summary>
        [Test]
        public void AddRoleImplementationTest()
        {
            Role role = new Role
            {
                NAME = "Buyer",
            };

            RoleDataService service = new RoleDataService();
            try
            {
                service.AddRole(role);
                role.NAME = "Host";
                service.UpdateRole(role);
                var people = service.GetAllRoles();
                var sameRole = service.GetRoleById(role.ID);
                service.DeleteRole(role);
            }
            catch
            {
                throw;
            }
        }
    }
}
