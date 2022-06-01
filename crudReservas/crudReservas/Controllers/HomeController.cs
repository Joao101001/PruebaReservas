using crudReservas.Models;
using crudReservas.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;

namespace crudReservas.Controllers
{
    public class HomeController : Controller
    {
        private readonly pruebaReservasContext _context;

        public HomeController(pruebaReservasContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            
            return View();
        }

    }
}