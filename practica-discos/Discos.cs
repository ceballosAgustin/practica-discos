using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practica_discos
{
    internal class Discos
    {
        public string Titulo { get; set; }
        public DateTime FechaLanzamiento { get; set; }
        public int CantidadCanciones { get; set; }
        public string UrlImagenTapa { get; set; }

        public Estilos IdEstilo { get; set; }
        public TiposEdicion IdTipoEdicion { get; set; }
    }
}
