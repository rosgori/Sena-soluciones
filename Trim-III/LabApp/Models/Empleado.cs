using System;
using System.Collections.Generic;

#nullable disable

namespace LabApp.Models
{
    public partial class Empleado
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Usuario { get; set; }
        public string Contraseña { get; set; }
        public string Rol { get; set; }
    }
}
