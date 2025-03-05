using System;

namespace Torres_de_Hanoi
{
    class Hanoi
    {
        private int movimientos;

        public Hanoi()
        {
            movimientos = 0; // Contador global ya que sino lo hiciéramos en cada llamada de recursividad volvería a 0 y no es el comportamiento que deseamos.
        }

        public void mover_disco(Pila a, Pila b, Pila ini, Pila aux, Pila fin, string nombreA, string nombreB)
        {
            if (a.isEmpty() && b.isEmpty()) return;

            if (a.isEmpty())
            {
                a.push(b.pop());
            }
            else if (b.isEmpty())
            {
                b.push(a.pop());
            }
            else
            {
                if (a.Top < b.Top)
                {
                    b.push(a.pop());
                }
                else
                {
                    a.push(b.pop());
                }
            }

            // Contador de movimientos
            movimientos++;

            // 🔹 Mostrar estado actual de las tres torres después de cada movimiento
            Console.WriteLine($"Situación tras el movimiento {movimientos}");
            Console.WriteLine($"Torre INI: {ini}");
            Console.WriteLine($"Torre AUX: {aux}");
            Console.WriteLine($"Torre FIN: {fin}");
            Console.WriteLine();
        }

        public int iterativo(int n, Pila ini, Pila fin, Pila aux)
        {
            movimientos = 0;  // Reiniciar el contador de movimientos

            if (n % 2 != 0) // Si n es impar
            {
                while (fin.Size != n)
                {
                    mover_disco(ini, fin, ini, aux, fin, "Torre INI", "Torre FIN");
                    if (fin.Size == n) break;

                    mover_disco(ini, aux, ini, aux, fin, "Torre INI", "Torre AUX");
                    if (fin.Size == n) break;

                    mover_disco(aux, fin, ini, aux, fin, "Torre AUX", "Torre FIN");
                }
            }
            else // Si n es par
            {
                while (fin.Size != n)
                {
                    mover_disco(ini, aux, ini, aux, fin, "Torre INI", "Torre AUX");
                    if (fin.Size == n) break;

                    mover_disco(ini, fin, ini, aux, fin, "Torre INI", "Torre FIN");
                    if (fin.Size == n) break;

                    mover_disco(aux, fin, ini, aux, fin, "Torre AUX", "Torre FIN");
                }
            }

            return movimientos;
        }

        // Método recursivo 
        public void recursivo(int n, Pila ini, Pila fin, Pila aux, string nombreIni, string nombreFin, string nombreAux) // 1.- Ejemplo: llamo con n = 2
        {
            if (n == 1) // Paso 2 (CASO BASE: Si solo hay un disco, lo movemos directamente.)
            {
                Disco d = ini.pop();
                fin.push(d);
                movimientos++;
                Console.WriteLine($"Situación tras el movimiento {movimientos}");
                Console.WriteLine($"Torre INI: {ini}");
                Console.WriteLine($"Torre AUX: {aux}");
                Console.WriteLine($"Torre FIN: {fin}");
                Console.WriteLine();
            }
            else
            {
                recursivo(n - 1, ini, aux, fin, nombreIni, nombreAux, nombreFin); // 2.- Se ecuentra aqui ya que n>1, al llamar a n-1 y ser n=1 (2-1), entra en el bloque del if

                // Mover disco más grande
                Disco d = ini.pop(); // 3.- Al salir del bloque del if, sigue con n=2 y ahora ejecuta estas lineas
                fin.push(d);
                movimientos++;
                Console.WriteLine($"Situación tras el movimiento {movimientos}");
                Console.WriteLine($"Torre INI: {ini}");
                Console.WriteLine($"Torre AUX: {aux}");
                Console.WriteLine($"Torre FIN: {fin}");
                Console.WriteLine();

                recursivo(n - 1, aux, fin, ini, nombreAux, nombreFin, nombreIni); // 4.- Y por último vuelve a ser n=1 y ejecuta esta linea, vuelve al caso base
            }
        }

        // Si por ejemplo fuera n=3 sería bastante similar ya que volvería a llamar a n=2, n=4 volvería a llamar a n=3 y a su vez a n=2. Y asi sucesivamente....

        public int GetMovimientos()
        {
            return movimientos;
        }
    }
}
