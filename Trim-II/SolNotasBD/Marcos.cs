using System;

namespace SolNotasBD
{
    public class Marcos
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

        public static void BorrarLinea(int xmin, int xmax, int y)
        {
            for (int x = xmin; x <= xmax; x++)
            {
                Console.SetCursorPosition(x, y); 
                Console.Write(" ");
            }
        }

        public static void LogoMensaje()
        {
            EscribirEn(@"  ______   ________  __    __   ______  ", 5, 20);
            EscribirEn(@" /      \ /        |/  \  /  | /      \ ", 5, 21);
            EscribirEn(@"/$$$$$$  |$$$$$$$$/ $$  \ $$ |/$$$$$$  |", 5, 22);
            EscribirEn(@"$$ \__$$/ $$ |__    $$$  \$$ |$$ |__$$ |", 5, 23);
            EscribirEn(@"$$      \ $$    |   $$$$  $$ |$$    $$ |", 5, 24);
            EscribirEn(@" $$$$$$  |$$$$$/    $$ $$ $$ |$$$$$$$$ |", 5, 25);
            EscribirEn(@"/  \__$$ |$$ |_____ $$ |$$$$ |$$ |  $$ |", 5, 26);
            EscribirEn(@"$$    $$/ $$       |$$ | $$$ |$$ |  $$ |", 5, 27);
            EscribirEn(@" $$$$$$/  $$$$$$$$/ $$/   $$/ $$/   $$/ ", 5, 28);

            Marcos.EscribirEn("Centro de Mercados, Logística y Tecnologías de la Información", 5, 30);
            Marcos.EscribirEn("BIENVENIDO", 50, 10);

        }


    }
}