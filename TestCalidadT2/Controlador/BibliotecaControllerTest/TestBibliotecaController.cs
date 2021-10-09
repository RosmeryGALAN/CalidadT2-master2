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
         //   mock.Setup(i => i.GetAll()).Returns(new List<User>());
        }
    }
}
