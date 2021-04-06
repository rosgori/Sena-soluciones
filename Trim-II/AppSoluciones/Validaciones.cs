using System;
using System.Text.RegularExpressions;

namespace AppSoluciones
{
    class Validaciones
    {
        public static bool Vacio(string texto)
        {
            bool aux = false;
            if (texto.Equals(""))
            {
                aux = true;
            }
            return aux;
        }

        public static bool TipoEntrada(string texto)
        {
            bool aux = false;
            string regla = @"^[0-9]{1,2}$";

            if (Regex.IsMatch(texto, regla))
            {
                aux = true;
            }

            return aux;
        }

        public static bool TipoNumero(string texto)
        {
            bool aux = false;
            string regla = @"^[0-9 ]*$";

            if (Regex.IsMatch(texto, regla))
            {
                aux = true;
            }

            return aux;
        }

        public static bool EsPrimo(string texto)
        {
            bool aux = false;
            bool entrada_valida = false;
            long numero_ent;

            do
            {
                if (!Vacio(texto))
                {
                    if (TipoNumero(texto))
                    {
                        entrada_valida = true;
                    }
                    else
                    {
                        Console.WriteLine("\nDigite un opción válida.\n");
                    }
                }
                else
                {
                    Console.WriteLine("\nDigite un número.\n");
                }

            } while (!entrada_valida);

            numero_ent = Int64.Parse(texto);

            if (numero_ent % 2 == 0)
            {
                return aux;
            }

            for (int i = 3; i < Math.Sqrt(numero_ent); i = i + 2)
            {
                if (numero_ent % i == 0)
                {
                    return aux;
                }
            }

            aux = true;
            return aux;
        }

        public static bool TipoTexto(string texto)
        {
            string regla = @"^[\p{L} ]+$";
            // string regla = @"^[ a-z A-Z ]*$";

            bool aux = false;

            if (Regex.IsMatch(texto, regla))
            {
                aux = true;
            }

            return aux;
        }
    }
}