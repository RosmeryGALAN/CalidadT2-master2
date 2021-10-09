using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using CalidadT2.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CalidadT2.Models;
using Microsoft.EntityFrameworkCore;

namespace CalidadT2.Controllers
{
    public class HomeController : Controller
    {
        private AppBibliotecaContext app;
        private readonly InterfaceLibro _libro;
        public HomeController(InterfaceLibro _libro)
        {
            this._libro = _libro;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var model = _libro.GetLisLibros();
            return View(model);
        }
    }
}
