using System;
using System.Collections.Generic;

namespace crudReservas.Models
{
    public partial class Persona
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public DateTime? FechaDeNacimiento { get; set; }
    }
}
