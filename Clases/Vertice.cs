using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases
{
    public class Vertice
    {
        // Información del hospital
        public Hospital dato;

        // Siguiente vértice de la lista
        public Vertice sig = null;

        // Lista de rutas hacia otros hospitales
        public ListaAristas ls = new ListaAristas();
    }
}
