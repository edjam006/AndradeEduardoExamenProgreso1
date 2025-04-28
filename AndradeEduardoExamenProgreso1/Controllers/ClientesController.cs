using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AndradeEduardoExamenProgreso1.Data;
using AndradeEduardoExamenProgreso1.Models;

namespace AndradeEduardoExamenProgreso1.Controllers
{
    public class ClientesController : Controller
    {
        private readonly AndradeEduardoExamenProgreso1Context _context;

        public ClientesController(AndradeEduardoExamenProgreso1Context context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Registro(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                _context.Cliente.Add(cliente);
                _context.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            return View(cliente);
        }


    }
}
