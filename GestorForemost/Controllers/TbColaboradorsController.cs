using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GestorForemost.Models;

namespace GestorForemost.Controllers
{
    public class TbColaboradorsController : Controller
    {
        private readonly GestorForemostContext _context;

        public TbColaboradorsController(GestorForemostContext context)
        {
            _context = context;
        }

        // GET: TbColaboradors
        public async Task<IActionResult> Index()
        {
            var gestorForemostContext = _context.TbColaboradors.Include(t => t.PuestoColaboradorNavigation);
            return View(await gestorForemostContext.ToListAsync());
        }

        // GET: TbColaboradors/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.TbColaboradors == null)
            {
                return NotFound();
            }

            var tbColaborador = await _context.TbColaboradors
                .Include(t => t.PuestoColaboradorNavigation)
                .FirstOrDefaultAsync(m => m.IdentificacionColaborador == id);
            if (tbColaborador == null)
            {
                return NotFound();
            }

            return View(tbColaborador);
        }


        // GET: TbColaboradors/DetalleColabFact/5
        public async Task<IActionResult> DetalleColabFact(string id)
        {
            if (id == null || _context.TbColaboradors == null)
            {
                return NotFound();
            }

            var tbColaborador = await _context.TbColaboradors
                .Include(t => t.PuestoColaboradorNavigation)
                .FirstOrDefaultAsync(m => m.IdentificacionColaborador == id);
            if (tbColaborador == null)
            {
                return NotFound();
            }

            return View(tbColaborador);
        }

        // GET: TbColaboradors/DetalleColabHist/5
        public async Task<IActionResult> DetalleColabHist(string id)
        {
            if (id == null || _context.TbColaboradors == null)
            {
                return NotFound();
            }

            var tbColaborador = await _context.TbColaboradors
                .Include(t => t.PuestoColaboradorNavigation)
                .FirstOrDefaultAsync(m => m.IdentificacionColaborador == id);
            if (tbColaborador == null)
            {
                return NotFound();
            }

            return View(tbColaborador);
        }

        // GET: TbColaboradors/Create
        public IActionResult Create()
        {
            ViewData["PuestoColaborador"] = new SelectList(_context.TbPuestos, "IdPuesto", "IdPuesto");
            return View();
        }

        // POST: TbColaboradors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdentificacionColaborador,NombreColaborador,Apellido1Colaborador,Apellido2Colaborador,TelefonoColaborador,CorreoColaborador,FechaIngresoColab,PuestoColaborador,PaisColaborador,EstadoColaborador")] TbColaborador tbColaborador)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tbColaborador);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PuestoColaborador"] = new SelectList(_context.TbPuestos, "IdPuesto", "IdPuesto", tbColaborador.PuestoColaborador);
            return View(tbColaborador);
        }

        // GET: TbColaboradors/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.TbColaboradors == null)
            {
                return NotFound();
            }

            var tbColaborador = await _context.TbColaboradors.FindAsync(id);
            if (tbColaborador == null)
            {
                return NotFound();
            }
            ViewData["PuestoColaborador"] = new SelectList(_context.TbPuestos, "IdPuesto", "IdPuesto", tbColaborador.PuestoColaborador);
            return View(tbColaborador);
        }

        // POST: TbColaboradors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("IdentificacionColaborador,NombreColaborador,Apellido1Colaborador,Apellido2Colaborador,TelefonoColaborador,CorreoColaborador,FechaIngresoColab,PuestoColaborador,PaisColaborador,EstadoColaborador")] TbColaborador tbColaborador)
        {
            if (id != tbColaborador.IdentificacionColaborador)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbColaborador);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TbColaboradorExists(tbColaborador.IdentificacionColaborador))
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
            ViewData["PuestoColaborador"] = new SelectList(_context.TbPuestos, "IdPuesto", "IdPuesto", tbColaborador.PuestoColaborador);
            return View(tbColaborador);
        }

        // GET: TbColaboradors/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.TbColaboradors == null)
            {
                return NotFound();
            }

            var tbColaborador = await _context.TbColaboradors
                .Include(t => t.PuestoColaboradorNavigation)
                .FirstOrDefaultAsync(m => m.IdentificacionColaborador == id);
            if (tbColaborador == null)
            {
                return NotFound();
            }

            return View(tbColaborador);
        }

        // POST: TbColaboradors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.TbColaboradors == null)
            {
                return Problem("Entity set 'GestorForemostContext.TbColaboradors'  is null.");
            }
            var tbColaborador = await _context.TbColaboradors.FindAsync(id);
            if (tbColaborador != null)
            {
                _context.TbColaboradors.Remove(tbColaborador);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TbColaboradorExists(string id)
        {
          return (_context.TbColaboradors?.Any(e => e.IdentificacionColaborador == id)).GetValueOrDefault();
        }
    }
}
