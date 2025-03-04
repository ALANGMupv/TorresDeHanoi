using System;

namespace Torres_de_Hanoi
{
    class Hanoi
    {
        // Método para mover un disco entre dos pilas respetando las reglas
        public void mover_disco(Pila a, Pila b)
        {
            if (a.isEmpty() && b.isEmpty()) return;

            if (a.isEmpty())
            {
                a.push(b.pop());
                Console.WriteLine("Moviendo disco de B a A");
            }
            else if (b.isEmpty())
            {
                b.push(a.pop());
                Console.WriteLine("Moviendo disco de A a B");
            }
            else
            {
                // Comparación directa de `int`, ya que `Disco.Valor` es int
                if (a.Top < b.Top)
                {
                    b.push(a.pop());
                    Console.WriteLine("Moviendo disco de A a B");
                }
                else
                {
                    a.push(b.pop());
                    Console.WriteLine("Moviendo disco de B a A");
                }
            }
        }

        // Método iterativo para resolver el problema de las Torres de Hanoi
        public int iterativo(int n, Pila ini, Pila fin, Pila aux)
        {
            int movimientos = 0;

            if (n % 2 != 0) // Si n es impar
            {
                while (fin.Size != n) // Repite hasta llegar a la solución
                {
                    mover_disco(ini, fin);
                    movimientos++;

                    if (fin.Size == n) break;

                    mover_disco(ini, aux);
                    movimientos++;

                    if (fin.Size == n) break;

                    mover_disco(aux, fin);
                    movimientos++;
                }
            }
            else // Si n es par
            {
                while (fin.Size != n)
                {
                    mover_disco(ini, aux);
                    movimientos++;

                    if (fin.Size == n) break;

                    mover_disco(ini, fin);
                    movimientos++;

                    if (fin.Size == n) break;

                    mover_disco(aux, fin);
                    movimientos++;
                }
            }

            return movimientos;
        }
    }
}
