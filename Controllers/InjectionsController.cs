using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VaccinatorNet.Models;

namespace VaccinatorNet.Controllers
{
    public class InjectionsController : Controller
    {
        private readonly ContextBDD _context;

        public InjectionsController(ContextBDD context)
        {
            _context = context;
        }

        // GET: Injections
        public async Task<IActionResult> Index()
        {
            return View(await _context.Injections.ToListAsync());
        }

        // GET: Injections/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var injection = await _context.Injections
                .FirstOrDefaultAsync(m => m.VaccinationId == id);
            if (injection == null)
            {
                return NotFound();
            }

            return View(injection);
        }

        // GET: Injections/Create
        public IActionResult Create()
        {
            ViewBag.ListPersons = _context.Persons.Select(x => new SelectListItem { Text = x.Lastname + " " + x.Firstname + " (" + x.PersonId + ")", Value = x.PersonId.ToString() }).ToList();
            ViewBag.ListVaccines = _context.Vaccines.Select(x => new SelectListItem { Text = x.Brand + " (" + x.VaccineType + ")", Value = x.VaccineId.ToString() }).ToList();
            return View();
        }

        // POST: Injections/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(IFormCollection values)
        {
            //if (ModelState.IsValid)
            //{
            //    _context.Add(injection);
            //    await _context.SaveChangesAsync();
            //    return RedirectToAction(nameof(Index));
            //}
            //return View(injection);

            Injection injection = new Injection();
            injection.Person = _context.Persons.Find(int.Parse(values["Person"]));
            injection.Vaccine = _context.Vaccines.Find(int.Parse(values["Vaccine"]));
            injection.InjectionDate = DateTime.Parse(values["InjectionDate"]);
            injection.Lot = values["Lot"];
            injection.ReminderDate = DateTime.Parse(values["ReminderDate"]);

            _context.Add(injection);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

            return View(injection);

        }

        // GET: Injections/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var injection = await _context.Injections.FindAsync(id);
            if (injection == null)
            {
                return NotFound();
            }
            return View(injection);
        }

        // POST: Injections/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("VaccinationId,InjectionDate,Lot,ReminderDate")] Injection injection)
        {
            if (id != injection.VaccinationId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(injection);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InjectionExists(injection.VaccinationId))
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
            return View(injection);
        }

        // GET: Injections/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var injection = await _context.Injections
                .FirstOrDefaultAsync(m => m.VaccinationId == id);
            if (injection == null)
            {
                return NotFound();
            }

            return View(injection);
        }

        // POST: Injections/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var injection = await _context.Injections.FindAsync(id);
            _context.Injections.Remove(injection);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InjectionExists(int id)
        {
            return _context.Injections.Any(e => e.VaccinationId == id);
        }
    }
}
