using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Numerics;

namespace AppSoluciones
{
    class Program
    {
        static void Main(string[] args)
        {
            int opcion_menu = 1;
            string entrada;

            Console.Clear();

            while (opcion_menu != 0)
            {
                Console.WriteLine("*** MENÚ PRINCIPAL ***");

                Console.WriteLine("\nDigite un número entre 1 y 10 para acceder al algoritmo hecho en C#, " +
                "digite 0 si desea salir.\n");

                bool entrada_valida = false;

                do
                {
                    entrada = Console.ReadLine();

                    if (!Validaciones.Vacio(entrada))
                    {
                        if (Validaciones.TipoEntrada(entrada))
                        {
                            entrada_valida = true;
                        }
                        else
                        {
                            Console.WriteLine("\nDigite una opción válida.\n");
                        }
                    }
                    else
                    {
                        Console.WriteLine("\nDigite un número.\n");
                    }

                } while (!entrada_valida);


                opcion_menu = Int32.Parse(entrada);

                switch (opcion_menu)
                {
                    case 1:
                        ParOImpar();
                        break;
                    case 2:
                        TablaMultiplicar();
                        break;
                    case 3:
                        TablasMultiplicar10();
                        break;
                    case 4:
                        NumeroPrimo();
                        break;
                    case 5:
                        OrdenarLista();
                        break;
                    case 6:
                        ExistirLista();
                        break;
                    case 7:
                        MayorMenorLista();
                        break;
                    case 8:
                        EsPalindromo();
                        break;
                    case 9:
                        SecuenciaFibonacci();
                        break;
                    case 10:
                        Parafiscales();
                        break;
                    case 0:
                        Console.WriteLine("\nSaliendo del programa...");
                        break;
                    default:
                        Console.WriteLine("\nOpción inválida, intente de nuevo.");
                        break;
                }

                Console.ReadKey();
                Console.Clear();
            }
        }

        public static void ParOImpar()
        {
            Console.Clear();
            Console.WriteLine("Este algoritmo lee un número e imprime si es par o impar.\n");
            Console.WriteLine("Digite un número.\n");

            bool entrada_valida = false;
            string entrada;
            long numero_ent;

            do
            {
                entrada = Console.ReadLine();

                if (!Validaciones.Vacio(entrada))
                {
                    if (Validaciones.TipoNumero(entrada))
                    {
                        entrada_valida = true;
                    }
                    else
                    {
                        Console.WriteLine("\nDigite una opción válida.\n");
                    }
                }
                else
                {
                    Console.WriteLine("\nDigite un número.\n");
                }

            } while (!entrada_valida);

            numero_ent = Int64.Parse(entrada);

            if (numero_ent % 2 == 0)
            {
                Console.WriteLine($"\nEl número {numero_ent} es par.");
            }
            else
            {
                Console.WriteLine($"\nEl número {numero_ent} es impar.");
            }

        }

        public static void TablaMultiplicar()
        {
            Console.Clear();
            Console.WriteLine("Este algoritmo lee un número e imprime la tabla de multiplicar del 1 al 10 "
            + "de ese número.\n");
            Console.WriteLine("Digite un número.\n");

            bool entrada_valida = false;
            string entrada;
            long numero_ent;

            do
            {
                entrada = Console.ReadLine();

                if (!Validaciones.Vacio(entrada))
                {
                    if (Validaciones.TipoNumero(entrada))
                    {
                        entrada_valida = true;
                    }
                    else
                    {
                        Console.WriteLine("\nDigite una opción válida.\n");
                    }
                }
                else
                {
                    Console.WriteLine("\nDigite un número.\n");
                }

            } while (!entrada_valida);

            numero_ent = Int64.Parse(entrada);

            Console.WriteLine($"\nLa tabla de multiplicar de {numero_ent} es:\n");

            for (int i = 1; i <= 10; i++)
            {
                Console.WriteLine($"{numero_ent} x {i} = {numero_ent * i}");
            }
        }

        public static void TablasMultiplicar10()
        {
            Console.Clear();
            Console.WriteLine("Este algoritmo imprime las tabla de multiplicar del 2 al 10, "
            + "cada una del 1 hasta el 10.");

            for (int i = 2; i <= 10; i ++)
            {
                Console.WriteLine($"\nLa tabla de multiplicar de {i} es:\n");

                for (int j = 1; j <= 10; j++)
                {
                    Console.WriteLine($"{i} x {j} = {i * j}");
                }

                if (i < 10)
                {
                    Console.WriteLine("\nPresione ENTER para continuar con la siguiente tabla.");
                    Console.ReadKey();
                }

            }
        }

