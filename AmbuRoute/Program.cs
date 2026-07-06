using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

            int opcion;
            do
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("====================================================");
                Console.WriteLine("   SISTEMA DE OPTIMIZACIÓN DE RUTAS PARA AMBULANCIAS");
                Console.WriteLine("====================================================");
                Console.WriteLine("1. Información de hospitales registrados");
                Console.WriteLine("2. Mostrar matriz de adyacencia");
                Console.WriteLine("3. Calcular ruta óptima");
                Console.WriteLine("0. Salir");
                Console.WriteLine("====================================================");
                Console.Write("Seleccione una opción: ");
                opcion = int.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("========== HOSPITALES REGISTRADOS ==========\n");
                        g.MostrarHospitales();
                        break;

                    case 2:
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("==========================================");
                        Console.WriteLine("        MATRIZ DE ADYACENCIA");
                        Console.WriteLine("==========================================");

                        Console.Write("\t");
                        g.MostrarMatriz();
                        break;

                    case 3:
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("========== CALCULAR RUTA ÓPTIMA ==========\n");

                        g.MostrarHospitales();

                        Console.Write("\nSeleccione hospital origen (1-6): ");
                        int origen = int.Parse(Console.ReadLine());

                        Console.Write("Seleccione hospital destino (1-6): ");
                        int destino = int.Parse(Console.ReadLine());

                        Thread.Sleep(500);
                        if (origen < 1 || origen > 6 || destino < 1 || destino > 6)
                        {
                            Console.WriteLine("\nHospital no válido.");
                        }
                        else
                        {
                            origen--;
                            destino--;

                            Console.Clear();
                            Console.WriteLine("========== RESULTADO ==========");

                            g.Dijkstra(origen, destino);
                        }

                        break;

                    case 0:
                        Console.WriteLine("\nGracias por utilizar el sistema.");
                        break;

                    default:
                        Console.WriteLine("\nOpción no válida.");
                        break;
                }

                if (opcion != 0)
                {
                    Console.WriteLine("\nPresione una tecla para volver al menú...");
                    Console.ReadKey();
                }

            } while (opcion != 4);
        }
    }
}
