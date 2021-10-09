using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CalidadT2.Constantes;
using CalidadT2.Interface;
using CalidadT2.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CalidadT2.Controllers
{
    [Authorize]
    public class BibliotecaController : Controller
    {
        private readonly AppBibliotecaContext app;
        protected readonly InterfaceAuth IAuth;
        protected readonly InterfaceUser InterfaceUser;
        protected readonly InterfaceBiblioteca interfaceBiblioteca;
        protected readonly InterfaceLibro interfaceLibro;
        public BibliotecaController(AppBibliotecaContext app, InterfaceAuth IAuth, InterfaceUser InterfaceUser, InterfaceLibro interfaceLibro, InterfaceBiblioteca interfaceBiblioteca)
        {
            this.app = app;
            this.IAuth = IAuth;
            this.InterfaceUser = InterfaceUser;
            this.interfaceLibro = interfaceLibro;
            this.interfaceBiblioteca = interfaceBiblioteca;
        }

        [HttpGet]
        public IActionResult Index()
        {
            Usuario user = LoggedUser();

            var model = interfaceBiblioteca.getLisBiblioteca(user.Id);

            return View(model);
        }

        [HttpGet]
        public ActionResult Add(int libro)
        {
            Usuario user = LoggedUser();

            interfaceBiblioteca.saveLibroPorLeer(user.Id,libro);

            TempData["SuccessMessage"] = "Se añádio el libro a su biblioteca";

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult MarcarComoLeyendo(int libroId)
        {
            Usuario user = LoggedUser();
            
           var libro = interfaceBiblioteca.getBibliotecaID(user, libroId);

           interfaceLibro.saverLibroLeyendo(libro);
            TempData["SuccessMessage"] = "Se marco como leyendo el libro";

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult MarcarComoTerminado(int libroId)
        {
            Usuario user = LoggedUser();

            var libro = interfaceBiblioteca.getBibliotecaID(user, libroId);
            interfaceLibro.saverLibroTerminado(libro);

            TempData["SuccessMessage"] = "Se marco como leyendo el libro";
            return RedirectToAction("Index");
        }

        private Usuario LoggedUser()
        {
          //  var claim = HttpContext.User.Claims.FirstOrDefault();
           var claim = IAuth.LoggedUser();
           var user = InterfaceUser.getUserId(claim);
                //app.Usuarios.Where(o => o.Username == claim.Value).FirstOrDefault();
            return user;
        }
    }
}
