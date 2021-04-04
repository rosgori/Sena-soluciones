using System;
using System.Text.RegularExpressions;

namespace SolNotasBD
{
    public class Mensajes
    {
        public static string NoVacio()
        {
            return "No debe ser vacío, intente de nuevo.";
        }

        public static string NoTexto()
        {
            return "Debe ser texto, intente de nuevo.";
        }

        public static string NoNumero()
        {
            return "Debe ser un número, intente de nuevo.";
        }

        public static string NoCodigo()
        {
            return "Debe ser un número de cuatro cifras.";
        }

        public static string NoCorreo()
        {
            return "Debe ser un correo electrónico.";
        }

        public static string NoNota()
        {
            return "Debe ser una nota válida.";
        }

        public static string NoEditar()
        {
            return "Presione ENTER para no editar un dato.";
        }

        public static string NoEditarDato()
        {
            return "El dato no será editado.";
        }
    }
}