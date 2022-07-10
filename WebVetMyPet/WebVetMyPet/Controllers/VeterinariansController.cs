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
    public class VeterinariansController : Controller
    {
        private readonly WebVetMyPetContext _context;

        public VeterinariansController(WebVetMyPetContext context)
        {
            _context = context;
        }

        // GET: Veterinarians
        public async Task<IActionResult> Index()
        {
            var webVetMyPetContext = _context.Veterinarian.Include(v => v.Specialty);
            return View(await webVetMyPetContext.ToListAsync());
        }

        // GET: Veterinarians/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Veterinarian == null)
            {
                return NotFound();
            }

            var veterinarian = await _context.Veterinarian
                .Include(v => v.Specialty)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (veterinarian == null)
            {
                return NotFound();
            }

            return View(veterinarian);
        }

        // GET: Veterinarians/Create
        public IActionResult Create()
        {
            ViewData["SpecialtyId"] = new SelectList(_context.Specialty, "Id", "Name");
            return View();
        }

        // POST: Veterinarians/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Cpf,Cellphone,Email,Crmv,SpecialtyId")] Veterinarian veterinarian)
        {
                _context.Add(veterinarian);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
         
        }

        // GET: Veterinarians/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Veterinarian == null)
            {
                return NotFound();
            }

            var veterinarian = await _context.Veterinarian.FindAsync(id);
            if (veterinarian == null)
            {
                return NotFound();
            }
            ViewData["SpecialtyId"] = new SelectList(_context.Specialty, "Id", "Name", veterinarian.SpecialtyId);
            return View(veterinarian);
        }

        // POST: Veterinarians/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Cpf,Cellphone,Email,Crmv,SpecialtyId")] Veterinarian veterinarian)
        {
            if (id != veterinarian.Id)
            {
                return NotFound();
            }

            _context.Update(veterinarian);
            await _context.SaveChangesAsync();
             
            ViewData["SpecialtyId"] = new SelectList(_context.Specialty, "Id", "Name", veterinarian.SpecialtyId);
            return View(veterinarian);
        }

        // GET: Veterinarians/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Veterinarian == null)
            {
                return NotFound();
            }

            var veterinarian = await _context.Veterinarian
                .Include(v => v.Specialty)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (veterinarian == null)
            {
                return NotFound();
            }

            return View(veterinarian);
        }

        // POST: Veterinarians/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Veterinarian == null)
            {
                return Problem("Entity set 'WebVetMyPetContext.Veterinarian'  is null.");
            }
            var veterinarian = await _context.Veterinarian.FindAsync(id);
            if (veterinarian != null)
            {
                _context.Veterinarian.Remove(veterinarian);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VeterinarianExists(int id)
        {
          return (_context.Veterinarian?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
