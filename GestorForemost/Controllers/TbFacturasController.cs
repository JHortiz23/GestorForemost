using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GestorForemost.Models;
using Microsoft.Data.SqlClient;

namespace GestorForemost.Controllers
{
    public class TbFacturasController : Controller
    {
        private readonly GestorForemostContext _context;

        public TbFacturasController(GestorForemostContext context)
        {
            _context = context;
        }

        // GET: TbFacturas
        public async Task<IActionResult> Index()
        {

            var saldosPendintes = await _context.TbFacturas
             .FromSqlRaw("EXEC sp_FacturasPendientes")
             .ToListAsync();

            return View(saldosPendintes);

        }
        // GET: TbFacturas/Historico
        public async Task<IActionResult> Historico()
        {

            var historicos = await _context.TbFacturas
             .FromSqlRaw("EXEC sp_HistoricoFacturas")
             .ToListAsync();

            return View(historicos);

        }

        // GET: TbFacturas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TbFacturas == null)
            {
                return NotFound();
            }

            var tbFactura = await _context.TbFacturas
                .Include(t => t.ClienteFacturaNavigation)
                .Include(t => t.ColaboradorFacturaNavigation)
                .FirstOrDefaultAsync(m => m.IdFactura == id);
            if (tbFactura == null)
            {
                return NotFound();
            }

            return View(tbFactura);

        }

        // GET: TbFacturas/Create
        public IActionResult Create()
        {
            ViewData["ClienteFactura"] = new SelectList(_context.TbClientes, "IdentificacionCliente", "IdentificacionCliente");
            ViewData["ColaboradorFactura"] = new SelectList(_context.TbColaboradors, "IdentificacionColaborador", "IdentificacionColaborador");
            return View();
        }

        // POST: TbFacturas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdFactura,ClienteFactura,FechaFactura,ColaboradorFactura,TipoFactura,MontoFactura,EstadoFactura")] TbFactura tbFactura)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tbFactura);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClienteFactura"] = new SelectList(_context.TbClientes, "IdentificacionCliente", "IdentificacionCliente", tbFactura.ClienteFactura);
            ViewData["ColaboradorFactura"] = new SelectList(_context.TbColaboradors, "IdentificacionColaborador", "IdentificacionColaborador", tbFactura.ColaboradorFactura);
            return View(tbFactura);
        }

        // GET: TbFacturas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TbFacturas == null)
            {
                return NotFound();
            }

            var tbFactura = await _context.TbFacturas.FindAsync(id);
            if (tbFactura == null)
            {
                return NotFound();
            }
            ViewData["ClienteFactura"] = new SelectList(_context.TbClientes, "IdentificacionCliente", "IdentificacionCliente", tbFactura.ClienteFactura);
            ViewData["ColaboradorFactura"] = new SelectList(_context.TbColaboradors, "IdentificacionColaborador", "IdentificacionColaborador", tbFactura.ColaboradorFactura);
            return View(tbFactura);
        }

        // POST: TbFacturas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdFactura,ClienteFactura,FechaFactura,ColaboradorFactura,TipoFactura,MontoFactura,EstadoFactura")] TbFactura tbFactura)
        {
            if (id != tbFactura.IdFactura)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbFactura);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TbFacturaExists(tbFactura.IdFactura))
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
            ViewData["ClienteFactura"] = new SelectList(_context.TbClientes, "IdentificacionCliente", "IdentificacionCliente", tbFactura.ClienteFactura);
            ViewData["ColaboradorFactura"] = new SelectList(_context.TbColaboradors, "IdentificacionColaborador", "IdentificacionColaborador", tbFactura.ColaboradorFactura);
            return View(tbFactura);
        }

        // GET: TbFacturas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TbFacturas == null)
            {
                return NotFound();
            }

            var tbFactura = await _context.TbFacturas
                .Include(t => t.ClienteFacturaNavigation)
                .Include(t => t.ColaboradorFacturaNavigation)
                .FirstOrDefaultAsync(m => m.IdFactura == id);
            if (tbFactura == null)
            {
                return NotFound();
            }

            return View(tbFactura);
        }

        // POST: TbFacturas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TbFacturas == null)
            {
                return Problem("Entity set 'GestorForemostContext.TbFacturas'  is null.");
            }
            var tbFactura = await _context.TbFacturas.FindAsync(id);
            if (tbFactura != null)
            {
                _context.TbFacturas.Remove(tbFactura);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        //// FACTURAR SALDO PENDIENTE
        //// SE REALIZA UN BORRADO LÓGICO PARA MANTENER EL REGISTRO
        //// SE CAMBIA EL ESTADO A CANCELADA O PAGADA
        //[HttpPost, ActionName("Facturar")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Facturar(int? id)
        //{
        //    if (id == null)
        //    {
        //        // Redirigir al Index con un mensaje de error si el id es nulo
        //        TempData["ErrorMessage"] = "El ID de la factura no es válido.";
        //        return RedirectToAction(nameof(Index));
        //    }

        //    var factura = await _context.TbFacturas.FindAsync(id);

        //    if (factura == null)
        //    {
        //        // Redirigir con un mensaje de error si la factura no fue encontrada
        //        TempData["ErrorMessage"] = "La factura no fue encontrada.";
        //        return RedirectToAction(nameof(Index));
        //    }

        //    // Cambiar el estado de la factura a cancelada o pagada
        //    factura.EstadoFactura = 0;  // 0 indica pagada/cancelada
        //    await _context.SaveChangesAsync();

        //    // Agregar un mensaje de éxito
        //    TempData["SuccessMessage"] = $"La factura con ID {id} ha sido facturada exitosamente.";

        //    // Redirigir al Index después de guardar los cambios
        //    return RedirectToAction(nameof(Index));
        //}


        private bool TbFacturaExists(int id)
        {
          return (_context.TbFacturas?.Any(e => e.IdFactura == id)).GetValueOrDefault();
        }
    }
}
