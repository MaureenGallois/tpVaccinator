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
    public class VaccinatedPersonsController : Controller
    {
        private readonly ContextBDD _context;

        public VaccinatedPersonsController(ContextBDD context)
        {
            _context = context;
        }

        // GET: VaccinatedPersons
        public async Task<IActionResult> Index(int Id)
        {
            ViewBag.ListPersons = _context.Persons.Select(x => new SelectListItem { Text = x.Lastname + " " + x.Firstname + " (" + x.PersonId + ")", Value = x.PersonId.ToString() }).ToList();
            ViewBag.ListPersons.Add(new SelectListItem { Text = "-- SELECT PERSON --", Value = null, Selected = true });
            if (Id == null)
            {
                return View(_context.Injections.ToListAsync());
            }
            else
            {
                var vaccinations = from v in _context.Injections select v;
                vaccinations = vaccinations.Where(s => s.Person.PersonId.Equals(Id));
                return View(await vaccinations.ToListAsync());
            }
        }

        // GET: VaccinatedPersons/Details/5
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

        // GET: VaccinatedPersons/Create
        public IActionResult Create()
        {
            ViewBag.ListPersons = _context.Persons.Select(x => new SelectListItem { Text = x.Lastname + " " + x.Firstname + " (" + x.PersonId + ")", Value = x.PersonId.ToString() }).ToList();
            return View();
        }

        // POST: VaccinatedPersons/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("VaccinationId,InjectionDate,Lot,ReminderDate")] Injection injection)
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

        // GET: VaccinatedPersons/Edit/5
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

        // POST: VaccinatedPersons/Edit/5
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

        // GET: VaccinatedPersons/Delete/5
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

        // POST: VaccinatedPersons/Delete/5
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
