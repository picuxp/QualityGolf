using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QualityGolf.Models
{
    public class PlanUsuario
    {
        public int PlanUsuarioID { get; set; }
        public int PlanesID { get; set; }
        public Planes Planes { get; set; }
        public int ApplicationUserID { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

    }
}
