using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CalidadT2.Constantes;
using CalidadT2.Interface;
using CalidadT2.Models;
using Microsoft.EntityFrameworkCore;

namespace CalidadT2.Repositorio
{
    public class RepositorioLibro : InterfaceLibro
    {
        readonly private AppBibliotecaContext mContext;
        public RepositorioLibro(AppBibliotecaContext mContext)
        {
            this.mContext = mContext;
        }

        public List<Libro> GetLisLibros()
        {
            return mContext.Libros.Include(o => o.Autor).ToList();
        }

        public void saverLibroLeyendo(Biblioteca biblioteca)
        {
            biblioteca.Estado = ESTADO.LEYENDO;
            mContext.SaveChanges();
        }

        public void saverLibroTerminado(Biblioteca biblioteca)
        {
            biblioteca.Estado = ESTADO.TERMINADO;
            mContext.SaveChanges();
        }
    }
}
