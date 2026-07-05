using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases
{
    public class ListaAristas
    {
        public Arista primero = null;

        // Insertar una nueva ruta hacia otro hospital
        public void Insertar(Vertice destino, float peso)
        {
            Arista nuevo = new Arista();

            nuevo.destino = destino;
            nuevo.peso = peso;

            if (primero == null)
            {
                primero = nuevo;
            }
            else
            {
                Arista temp = primero;

                while (temp.sig != null)
                {
                    temp = temp.sig;
                }

                temp.sig = nuevo;
            }
        }

        // Mostrar todas las rutas disponibles
        public void Mostrar()
        {
            if (primero == null)
            {
                Console.WriteLine("No existen rutas.");
                return;
            }

            Arista temp = primero;
            int i = 1;

            while (temp != null)
            {
                Console.WriteLine(i + ". " +
                                  temp.destino.dato.nombre +
                                  " - Tiempo: " +
                                  temp.peso +
                                  " minutos");

                temp = temp.sig;
                i++;
            }
        }
    }
}
