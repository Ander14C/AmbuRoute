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
        string[] nombres_hospital = {"Hospital Central", "Hospital Norte", "Hospital Sur", "Clinica San Jose", "ESSALUD", "Hospital Regional"};

        // Nivel de cada hospital
        string[] niveles = {"III", "II", "II", "I", "III", "II"};

        // Constructor
        public Grafo()
        {
            Random r = new Random();

            for (int i = 0; i < nombres_hospital.Length; i++)//Aqui el length es para que el for se repita la cantidad de veces que hay hospitales(6)
            {
                Hospital h = new Hospital();

                h.nombre = nombres_hospital[i];
                h.nivel = niveles[i];
                h.capacidad = r.Next(80, 200);

                l_vertices.Insertar(h);
            }

            ma = new int[nombres_hospital.Length, nombres_hospital.Length];//El length es para que la matriz se cree con el tamaño de la cantidad de hospitales que hay(6)
        }

        // Devuelve la cantidad de hospitales
        public int CantidadHospitales()
        {
            return nombres_hospital.Length;
        }

        // Mostrar hospitales registrados
        public void MostrarHospitales()
        {
            Console.WriteLine("INFORMACION DE HOSPITALES:");
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
                    if (i == j) //Hace que los hospitales no puedan conectarse consigo mismos, es decir, que no se pueda ir de un hospital a si mismo
                    {
                        ma[i, j] = 0;
                    }
                    else if (j > i)//Hace que la matriz sea simétrica, es decir, que si hay una ruta de un hospital a otro, también haya una ruta de ese hospital al primero
                    {
                        int existe = r.Next(0, 2);//Genera aleatoriamente si habra o no una conexion entre los hospitales, siendo 0 que no habra conexion y 1 que si habra conexion

                        if (existe == 1)//Verifica si se creo una conexion entre los hospitales, si es asi, genera un tiempo aleatorio entre 5 y 30 minutos para la ruta
                        {
                            int tiempo = r.Next(5, 31);

                            ma[i, j] = tiempo;
                            ma[j, i] = tiempo;
                        }
                        else//Si no se creo una conexion entre los hospitales, asigna un valor de 0 a la matriz, indicando que no hay conexion entre esos hospitales
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
            for (int i = 0; i < CantidadHospitales(); i++)//Muestra la parte de arriba de la matriz que seria: H1, H2, H3 etc
            {
                Console.Write("H" + (i + 1) + "\t");
            }
            Console.WriteLine();

            for (int i = 0; i < CantidadHospitales(); i++)//Recorre cada fila de la matriz 
            {
                Console.Write("H" + (i + 1) + "\t");//Muestra el nombre del hospital(H1, H2, H3 etc) al inicio de cada fila
                for (int j = 0; j < CantidadHospitales(); j++)//Recorre todas las columna.
                {
                    Console.Write(ma[i, j] + "\t");//Muestra el valor almacenado en la matriz, por ejemplo si ma[0,2] = 5 imprime 5
                }
                Console.WriteLine();
            }

            Console.WriteLine();
            Console.WriteLine("Referencia:");

            for (int i = 0; i < nombres_hospital.Length; i++)//Recorre todos los hospitales para mostrar su nombre
            {
                Console.WriteLine("H" + (i + 1) + " -> " + nombres_hospital[i]);//Relaciona el codigo del hospital(H1, H2, H3 etc) con su nombre completo
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
                    if (ma[i, j] > 0)//Lo que hace es verificar si hay una conexion entre el hospital de origen y destino
                    {
                        origen.ls.Insertar(destino, ma[i, j]);//Agrega la conexión del hospital de origen hacia el hospital de destino con su tiempo correspondiente.
                    }
                    destino = destino.sig;
                }
                origen = origen.sig;
            }
        }

        // Algoritmo de Dijkstra
        public void Dijkstra(int origen, int destino)
        {

            int n = CantidadHospitales(); // Guarda la cantidad de hospitales

            int[] distancia = new int[n]; // Almacena la distancia mínima hacia cada hospital
            bool[] visitado = new bool[n]; // Indica si un hospital ya fue visitado
            int[] anterior = new int[n]; // Guarda el hospital anterior de la ruta

            // Inicializar los arreglos
            for (int i = 0; i < n; i++)
            {
                distancia[i] = int.MaxValue; // Todas las distancias empiezan en "infinito"
                visitado[i] = false; // Ningún hospital ha sido visitado
                anterior[i] = -1; // Aún no existe un hospital anterior
            }

            distancia[origen] = 0; // El hospital de origen tiene distancia 0

            // Algoritmo principal
            for (int i = 0; i < n - 1; i++)
            {
                int menor = int.MaxValue; // Guarda la menor distancia encontrada
                int u = -1; // Guarda el índice del hospital más cercano

                // Buscar el hospital no visitado con menor distancia
                for (int j = 0; j < n; j++)
                {
                    if (!visitado[j] && distancia[j] < menor)
                    {
                        menor = distancia[j]; // Actualiza la menor distancia
                        u = j; // Guarda el hospital correspondiente
                    }
                }

                // Si no existen más caminos posibles, termina el algoritmo
                if (u == -1)
                    break;

                visitado[u] = true; // Marca el hospital como visitado

                // Revisar los hospitales vecinos
                for (int v = 0; v < n; v++)
                {
                    // Verifica si existe una ruta más corta
                    if (!visitado[v] &&
                        ma[u, v] > 0 &&
                        distancia[u] != int.MaxValue &&
                        distancia[u] + ma[u, v] < distancia[v])
                    {
                        distancia[v] = distancia[u] + ma[u, v]; // Actualiza la distancia mínima
                        anterior[v] = u; // Guarda el hospital anterior de la ruta
                    }
                }
            }
        }
        // Mostrar la ruta óptima utilizando recursividad
        private void MostrarRuta(int[] anterior, int destino)
        {
            // Si no existe un hospital anterior, significa que es el inicio de la ruta
    if (anterior[destino] == -1)
    {
        Console.ForegroundColor = ConsoleColor.Green; // Cambia el color del texto
        Console.WriteLine(nombres_hospital[destino]); // Muestra el hospital
        Console.ResetColor(); // Restaura el color original
        return; // Finaliza la llamada recursiva
    }

    // Llama al método para mostrar primero los hospitales anteriores
    MostrarRuta(anterior, anterior[destino]);

    Console.WriteLine("   | "); // Dibuja la línea de la ruta
    Console.WriteLine("   V "); // Dibuja la flecha hacia el siguiente hospital

    Console.ForegroundColor = ConsoleColor.Green; // Cambia el color del texto
    Console.WriteLine(nombres_hospital[destino]); // Muestra el hospital actual
    Console.ResetColor(); // Restaura el color original
        }
    }
}
