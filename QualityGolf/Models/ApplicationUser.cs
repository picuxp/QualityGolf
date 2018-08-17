using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace QualityGolf.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        [Required]
        public string Dni { get; set; }

        [Required]
        public string Nombre { get; set; }

        [Required]
        public string Apellido { get; set; }


        public string Nacionalidad { get; set; }
        public string Sexo { get; set; }
        public string EstadoCivil { get; set; }
        public string Cuit { get; set; }
        public string Localidad { get; set; }
        public string Direccion { get; set; }
        public string CodigoPostal { get; set; }
        public string TipoSuscripcion { get; set; }
        public string TipoPlan { get; set; }
        public byte Handicap { get; set; }
        public string Nivel { get; set; }
        public string FechaNacimiento { get; set; }
        public string StartingDate { get; set; }
        public string VigenciaDesde { get; set; }
        public string VigenciaHasta { get; set; }
        public byte CantidadClasesMes { get; set; }
        public byte ClasesPendiente { set; get; }



    }
}
