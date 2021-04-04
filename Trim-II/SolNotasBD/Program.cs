using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using SolNotasBD.Modelo;

namespace SolNotasBD
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int opcion_menu = 1;
            string temporal;

            CultureInfo.CurrentCulture = new CultureInfo("en-US", false);

            while (opcion_menu != 0)
            {
                bool entrada_valida = false;
                Console.Clear();

                MenuPrincipal();
                Marcos.LogoMensaje();

                do
                {
                    Marcos.EscribirEn("Escoja una opción: ", 70, 1);
                    temporal = Console.ReadLine();
                    if (!Validaciones.Vacio(temporal))
                    {
                        if (Validaciones.TipoEntradaNumero(temporal))
                        {
                            entrada_valida = true;
                        }
                        else
                        {
                            // Para borrar la línea de escoja la opción
                            Marcos.BorrarLinea(70, 119, 1);
                            // Para borrar la línea dentro marco pequeño
                            Marcos.BorrarLinea(30, 70, 36);
                            MarcoPequeño();
                            Marcos.EscribirEn(Mensajes.NoNumero(), 30, 36);
                        }
                    }
                    else
                    {
                        // Para borrar la línea de escoja la opción
                        Marcos.BorrarLinea(70, 119, 1);
                        // Para borrar la línea dentro marco pequeño
                        Marcos.BorrarLinea(30, 70, 36);
                        MarcoPequeño();
                        Marcos.EscribirEn(Mensajes.NoVacio(), 30, 36);
                    }
                } while (!entrada_valida);

                opcion_menu = Convert.ToInt32(temporal);

                switch (opcion_menu)
                {
                    case 1:
                        InsertarNombre();
                        break;
                    case 2:
                        ListarNombres();
                        break;
                    case 3:
                        BuscarNombre();
                        break;
                    case 4:
                        EditarNombre();
                        break;
                    case 5:
                        BorrarNombre();
                        break;
                    case 0:
                        Marcos.BorrarLinea(30, 70, 36);
                        MarcoPequeño();
                        Marcos.EscribirEn("Gracias por usar el programa.", 35, 36);
                        break;
                    default:
                        Marcos.BorrarLinea(30, 60, 36);
                        MarcoPequeño();
                        Marcos.EscribirEn("Opción inválida. Digite una opción válida.", 30, 36);
                        break;
                }
                Console.ReadKey();
                Console.Clear();
            }

        }


        public static void MenuPrincipal()
        {
            Marcos.DibujarMarco(1, 140, 0, 4);
            Marcos.EscribirEn("App Estudiante", 5, 1);
            Marcos.EscribirEn("1. Agregar", 5, 3);
            Marcos.EscribirEn("2. Listar", 20, 3);
            Marcos.EscribirEn("3. Buscar", 35, 3);
            Marcos.EscribirEn("4. Editar", 50, 3);
            Marcos.EscribirEn("5. Borrar", 65, 3);
            Marcos.EscribirEn("0. Salir", 80, 3);

            Marcos.DibujarMarco(1, 140, 5, 55);

        }

        public static void MarcoPequeño()
        {
            Marcos.DibujarMarco(25, 90, 35, 38);
        }

        public static void InsertarNombre()
        {
            Console.Clear();
            MenuPrincipal();

            bool entrada_valida_cod = false;
            bool entrada_valida_nombre = false;
            bool entrada_valida_correo = false;
            bool entrada_valida_nota1 = false;
            bool entrada_valida_nota2 = false;
            bool entrada_valida_nota3 = false;

            string codigo;
            string nombre;
            string correo;
            string nota1;
            string nota2;
            string nota3;
            string respuesta;

            Marcos.EscribirEn("AGREGANDO ESTUDIANTE", 40, 7);

            // Para el código
            do
            {
                Marcos.EscribirEn("Digite el código del estudiante: ", 10, 11);
                codigo = Console.ReadLine();
                if (!Validaciones.Vacio(codigo))
                {
                    if (Validaciones.TipoCodigo(codigo))
                    {
                        entrada_valida_cod = true;
                    }
                    else
                    {
                        Marcos.BorrarLinea(10, 100, 11);
                        // Para borrar la línea dentro marco pequeño
                        Marcos.BorrarLinea(30, 70, 36);
                        MarcoPequeño();
                        Marcos.EscribirEn(Mensajes.NoCodigo(), 30, 36);
                    }
                }
                else
                {
                    Marcos.BorrarLinea(10, 100, 11);
                    // Para borrar la línea dentro marco pequeño
                    Marcos.BorrarLinea(30, 70, 36);
                    MarcoPequeño();
                    Marcos.EscribirEn(Mensajes.NoVacio(), 30, 36);
                }
            } while (!entrada_valida_cod);


            if (!ExisteCodigo(Convert.ToInt32(codigo)))
            {
                // Para el nombre
                do
                {
                    Marcos.EscribirEn("Digite el nombre del estudiante: ", 10, 12);
                    nombre = Console.ReadLine();

                    if (!Validaciones.Vacio(nombre))
                    {
                        if (Validaciones.TipoTexto(nombre))
                        {
                            entrada_valida_nombre = true;
                        }
                        else
                        {
                            Marcos.BorrarLinea(10, 100, 12);
                            // Para borrar la línea dentro marco pequeño
                            Marcos.BorrarLinea(30, 90, 36);
                            MarcoPequeño();
                            Marcos.EscribirEn(Mensajes.NoTexto(), 30, 36);
                        }
                    }
                    else
                    {
                        Marcos.BorrarLinea(10, 100, 12);
                        // Para borrar la línea dentro marco pequeño
                        Marcos.BorrarLinea(30, 70, 36);
                        MarcoPequeño();
                        Marcos.EscribirEn(Mensajes.NoVacio(), 30, 36);
                    }
                } while (!entrada_valida_nombre);

                // Para el correo
                do
                {
                    Marcos.EscribirEn("Digite el correo del estudiante: ", 10, 13);
                    correo = Console.ReadLine();

                    if (!Validaciones.Vacio(correo))
                    {
                        if (Validaciones.TipoCorreo(correo))
                        {
                            entrada_valida_correo = true;
                        }
                        else
                        {
                            Marcos.BorrarLinea(10, 100, 13);
                            // Para borrar la línea dentro marco pequeño
                            Marcos.BorrarLinea(30, 70, 36);
                            MarcoPequeño();
                            Marcos.EscribirEn(Mensajes.NoCorreo(), 30, 36);
                        }
                    }
                    else
                    {
                        Marcos.BorrarLinea(10, 100, 13);
                        // Para borrar la línea dentro marco pequeño
                        Marcos.BorrarLinea(30, 70, 36);
                        MarcoPequeño();
                        Marcos.EscribirEn(Mensajes.NoVacio(), 30, 36);
                    }
                } while (!entrada_valida_correo);

                // Para la nota 1
                do
                {
                    Marcos.EscribirEn("Digite la nota 1 del estudiante (use punto decimal, número entre 0 y 5): ", 10, 14);
                    nota1 = Console.ReadLine();
                    if (Validaciones.TipoNota(nota1))
                    {
                        entrada_valida_nota1 = true;
                    }
                    else
                    {
                        Marcos.BorrarLinea(10, 119, 14);
                        // Para borrar la línea dentro marco pequeño
                        Marcos.BorrarLinea(30, 70, 36);
                        MarcoPequeño();
                        Marcos.EscribirEn(Mensajes.NoNota(), 30, 36);
                    }
                } while (!entrada_valida_nota1);

                // Para la nota 2
                do
                {
                    Marcos.EscribirEn("Digite la nota 2 del estudiante (use punto decimal, número entre 0 y 5): ", 10, 15);
                    nota2 = Console.ReadLine();
                    if (Validaciones.TipoNota(nota2))
                    {
                        entrada_valida_nota2 = true;
                    }
                    else
                    {
                        Marcos.BorrarLinea(10, 119, 15);
                        // Para borrar la línea dentro marco pequeño
                        Marcos.BorrarLinea(30, 70, 36);
                        MarcoPequeño();
                        Marcos.EscribirEn(Mensajes.NoNota(), 30, 36);
                    }
                } while (!entrada_valida_nota2);


                // Para la nota 3
                do
                {
                    Marcos.EscribirEn("Digite la nota 3 del estudiante (use punto decimal, número entre 0 y 5): ", 10, 16);
                    nota3 = Console.ReadLine();
                    if (Validaciones.TipoNota(nota3))
                    {
                        entrada_valida_nota3 = true;
                    }
                    else
                    {
                        Marcos.BorrarLinea(10, 119, 16);
                        // Para borrar la línea dentro marco pequeño
                        Marcos.BorrarLinea(30, 70, 36);
                        MarcoPequeño();
                        Marcos.EscribirEn(Mensajes.NoNota(), 30, 36);
                    }
                } while (!entrada_valida_nota3);

                var base_datos = new Taller_estudiantesContext();
                // var Estudiantes = base_datos.Estudiantes.ToList();

                Estudiante estudiante = new Estudiante();
                estudiante.Codigo = Convert.ToUInt32(codigo);
                estudiante.Nombre = nombre;
                estudiante.Correo = correo;
                estudiante.Nota1 = double.Parse(nota1);
                estudiante.Nota2 = double.Parse(nota2);
                estudiante.Nota3 = double.Parse(nota3);

                Marcos.BorrarLinea(30, 90, 36);
                MarcoPequeño();
                Marcos.EscribirEn("Con estos datos, ¿desea agregar este estudiante? (S/n) ", 30, 36);
                respuesta = Console.ReadLine();

                if (respuesta.ToLower().Equals("s"))
                {
                    base_datos.Estudiantes.Add(estudiante);
                    base_datos.SaveChanges();

                    Marcos.BorrarLinea(30, 90, 36);
                    MarcoPequeño();
                    Marcos.EscribirEn("Los datos han sido añadidos.", 30, 36);
                }
                else
                {
                    Marcos.BorrarLinea(30, 90, 36);
                    MarcoPequeño();
                    Marcos.EscribirEn("Los datos no han sido añadidos.", 30, 36);

                }

            }
            else
            {
                Marcos.BorrarLinea(30, 60, 36);
                MarcoPequeño();
                Marcos.EscribirEn("El código ya existe, intente con otro.", 30, 36);
            }
            // Console.ReadKey();
        }

        public static void ListarNombres()
        {
            Console.Clear();
            MenuPrincipal();

            var base_datos = new Taller_estudiantesContext();
            var Estudiantes = base_datos.Estudiantes.ToList();
            string mensaje;

            Marcos.EscribirEn("LISTA DE ESTUDIANTES", 40, 7);

            string header = String.Format("{0, 5} {1, 20} {2, 30} {3, 14} {4, 10} {5, 10} {6, 13} {7, 13}",
                              "CÓDIGO", "NOMBRE", "CORREO", "NOTA 1", "NOTA 2", "NOTA 3", "NOTA FINAL", "ESTADO");
            Marcos.EscribirEn(header, 3, 10);

            int ii = 12;

            foreach (var estudiante in Estudiantes)
            {
                double nota1 = Convert.ToDouble(estudiante.Nota1);
                double nota2 = Convert.ToDouble(estudiante.Nota2);
                double nota3 = Convert.ToDouble(estudiante.Nota3);
                double nota_final = (nota1 + nota2 + nota3) / 3;

                if (nota_final >= 3.5)
                {
                    mensaje = "Aprobado";
                }
                else
                {
                    mensaje = "No aprobado";
                }

                string header2 = String.Format($"{estudiante.Codigo,5} {estudiante.Nombre,25} {estudiante.Correo,30}" +
                $"{estudiante.Nota1,10:.##} {estudiante.Nota2,10:.##} {estudiante.Nota3,10:.##} {nota_final,12:.##} {mensaje,17}");
                Marcos.EscribirEn(header2, 3, ii);
                ii += 1;
            }

            // Console.ReadKey();
            // Console.Clear();
        }

        public static void BuscarNombre()
        {
            Console.Clear();
            MenuPrincipal();

            var base_datos = new Taller_estudiantesContext();
            var Estudiantes = base_datos.Estudiantes.ToList();

            string codigo;
            bool entrada_valida_cod = false;
            string mensaje;

            do
            {
                Marcos.EscribirEn("Digite el código del estudiante a buscar: ", 10, 7);
                codigo = Console.ReadLine();
                if (!Validaciones.Vacio(codigo))
                {
                    if (Validaciones.TipoCodigo(codigo))
                    {
                        entrada_valida_cod = true;
                    }
                    else
                    {
                        Marcos.BorrarLinea(10, 60, 11);
                        // Para borrar la línea dentro marco pequeño
                        Marcos.BorrarLinea(30, 70, 36);
                        MarcoPequeño();
                        Marcos.EscribirEn(Mensajes.NoCodigo(), 30, 36);
                    }
                }
                else
                {
                    Marcos.BorrarLinea(10, 60, 11);
                    // Para borrar la línea dentro marco pequeño
                    Marcos.BorrarLinea(30, 70, 36);
                    MarcoPequeño();
                    Marcos.EscribirEn(Mensajes.NoVacio(), 30, 36);
                }
            } while (!entrada_valida_cod);

            if (ExisteCodigo(Convert.ToInt32(codigo)))
            {
                Estudiante estudiante = ObtenerEstudiante(Convert.ToInt32(codigo));
                string header = String.Format("{0, 5} {1, 20} {2, 30} {3, 14} {4, 10} {5, 10} {6, 13} {7, 13}",
                              "CÓDIGO", "NOMBRE", "CORREO", "NOTA 1", "NOTA 2", "NOTA 3", "NOTA FINAL", "ESTADO");
                Marcos.EscribirEn(header, 3, 13);

                double nota1 = Convert.ToDouble(estudiante.Nota1);
                double nota2 = Convert.ToDouble(estudiante.Nota2);
                double nota3 = Convert.ToDouble(estudiante.Nota3);
                double nota_final = (nota1 + nota2 + nota3) / 3;

                if (nota_final >= 3.5)
                {
                    mensaje = "Aprobado";
                }
                else
                {
                    mensaje = "No aprobado";
                }
                string header2 = String.Format($"{estudiante.Codigo,5} {estudiante.Nombre,25} {estudiante.Correo,30}" +
                $"{estudiante.Nota1,10:.##} {estudiante.Nota2,10:.##} {estudiante.Nota3,10:.##} {nota_final,12:.##} {mensaje,17}");
                Marcos.EscribirEn(header2, 3, 15);
            }
            else
            {
                // Para borrar la línea dentro marco pequeño
                Marcos.BorrarLinea(30, 70, 36);
                MarcoPequeño();
                Marcos.EscribirEn("El código no existe.", 30, 36);
            }

            // Console.ReadKey();
        }

        public static void EditarNombre()
        {
            Console.Clear();
            MenuPrincipal();

            var base_datos = new Taller_estudiantesContext();

            string codigo;
            bool entrada_valida_cod = false;
            bool entrada_valida_nombre = false;
            bool entrada_valida_correo = false;
            bool entrada_valida_nota1 = false;
            bool entrada_valida_nota2 = false;
            bool entrada_valida_nota3 = false;

            string nombre;
            string correo;
            string nota1;
            string nota2;
            string nota3;
            string respuesta;

            Marcos.EscribirEn("EDITANDO INFORMACIÓN DEL ESTUDIANTE", 40, 7);

            // Para borrar la línea dentro marco pequeño
            Marcos.BorrarLinea(30, 70, 36);
            MarcoPequeño();
            Marcos.EscribirEn(Mensajes.NoEditar(), 30, 36);

            // Para el código
            do
            {
                Marcos.EscribirEn("Digite el código del estudiante: ", 5, 13);
                codigo = Console.ReadLine();
                if (!Validaciones.Vacio(codigo))
                {
                    if (Validaciones.TipoCodigo(codigo))
                    {
                        entrada_valida_cod = true;
                    }
                    else
                    {
                        Marcos.BorrarLinea(5, 60, 13);
                        // Para borrar la línea dentro marco pequeño
                        Marcos.BorrarLinea(30, 70, 36);
                        MarcoPequeño();
                        Marcos.EscribirEn(Mensajes.NoCodigo(), 30, 36);
                    }
                }
                else
                {
                    Marcos.BorrarLinea(5, 60, 13);
                    // Para borrar la línea dentro marco pequeño
                    Marcos.BorrarLinea(30, 70, 36);
                    MarcoPequeño();
                    Marcos.EscribirEn(Mensajes.NoVacio(), 30, 36);
                }
            } while (!entrada_valida_cod);

            if (ExisteCodigo(Convert.ToInt32(codigo)))
            {
                Estudiante estudiante = ObtenerEstudiante(Convert.ToInt32(codigo));
                Marcos.EscribirEn($"Código del estudiante: {estudiante.Codigo}", 5, 16);
                Marcos.EscribirEn($"Nombre del estudiante: {estudiante.Nombre}", 5, 17);
                Marcos.EscribirEn($"Correo del estudiante: {estudiante.Correo}", 5, 18);
                Marcos.EscribirEn($"Nota 1: {estudiante.Nota1}", 5, 19);
                Marcos.EscribirEn($"Nota 2: {estudiante.Nota2}", 5, 20);
                Marcos.EscribirEn($"Nota 3: {estudiante.Nota3}", 5, 21);

                Marcos.EscribirEn("Datos a cambiar: ", 70, 13);
                Marcos.EscribirEn($"Código: {estudiante.Codigo}", 70, 16);

                // Para el nombre
                do
                {
                    Marcos.EscribirEn("Nombre: ", 70, 17);
                    nombre = Console.ReadLine();

                    if (!Validaciones.Vacio(nombre))
                    {
                        if (Validaciones.TipoTexto(nombre))
                        {
                            entrada_valida_nombre = true;
                        }
                        else
                        {
                            Marcos.BorrarLinea(70, 139, 17);
                            // Para borrar la línea dentro marco pequeño
                            Marcos.BorrarLinea(30, 70, 36);
                            MarcoPequeño();
                            Marcos.EscribirEn(Mensajes.NoTexto(), 30, 36);
                        }
                    }
                    else
                    {
                        // Para borrar la línea dentro marco pequeño
                        Marcos.BorrarLinea(30, 70, 36);
                        MarcoPequeño();
                        Marcos.EscribirEn(Mensajes.NoEditarDato(), 30, 36);
                        entrada_valida_nombre = true;

                    }
                } while (!entrada_valida_nombre);

                // Para el correo
                do
                {
                    Marcos.EscribirEn("Correo: ", 70, 18);
                    correo = Console.ReadLine();

                    if (!Validaciones.Vacio(correo))
                    {
                        if (Validaciones.TipoCorreo(correo))
                        {
                            entrada_valida_correo = true;
                        }
                        else
                        {
                            Marcos.BorrarLinea(70, 139, 18);
                            // Para borrar la línea dentro marco pequeño
                            Marcos.BorrarLinea(30, 70, 36);
                            MarcoPequeño();
                            Marcos.EscribirEn(Mensajes.NoCorreo(), 30, 36);
                        }
                    }
                    else
                    {
                        // Para borrar la línea dentro marco pequeño
                        Marcos.BorrarLinea(30, 70, 36);
                        MarcoPequeño();
                        Marcos.EscribirEn(Mensajes.NoEditarDato(), 30, 36);
                        entrada_valida_correo = true;

                    }
                } while (!entrada_valida_correo);

                // Para la nota 1
                do
                {
                    Marcos.EscribirEn("Nota 1 (use punto decimal, número entre 0 y 5): ", 70, 19);
                    nota1 = Console.ReadLine();
                    if (!Validaciones.Vacio(nota1))
                    {
                        if (Validaciones.TipoNota(nota1))
                        {
                            entrada_valida_nota1 = true;
                        }
                        else
                        {
                            Marcos.BorrarLinea(70, 139, 19);
                            // Para borrar la línea dentro marco pequeño
                            Marcos.BorrarLinea(30, 70, 36);
                            MarcoPequeño();
                            Marcos.EscribirEn(Mensajes.NoNota(), 30, 36);
                        }
                    }
                    else
                    {
                        // Para borrar la línea dentro marco pequeño
                        Marcos.BorrarLinea(30, 70, 36);
                        MarcoPequeño();
                        Marcos.EscribirEn(Mensajes.NoEditarDato(), 30, 36);
                        entrada_valida_nota1 = true;
                    }

                } while (!entrada_valida_nota1);

                // Para la nota 2
                do
                {
                    Marcos.EscribirEn("Nota 2 (use punto decimal, número entre 0 y 5): ", 70, 20);
                    nota2 = Console.ReadLine();
                    if (!Validaciones.Vacio(nota2))
                    {
                        if (Validaciones.TipoNota(nota2))
                        {
                            entrada_valida_nota2 = true;
                        }
                        else
                        {
                            Marcos.BorrarLinea(70, 139, 20);
                            // Para borrar la línea dentro marco pequeño
                            Marcos.BorrarLinea(30, 70, 36);
                            MarcoPequeño();
                            Marcos.EscribirEn(Mensajes.NoNota(), 30, 36);
                        }
                    }
                    else
                    {
                        // Para borrar la línea dentro marco pequeño
                        Marcos.BorrarLinea(30, 70, 36);
                        MarcoPequeño();
                        Marcos.EscribirEn(Mensajes.NoEditarDato(), 30, 36);
                        entrada_valida_nota2 = true;
                    }

                } while (!entrada_valida_nota2);


                // Para la nota 3
                do
                {
                    Marcos.EscribirEn("Nota 3 (use punto decimal, número entre 0 y 5): ", 70, 21);
                    nota3 = Console.ReadLine();
                    if (!Validaciones.Vacio(nota3))
                    {
                        if (Validaciones.TipoNota(nota3))
                        {
                            entrada_valida_nota3 = true;
                        }
                        else
                        {
                            Marcos.BorrarLinea(70, 139, 21);
                            // Para borrar la línea dentro marco pequeño
                            Marcos.BorrarLinea(30, 70, 36);
                            MarcoPequeño();
                            Marcos.EscribirEn(Mensajes.NoNota(), 30, 36);
                        }
                    }
                    else
                    {
                        // Para borrar la línea dentro marco pequeño
                        Marcos.BorrarLinea(30, 70, 36);
                        MarcoPequeño();
                        Marcos.EscribirEn(Mensajes.NoEditarDato(), 30, 36);
                        entrada_valida_nota3 = true;
                    }

                } while (!entrada_valida_nota3);

                // Para borrar la línea dentro marco pequeño
                Marcos.BorrarLinea(30, 70, 36);
                MarcoPequeño();
                Marcos.EscribirEn("Los datos serán cambiados. ¿Desea continuar? (S/n) ", 30, 36);
                respuesta = Console.ReadLine();

                if (respuesta.ToLower().Equals("s"))
                {
                    if (!nombre.Equals(""))
                    {
                        estudiante.Nombre = nombre;
                    }

                    if (!correo.Equals(""))
                    {
                        estudiante.Correo = correo;
                    }

                    if (!nota1.Equals(""))
                    {
                        estudiante.Nota1 = double.Parse(nota1);
                    }

                    if (!nota2.Equals(""))
                    {
                        estudiante.Nota2 = double.Parse(nota2);
                    }

                    if (!nota3.Equals(""))
                    {
                        estudiante.Nota3 = double.Parse(nota3);
                    }

                    base_datos.Estudiantes.Update(estudiante);
                    base_datos.SaveChanges();
                    Marcos.BorrarLinea(26, 100, 36);
                    MarcoPequeño();
                    Marcos.EscribirEn("Los datos han sido cambiados.", 30, 36);
                }
                else
                {
                    Marcos.BorrarLinea(26, 100, 36);
                    MarcoPequeño();
                    Marcos.EscribirEn("No hubo cambios.", 30, 36);
                }
            }
            else
            {
                Marcos.BorrarLinea(30, 70, 36);
                MarcoPequeño();
                Marcos.EscribirEn("No existe el código.", 30, 36);
            }

            // Console.ReadKey();
        }

        public static void BorrarNombre()
        {
            Console.Clear();
            MenuPrincipal();

            var base_datos = new Taller_estudiantesContext();
            string codigo;
            bool entrada_valida_cod = false;
            string respuesta;

            // Para el código
            do
            {
                Marcos.EscribirEn("Digite el código del estudiante a borrar: ", 10, 13);
                codigo = Console.ReadLine();
                if (!Validaciones.Vacio(codigo))
                {
                    if (Validaciones.TipoCodigo(codigo))
                    {
                        entrada_valida_cod = true;
                    }
                    else
                    {
                        Marcos.BorrarLinea(5, 60, 13);
                        // Para borrar la línea dentro marco pequeño
                        Marcos.BorrarLinea(30, 70, 36);
                        MarcoPequeño();
                        Marcos.EscribirEn(Mensajes.NoCodigo(), 30, 36);
                    }
                }
                else
                {
                    Marcos.BorrarLinea(5, 60, 13);
                    // Para borrar la línea dentro marco pequeño
                    Marcos.BorrarLinea(30, 70, 36);
                    MarcoPequeño();
                    Marcos.EscribirEn(Mensajes.NoVacio(), 30, 36);
                }
            } while (!entrada_valida_cod);

            if (ExisteCodigo(Convert.ToInt32(codigo)))
            {
                Estudiante estudiante = ObtenerEstudiante(Convert.ToInt32(codigo));
                Marcos.EscribirEn($"Código: {estudiante.Codigo}", 10, 16);
                Marcos.EscribirEn($"Nombre: {estudiante.Nombre}", 10, 17);
                Marcos.EscribirEn($"Correo: {estudiante.Correo}", 10, 18);
                Marcos.EscribirEn($"Nota 1: {estudiante.Nota1}", 10, 19);
                Marcos.EscribirEn($"Nota 2: {estudiante.Nota2}", 10, 20);
                Marcos.EscribirEn($"Nota 3: {estudiante.Nota3}", 10, 21);

                // Para borrar la línea dentro marco pequeño
                Marcos.BorrarLinea(30, 70, 36);
                MarcoPequeño();
                Marcos.EscribirEn("Estos datos serán borrados. ¿Desea continuar? (S/n) ", 30, 36);
                respuesta = Console.ReadLine();

                if (respuesta.ToLower().Equals("s"))
                {
                    base_datos.Estudiantes.Remove(estudiante);
                    base_datos.SaveChanges();
                    // Para borrar la línea dentro marco pequeño
                    Marcos.BorrarLinea(30, 90, 36);
                    MarcoPequeño();
                    Marcos.EscribirEn("Datos borrados de este estudiante", 30, 36);
                }
                else
                {
                    // Para borrar la línea dentro marco pequeño
                    Marcos.BorrarLinea(30, 90, 36);
                    MarcoPequeño();
                    Marcos.EscribirEn("No hubo cambios.", 30, 36);
                }

            }
            else
            {
                // Para borrar la línea dentro marco pequeño
                Marcos.BorrarLinea(30, 90, 36);
                MarcoPequeño();
                Marcos.EscribirEn("No existe el código.", 30, 36);
            }
        }

        public static bool ExisteCodigo(int cod)
        {
            bool aux = false;
            var base_datos = new Taller_estudiantesContext();
            var Estudiantes = base_datos.Estudiantes.ToList();

            foreach (var estudiante in Estudiantes)
            {
                if (estudiante.Codigo == cod)
                    aux = true;
            }
            return aux;
        }

        public static Estudiante ObtenerEstudiante(int cod)
        {
            var base_datos = new Taller_estudiantesContext();
            var Estudiantes = base_datos.Estudiantes.ToList();

            foreach (Estudiante estudiante in Estudiantes)
            {
                if (estudiante.Codigo == cod)
                    return estudiante;
            }

            return null;
        }

    }

}

