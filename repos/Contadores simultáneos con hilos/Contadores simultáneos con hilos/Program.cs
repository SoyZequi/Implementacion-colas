using System;
using System.Collections.Generic;
using System.Threading;

class Program
{
    static Dictionary<int, Counter> counters = new Dictionary<int, Counter>();
    static bool exitRequested = false;

    static void Main(string[] args)
    {
        while (!exitRequested)
        {
            Console.Clear();
            Console.WriteLine("Menu:");
            Console.WriteLine("1. Iniciar un nuevo contador");
            Console.WriteLine("2. Detener un contador");
            Console.WriteLine("3. Mostrar estado de los contadores");
            Console.WriteLine("4. Salir");
            Console.Write("Selecciona una opción: ");
            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    StartNewCounter();
                    break;
                case "2":
                    StopCounter();
                    break;
                case "3":
                    ShowCountersStatus();
                    break;
                case "4":
                    exitRequested = true;
                    StopAllCounters();
                    break;
                default:
                    Console.WriteLine("Opción no válida. Intenta de nuevo.");
                    break;
            }
        }
    }

    static void StartNewCounter()
    {
        Console.Write("Introduce el intervalo de tiempo en milisegundos para el contador: ");
        if (int.TryParse(Console.ReadLine(), out int interval))
        {
            var counter = new Counter(interval);
            counters.Add(counter.Id, counter);
            counter.Start();
            Console.WriteLine($"Contador {counter.Id} iniciado con un intervalo de {interval} ms.");
        }
        else
        {
            Console.WriteLine("Intervalo inválido.");
        }
        Thread.Sleep(1000);
    }

    static void StopCounter()
    {
        Console.Write("Introduce el ID del contador a detener: ");
        if (int.TryParse(Console.ReadLine(), out int id) && counters.ContainsKey(id))
        {
            counters[id].Stop();
            counters.Remove(id);
            Console.WriteLine($"Contador {id} detenido.");
        }
        else
        {
            Console.WriteLine("ID de contador inválido.");
        }
        Thread.Sleep(1000);
    }

    static void ShowCountersStatus()
    {
        Console.WriteLine("Estado actual de los contadores:");
        foreach (var counter in counters.Values)
        {
            Console.WriteLine($"Contador {counter.Id}: Valor = {counter.Value}");
        }
        Console.WriteLine("Presiona cualquier tecla para continuar...");
        Console.ReadKey();
    }

    static void StopAllCounters()
    {
        foreach (var counter in counters.Values)
        {
            counter.Stop();
        }
        counters.Clear();
        Console.WriteLine("Todos los contadores se han detenido.");
    }
}

class Counter
{
    private static int _globalId = 1;
    private Thread? _thread = null; // Permitir que sea NULL inicialmente
    private int _interval;
    private bool _running;

    public int Id { get; }
    public int Value { get; private set; }

    public Counter(int interval)
    {
        Id = _globalId++;
        _interval = interval;
        _running = false;

    }

    public void Start()
    {
        _running = true;
        _thread = new Thread(Run);
        _thread.Start();
    }

    public void Stop()
    {
        _running = false;
        if (_thread != null && _thread.IsAlive)
        {
            _thread.Join(); // Espera a que el hilo termine de forma segura
        }
    }

    private void Run()
    {
        while (_running)
        {
            Value++;
            Console.WriteLine($"Contador {Id}: {Value}");
            Thread.Sleep(_interval);
        }
    }
}
