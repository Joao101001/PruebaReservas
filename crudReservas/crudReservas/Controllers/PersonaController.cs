using crudReservas.Models;
using crudReservas.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;

namespace crudReservas.Controllers
{

    public class PersonaController
    {
        private readonly pruebaReservasContext _DBContext;

        public PersonaController(pruebaReservasContext context)
        {
            _DBContext = context;
        }

        public IActionResult Index()
        {
            List<Persona> lista = _DBContext.Personas.ToList();
            return View(lista);
        }

        [HttpGet]
        public IActionResult Persona_Detalle(int IdPersona)
        {
            PersonaVM OPersonaVM = new PersonaVM()
            {
                oPersona = new Persona()

            };

            if (IdPersona != 0)
            {
                OPersonaVM.oPersona = _DBContext.Personas.Find(IdPersona);
            }
            return View(OPersonaVM);
        }

        [HttpPost]
        public IActionResult Persona_Detalle(PersonaVM oPersonaVM)
        {
            if (oPersonaVM.oPersona.Id == 0)
            {
                _DBContext.Personas.Add(oPersonaVM.oPersona);
            }
            else
            {
                _DBContext.Personas.Update(oPersonaVM.oPersona);
            }
            _DBContext.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Eliminar(int IdPersona)
        {
            Persona oPersonaVM = _DBContext.Personas.Where(e => e.Id == IdPersona).FirstOrDefault();

            return View(oPersonaVM);
        }

        [HttpPost]
        public IActionResult Eliminar(Persona oPersona)
        {
            _DBContext.Personas.Remove(oPersona);
            _DBContext.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

    }
}
