using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QualityGolf.Data;
using QualityGolf.Models;

namespace QualityGolf.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly ApplicationDbContext _context;
        UserManager<ApplicationUser> _userManager;
        RoleManager<IdentityRole> _roleManager;
        UsuarioRole _usuarioRole;
        public List<SelectListItem> usuarioRole;

        public UsuariosController(ApplicationDbContext context,
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
            _usuarioRole = new UsuarioRole();
            usuarioRole = new List<SelectListItem>();

        }

        // GET: Usuarios
        public async Task<IActionResult> Index()
        {
            //declaro una variable ID vacia
            var ID = "";
            //declaro un objeto list que depende de la clase Usuario
            List<Usuario> usuario = new List<Usuario>();
            //obtengo todos los registros de la tabla donde almaceno los usuarios y lo almacveno en el obj
            var appUsuario = await _context.ApplicationUser.ToListAsync();
            foreach (var Data in appUsuario)
            {
                ID = Data.Id;
                usuarioRole = await _usuarioRole.GetRole(_userManager, _roleManager, ID);

                usuario.Add(new Usuario()
                {
                    Id = Data.Id,
                    UserName = Data.UserName,
                    Nombre = Data.Nombre,
                    Apellido = Data.Apellido,
                    Email = Data.Email,
                    Role = usuarioRole[0].Text
                } );
            }

            return View(usuario.ToList());
            //return View(await _context.ApplicationUser.ToListAsync());
        }

        public async Task<List<Usuario>> GetUsuario(string id)
        {
            //declaro objeto list que depende de la clase usuario
            List<Usuario> usuario =new List<Usuario>();
            var appUsuario = await _context.ApplicationUser.SingleOrDefaultAsync(m => m.Id == id);
            usuarioRole = await _usuarioRole.GetRole(_userManager, _roleManager, id);

            usuario.Add(new Usuario()
            {
                Id = appUsuario.Id,
                UserName = appUsuario.UserName,
                PhoneNumber = appUsuario.PhoneNumber,
                Email = appUsuario.Email,
                Role = usuarioRole[0].Text,
                RoleId = usuarioRole[0].Value,
                AccessFailedCount = appUsuario.AccessFailedCount,
                ConcurrencyStamp = appUsuario.ConcurrencyStamp,
                EmailConfirmed = appUsuario.EmailConfirmed,
                LockoutEnabled = appUsuario.LockoutEnabled,
                LockoutEnd = appUsuario.LockoutEnd,
                NormalizedEmail = appUsuario.NormalizedEmail,
                NormalizedUserName = appUsuario.NormalizedUserName,
                
                PasswordHash = appUsuario.PasswordHash,
                Nombre = appUsuario.Nombre,
                Apellido = appUsuario.Apellido,
                Dni = appUsuario.Dni,
                PhoneNumberConfirmed = appUsuario.PhoneNumberConfirmed,
                SecurityStamp = appUsuario.SecurityStamp,
                TwoFactorEnabled = appUsuario.TwoFactorEnabled,
                Nacionalidad = appUsuario.Nacionalidad,
                Sexo = appUsuario.Sexo,
                Direccion = appUsuario.Direccion,
                Localidad = appUsuario.Localidad,
                CodigoPostal = appUsuario.CodigoPostal,
                TipoPlan = appUsuario.TipoPlan,
                TipoSuscripcion = appUsuario.TipoSuscripcion,
                CantidadClasesMes = appUsuario.CantidadClasesMes,
                ClasesPendiente = appUsuario.ClasesPendiente



            });

            return usuario;
        }

        public async Task<List<SelectListItem>> GetRoles()
        {
            List<SelectListItem> rolesLista = new List<SelectListItem>();

            rolesLista = _usuarioRole.Roles(_roleManager);

            return rolesLista;
        }


        public async Task<string> EditUsuario(string id, string userName, string email, string phoneNumber,
            int accessFailedCount, string concurrencyStamp, bool emailConfirmed, bool lockoutEnabled,
            DateTimeOffset lockoutEnd, string normalizedEmail, string normalizedUserName, string passwordHash,
            bool phoneNumberConfirmed, string securityStamp, bool twoFactorEneable, string selectRole, string tipoSuscripcion, 
            string tipoPlan, string codigoPostal, string localidad, string direccion, string sexo, string dni,
            string nacionalidad, string apellido, string nombre, ApplicationUser applicationUser)
        {
            var resp = "";
            try
            {
                applicationUser = new ApplicationUser
                {
                    Id = id,
                    UserName = userName,
                    Email = email,
                    PhoneNumber = phoneNumber,
                    EmailConfirmed = emailConfirmed,
                    LockoutEnabled = lockoutEnabled,
                    LockoutEnd = lockoutEnd,
                    NormalizedEmail = normalizedEmail,
                    NormalizedUserName = normalizedUserName,
                    PasswordHash = passwordHash,
                    PhoneNumberConfirmed = phoneNumberConfirmed,
                    SecurityStamp = securityStamp,
                    TwoFactorEnabled = twoFactorEneable,
                    AccessFailedCount = accessFailedCount,
                    ConcurrencyStamp = concurrencyStamp,
                    TipoSuscripcion = tipoSuscripcion,
                    TipoPlan = tipoPlan,
                    CodigoPostal = codigoPostal,
                    Localidad = localidad,
                    Direccion = direccion,
                    Sexo = sexo,
                    Dni = dni,
                    Nacionalidad = nacionalidad,
                    Apellido = apellido,
                    Nombre = nombre


                };
                //actualizo datos
                _context.Update(applicationUser);
                await _context.SaveChangesAsync();

                //obtener el usuario
                var usuario = await _userManager.FindByIdAsync(id);

                usuarioRole = await _usuarioRole.GetRole(_userManager, _roleManager, id);

                if (usuarioRole[0].Text != "No Role")
                {
                    await _userManager.RemoveFromRoleAsync(usuario, usuarioRole[0].Text);
                }

                if (selectRole == "No Role")
                {
                    selectRole = "Usuario";
                }

                //ahora si almaceno el rol

                var resultado = await _userManager.AddToRoleAsync(usuario, selectRole);


                resp = "Save";

            }
            catch
            {
                resp = "No Save";
            }

            return resp;
        }


        public async Task<String> DeleteUsuario(string id)
        {
            var resp = "";
            try
            {
                var applicationUser = await _context.ApplicationUser.SingleOrDefaultAsync(m => m.Id == id);
                _context.ApplicationUser.Remove(applicationUser);
                await _context.SaveChangesAsync();
                resp = "Delete";
            }
            catch
            {
                resp = "No Delete";
            }
            return resp;
        }



        public async Task<String> CreateUsuario( string email,string passwordHash,string selectRole, string nombre, string apellido,
            string nacionalidad, string dni, string sexo, string phoneNumber, string direccion, string localidad,
            string codigoPostal, string tipoPlan, string tipoSuscripcion , byte cantidadClasesMes, byte clasesPendiente, ApplicationUser applicationUser )
        {
            var resp = "";

            applicationUser = new ApplicationUser
            {
                UserName = email,
                Email = email,
                Nombre = nombre,
                Apellido = apellido,
                Nacionalidad = nacionalidad,
                Dni = dni,
                Sexo = sexo,
                PhoneNumber = phoneNumber,
                Direccion = direccion,
                Localidad = localidad,
                CodigoPostal = codigoPostal,
                TipoPlan = tipoPlan,
                TipoSuscripcion = tipoSuscripcion,
                CantidadClasesMes = cantidadClasesMes,
                ClasesPendiente = clasesPendiente

        
            };
            var result = await _userManager.CreateAsync(applicationUser, passwordHash);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(applicationUser, selectRole);
                resp = "Save";
            }
            else
            {
                resp = "NoSave";
            }

            return resp;
        }
        

        private bool ApplicationUserExists(string id)
        {
            return _context.ApplicationUser.Any(e => e.Id == id);
        }
    }
}
