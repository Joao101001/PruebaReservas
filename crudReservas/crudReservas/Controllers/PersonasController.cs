using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using crudReservas.Models;
using crudReservas.Models.ViewModels;
using System.Diagnostics;



namespace crudReservas.Controllers
{
    public class PersonasController : Controller
    {
        private readonly pruebaReservasContext _DBContext;

        public PersonasController(pruebaReservasContext context)
        {
            _DBContext = context;
        }

        public IActionResult Persona()
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

            return RedirectToAction("Persona", "Personas");
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

            return RedirectToAction("Persona", "Personas");
        }
    }
}
