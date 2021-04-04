using System;
using System.Collections.Generic;

#nullable disable

namespace SolNotasBD.Modelo
{
    public partial class Estudiante
    {
        public uint Codigo { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public double? Nota1 { get; set; }
        public double? Nota2 { get; set; }
        public double? Nota3 { get; set; }
    }
}
