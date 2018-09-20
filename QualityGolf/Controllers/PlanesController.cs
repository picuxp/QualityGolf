using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QualityGolf.Data;
using QualityGolf.Models;

namespace QualityGolf.Controllers
{
    public class PlanesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PlanesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Planes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Planes.ToListAsync());
        }

        // GET: Planes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var planes = await _context.Planes
                .SingleOrDefaultAsync(m => m.PlanesID == id);
            if (planes == null)
            {
                return NotFound();
            }

            return View(planes);
        }

        public async Task<List<SelectListItem>> GetPlanes()
        {
            var planes = await _context.Planes.ToListAsync();

            List<SelectListItem> planesLista = new List<SelectListItem>();

            foreach (var Data in planes)
            {

                planesLista.Add(new SelectListItem()
                {
                    Value = Data.PlanesID.ToString(),
                    Text = Data.Tipo
                });
            }
            
            return planesLista;
        }


        public async Task<List<SelectListItem>> GetSuscripcion(string plan)
        {
            var planes = await _context.Planes.ToListAsync();

            List<SelectListItem> suscripcionLista = new List<SelectListItem>();
           
            foreach (var Data in planes)
            {
                //if (Data.Tipo == plan)
                {
                    suscripcionLista.Add(new SelectListItem()
                    {
                        Value = Data.PlanesID.ToString(),
                        Text = Data.Suscripcion
                    });
                }
            }

            return suscripcionLista;
        }




        // GET: Planes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Planes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PlanesID,Tipo,Suscripcion,CantidadClases,ClasesMes,Estado")] Planes planes)
        {
            if (ModelState.IsValid)
            {
                _context.Add(planes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(planes);
        }

        // GET: Planes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var planes = await _context.Planes.SingleOrDefaultAsync(m => m.PlanesID == id);
            if (planes == null)
            {
                return NotFound();
            }
            return View(planes);
        }

        // POST: Planes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PlanesID,Tipo,Suscripcion,CantidadClases,ClasesMes,Estado")] Planes planes)
        {
            if (id != planes.PlanesID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(planes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlanesExists(planes.PlanesID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(planes);
        }

        // GET: Planes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var planes = await _context.Planes
                .SingleOrDefaultAsync(m => m.PlanesID == id);
            if (planes == null)
            {
                return NotFound();
            }

            return View(planes);
        }

        // POST: Planes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var planes = await _context.Planes.SingleOrDefaultAsync(m => m.PlanesID == id);
            _context.Planes.Remove(planes);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PlanesExists(int id)
        {
            return _context.Planes.Any(e => e.PlanesID == id);
        }
    }
}
