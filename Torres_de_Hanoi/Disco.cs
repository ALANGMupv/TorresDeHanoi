using System;

namespace Torres_de_Hanoi
{
    class Disco
    {
        public int Valor { get; private set; } // Cambiar de `string` a `int`

        public Disco(int valor) // Ahora recibe `int` en lugar de `string`
        {
            if (valor <= 0)
            {
                throw new ArgumentException("El valor del disco debe ser un número entero positivo.");
            }
            Valor = valor;
        }

        public override string ToString()
        {
            return $"Disco: {Valor}";
        }
    }
}
