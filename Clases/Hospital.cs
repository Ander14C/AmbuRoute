using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases
{
    public class Hospital
    {
        public string nombre;
        public string nivel;
        public int capacidad;

        public override string ToString()
        {
            return $"{nombre} (Nivel: {nivel} - Capacidad: {capacidad} camas)";
        }
    }
}
