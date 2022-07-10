using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebVetMyPet.Data;
using WebVetMyPet.Models;

namespace WebVetMyPet.Controllers
{
    public class ServicesController : Controller
    {
        private readonly WebVetMyPetContext _context;

        public ServicesController(WebVetMyPetContext context)
        {
            _context = context;
        }

        // GET: Services
        public async Task<IActionResult> Index()
        {
            var webVetMyPetContext = _context.Service.Include(s => s.Animal).Include(s => s.Veterinarian);
            return View(await webVetMyPetContext.ToListAsync());
        }

        // GET: Services/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Service == null)
            {
                return NotFound();
            }

            var service = await _context.Service
                .Include(s => s.Animal)
                .Include(s => s.Veterinarian)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (service == null)
            {
                return NotFound();
            }

            return View(service);
        }

        // GET: Services/Create
        public IActionResult Create()
        {
            ViewData["AnimalId"] = new SelectList(_context.Animal, "Id", "Name");
            ViewData["VeterinarianId"] = new SelectList(_context.Veterinarian, "Id", "Name");
            return View();
        }

        // POST: Services/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Date,Value,Note,VeterinarianId,AnimalId")] Service service)
        {
            _context.Add(service);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: Services/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Service == null)
            {
                return NotFound();
            }

            var service = await _context.Service.FindAsync(id);
            if (service == null)
            {
                return NotFound();
            }
            ViewData["AnimalId"] = new SelectList(_context.Animal, "Id", "Gender", service.AnimalId);
            ViewData["VeterinarianId"] = new SelectList(_context.Veterinarian, "Id", "Cellphone", service.VeterinarianId);
            return View(service);
        }

        // POST: Services/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Date,Value,Note,VeterinarianId,AnimalId")] Service service)
        {
            if (id != service.Id)
            {
                return NotFound();
            }

            _context.Update(service);
            await _context.SaveChangesAsync();

            ViewData["AnimalId"] = new SelectList(_context.Animal, "Id", "Gender", service.AnimalId);
            ViewData["VeterinarianId"] = new SelectList(_context.Veterinarian, "Id", "Cellphone", service.VeterinarianId);
            return View(service);
        }

        // GET: Services/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Service == null)
            {
                return NotFound();
            }

            var service = await _context.Service
                .Include(s => s.Animal)
                .Include(s => s.Veterinarian)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (service == null)
            {
                return NotFound();
            }

            return View(service);
        }

        // POST: Services/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Service == null)
            {
                return Problem("Entity set 'WebVetMyPetContext.Service'  is null.");
            }
            var service = await _context.Service.FindAsync(id);
            if (service != null)
            {
                _context.Service.Remove(service);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ServiceExists(int id)
        {
          return (_context.Service?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
