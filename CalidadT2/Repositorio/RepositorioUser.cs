using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using CalidadT2.Interface;
using CalidadT2.Models;
using Microsoft.AspNetCore.Http;

namespace CalidadT2.Repositorio
{
    public class RepositorioUser : InterfaceUser
    {
        private readonly AppBibliotecaContext mContext;
        public RepositorioUser(AppBibliotecaContext mContext)
        {
            this.mContext = mContext;
        }

        public Usuario FindUserByCredentials(string username, string password)
        {
            return mContext.Usuarios.FirstOrDefault(o => o.Username == username && o.Password == password);
        }

        public Usuario getUserId(Claim claim)
        {
            return mContext.Usuarios.Where(o => o.Username == claim.Value).FirstOrDefault();
        }
    }
}
