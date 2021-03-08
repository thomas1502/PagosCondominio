using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PagosCondominio
{
    public partial class Form1 : Form
    {
        // Instanciar listas
        List<Propietario> propietarios = new List<Propietario>();
        List<Propiedad> propiedades = new List<Propiedad>();

        // Funciones propias
        private void LeerPropietarios()
        {

        }
        private void LeerPropiedades()
        {

        }
        //
        private void General()
        {

        }
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LeerPropietarios();
            LeerPropiedades();
        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            if(cmbFiltro.SelectedIndex == 0)
            {
                General();
            }
        }
    }
}
