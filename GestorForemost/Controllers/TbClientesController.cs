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
    public class TbClientesController : Controller
    {
        private readonly GestorForemostContext _context;

        public TbClientesController(GestorForemostContext context)
        {
            _context = context;
        }

        // GET: TbClientes
        public async Task<IActionResult> Index()
        {
              return _context.TbClientes != null ? 
                          View(await _context.TbClientes.ToListAsync()) :
                          Problem("Entity set 'GestorForemostContext.TbClientes'  is null.");
        }

        // GET: TbClientes/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.TbClientes == null)
            {
                return NotFound();
            }

            var tbCliente = await _context.TbClientes
                .FirstOrDefaultAsync(m => m.IdentificacionCliente == id);
            if (tbCliente == null)
            {
                return NotFound();
            }

            return View(tbCliente);
        }

        // GET: TbClientes/DetalleClienteFac/5
        public async Task<IActionResult> DetalleClienteFact(string id)
        {
            if (id == null || _context.TbClientes == null)
            {
                return NotFound();
            }

            var tbCliente = await _context.TbClientes
                .FirstOrDefaultAsync(m => m.IdentificacionCliente == id);
            if (tbCliente == null)
            {
                return NotFound();
            }

            return View(tbCliente);
        }

        // GET: TbClientes/DetalleClienteHisto/5
        public async Task<IActionResult> DetalleClienteHisto(string id)
        {
            if (id == null || _context.TbClientes == null)
            {
                return NotFound();
            }

            var tbCliente = await _context.TbClientes
                .FirstOrDefaultAsync(m => m.IdentificacionCliente == id);
            if (tbCliente == null)
            {
                return NotFound();
            }

            return View(tbCliente);
        }

        // GET: TbClientes/DetalleClienteSaldo/5
        public async Task<IActionResult> DetalleClienteSaldo(string id)
        {
            if (id == null || _context.TbClientes == null)
            {
                return NotFound();
            }

            var tbCliente = await _context.TbClientes
                .FirstOrDefaultAsync(m => m.IdentificacionCliente == id);
            if (tbCliente == null)
            {
                return NotFound();
            }

            return View(tbCliente);
        }

        // GET: TbClientes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TbClientes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdentificacionCliente,NombreCliente,Apellido1Cliente,Apellido2Cliente,TelefonoCliente,CorreoCliente,DireccionCliente")] TbCliente tbCliente)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tbCliente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tbCliente);
        }

        // GET: TbClientes/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.TbClientes == null)
            {
                return NotFound();
            }

            var tbCliente = await _context.TbClientes.FindAsync(id);
            if (tbCliente == null)
            {
                return NotFound();
            }
            return View(tbCliente);
        }

        // POST: TbClientes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("IdentificacionCliente,NombreCliente,Apellido1Cliente,Apellido2Cliente,TelefonoCliente,CorreoCliente,DireccionCliente")] TbCliente tbCliente)
        {
            if (id != tbCliente.IdentificacionCliente)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbCliente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TbClienteExists(tbCliente.IdentificacionCliente))
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
            return View(tbCliente);
        }

        // GET: TbClientes/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.TbClientes == null)
            {
                return NotFound();
            }

            var tbCliente = await _context.TbClientes
                .FirstOrDefaultAsync(m => m.IdentificacionCliente == id);
            if (tbCliente == null)
            {
                return NotFound();
            }

            return View(tbCliente);
        }

        // POST: TbClientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.TbClientes == null)
            {
                return Problem("Entity set 'GestorForemostContext.TbClientes'  is null.");
            }
            var tbCliente = await _context.TbClientes.FindAsync(id);
            if (tbCliente != null)
            {
                _context.TbClientes.Remove(tbCliente);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TbClienteExists(string id)
        {
          return (_context.TbClientes?.Any(e => e.IdentificacionCliente == id)).GetValueOrDefault();
        }
    }
}
