using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QualityGolf.Models
{
    public class Planes
    {
        public int PlanesID { get; set; }
        public string Tipo { get; set; }
        public string Suscripcion { get; set; }
        public int CantidadClases { get; set; }
        public int ClasesMes { get; set; }
        public Boolean Estado { get; set; }

    }
}