        public static void NumeroPrimo()
        {
            string entrada;

            Console.Clear();
            Console.WriteLine("Este algoritmo recibe un número e imprime si ese número es primo o no.\n");
            Console.WriteLine("Digite un número.\n");

            entrada = Console.ReadLine();            

            if(Validaciones.EsPrimo(entrada))
            {
                Console.WriteLine($"\nEl número {entrada} es primo.");
            }
            else
            {
                Console.WriteLine($"\nEl número {entrada} no es primo.");
            }

        }

        public static void OrdenarLista()
        {
            Console.Clear();
            Console.WriteLine("Este algoritmo ordena la siguiente lista de forma ascendente: [12,50,23,11,18,35,41,85,16,45]");

            int [] lista_numeros = {12, 50, 23, 11, 18, 35, 41, 85, 16, 45};

            int i = 1;
            int j;

            while (i < lista_numeros.Length)
            {
                j = i;
                while (j > 0 && (lista_numeros[j-1] > lista_numeros[j]))
                {
                    int temp = lista_numeros[j - 1];
                    int temp2 = lista_numeros[j];
                    lista_numeros[j - 1] = temp2;
                    lista_numeros[j] = temp;
                    j = j - 1;
                }
                i = i + 1;
            }

            Console.WriteLine("\nLa lista ordenada es:\n");
            Console.WriteLine("[" + String.Join(", ", lista_numeros) + "]");

        }

        public static void ExistirLista()
        {
            string entrada;
            bool entrada_valida = false;
            int indice;
            int edad;

            Console.Clear();
            Console.WriteLine("Con los vectores edad y nombre:\n");
            Console.WriteLine("edades = [12,50,23,11,18,35,41,85,16,45]"); 
            Console.WriteLine("nombres = [juan, maria, tereza, pedro, javier, ana, diana, jorge, dayana, lady]\n");
            Console.WriteLine("Se lee un nombre y se define si existe, si existe se muestra la edad, si no existe el nombre "
            + "se muestra un mensaje diciendo que no existe.");

            int [] edades = {12,50,23,11,18,35,41,85,16,45};
            string [] nombres = {"juan", "maria", "tereza", "pedro", "javier", "ana", "diana", "jorge","dayana", "lady"};
            
            Console.WriteLine("Escriba un nombre: \n");

            do
            {
                entrada = Console.ReadLine();

                if (!Validaciones.Vacio(entrada))
                {
                    if (Validaciones.TipoTexto(entrada))
                    {
                        entrada_valida = true;
                    }
                    else
                    {
                        Console.WriteLine("\nDigite una opción válida.\n");
                    }
                }
                else
                {
                    Console.WriteLine("\nDigite texto.\n");
                }

            } while (!entrada_valida);

            foreach (string nom in nombres)
            {
                if (entrada.ToLower().Equals(nom))
                {
                    indice = Array.IndexOf(nombres, entrada);
                    edad = edades[indice];
                    Console.WriteLine($"\nEl nombre {entrada} sí existe, su edad es {edad}.");
                    return;
                }
            }
            
            Console.WriteLine($"\nEl nombre {entrada} no existe.");
        }

        public static void MayorMenorLista()
        {
            int edad_max;
            int edad_min;
            int indice_max;
            int indice_min;
            string nombre_max;
            string nombre_min;

            Console.Clear();
            Console.WriteLine("Con los vectores edad y nombre:\n");
            Console.WriteLine("edades = [12,50,23,11,18,35,41,85,16,45]"); 
            Console.WriteLine("nombres = [juan, maria, tereza, pedro, javier, ana, diana, jorge, dayana, lady]\n");
            Console.WriteLine("Buscar el de menor edad e imprimir su nombre, buscar el de mayor edad e imprimir su nombre.");

            int [] edades = {12,50,23,11,18,35,41,85,16,45};
            string [] nombres = {"juan", "maria", "tereza", "pedro", "javier", "ana", "diana", "jorge","dayana", "lady"};

            edad_max = edades.Max();
            indice_max = Array.IndexOf(edades, edad_max);
            nombre_max = nombres[indice_max];

            edad_min = edades.Min();
            indice_min = Array.IndexOf(edades, edad_min);
            nombre_min = nombres[indice_min];

            Console.WriteLine($"\nLa edad mayor es {edad_max} con el nombre {nombre_max}, la edad menor es {edad_min} con el nombre {nombre_min}.");
            
        }

