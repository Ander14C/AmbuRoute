using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clases;

namespace AmbuRoute
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Grafo g = new Grafo();

            // Crear el grafo
            g.GenerarMatriz();
            g.CrearGrafo();

            Console.Title = "Sistema de Optimización de Rutas para Ambulancias";

            Console.WriteLine("==============================================");
            Console.WriteLine(" SISTEMA DE OPTIMIZACIÓN DE RUTAS");
            Console.WriteLine("          PARA AMBULANCIAS");
            Console.WriteLine("==============================================");

            // Mostrar hospitales
            g.MostrarHospitales();

            // Mostrar matriz
            g.MostrarMatriz();

            Console.WriteLine();

            Console.Write("Seleccione hospital origen (1-6): ");
            int origen = int.Parse(Console.ReadLine());

            Console.Write("Seleccione hospital destino (1-6): ");
            int destino = int.Parse(Console.ReadLine());

            // Convertir a índices
            origen--;
            destino--;

            Console.Clear();

            Console.WriteLine("==============================================");
            Console.WriteLine("      RESULTADO DEL ALGORITMO DIJKSTRA");
            Console.WriteLine("==============================================");

            g.Dijkstra(origen, destino);

            Console.WriteLine();
            Console.WriteLine("Presione una tecla para salir...");
            Console.ReadKey();
        }
    }
}
