using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using CalidadT2.Models;

namespace CalidadT2.Interface
{
    public interface InterfaceUser
    {
        Usuario FindUserByCredentials(string username, string password);
        Usuario getUserId(Claim claim);
    }
}
