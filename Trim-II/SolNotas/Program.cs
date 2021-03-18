using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace SolNotas
{
    class Program
    {
        static Validaciones Verificar = new Validaciones();
        static List<Estudiantes> ListaEstudiantes = new List<Estudiantes>();

         // Datos para dibujar el marco
        static int x_min = 1;
        static int x_max = 115;
        static int y_min = 1;
        static int y_max = 35;
        
        static void Main(string[] args)
        {
            int opcion_menu;

            LeerDatosXml();
            Marcos.EscribirEn("Presione cualquier tecla para continuar.", 35, 20);
            Console.ReadKey();

            do
            {
                string temporal;
                bool EntradaValida = false;

                Console.Clear();
                Marcos.DibujarMarco(x_min, x_max, y_min, y_max);
                Marcos.EscribirEn("*** Menú Principal *** ", 35, 5);
                Marcos.EscribirEn("1. Insertar estudiante.", 35, 7);
                Marcos.EscribirEn("2. Listar estudiante.", 35, 8);
                Marcos.EscribirEn("3. Buscar estudiante.", 35, 9);
                Marcos.EscribirEn("8. Leer datos de archivo.", 35, 10);
                Marcos.EscribirEn("9. Guardar datos en archivo.", 35, 11);
                Marcos.EscribirEn("0. Salir", 35, 12);

                do
                {                    
                    Marcos.EscribirEn("Escoja una opción: ", 35, 14);
                    temporal = Console.ReadLine();
                    if (!Verificar.Vacio(temporal))
                        if (Verificar.TipoNumero(temporal))
                            EntradaValida = true;
                } while (!EntradaValida);

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
                    case 8:
                        LeerDatosXml();
                        break;
                    case 9:
                        EscribirDatosXml();
                        break;
                    case 0:
                        Marcos.EscribirEn("Gracias por usar el programa.", 35, 20);
                        break;
                    default:
                        Marcos.EscribirEn("Opción inválida. Digite una opción válida.", 35, 20);
                        break;
                }

                Marcos.EscribirEn("Presione cualquier tecla para continuar.", 35, 30);
                Console.ReadKey();
                Console.Clear();
            } while (opcion_menu != 0);
        }

        static void InsertarNombre()
        {
            bool EntradaValidaNombre = false;
            bool EntradaValidaCodigo = false;
            bool EntradaValidaCorreo = false;
            bool EntradaValidaNota1 = false;
            bool EntradaValidaNota2 = false;
            bool EntradaValidaNota3 = false;

            string codigo;
            string nombre;
            string correo;
            string nota1;
            string nota2;
            string nota3;
            double temp1;
            double temp2;
            double temp3;
            int temp4;

            Console.Clear();
            Marcos.DibujarMarco(x_min, x_max, y_min, y_max);
            Marcos.EscribirEn("Añadiendo el estudiante.", 25, 5);

            // Validaciones para todos los casos
            // Para el código
            do
            {
                Marcos.EscribirEn("Digite el código del estudiante: ", 25, 7);
                codigo = Console.ReadLine();
                if (!Verificar.Vacio(codigo))
                    if (Verificar.TipoNumero(codigo))
                    {
                        temp4 = Convert.ToInt32(codigo);
                        if (temp4 > 0)
                            EntradaValidaCodigo = true;
                    }                        
            } while (!EntradaValidaCodigo);

            if (!Existe(Convert.ToInt32(codigo)))
            {          
                // Para el nombre
                do
                {
                    Marcos.EscribirEn("Digite el nombre del estudiante: ", 25, 8);
                    nombre = Console.ReadLine();
                    if (!Verificar.Vacio(nombre))
                        if (Verificar.TipoTexto(nombre))
                            EntradaValidaNombre = true;
                } while (!EntradaValidaNombre);

                // Para el correo
                do
                {
                    Marcos.EscribirEn("Digite el correo: ", 25, 9);
                    correo = Console.ReadLine();
                    if (!Verificar.Vacio(correo))
                        if (Verificar.TipoCorreo(correo))
                            EntradaValidaCorreo = true;
                } while (!EntradaValidaCorreo);

                // Para la primera nota
                do
                {
                    Marcos.EscribirEn("Digite la primera nota (use coma decimal, número entre 0 y 5): ", 25, 10);
                    nota1 = Console.ReadLine();
                    if (!Verificar.Vacio(nota1))
                        if (Verificar.TipoNumero(nota1))
                        {
                            temp1 = Convert.ToDouble(nota1);
                            if (temp1 >= 0 && temp1 <= 5)
                                EntradaValidaNota1 = true;
                        }
                } while (!EntradaValidaNota1);

                // Para la segunda nota     
                do
                {
                    Marcos.EscribirEn("Digite la segunda nota (use coma decimal, número entre 0 y 5): ", 25, 11);
                    nota2 = Console.ReadLine();
                    if (!Verificar.Vacio(nota2))
                        if (Verificar.TipoNumero(nota2))
                        {
                            temp2 = Convert.ToDouble(nota2);
                            if (temp2 >= 0 && temp2 <= 5)
                            {
                                EntradaValidaNota2 = true;
                            }
                        }
                } while (!EntradaValidaNota2);

                // Para la tercera nota     
                do
                {
                    Marcos.EscribirEn("Digite la tercera nota (use coma decimal, número entre 0 y 5): ", 25, 12);
                    nota3 = Console.ReadLine();
                    if (!Verificar.Vacio(nota3))
                        if (Verificar.TipoNumero(nota3))
                        {
                            temp3 = Convert.ToDouble(nota3);
                            if (temp3 >= 0.0 && temp3 <= 5.0)
                                EntradaValidaNota3 = true;
                        }
                } while (!EntradaValidaNota3);

                // Para crear el objeto Estudiantes
                Estudiantes estudiante = new Estudiantes(); 
                estudiante.Codigo = Convert.ToInt32(codigo);
                estudiante.Nombre = nombre;
                estudiante.Correo = correo;
                estudiante.Nota1 = Convert.ToDouble(nota1) ;
                estudiante.Nota2 = Convert.ToDouble(nota2); 
                estudiante.Nota3 = Convert.ToDouble(nota3);


                // Para añadir todo
                ListaEstudiantes.Add(estudiante);
                Marcos.EscribirEn("El estudiante ha sido ingresado en el sistema.", 25, 18);
            }
            else
                Marcos.EscribirEn("El estudiante con el código " + codigo + " ya existe en el sistema.", 25, 8);

        }

        static void ListarNombres()
        {
            Console.Clear();
            Marcos.DibujarMarco(x_min, x_max, y_min, y_max);
            string header = String.Format("{0, 8} {1, 20} {2, 20}\n",
                              "Código", "Nombre", "Correo");
            Marcos.EscribirEn(header, 25, 2);

            int ii = 4;

            foreach (Estudiantes estudiante in ListaEstudiantes)
            {
                
                string header2 = String.Format($"{estudiante.Codigo, 8} {estudiante.Nombre, 20} {estudiante.Correo, 20}\n");
                Marcos.EscribirEn(header2, 25, ii);
                double nota1 = estudiante.Nota1;
                double nota2 = estudiante.Nota2;
                double nota3 = estudiante.Nota3;
                string mensaje = Aprobado(nota1, nota2, nota3);
                Marcos.EscribirEn("Este estudiante tiene la categoría de: " + mensaje, 25, ii + 1);
                ii += 3;
            }

            Console.ReadKey();

        }

        static void BuscarNombre()
        {
            string codigo;
            bool EntradaValidaCodigo = false;

            Console.Clear();
            Marcos.DibujarMarco(x_min, x_max, y_min, y_max);

            do
            {
                Marcos.EscribirEn("Digite el código del estudiante que desea buscar: ", 25, 5);
                codigo = Console.ReadLine();
                if (!Verificar.Vacio(codigo))
                    if (Verificar.TipoNumero(codigo))
                        EntradaValidaCodigo = true;
            } while (!EntradaValidaCodigo);

            if (Existe(Convert.ToInt32(codigo)))
            {
                Estudiantes estudiante = ObtenerDatos(Convert.ToInt32(codigo));

                string header = String.Format("{0, 8} {1, 20} {2, 20}\n",
                              "Código", "Nombre", "Correo");
                Marcos.EscribirEn(header, 25, 8);
                string header2 = String.Format($"{estudiante.Codigo, 8} {estudiante.Nombre, 20} {estudiante.Correo, 20}");
                Marcos.EscribirEn(header2, 25, 10);
                double nota1 = estudiante.Nota1;
                double nota2 = estudiante.Nota2;
                double nota3 = estudiante.Nota3;
                string mensaje = Aprobado(nota1, nota2, nota3);
                Marcos.EscribirEn("Este estudiante tiene la categoría de: " + mensaje, 25, 11);

            }
            else
            {
                Marcos.EscribirEn(" El estudiante con código " + codigo + " no existe.", 25, 7);
            }
        }

        static Estudiantes ObtenerDatos(int cod)
        {
            foreach (Estudiantes estudiante in ListaEstudiantes)
            {
                if (estudiante.Codigo == cod)
                    return estudiante;
            }
            return null;

        }


        static bool Existe(int cod)
        {
            bool aux = false;

            foreach (Estudiantes estudiante in ListaEstudiantes)
            {
                if (estudiante.Codigo == cod)
                    aux = true;
            }
            return aux;
        }

        static string Aprobado(double nota1, double nota2, double nota3)
        {
            double promedio;
            promedio = (nota1 + nota2 + nota3) / 3;
            if (promedio >= 3.5)
            {
                return "APROBADO";
            }
            else
            {
                return "REPROBADO";
            }

        }

        static void EscribirDatosXml()
        {
            Console.Clear();
            Marcos.DibujarMarco(x_min, x_max, y_min, y_max);
            XmlSerializer codificador = new XmlSerializer(typeof(List<Estudiantes>));
            TextWriter escribirXml = new StreamWriter("Archivo_estudiantes.xml");
            codificador.Serialize(escribirXml, ListaEstudiantes);
            escribirXml.Close();
            Marcos.EscribirEn("Archivo guardado con éxito.", 35, 17);
        }

        static void LeerDatosXml()
        {
            
            if (File.Exists("Archivo_estudiantes.xml"))
            {
                Console.Clear();
                Marcos.DibujarMarco(x_min, x_max, y_min, y_max);
                ListaEstudiantes.Clear();
                XmlSerializer codificador = new XmlSerializer(typeof(List<Estudiantes>));
                FileStream leerXml = File.OpenRead("Archivo_estudiantes.xml");
                ListaEstudiantes = (List<Estudiantes>) codificador.Deserialize(leerXml);
                leerXml.Close();
                Marcos.EscribirEn("Archivo cargado con éxito.", 35, 15);
            }
            else
            {
                Console.Clear();
                Marcos.DibujarMarco(x_min, x_max, y_min, y_max);
                Marcos.EscribirEn("No hay un archivo local para cargar datos de los estudiantes.", 25, 5);
            }
        }
        
    }
}
