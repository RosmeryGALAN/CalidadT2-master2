using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using CalidadT2.Models;

namespace CalidadT2.Interface
{
    public interface InterfaceBiblioteca
    {
        Biblioteca getBibliotecaID (Usuario user, int libroId);
        void saveLibroPorLeer(int id,int libro);
        List<Biblioteca> getLisBiblioteca(int id);
    }
}
