using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Cola cola = new Cola();

            // Ejemplo de encolar valores
            cola.Encolar(10);
            cola.Encolar(20);
            cola.Encolar(30);

            Console.WriteLine("Elementos en la cola:");
            cola.MostrarCola();

            // Ejemplo de desencolar un valor
            Console.WriteLine("\nDesencolando un elemento...");
            int valorDesencolado = cola.Desencolar();
            Console.WriteLine($"Elemento desencolado: {valorDesencolado}");

            Console.WriteLine("\nElementos restantes en la cola:");
            cola.MostrarCola();

            // Verificación de cola vacía
            Console.WriteLine("\n¿La cola está vacía? " + cola.EstaVacia());
        }
    }

