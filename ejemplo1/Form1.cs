using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ejemplo1
{
    public partial class frmPokemons : Form
    {
        // Creo lista privada para guardar datos
        private List<Pokemon> listaPokemon;
        
        public frmPokemons()
        {
            InitializeComponent();
        }

        // Evento de carga Formulario (doble click en el formulario)
        private void frmPokemons_Load(object sender, EventArgs e)
        {
            // Creo un negocio de tipo PokemonNegocio (donde está todo lo de DB)
            PokemonNegocio negocio = new PokemonNegocio();
            
            // Los datos de la DB me los guardo en un atributo privado
            listaPokemon = negocio.listar();
            
            // Igualo el DGV a la lista para que tenga el mismo metodo
            // y así se muestre en el Form
            dgvPokemons.DataSource = listaPokemon;

            // De esta manera puedo ocultar una columna, la puedo referenciar por nombre o número
            dgvPokemons.Columns["UrlImagen"].Visible = false;


            // Al picture box le cargo la URl de la imagen en la posición 0 (Primer dato en la DB)
             cargarImagen(listaPokemon[0].UrlImagen);

            
            
            
            // Le asigno el método que cree al DGV que puse en el Form
            // dgvPokemons.DataSource = negocio.listar();


        }

        // Creo el evento para cuando cambié la sección de la grilla 
        // y así cambia de imagen
        private void dgvPokemons_SelectionChanged(object sender, EventArgs e)
        {
            // Creo una variable de Pokemon seleccionado
            // Y la igualo al renglon actual del DGV con el item que tenga
            // Tengo que hacer un casteo ya que uno es Pokemon y el otro listaPokemon
            Pokemon seleccionado = (Pokemon)dgvPokemons.CurrentRow.DataBoundItem;
            // Luego le cargo la URL de esta forma
            cargarImagen(seleccionado.UrlImagen);



        }

        private void cargarImagen(string imagen)
        {
            try
            {
                pbxPokemon.Load(imagen);

            }
            catch (Exception ex)
            {

                pbxPokemon.Load("https://uning.es/wp-content/uploads/2016/08/ef3-placeholder-image.jpg");
            }
        }
    }
}
