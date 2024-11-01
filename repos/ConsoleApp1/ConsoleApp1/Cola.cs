using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Cola
    {
        private Nodo frente;
        private Nodo final;

        public Cola()
        {
            frente = null;
            final = null;
        }

        // Método para encolar (agregar al final)
        public void Encolar(int valor)
        {
            Nodo nuevoNodo = new Nodo(valor);
            if (final == null)
            {
                frente = nuevoNodo;
                final = nuevoNodo;
            }
            else
            {
                final.Siguiente = nuevoNodo;
                final = nuevoNodo;
            }
        }

        // Método para desencolar (remover del frente)
        public int Desencolar()
        {
            if (frente == null)
            {
                throw new InvalidOperationException("La cola está vacía.");
            }

            int valor = frente.Valor;
            frente = frente.Siguiente;

            if (frente == null)
            {
                final = null;
            }

            return valor;
        }

        // Método para mostrar los elementos de la cola
        public void MostrarCola()
        {
            Nodo actual = frente;
            while (actual != null)
            {
                Console.WriteLine(actual.Valor);
                actual = actual.Siguiente;
            }
        }

        // Método para verificar si la cola está vacía
        public bool EstaVacia()
        {
            return frente == null;
        }
    }

