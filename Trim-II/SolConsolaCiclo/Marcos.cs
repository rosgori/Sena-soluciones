using System;

namespace SolConsolaCiclo
{
    class Marcos
    {
        public static void DibujarMarco(int xmin, int xmax, int ymin, int ymax)
        {
            for (int x=xmin; x<= xmax; x++) {
                Console.SetCursorPosition(x, ymin); Console.Write("―");
                Console.SetCursorPosition(x, ymax); Console.Write("―");
            }

            for (int y = ymin; y <= ymax; y++)
            {
                Console.SetCursorPosition(xmin, y); Console.Write("|");
                Console.SetCursorPosition(xmax, y); Console.Write("|");
            }

            Console.SetCursorPosition(xmin, ymin); Console.Write("+");
            Console.SetCursorPosition(xmax, ymin); Console.Write("+");
            Console.SetCursorPosition(xmin, ymax); Console.Write("+");
            Console.SetCursorPosition(xmax, ymax); Console.Write("+");
        }

        public static void EscribirEn(string texto, int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(texto);
        }

        public static void BorrarLinea(int xmin, int y , int xmax)
        {
            for (int x = xmin; x <= xmax; x++)
            {
                Console.SetCursorPosition(x, y); 
                Console.Write(" ");
            }
        }
    }
}