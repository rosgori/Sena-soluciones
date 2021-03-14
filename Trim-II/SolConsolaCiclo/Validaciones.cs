using System;
using System.Text.RegularExpressions;

namespace SolConsolaCiclo
{
    public class Validaciones
    {
        public bool     Vacio(string texto)
        {
            if (texto.Equals(""))
            {
                Marcos.EscribirEn("El texto no puede ser vacío. ", 35, 13);
                Marcos.BorrarLinea(34, 12, 80);
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool TipoNumero(string texto)
        {
            Regex regla = new Regex("[0-9]{1,9}(\\.[0-9]{0,2})?$");

            if (regla.IsMatch(texto))
            {
                return true;
            }                
            else
            {
                Marcos.EscribirEn("La entrada debe ser numérica.", 35, 13);
                Marcos.BorrarLinea(34, 12, 80);
                return false;
            }
        }

        public bool TipoTexto(string texto)
        {
            Regex regla = new Regex("^[a-zA-Z ]*$");

            if (regla.IsMatch(texto))
                return true;
            else
            {
                Marcos.EscribirEn("La entrada debe ser texto.", 35, 13);
                Marcos.BorrarLinea(34, 12, 80);
                return false;
            }
        }
    }
}