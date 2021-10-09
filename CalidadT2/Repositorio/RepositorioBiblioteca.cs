using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using CalidadT2.Constantes;
using CalidadT2.Interface;
using CalidadT2.Models;
using Microsoft.EntityFrameworkCore;

namespace CalidadT2.Repositorio
{
    public class RepositorioBiblioteca : InterfaceBiblioteca
    {
        readonly private AppBibliotecaContext mContext;

        public RepositorioBiblioteca(AppBibliotecaContext mContext)
        {
            this.mContext = mContext;
        } 
        public Biblioteca getBibliotecaID(Usuario user, int libroId)
        {
            return mContext.Bibliotecas
                .Where(o => o.LibroId == libroId && o.UsuarioId == user.Id)
                .FirstOrDefault();

        }

        public void saveLibroPorLeer(int id, int libro)
        {
            var biblioteca = new Biblioteca
            {
                LibroId = libro,
                UsuarioId = id,
                Estado = ESTADO.POR_LEER
            };

            mContext.Bibliotecas.Add(biblioteca);
            mContext.SaveChanges();
        }

        public List<Biblioteca> getLisBiblioteca(int id)
        {
            return mContext.Bibliotecas
                .Include(o => o.Libro.Autor)
                .Include(o => o.Usuario)
                .Where(o => o.UsuarioId == id)
                .ToList();
        }
        
    }
}
