using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Librería para establecer conexión con DB
using System.Data.SqlClient;

namespace ejemplo1
{
    internal class PokemonNegocio
    {
        public List<Pokemon> listar()
        {
            List<Pokemon> lista = new List<Pokemon>();

            // Para establecer conexión
            SqlConnection conexion = new SqlConnection();
            // Para realizar acciones
            SqlCommand comando = new SqlCommand();
            // Para lectura con DB
            SqlDataReader lector;

            try
            {
                // Así me conecto a la base de datos
                // Primero pongo el server (nombre del principio),
                // después el nombre de la DB y por ultimo como me conecto (así es de manera local, hay por autentication)
                conexion.ConnectionString = "server=.\\SQLEXPRESS; database=POKEDEX_DB; integrated security=true";

                // Elijo el tipo de comando, va a ser de texto
                comando.CommandType = System.Data.CommandType.Text;
                // Al comando de texto le envío la consulta que primero debo hacer en SQL
                comando.CommandText = "Select Numero, Nombre, P.Descripcion, UrlImagen, E.Descripcion Tipo, D.Descripcion Debilidad from POKEMONS P, ELEMENTOS E, ELEMENTOS D where E.Id = P.IdTipo And D.Id = P.IdDebilidad\r\n";
                // Establezco la conexión con el comando
                comando.Connection = conexion;

                // Abro la conexión
                conexion.Open();
                // Ejecuto la lectura
                lector = comando.ExecuteReader();

                // Creo un while para que se lean los datos
                while(lector.Read())
                {
                    // Creo un Pokemon auxiliar
                    Pokemon aux = new Pokemon();

                    // Asigno los valores de la DB al auxiliar

                    // Esta es una manera de asignar, 0 = Numero, 1 = Nombre, 2 = Descripción
                    aux.Numero = lector.GetInt32(0);
                    // Esta es otra manera de asignar, más practica y tengo que utilizar el casteo
                    aux.Nombre = (string) lector["Nombre"];
                    aux.Descripcion = (string) lector["Descripcion"];
                    aux.UrlImagen = (string)lector["UrlImagen"];
                    
                    // Se crea así porque sino en Tipo.Descripcion va a dar referencia NULA 
                    aux.Tipo = new Elemento();
                    aux.Tipo.Descripcion = (string)lector["Tipo"];

                    aux.Debilidad = new Elemento();
                    aux.Debilidad.Descripcion = (string)lector["Debilidad"];

                    // Por ultimo, agrego el Pokemon a la lista
                    lista.Add(aux);
                }

                // Cierro la conexión
                conexion.Close();
                
                // Retorno
                return lista;       
            }
            catch (Exception ex)
            {

                throw ex;
            }


        }
    }
}
