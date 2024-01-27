using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejemplo1
{
    internal class Pokemon
    {
        public int Numero { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

        // Creo el prop de la URL
        public string UrlImagen { get; set; }

        // Creo la prop de tipo Elemento que sería la descripción de la tabla ELEMENTOS
        public Elemento Tipo { get; set; }
        
        // Creo la prop de Debilidad de tipo Elemento 
        public Elemento Debilidad { get; set; }
    }
}
