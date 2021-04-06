using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VaccinatorNet.Models;

namespace VaccinatorNet.Controllers
{
    public class ReminderAlertsController : Controller
    {
        private readonly ContextBDD _context;

        public ReminderAlertsController(ContextBDD context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var alerts = from v in _context.Injections select v;
            alerts = alerts.Where(s => s.ReminderDate.CompareTo(System.DateTime.Now) < 0);
            return View(await alerts.ToListAsync());
        }
    }
}
