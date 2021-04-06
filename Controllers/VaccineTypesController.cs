using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VaccinatorNet.Models;

namespace VaccinatorNet.Controllers
{
    public class VaccineTypesController : Controller
    {
        private readonly ContextBDD _context = new ContextBDD();

        public VaccineTypesController(ContextBDD context)
        {
            _context = context;
        }

        // GET: VaccineTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.VaccineTypes.ToListAsync());
        }

        // GET: VaccineTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vaccineType = await _context.VaccineTypes
                .FirstOrDefaultAsync(m => m.VaccineTypeId == id);
            if (vaccineType == null)
            {
                return NotFound();
            }

            return View(vaccineType);
        }

        // GET: VaccineTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: VaccineTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("VaccineTypeId,Name")] VaccineType vaccineType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vaccineType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vaccineType);
        }

        // GET: VaccineTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vaccineType = await _context.VaccineTypes.FindAsync(id);
            if (vaccineType == null)
            {
                return NotFound();
            }
            return View(vaccineType);
        }

        // POST: VaccineTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("VaccineTypeId,Name")] VaccineType vaccineType)
        {
            if (id != vaccineType.VaccineTypeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vaccineType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VaccineTypeExists(vaccineType.VaccineTypeId))
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
            return View(vaccineType);
        }

        // GET: VaccineTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vaccineType = await _context.VaccineTypes
                .FirstOrDefaultAsync(m => m.VaccineTypeId == id);
            if (vaccineType == null)
            {
                return NotFound();
            }

            return View(vaccineType);
        }

        // POST: VaccineTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vaccineType = await _context.VaccineTypes.FindAsync(id);
            _context.VaccineTypes.Remove(vaccineType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VaccineTypeExists(int id)
        {
            return _context.VaccineTypes.Any(e => e.VaccineTypeId == id);
        }
    }
}
