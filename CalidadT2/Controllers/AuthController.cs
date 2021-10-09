using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using CalidadT2.Interface;
using CalidadT2.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

namespace CalidadT2.Controllers
{
    public class AuthController : Controller
    {
        protected readonly InterfaceUser Iuser;
        protected readonly InterfaceAuth IAuth;

        public AuthController(InterfaceUser Iuser, InterfaceAuth IAuth)
        {
            this.Iuser = Iuser;
            this.IAuth = IAuth;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            var usuario = Iuser.FindUserByCredentials(username, password);
            if (usuario != null)
            {
                var claims = new List<Claim> {
                    new Claim(ClaimTypes.Name, username)
                };

                IAuth.Login(claims);
                return RedirectToAction("Index", "Home");
            }

            ViewBag.Validation = "Usuario y/o contraseña incorrecta";
            return View();
        }


        public ActionResult Logout()
        {
            IAuth.Logout();
            return RedirectToAction("Login");
        }
    }
}
