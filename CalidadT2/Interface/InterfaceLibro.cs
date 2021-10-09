using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CalidadT2.Models;

namespace CalidadT2.Interface
{
    public interface InterfaceLibro
    {
        List<Libro> GetLisLibros();
        void saverLibroLeyendo(Biblioteca biblioteca);
        void saverLibroTerminado(Biblioteca biblioteca);
    }
}
