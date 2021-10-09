using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using CalidadT2.Controllers;
using CalidadT2.Interface;
using CalidadT2.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;

namespace TestCalidadT2.Controlador.BibliotecaControllerTest
{
    public class TestBibliotecaController
    {
       // private Mock<AppBibliotecaContext> _context;

        private Mock<InterfaceUser> mocUser;
        private Mock<InterfaceAuth> mocAut;
        private Mock<InterfaceBiblioteca> mocBiblioteca;
        private Mock<InterfaceLibro> mocibror;

        private Mock<AppBibliotecaContext> _context;
        [SetUp]
        public void SetUp()
        {
            mocUser = new Mock<InterfaceUser>();
            mocAut = new Mock<InterfaceAuth>();
            mocBiblioteca = new Mock<InterfaceBiblioteca>();
            mocibror = new Mock<InterfaceLibro>();

            _context = ContextTest.GetAplicationContextMockBiblioteca();
        }
        [Test]
        public void TestIndex01()
        {

            var a =  new List<Biblioteca>();
            var bi1 = new Biblioteca
            {
                Id = 1,Estado = 1,Libro = new Libro(), Usuario = new Usuario(),LibroId = 1,UsuarioId = 1
            };

            mocBiblioteca.Setup(i => i.getLisBiblioteca(1)).Returns(a);
            var authMock = new Mock<InterfaceAuth>();
            authMock.Setup(a => a.LoggedUser()).Returns(() => new Claim("ID","1"));
            var userMock = new Mock<InterfaceUser>();
            userMock.Setup(a => a.getUserId(new Claim("ID","1"))).Returns(new Usuario
                { Id = 1, Nombres = "a", Password = "a", Username = "a" });


            var controller = new BibliotecaController(null,authMock.Object,null,null,mocBiblioteca.Object);
           
            var view = controller.Index();

            Assert.IsInstanceOf<ViewResult>(view);
        }
    }
}