        public static void EsPalindromo()
        {
            bool entrada_valida = false;
            string entrada;
            char [] caracteres;
            char [] caract_reverso;

            Console.Clear();
            Console.WriteLine("Este algoritmo recibe una palabra y verifica si es palíndromo.\n");
            Console.WriteLine("Digite la palabra:\n");

            do
            {
                entrada = Console.ReadLine();

                if (!Validaciones.Vacio(entrada))
                {
                    if (Validaciones.TipoTexto(entrada))
                    {
                        entrada_valida = true;
                    }
                    else
                    {
                        Console.WriteLine("\nDigite una opción válida.\n");
                    }
                }
                else
                {
                    Console.WriteLine("\nDigite texto.\n");
                }

            } while (!entrada_valida);

            caracteres = entrada.ToCharArray();
            caract_reverso = entrada.ToCharArray();
            Array.Reverse(caract_reverso);

            if (caracteres.SequenceEqual(caract_reverso))
            {
                Console.WriteLine($"\nLa palabra {entrada} es un palíndromo.");
            }
            else
            {
                Console.WriteLine($"\nLa palabra {entrada} no es un palíndromo.");
            }

        }

        public static void SecuenciaFibonacci()
        {
            string entrada;
            bool entrada_valida = false;
            long numero;

            Console.Clear();
            Console.WriteLine("Este algoritmo muestra los primeros n números de la serie de Fibonacci. Se pregunta " 
            + "al usuario el número.");

            Console.WriteLine("\nDigite el número: \n");

            do
            {
                entrada = Console.ReadLine();

                if (!Validaciones.Vacio(entrada))
                {
                    if (Validaciones.TipoNumero(entrada))
                    {
                        entrada_valida = true;
                    }
                    else
                    {
                        Console.WriteLine("\nDigite una opción válida.\n");
                    }
                }
                else
                {
                    Console.WriteLine("\nDigite un número.\n");
                }

            } while (!entrada_valida);

            numero = Int64.Parse(entrada);

            if (numero == 1)
            {
                Console.WriteLine("\nEl primer número de la serie de Fibonacci es 0");
                return;
            }
            else if (numero == 0)
            {
                Console.WriteLine("\nPues no se muestra ningún número de la serie de Fibonacci.");
                return;
            }


            BigInteger [] arreglo_num = new BigInteger [numero];

            BigInteger i_0 = 0;
            BigInteger i_1 = 1;
            BigInteger temp;

            arreglo_num[0] = i_0;
            arreglo_num[1] = i_1 ;

            for (int j = 2; j < numero; j++)
            {
                temp = arreglo_num[j - 1] + arreglo_num[j - 2];
                arreglo_num[j] = temp;
            }

            Console.WriteLine($"\nLos primeros {entrada} números de la serie de Fibonacci son: \n");

            foreach (BigInteger j in arreglo_num)
            {
                Console.WriteLine(j);
            }
        }

        public static void Parafiscales()
        {
            string entrada;
            bool entrada_valida = false;
            decimal num;

            Console.Clear();
            Console.WriteLine("Este algoritmo muestra el monto de parafiscales que un empleado "
            + "independiente tiene que pagar.\n");

            Console.WriteLine("Digite el salario: \n");

            do
            {
                entrada = Console.ReadLine();

                if (!Validaciones.Vacio(entrada))
                {
                    if (Validaciones.TipoNumero(entrada))
                    {
                        entrada_valida = true;
                    }
                    else
                    {
                        Console.WriteLine("\nDigite una opción válida.\n");
                    }
                }
                else
                {
                    Console.WriteLine("\nDigite un número.\n");
                }

            } while (!entrada_valida);

            num = Decimal.Parse(entrada);

            decimal salud_ingresos = num * (decimal) 0.125;
            decimal pension_ingresos = num * (decimal) 0.16;

            NumberFormatInfo nfi = new System.Globalization.NumberFormatInfo();
            nfi.NumberDecimalSeparator = ".";

            // Console.WriteLine(salud_ingresos.ToString(nfi));
            // Console.WriteLine(salud_ingresos);

            Console.WriteLine($"\nPor salud usted debe consignar {salud_ingresos.ToString("N2", nfi)}.");
            Console.WriteLine($"Por pensión usted debe consignar {pension_ingresos.ToString("N2", nfi)}.");


        }

    }
}

