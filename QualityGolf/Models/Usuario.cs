using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QualityGolf.Models
{
    public class Usuario
    {
        public virtual DateTimeOffset? LockoutEnd { get; set; }
        public virtual bool TwoFactorEnabled { get; set; }
        public virtual bool PhoneNumberConfirmed { get; set; }
        public virtual string PhoneNumber { get; set; }
        public virtual string ConcurrencyStamp { get; set; }
        public virtual string SecurityStamp { get; set; }
        public virtual string PasswordHash { get; set; }
        public virtual bool EmailConfirmed { get; set; }
        public virtual string NormalizedEmail { get; set; }
        public virtual string Email { get; set; }
        public virtual string NormalizedUserName { get; set; }
        public virtual string UserName { get; set; }
        public virtual string Id { get; set; }
        public virtual bool LockoutEnabled { get; set; }
        public virtual int AccessFailedCount { get; set; }
       
        public string Dni { get; set; }

      
        public string Nombre { get; set; }

      
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

       

        public string Role { get; set; }
        public string RoleId { set; get; }

        public int PlanesID { get; set; }
        

    }
}
