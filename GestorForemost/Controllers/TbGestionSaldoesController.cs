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
    public class TbGestionSaldoesController : Controller
    {
        private readonly GestorForemostContext _context;

        public TbGestionSaldoesController(GestorForemostContext context)
        {
            _context = context;
        }

        // GET: TbGestionSaldoes
        public async Task<IActionResult> Index()
        {
            var saldosAsignados = await _context.TbGestionSaldos
             .FromSqlRaw("EXEC sp_GestoresAsignados")
             .ToListAsync();

            return View(saldosAsignados);
        }

        // GET: TbGestionSaldoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TbGestionSaldos == null)
            {
                return NotFound();
            }

            var tbGestionSaldo = await _context.TbGestionSaldos
                .Include(t => t.IdFacturaSaldoNavigation)
                .Include(t => t.IdGestorSaldoNavigation)
                .FirstOrDefaultAsync(m => m.IdSaldo == id);
            if (tbGestionSaldo == null)
            {
                return NotFound();
            }

            return View(tbGestionSaldo);
        }

        // GET: TbGestionSaldoes/Create
        public async Task<IActionResult> Create()
        {

            await _context.Database.ExecuteSqlRawAsync("EXEC sp_AsignarSaldos");

            return RedirectToAction("Index");


        }

        // POST: TbFacturas/ReAsignar
        [HttpPost]
        [Route("ReAsignar")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ReAsignar(string fechaSaldo)
        {
            try
            {
                await _context.Database.ExecuteSqlRawAsync("EXEC sp_ReAsignarSaldos @FechaSaldo",
                    new SqlParameter("@FechaSaldo", fechaSaldo)
                );

                TempData["SuccessMessage"] = "Cuentas re-asignadas exitosamente.";
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "Error al re-asignar: " + ex.Message;
            }

            return RedirectToAction(nameof(Index));
        }

        // POST: TbGestionSaldoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdSaldo,IdFacturaSaldo,IdGestorSaldo,FechaAsignSaldo,EstadoSaldo")] TbGestionSaldo tbGestionSaldo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tbGestionSaldo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdFacturaSaldo"] = new SelectList(_context.TbFacturas, "IdFactura", "IdFactura", tbGestionSaldo.IdFacturaSaldo);
            ViewData["IdGestorSaldo"] = new SelectList(_context.TbColaboradors, "IdentificacionColaborador", "IdentificacionColaborador", tbGestionSaldo.IdGestorSaldo);
            return View(tbGestionSaldo);
        }

        // GET: TbGestionSaldoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TbGestionSaldos == null)
            {
                return NotFound();
            }

            var tbGestionSaldo = await _context.TbGestionSaldos.FindAsync(id);
            if (tbGestionSaldo == null)
            {
                return NotFound();
            }
            ViewData["IdFacturaSaldo"] = new SelectList(_context.TbFacturas, "IdFactura", "IdFactura", tbGestionSaldo.IdFacturaSaldo);
            ViewData["IdGestorSaldo"] = new SelectList(_context.TbColaboradors, "IdentificacionColaborador", "IdentificacionColaborador", tbGestionSaldo.IdGestorSaldo);
            return View(tbGestionSaldo);
        }

        // POST: TbGestionSaldoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdSaldo,IdFacturaSaldo,IdGestorSaldo,FechaAsignSaldo,EstadoSaldo")] TbGestionSaldo tbGestionSaldo)
        {
            if (id != tbGestionSaldo.IdSaldo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbGestionSaldo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TbGestionSaldoExists(tbGestionSaldo.IdSaldo))
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
            ViewData["IdFacturaSaldo"] = new SelectList(_context.TbFacturas, "IdFactura", "IdFactura", tbGestionSaldo.IdFacturaSaldo);
            ViewData["IdGestorSaldo"] = new SelectList(_context.TbColaboradors, "IdentificacionColaborador", "IdentificacionColaborador", tbGestionSaldo.IdGestorSaldo);
            return View(tbGestionSaldo);
        }

        // GET: TbGestionSaldoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TbGestionSaldos == null)
            {
                return NotFound();
            }

            var tbGestionSaldo = await _context.TbGestionSaldos
                .Include(t => t.IdFacturaSaldoNavigation)
                .Include(t => t.IdGestorSaldoNavigation)
                .FirstOrDefaultAsync(m => m.IdSaldo == id);
            if (tbGestionSaldo == null)
            {
                return NotFound();
            }

            return View(tbGestionSaldo);
        }
        //// FACTURAR SALDO PENDIENTE
        //// SE REALIZA UN BORRADO LÓGICO PARA MANTENER EL REGISTRO
        //// SE CAMBIA EL ESTADO A CANCELADA O PAGADA
        // POST: TbFacturas/Facturar
        [HttpPost]
        [Route("Facturar")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Facturar(int idFactura, int idSaldo)
        {
            try
            {
                await _context.Database.ExecuteSqlRawAsync("EXEC sp_Facturar @IdFactura, @IdSaldo",
                    new SqlParameter("@IdFactura", idFactura),
                    new SqlParameter("@IdSaldo", idSaldo)
                );

                TempData["SuccessMessage"] = "Factura facturada exitosamente.";
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "Error al facturar: " + ex.Message;
            }

            return RedirectToAction(nameof(Index));
        }

        // POST: TbGestionSaldoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TbGestionSaldos == null)
            {
                return Problem("Entity set 'GestorForemostContext.TbGestionSaldos'  is null.");
            }
            var tbGestionSaldo = await _context.TbGestionSaldos.FindAsync(id);
            if (tbGestionSaldo != null)
            {
                _context.TbGestionSaldos.Remove(tbGestionSaldo);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TbGestionSaldoExists(int id)
        {
          return (_context.TbGestionSaldos?.Any(e => e.IdSaldo == id)).GetValueOrDefault();
        }
    }
}
