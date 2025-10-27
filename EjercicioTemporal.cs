using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taller2_G34
{
    public class EjercicioTemporal
    {
            public int IdEjercicio { get; set; }
            public string Nombre { get; set; }
            public int IdDia { get; set; }
            public string NombreDia { get; set; }
            public int Series { get; set; }
            public int Repeticiones { get; set; }
            public int Tiempo { get; set; }
            public bool EsTemporal { get; set; } // Para identificar si es temporal o de BD
    }
}
