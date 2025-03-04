using System;
using System.Collections.Generic;

namespace Torres_de_Hanoi
{
    class Pila
    {
        // Inicializa los atributos
        public int Size { get; private set; } // Representa la cantidad de discos en la pila
        public int? Top { get; private set; } // `int?` permite valores nulos si está vacía
        public List<Disco> Elementos { get; private set; } // Lista para almacenar los discos

        public Pila()
        {
            // Constructor
            Elementos = new List<Disco>();
            Size = 0;
            Top = null;
        }

        public void push(Disco d)
        {
            Elementos.Add(d);
            Top = d.Valor; 
            Size++;
        }

        public Disco pop()
        {
            if (isEmpty())
            {
                return null;
            }

            Disco discoExtraido = Elementos[Size - 1];
            Elementos.RemoveAt(Size - 1);
            Size--;

            // Actualizamos Top 
            if (Size > 0)
            {
                Top = Elementos[Size - 1].Valor;
            }
            else
            {
                Top = null;
            }

            return discoExtraido;
        }

        public bool isEmpty()
        {
            if (Size == 0)
            {
                return true;
            }
            return false;
        }

        // Para mostrar los discos de la pila, ejemplo: Torre INI: 3, 2, 1
        public override string ToString()
        {
            if (Elementos.Count == 0)
                return "(vacía)";

            return string.Join(", ", Elementos.ConvertAll(d => d.Valor.ToString()));
        }

    }
}
