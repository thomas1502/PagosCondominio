using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PagosCondominio
{
    class Propiedad
    {
        int numCasa;
        string dpi;
        float cuota;

        public int NumCasa { get => numCasa; set => numCasa = value; }
        public string Dpi { get => dpi; set => dpi = value; }
        public float Cuota { get => cuota; set => cuota = value; }
    }
}
