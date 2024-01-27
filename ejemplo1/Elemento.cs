using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejemplo1
{
    internal class Elemento
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }

        // Hago un override del ToString para que no me muestre el namespace y el nombre de la clase
        public override string ToString()
        {
            return Descripcion;
        }
    }
}
