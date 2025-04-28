using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AndradeEduardoExamenProgreso1.Data;
using AndradeEduardoExamenProgreso1.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AndradeEduardoExamenProgreso1.Controllers
{
    public class ReservasController : Controller
    {
        private readonly AndradeEduardoExamenProgreso1Context _context;

        public ReservasController(AndradeEduardoExamenProgreso1Context context)
        {
            _context = context;
        }

        // GET: Reservas
        public async Task<IActionResult> Index()
        {
            var reservas = await _context.Reserva.Include(r => r.Cliente).ToListAsync();
            return View(reservas);
        }

        // GET: Reservas/Create
        // GET: Reservas/Create
        public IActionResult Create()
        {
            ViewBag.Clientes = new SelectList(_context.Cliente.ToList(), "clienteId", "Nombre");
            return View();
        }

        // POST: Reservas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Create(Reserva reserva)
        {
            // Forzar para pruebas
            reserva.clienteId = 1; // Obligatoriamente asignamos un cliente
            reserva.fechaIngreso = reserva.fechaIngreso == DateTime.MinValue ? DateTime.Now : reserva.fechaIngreso;
            reserva.fechaSalida = reserva.fechaSalida == DateTime.MinValue ? DateTime.Now.AddDays(1) : reserva.fechaSalida;

            if (ModelState.IsValid)
            {
                _context.Reserva.Add(reserva);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Clientes = new SelectList(_context.Cliente.ToList(), "clienteId", "Nombre", reserva.clienteId);
            return View(reserva);
        }





        // GET: Reservas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var reserva = await _context.Reserva.FindAsync(id);
            if (reserva == null) return NotFound();

            ViewBag.clienteId = new SelectList(_context.Cliente.ToList(), "clienteId", "Nombre", reserva.clienteId);
            return View(reserva);
        }

        // POST: Reservas/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Reserva reserva)
        {
            if (id != reserva.reservaId) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reserva);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReservaExists(reserva.reservaId))
                        return NotFound();
                    else
                        throw;
                }
                return RedirectToAction(nameof(Index));
            }

            ViewBag.clienteId = new SelectList(_context.Cliente.ToList(), "clienteId", "Nombre", reserva.clienteId);
            return View(reserva);
        }

        // GET: Reservas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var reserva = await _context.Reserva
                .Include(r => r.Cliente)
                .FirstOrDefaultAsync(m => m.reservaId == id);

            if (reserva == null) return NotFound();

            return View(reserva);
        }

        // POST: Reservas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reserva = await _context.Reserva.FindAsync(id);
            if (reserva != null)
            {
                _context.Reserva.Remove(reserva);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        private bool ReservaExists(int id)
        {
            return _context.Reserva.Any(e => e.reservaId == id);
        }
    }
}
