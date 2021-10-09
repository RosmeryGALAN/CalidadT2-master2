using System;
using System.Collections.Generic;
using System.Text;
using CalidadT2.Interface;
using CalidadT2.Models;
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

        [SetUp]
        public void SetUp()
        {
            mocUser = new Mock<InterfaceUser>();
            mocAut = new Mock<InterfaceAuth>();
            mocBiblioteca = new Mock<InterfaceBiblioteca>();
            mocibror = new Mock<InterfaceLibro>();
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
        }
    }
}
