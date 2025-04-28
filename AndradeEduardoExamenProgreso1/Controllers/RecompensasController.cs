using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AndradeEduardoExamenProgreso1.Data;
using AndradeEduardoExamenProgreso1.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AndradeEduardoExamenProgreso1.Controllers
{
    public class RecompensasController : Controller
    {
        private readonly AndradeEduardoExamenProgreso1Context _context;

        public RecompensasController(AndradeEduardoExamenProgreso1Context context)
        {
            _context = context;
        }

        // GET: Recompensas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Recompensas.ToListAsync());
        }

        // GET: Recompensas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var recompensa = await _context.Recompensas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (recompensa == null) return NotFound();

            return View(recompensa);
        }

        // GET: Recompensas/Create
        public IActionResult Create()
        {
            ViewBag.Clientes = new SelectList(_context.Cliente.ToList(), "clienteId", "Nombre");
            ViewBag.Reservas = new SelectList(_context.Reserva.ToList(), "reservaId", "reservaId");
            return View();
        }

        // POST: Recompensas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Recompensas recompensa)
        {
            if (ModelState.IsValid)
            {
                _context.Add(recompensa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Clientes = new SelectList(_context.Cliente.ToList(), "clienteId", "Nombre", recompensa.clienteId);
            ViewBag.Reservas = new SelectList(_context.Reserva.ToList(), "reservaId", "reservaId", recompensa.reservaId);
            return View(recompensa);
        }

        // GET: Recompensas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var recompensa = await _context.Recompensas.FindAsync(id);
            if (recompensa == null) return NotFound();

            ViewBag.Clientes = new SelectList(_context.Cliente.ToList(), "clienteId", "Nombre", recompensa.clienteId);
            ViewBag.Reservas = new SelectList(_context.Reserva.ToList(), "reservaId", "reservaId", recompensa.reservaId);
            return View(recompensa);
        }

        // POST: Recompensas/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Recompensas recompensa)
        {
            if (id != recompensa.Id) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(recompensa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RecompensaExists(recompensa.Id)) return NotFound();
                    else throw;
                }
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Clientes = new SelectList(_context.Cliente.ToList(), "clienteId", "Nombre", recompensa.clienteId);
            ViewBag.Reservas = new SelectList(_context.Reserva.ToList(), "reservaId", "reservaId", recompensa.reservaId);
            return View(recompensa);
        }

        // GET: Recompensas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var recompensa = await _context.Recompensas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (recompensa == null) return NotFound();

            return View(recompensa);
        }

        // POST: Recompensas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var recompensa = await _context.Recompensas.FindAsync(id);
            if (recompensa != null)
            {
                _context.Recompensas.Remove(recompensa);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        private bool RecompensaExists(int id)
        {
            return _context.Recompensas.Any(e => e.Id == id);
        }
    }
}
