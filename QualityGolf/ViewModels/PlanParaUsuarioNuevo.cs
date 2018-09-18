using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QualityGolf.Models;

namespace QualityGolf.ViewModels
{
    public class PlanParaUsuarioNuevo
    {
        
        public IEnumerable<Planes> Planes { get; set; }
        public IEnumerable<Usuario> Usuarios { get; set; }  
        
    }
}
