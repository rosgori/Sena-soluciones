using System;
using System.Collections.Generic;

namespace SolConsolaCiclo
{
    class Program
    {
        // Para crear un objeto de Validaciones
        static Validaciones Verificacion = new Validaciones();
        // Para crear una lista de Personajes
        static List<string> ListaPersonajes = new List<string>();

        // Datos para dibujar el marco
        static int x_min = 1;
        static int x_max = 115;
        static int y_min = 1;
        static int y_max = 35;

        static void Main(string[] args)
        {
            string [] personas = {"Homero", "Jorge Luis Borges", "Margaret Atwood"};
            ListaPersonajes.AddRange(personas);

            int opcion_menu;
            string temporal;

            do
            {
                bool EntradaValida = false;

                Console.Clear();
                Marcos.DibujarMarco(x_min, x_max, y_min, y_max);
                Marcos.EscribirEn("*** MENÚ PRINCIPAL ***", 35, 5);
                Marcos.EscribirEn("1. Quiénes somos.", 35, 7);
                Marcos.EscribirEn("2. Menú aplicación.", 35, 8);
                Marcos.EscribirEn("0. Salir.", 35, 9);

                do
                {
                    Marcos.EscribirEn("Escoja una opción: ", 35, 12);
                    temporal = Console.ReadLine();                    
                    if (!Verificacion.Vacio(temporal))
                    {
                        if(Verificacion.TipoNumero(temporal))
                        {
                            EntradaValida = true;
                        }
                    }
                            

                } while (!EntradaValida);

                opcion_menu = Convert.ToInt32(temporal);                

                switch (opcion_menu)
                {
                    case 1:
                        MostrarPrimeraOpcion();
                        break;
                    case 2:
                        MostrarSegundaOpcion();
                        break;
                    case 0:
                        Marcos.EscribirEn("Gracias por usar el programa.", 35, 14);
                        break;
                    default:
                        Marcos.EscribirEn("Opción inválida, digite de nuevo un número.", 35, 16);
                        break;
                }
                Marcos.EscribirEn("Presione cualquier tecla para continuar.", 35, 18);
                Console.ReadKey();
                Console.Clear();
            } while (opcion_menu != 0);
        }

        static void MostrarPrimeraOpcion()
        {
            Console.Clear();
            Marcos.DibujarMarco(x_min, x_max, y_min, y_max);
            Marcos.EscribirEn("Los integrantes son las siguientes personas:", 35, 5);
            int ii = 7;
            foreach (string persona in ListaPersonajes)
            {
                Marcos.EscribirEn(persona, 35, ii);
                ii += 1;
            }   
        }

        static void MostrarSegundaOpcion()
        {
            bool EntradaValida = false;
            string temporal2;
            int opcion_submenu = 1;

            while (opcion_submenu != 0)
            {

                Console.Clear();
                Marcos.DibujarMarco(x_min, x_max, y_min, y_max);
                Marcos.EscribirEn("Las opciones son:", 35, 5);
                Marcos.EscribirEn("1. Agregar personajes.", 35, 7);
                Marcos.EscribirEn("2. Listar personajes.", 35, 8);
                Marcos.EscribirEn("3. Buscar personajes.", 35, 9);
                Marcos.EscribirEn("0. Salir a menú principal.", 35, 10);

                do
                {
                    Marcos.EscribirEn("Escoja una opción: ", 35, 12);
                    temporal2 = Console.ReadLine();                    
                    if (!Verificacion.Vacio(temporal2))
                    {
                        if(Verificacion.TipoNumero(temporal2))
                        {
                            EntradaValida = true;
                        }
                    }

                } while (!EntradaValida);

                opcion_submenu = Convert.ToInt32(temporal2);

                switch (opcion_submenu)
                {
                    case 1:
                        AgregarPersonajes();
                        break;
                    case 2:
                        ListarPersonajes();
                        break;
                    case 3:
                        BuscarPersonajes();
                        break;
                    case 0:
                        break;
                    default:
                        Marcos.EscribirEn("Opción inválida, digite de nuevo un número.", 35, 18);
                        Marcos.EscribirEn("Presione una cualquier tecla para continuar.", 35, 19);
                        Console.ReadKey();
                        break;
                }
            }

        }

        static void AgregarPersonajes()
        {
            bool EntradaValida = false;
            string persona;

            Marcos.EscribirEn("Insertando un personaje...", 35, 14);

            do
            {
                Marcos.EscribirEn("Digite el nombre del personaje que desear añadir:\n", 35, 16);
                Console.SetCursorPosition(35, 17);
                persona = Console.ReadLine();                    
                if (!Verificacion.Vacio(persona))
                    if(Verificacion.TipoTexto(persona))
                        EntradaValida = true;

            } while (!EntradaValida);

            // Para saber si existe el personaje en la lista
            if (!Existe(persona))
            {
                ListaPersonajes.Add(persona);
                Marcos.EscribirEn("Personaje añadido.", 35, 18);
            }
            else
            {
                Marcos.EscribirEn("Ese nombre ya existe.", 35, 18);
            }
            Marcos.EscribirEn("Presione cualquier tecla para continuar.", 35, 20);
            Console.ReadKey();            

        }

        static bool Existe(string persona)
        {
            bool aux = false;

            foreach (string persona2 in ListaPersonajes)
            {
                if (persona2.Equals(persona))
                    aux = true;
            }
            return aux;
        }

        static void ListarPersonajes()
        {
            Console.Clear();
            Marcos.DibujarMarco(x_min, x_max, y_min, y_max);
            Marcos.EscribirEn("Todos los personajes son:", 35, 5);
            int ii = 7;
            foreach (string persona in ListaPersonajes)
            {
                Marcos.EscribirEn(persona, 35, ii);
                ii += 1;
            }
            Marcos.EscribirEn("Presione cualquier tecla para continuar.", 35, 20);
            Console.ReadKey();
        }

        static void BuscarPersonajes()
        {
            bool EntradaValida = false;
            string personaje;

            Console.Clear();
            Marcos.DibujarMarco(x_min, x_max, y_min, y_max);

            do
            {
                Marcos.EscribirEn("Digite el nombre del personaje que desea buscar: \n", 35, 5);
                Console.SetCursorPosition(35, 6);
                personaje = Console.ReadLine();                    
                if (!Verificacion.Vacio(personaje))
                    if(Verificacion.TipoTexto(personaje))
                        EntradaValida = true;

            } while (!EntradaValida);

            if(Existe(personaje))
            {
                Marcos.EscribirEn("Ese nombre existe en el grupo.", 35, 8);
            }
            else
            {
                Marcos.EscribirEn("Ese nombre no existe en el grupo.", 35, 8);
            }
            Marcos.EscribirEn("Presione cualquier tecla para continuar.", 35, 10);
            Console.ReadKey();
            
        }
        
    }
}
