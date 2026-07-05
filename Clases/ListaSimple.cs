using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases
{
    public class ListaSimple
    {
        public Vertice primero = null;

        // Insertar un hospital en la lista
        public void Insertar(Hospital d)
        {
            Vertice nuevo = new Vertice();
            nuevo.dato = d;

            if (primero == null)
            {
                primero = nuevo;
            }
            else
            {
                Vertice temp = primero;

                while (temp.sig != null)
                {
                    temp = temp.sig;
                }

                temp.sig = nuevo;
            }
        }

        // Mostrar todos los hospitales
        public void Mostrar()
        {
            Vertice temp = primero;
            int i = 1;

            while (temp != null)
            {
                Console.WriteLine(i + ". " + temp.dato);

                temp = temp.sig;
                i++;
            }
        }
    }
}
