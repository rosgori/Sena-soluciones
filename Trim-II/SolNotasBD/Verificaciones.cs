using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace SolNotasBD
{
    public class Validaciones
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

        public static bool TipoEntradaNumero(string texto)
        {   
            bool aux = false;
            string regla = @"^-?[0-9]+$";

            if (Regex.IsMatch(texto, regla))
            {
                aux = true;
            }                
            
            return aux;
        }

        public static bool TipoTexto(string texto)
        {
            string regla = @"^[\p{L} .']+$";
            // string regla = @"^[ a-z A-Z ]*$";

            bool aux = false;

            if (Regex.IsMatch(texto, regla))
            {
                aux = true;
            }

            return aux;
        }

        public static bool TipoCorreo(string texto)
        {
            string regla = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            bool aux = false;

            if (Regex.IsMatch(texto, regla))
            {
                aux = true;
            }
        
            return aux;           
        }
        
        public static bool TipoCodigo(string texto)
        {
            string regla = "^[0-9]{4}$";
            bool aux = false;

            if (Regex.IsMatch(texto, regla, RegexOptions.ECMAScript))
            {
                aux = true;
            }
        
            return aux;

        }

        public static bool TipoNota(string texto)
        {
            // string regla = @"^(0|[1-9]\d*)?(\.\d+)?(?<=\d)$";
            string regla = @"^[0-9]{1,2}(\.[0-9]{0,4})?$";
            bool aux = false;
            double temp1;

            if (!Vacio(texto))
            {
                if(Regex.IsMatch(texto, regla, RegexOptions.CultureInvariant | RegexOptions.ECMAScript))
                {
                    // Console.WriteLine(texto);
                    CultureInfo usCulture = new CultureInfo("en-US");
                    NumberFormatInfo dbNumberFormat = usCulture.NumberFormat;
                    temp1 = Double.Parse(texto, dbNumberFormat);
                    // Console.WriteLine(temp1);
                    if (temp1 >= 0 && temp1 <= 5)
                    {
                        aux = true;
                    }
                        
                }
            }
            return aux;
        }

        public static bool EsNota(string texto)
        {
            bool aux = false;
            if (!Vacio(texto))
            {
                if (TipoNota(texto))
                {
                    aux = true;
                }
            }
            return aux;
        }
    }
}
