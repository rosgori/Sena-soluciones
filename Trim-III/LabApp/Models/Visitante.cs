using System;
using System.Collections.Generic;

#nullable disable

namespace LabApp.Models
{
    public partial class Visitante
    {
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public string Rol {get; set;}
    }
}
