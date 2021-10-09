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

            var claimCollection = new Claim("Username", "Rous");
           
            var a =  new List<Biblioteca>();
            var bi1 = new Biblioteca
            {
                Id = 1,Estado = 1,Libro = new Libro(), Usuario = new Usuario{Id = 1,Nombres = "Ro",Password = "Pos",Username = "Rous"},LibroId = 1,UsuarioId = 1
            };

            mocBiblioteca.Setup(i => i.getLisBiblioteca(1)).Returns(a);
            var authMock = new Mock<InterfaceAuth>();
            authMock.Setup(a => a.LoggedUser()).Returns(claimCollection);
            var userMock = new Mock<InterfaceUser>();
            userMock.Setup(a => a.getUserId(claimCollection)).Returns(new Usuario()
            {
                Id = 1,Nombres = "a",Username = "a"
            });


            var controller = new BibliotecaController(null,authMock.Object, userMock.Object, null,mocBiblioteca.Object);
           
            var view = controller.Index();

            Assert.IsInstanceOf<ViewResult>(view);
        }
        [Test]
        public void  TestMarcarComoLeyendo02()
        {
             
            var claimCollection = new Claim("Username", "Rous");

            var a = new List<Biblioteca>();
            var bi1 = new Biblioteca
            {
                Id = 1,
                Estado = 1,
                Libro = new Libro(),
                Usuario = new Usuario { Id = 1, Nombres = "Ro", Password = "Pos", Username = "Rous" },
                LibroId = 1,
                UsuarioId = 1
            };
            a.Add(bi1);

            mocBiblioteca.Setup(i => i.saveLibroPorLeer(1, 1));
            var authMock = new Mock<InterfaceAuth>();
            authMock.Setup(a => a.LoggedUser()).Returns(claimCollection);
            
            var userMock = new Mock<InterfaceUser>();
            userMock.Setup(a => a.getUserId(claimCollection)).Returns(new Usuario()
            {
                Id = 1,
                Nombres = "a",
                Username = "a"
            });


          

            var controller = new BibliotecaController(null, authMock.Object, userMock.Object, null, mocBiblioteca.Object);

            var view = controller.Add(1);

            Assert.IsInstanceOf<RedirectToActionResult>(view);
        }

        [Test]
        public void TestAdd02()
        {

            var claimCollection = new Claim("Username", "Rous");

            var a = new List<Biblioteca>();
            var bi1 = new Biblioteca
            {
                Id = 1,
                Estado = 1,
                Libro = new Libro(),
                Usuario = new Usuario { Id = 1, Nombres = "Ro", Password = "Pos", Username = "Rous" },
                LibroId = 1,
                UsuarioId = 1
            };
            a.Add(bi1);

            mocBiblioteca.Setup(i => i.getBibliotecaID(new Usuario(),1)).Returns(bi1);
            

            var authMock = new Mock<InterfaceAuth>();
            authMock.Setup(a => a.LoggedUser()).Returns(claimCollection);

            var userMock = new Mock<InterfaceUser>();
            userMock.Setup(a => a.getUserId(claimCollection)).Returns(new Usuario()
            {
                Id = 1,
                Nombres = "a",
                Username = "a"
            });


            var controller = new BibliotecaController(null, authMock.Object, userMock.Object, null, mocBiblioteca.Object);

            var view = controller.Add(1);

            Assert.IsInstanceOf<RedirectToActionResult>(view);
        }
       
    }
}
