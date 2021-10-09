using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CalidadT2.Models;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace TestCalidadT2
{
    public class ContextTest
    {
        public static Mock<AppBibliotecaContext> GetAplicationContextMockUser()
        {
            var data = new List<Usuario>
            {
                new Usuario { Id = 1, Password = "Admin", Username = "Admin" },
                new Usuario { Id = 2, Password = "Admin2", Username = "Admin2" },
                new Usuario { Id = 3, Password = "Admin3", Username = "Admin3" },
            }.AsQueryable();

            var mokSet = new Mock<DbSet<Usuario>>();
            mokSet.As<IQueryable<Usuario>>().Setup(m => m.Provider).Returns(data.Provider);
            mokSet.As<IQueryable<Usuario>>().Setup(m => m.Expression).Returns(data.Expression);
            mokSet.As<IQueryable<Usuario>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mokSet.As<IQueryable<Usuario>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var context = new Mock<AppBibliotecaContext>(new DbContextOptions<AppBibliotecaContext>());
            context.Setup(a => a.Usuarios).Returns(mokSet.Object);

            return context;
        }
        public static Mock<AppBibliotecaContext> GetAplicationContextMockBiblioteca(){
        
            var data = new List<Biblioteca>
            {
                new Biblioteca { Id = 1,Estado = 1,Libro = new Libro(),Usuario = new Usuario(),UsuarioId = 1},
            }.AsQueryable();

            var mokSet = new Mock<DbSet<Biblioteca>>();
            mokSet.As<IQueryable<Biblioteca>>().Setup(m => m.Provider).Returns(data.Provider);
            mokSet.As<IQueryable<Biblioteca>>().Setup(m => m.Expression).Returns(data.Expression);
            mokSet.As<IQueryable<Biblioteca>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mokSet.As<IQueryable<Biblioteca>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var context = new Mock<AppBibliotecaContext>(new DbContextOptions<AppBibliotecaContext>());
            context.Setup(a => a.Bibliotecas).Returns(mokSet.Object);

            return context;
        }
    }
}
