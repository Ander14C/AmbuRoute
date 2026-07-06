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

        // Inserta un hospital en la lista
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

        // Muestra todos los hospitales
        public void Mostrar()
        {
            Vertice temp = primero;
            //Declara la variable llamada i y la inicializa en 1.
            int i = 1;

            while (temp != null)
            {
                Console.WriteLine(i + ". " + temp.dato); //Lo que hace aqui es agregarle el numero de hospital a la informacion del hospital

                temp = temp.sig;
                i++; //Aqui incrementa el valor de i en 1 para que el siguiente hospital tenga un numero mayor(todo eso se aplica en la opcion 1)
            }
        }
    }
}
