using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases
{
    public class Grafo
    {
        ListaSimple l_vertices = new ListaSimple();

        // Matriz de adyacencia con pesos (tiempo en minutos)
        int[,] ma;

        // Hospitales fijos
        string[] nombres =
        {
        "Hospital Central",
        "Hospital Norte",
        "Hospital Sur",
        "Clinica San Jose",
        "ESSALUD",
        "Hospital Regional"
    };

        // Nivel de cada hospital
        string[] niveles =
        {
        "III",
        "II",
        "II",
        "I",
        "III",
        "II"
    };

        // Constructor
        public Grafo()
        {
            Random r = new Random();

            for (int i = 0; i < nombres.Length; i++)
            {
                Hospital h = new Hospital();

                h.nombre = nombres[i];
                h.nivel = niveles[i];
                h.capacidad = r.Next(80, 251);

                l_vertices.Insertar(h);
            }

            ma = new int[nombres.Length, nombres.Length];
        }

        // Devuelve la cantidad de hospitales
        public int CantidadHospitales()
        {
            return nombres.Length;
        }

        // Mostrar hospitales registrados
        public void MostrarHospitales()
        {
            //Console.WriteLine("\n==========================================");
            Console.WriteLine("      HOSPITALES REGISTRADOS");
            Console.WriteLine("==========================================\n");

            l_vertices.Mostrar();
        }

        // Generar matriz de adyacencia con pesos
        public void GenerarMatriz()
        {
            Random r = new Random();

            for (int i = 0; i < ma.GetLength(0); i++)
            {
                for (int j = 0; j < ma.GetLength(1); j++)
                {
                    if (i == j)
                    {
                        ma[i, j] = 0;
                    }
                    else if (j > i)
                    {
                        int existe = r.Next(0, 2);

                        if (existe == 1)
                        {
                            int tiempo = r.Next(5, 31);

                            ma[i, j] = tiempo;
                            ma[j, i] = tiempo;
                        }
                        else
                        {
                            ma[i, j] = 0;
                            ma[j, i] = 0;
                        }
                    }
                }
            }
        }

        // Mostrar la matriz
        public void MostrarMatriz()
        {
            Console.WriteLine("\n==========================================");
            Console.WriteLine("        MATRIZ DE ADYACENCIA");
            Console.WriteLine("==========================================\n");

            Console.Write("\t");

            for (int i = 0; i < CantidadHospitales(); i++)
            {
                Console.Write("H" + (i + 1) + "\t");
            }

            Console.WriteLine();

            for (int i = 0; i < CantidadHospitales(); i++)
            {
                Console.Write("H" + (i + 1) + "\t");

                for (int j = 0; j < CantidadHospitales(); j++)
                {
                    Console.Write(ma[i, j] + "\t");
                }

                Console.WriteLine();
            }

            Console.WriteLine();

            Console.WriteLine("Referencia:");

            for (int i = 0; i < nombres.Length; i++)
            {
                Console.WriteLine("H" + (i + 1) + " -> " + nombres[i]);
            }
        }

        // Crear el grafo usando la matriz
        public void CrearGrafo()
        {
            Vertice origen = l_vertices.primero;

            for (int i = 0; i < CantidadHospitales(); i++)
            {
                Vertice destino = l_vertices.primero;

                for (int j = 0; j < CantidadHospitales(); j++)
                {
                    if (ma[i, j] > 0)
                    {
                        origen.ls.Insertar(destino, ma[i, j]);
                    }

                    destino = destino.sig;
                }

                origen = origen.sig;
            }
        }

        // Algoritmo de Dijkstra
        public void Dijkstra(int origen, int destino)
        {
            int n = CantidadHospitales();

            int[] distancia = new int[n];
            bool[] visitado = new bool[n];
            int[] anterior = new int[n];

            // Inicializar
            for (int i = 0; i < n; i++)
            {
                distancia[i] = int.MaxValue;
                visitado[i] = false;
                anterior[i] = -1;
            }

            distancia[origen] = 0;

            // Algoritmo principal
            for (int i = 0; i < n - 1; i++)
            {
                int menor = int.MaxValue;
                int u = -1;

                // Buscar el vértice con menor distancia
                for (int j = 0; j < n; j++)
                {
                    if (!visitado[j] && distancia[j] < menor)
                    {
                        menor = distancia[j];
                        u = j;
                    }
                }

                // Si no hay más caminos posibles
                if (u == -1)
                    break;

                visitado[u] = true;

                // Actualizar las distancias
                for (int v = 0; v < n; v++)
                {
                    if (!visitado[v] &&
                        ma[u, v] > 0 &&
                        distancia[u] != int.MaxValue &&
                        distancia[u] + ma[u, v] < distancia[v])
                    {
                        distancia[v] = distancia[u] + ma[u, v];
                        anterior[v] = u;
                    }
                }
            }

            // Verificar si existe ruta
            if (distancia[destino] == int.MaxValue)
            {
                Console.WriteLine("\nNo existe una ruta entre esos hospitales.");
                return;
            }

            Console.WriteLine("\n==========================================");
            Console.WriteLine("          RUTA ÓPTIMA");
            Console.WriteLine("==========================================");

            MostrarRuta(anterior, destino);

            Console.WriteLine("\nTiempo total: " + distancia[destino] + " minutos");
        }
        // Mostrar la ruta óptima utilizando recursividad
        private void MostrarRuta(int[] anterior, int destino)
        {
            if (anterior[destino] == -1)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(nombres[destino]);
                Console.ResetColor();
                return;
            }

            MostrarRuta(anterior, anterior[destino]);

            Console.WriteLine("   ↓");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(nombres[destino]);
            Console.ResetColor();
        }
    }
}
