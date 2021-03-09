using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PagosCondominio
{
    class Datos
    {
        string nombre;
        string apellido;
        int numCasa;
        float cuota;

        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public int NumCasa { get => numCasa; set => numCasa = value; }
        public float Cuota { get => cuota; set => cuota = value; }

        internal object Clone()
        {
            throw new NotImplementedException();
        }
    }
}
