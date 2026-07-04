using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases
{
    public class Arista
    {
        // Hospital destino
        public Vertice destino;

        // Tiempo de recorrido (peso)
        public float peso;

        // Siguiente arista de la lista
        public Arista sig = null;
    }
}
