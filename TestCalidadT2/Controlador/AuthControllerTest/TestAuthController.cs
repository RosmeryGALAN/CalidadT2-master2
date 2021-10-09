using System;
using System.Collections.Generic;
using System.Text;
using CalidadT2.Controllers;
using CalidadT2.Interface;
using CalidadT2.Models;
using CalidadT2.Repositorio;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;

namespace TestCalidadT2.Controlador.AuthControllerTest
{
    public class TestAuthController
    {
        private Mock<AppBibliotecaContext> _context;

        [SetUp]
        public void SetUp()
        {
            _context = ContextTest.GetAplicationContextMockUser();
        }
        
        [Test]
        public void LoginPasaTest01()
        {

            var mock = new Mock<InterfaceUser>();
            mock.Setup(p => p.FindUserByCredentials("admin", "admin")).Returns(new Usuario());
            var authMock = new Mock<InterfaceAuth>();

            var controller = new AuthController(mock.Object, authMock.Object);
            var result = controller.Login("admin", "admin");
            Assert.IsInstanceOf<RedirectToActionResult>(result);
           // Assert.IsFalse(controller.ModelState.IsValid);
        }
        [Test]
        public void LoginnOPasaTest02()
        {

            var mock = new Mock<InterfaceUser>();
            mock.Setup(p => p.FindUserByCredentials("admin", "admin")).Returns((Usuario)null);
            var authMock = new Mock<InterfaceAuth>();

            var controller = new AuthController(mock.Object, authMock.Object);
            var result = controller.Login("admin", "1234");
            Assert.IsInstanceOf<ViewResult>(result);
        }

        [Test]
        public void TestFindUserByCredentials03()
        {
            var service = new RepositorioUser(_context.Object);

            var user = service.FindUserByCredentials("Admin", "Admin");

            Assert.AreEqual(1, user.Id);
        }
    }
}
