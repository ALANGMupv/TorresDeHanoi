using System;

namespace Torres_de_Hanoi
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("El Gran Juego de las Torres de Hanoi\n");

            // Definir número de discos
            Console.Write("Indica el número de discos... ");
            int n;
            while (!int.TryParse(Console.ReadLine(), out n) || n <= 0)
            {
                Console.Write("Por favor, introduce un número entero positivo: ");
            }

            Console.WriteLine($"\nHas seleccionado {n} discos\n");

            // Inicialización de las pilas
            Pila ini = new Pila();
            Pila aux = new Pila();
            Pila fin = new Pila();

            // Agregar los discos en orden decreciente al palo INI
            for (int i = n; i >= 1; i--)
            {
                ini.push(new Disco(i));
            }

            // Mostrar estado inicial
            Console.WriteLine("Situación inicial");
            MostrarEstado(ini, aux, fin);

            // Resolver con el método iterativo
            Hanoi hanoi = new Hanoi();
            int movimientos = hanoi.iterativo(n, ini, fin, aux);

            // Mostrar número total de movimientos
            Console.WriteLine($"\nResuelto en {movimientos} movimientos");

            // Mantener la consola abierta hasta que el usuario presione una tecla
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }

        // Método para mostrar el estado de las pilas en consola
        static void MostrarEstado(Pila ini, Pila aux, Pila fin)
        {
            Console.WriteLine("Torre INI: " + ini);
            Console.WriteLine("Torre AUX: " + aux);
            Console.WriteLine("Torre FIN: " + fin);
            Console.WriteLine();
        }
    }
}
