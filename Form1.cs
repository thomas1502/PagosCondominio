using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace PagosCondominio
{
    public partial class Form1 : Form
    {
        // Instanciar listas
        List<Propietario> propietarios = new List<Propietario>();
        List<Propiedad> propiedades = new List<Propiedad>();
        List<Datos> datos = new List<Datos>();
        // Variables globales
        int contador; int indice; float cuotaTotal;
        // Funciones propias
        private void GuardarDatos()
        {
            FileStream stream = new FileStream("Datos.txt", FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter writer = new StreamWriter(stream);

            foreach (var p in datos)
            {
                writer.WriteLine(p.Nombre);
                writer.WriteLine(p.Apellido);
                writer.WriteLine(p.NumCasa);
                writer.WriteLine(p.Cuota);
            }

            writer.Close();
        }
        private void LeerPropietarios()
        {
            FileStream stream = new FileStream("Propietarios.txt", FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(stream);

            while (reader.Peek() > -1)
            {
                Propietario propietarioTemp = new Propietario();
                propietarioTemp.Dpi = reader.ReadLine();
                propietarioTemp.Nombre = reader.ReadLine();
                propietarioTemp.Apellido = reader.ReadLine();

                propietarios.Add(propietarioTemp);
            }
            reader.Close();
        }
        private void LeerPropiedades()
        {
            FileStream stream = new FileStream("Propiedades.txt", FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(stream);

            while (reader.Peek() > -1)
            {
                Propiedad propiedadTemp = new Propiedad();
                propiedadTemp.NumCasa = Convert.ToInt32(reader.ReadLine());
                propiedadTemp.Dpi = reader.ReadLine();                
                propiedadTemp.Cuota = float.Parse(reader.ReadLine());

                propiedades.Add(propiedadTemp);
            }
            reader.Close();
        }
        private void LeerDatos()
        {
            FileStream stream = new FileStream("Datos.txt", FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(stream);

            while (reader.Peek() > -1)
            {
                Datos datosTemp = new Datos();
                datosTemp.Nombre = reader.ReadLine();
                datosTemp.Apellido = reader.ReadLine();
                datosTemp.NumCasa = Convert.ToInt32(reader.ReadLine());
                datosTemp.Cuota = float.Parse(reader.ReadLine());

                datos.Add(datosTemp);
            }
            reader.Close();
        }
        //
        private void Mostrar()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = datos;
            dataGridView1.Refresh();
        }
        private void General()
        {
            int contadorTemp = 0; int i = 0;
            float cuotaTotalTemp = 0;
            for (int x = 0; x < propietarios.Count; x++)
            {
                contador = 0; cuotaTotal = 0; 
                for (int y = 0; y < propiedades.Count; y++)
                {
                    if (propietarios[x].Dpi.Contains(propiedades[y].Dpi))
                    {
                        contador++;
                        indice = x;
                        cuotaTotal += propiedades[y].Cuota; 
                        // Si se cumple la condición es porque la propiedad le pertenece
                        // a la persona.
                        Datos datosTemp = new Datos();

                        datosTemp.Nombre = propietarios[x].Nombre;
                        datosTemp.Apellido = propietarios[x].Apellido;
                        datosTemp.NumCasa = propiedades[y].NumCasa;
                        datosTemp.Cuota = propiedades[y].Cuota;

                        datos.Add(datosTemp);
                        GuardarDatos();
                    }
                }
                // Comprobar quien tiene más propiedades
                if (contador > contadorTemp)
                {
                    contadorTemp = contador;
                    i = indice;
                }
                if(cuotaTotal > cuotaTotalTemp)
                {
                    cuotaTotalTemp = cuotaTotal;
                    i = indice;
                }
            }
            // Mostrar al propietario con más propiedades
            label5.Text = propietarios[i].Dpi;
            label7.Text = contadorTemp.ToString();
            label15.Text = propietarios[i].Nombre; ;
            label13.Text = propietarios[i].Apellido;
            // Mostrar el propietario con la cuota total mayor
            label11.Text = propietarios[i].Dpi;
            label9.Text = cuotaTotalTemp.ToString();
            label33.Text = propietarios[i].Nombre; ;
            label31.Text = propietarios[i].Apellido;
        }
        private void OrdenarCuota()
        {
            List <Datos> d = datos.OrderBy(al => al.Cuota).ToList();
            // Mostrar datos ordenados
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = d;
            dataGridView1.Refresh();
        }
        private void CuotasAltas()
        {
            List<Datos> d = datos.OrderByDescending(al => al.Cuota).ToList();
            label19.Text = (d[0].Cuota).ToString();
            label17.Text = (d[1].Cuota).ToString();
            label22.Text = (d[2].Cuota).ToString();
        }
        private void CuotasBajas()
        {
            List<Datos> d = datos.OrderBy(al => al.Cuota).ToList();
            label28.Text = (d[0].Cuota).ToString();
            label26.Text = (d[1].Cuota).ToString();
            label24.Text = (d[2].Cuota).ToString();
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LeerPropietarios();
            LeerPropiedades();
            if(datos.Count > 0)
                LeerDatos();
            General();
            CuotasAltas();
            CuotasBajas();
        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            if (cmbFiltro.SelectedIndex == 0)
            {
                Mostrar();               
            }
            else if (cmbFiltro.SelectedIndex == 1)
            {
                OrdenarCuota();
            }
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }
    }
}
