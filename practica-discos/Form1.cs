using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace practica_discos
{
    public partial class frmDiscos : Form
    {
        private List<Discos> listaDiscos;
        
        public frmDiscos()
        {
            InitializeComponent();
        }

        private void frmDiscos_Load(object sender, EventArgs e)
        {
            DiscosNegocio negocio = new DiscosNegocio();

            listaDiscos = negocio.listar();

            dgvDiscos.DataSource = listaDiscos;

            dgvDiscos.Columns["UrlImagenTapa"].Visible = false;

        }

        private void dgvDiscos_SelectionChanged(object sender, EventArgs e)
        {
            Discos seleccionado = (Discos)dgvDiscos.CurrentRow.DataBoundItem;

            cargarImagen(seleccionado.UrlImagenTapa);
        }


        private void cargarImagen(string imagen)
        {
            try
            {
                pbxDiscos.Load(imagen);

            }
            catch (Exception ex)
            {

                pbxDiscos.Load("https://uning.es/wp-content/uploads/2016/08/ef3-placeholder-image.jpg");
            }
        }

    }
}
