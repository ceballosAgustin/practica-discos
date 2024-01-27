using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;

namespace practica_discos
{
    internal class DiscosNegocio
    {
        public List<Discos> listar() 
        {
            List<Discos> lista = new List<Discos>();

            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;

            try
            {
                conexion.ConnectionString = "server=. \\SQLEXPRESS; database=DISCOS_DB; integrated security=true";

                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "select D.Titulo, D.FechaLanzamiento, D.CantidadCanciones, D.UrlImagenTapa, E.Descripcion as Estilo, T.Descripcion as TipoEdicion from DISCOS D, ESTILOS E, TIPOSEDICION T where E.Id = D.IdEstilo And T.Id = D.IdTipoEdicion";
                comando.Connection = conexion;

                conexion.Open();
                lector = comando.ExecuteReader();

                while(lector.Read())
                {
                    Discos aux = new Discos();

                    aux.Titulo = (string)lector["Titulo"];
                    aux.FechaLanzamiento = (DateTime)lector["FechaLanzamiento"];
                    aux.CantidadCanciones = (int)lector["CantidadCanciones"];
                    aux.UrlImagenTapa = (string)lector["UrlImagenTapa"];

                    aux.IdEstilo = new Estilos();
                    aux.IdEstilo.Descripcion = (string)lector["Estilo"];

                    aux.IdTipoEdicion = new TiposEdicion();
                    aux.IdTipoEdicion.Descripcion = (string)lector["TipoEdicion"];

                    lista.Add(aux);

                }

                conexion.Close();

                return lista;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
