using System;

namespace Torres_de_Hanoi
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("El Gran Juego de las Torres de Hanoi");
            Console.WriteLine("\n3 torres");

            Console.WriteLine("\nIndica el número de discos...");
            int n = int.Parse(Console.ReadLine());

            Console.WriteLine($"\nHas seleccionado {n} discos");

            Console.WriteLine("\nIndica I para Iterativo o R para Recursivo...");
            string metodo = Console.ReadLine().ToUpper();

            Hanoi juego = new Hanoi();

            Pila ini = new Pila();
            Pila aux = new Pila();
            Pila fin = new Pila();

            // Inicializar la torre inicial con discos
            for (int i = n; i >= 1; i--)
            {
                ini.push(new Disco(i));
            }

            Console.WriteLine("\nSituación inicial");
            Console.WriteLine($"Torre INI: {ini}");
            Console.WriteLine($"Torre AUX: {aux}");
            Console.WriteLine($"Torre FIN: {fin}");
            Console.WriteLine();

            int movimientos = 0;

            if (metodo == "I")
            {
                Console.WriteLine("\nHas seleccionado el método I");
                movimientos = juego.iterativo(n, ini, fin, aux);
            }
            else if (metodo == "R")
            {
                Console.WriteLine("\nHas seleccionado el método R");
                juego.recursivo(n, ini, fin, aux, "Torre INI", "Torre FIN", "Torre AUX");
                movimientos = juego.GetMovimientos();
            }
            else
            {
                Console.WriteLine("Opción no válida. Terminando el programa.");
                return;
            }

            Console.WriteLine($"\nResuelto en {movimientos} movimientos");
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}
