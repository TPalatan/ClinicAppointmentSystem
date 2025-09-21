using Microsoft.AspNetCore.Mvc;
using ClinicAppointmentSystem.Models;
using System.Linq;
using System.Xml.Linq;

namespace PracticeWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ClinicDbContent _context;

        public HomeController(ClinicDbContent context)
        {
            _context = context;
        }

        // Show all records
        public IActionResult Index()
        {
            var dataList = _context.datas.ToList();
            return View(dataList);
        }

        // Create page (GET)
        public IActionResult Create()
        {
            // Generate the next ID here so it shows in the form
            var newData = new ClinicDb
            {
                appointmentId  = GenerateNextId()
            };
            return View(newData);
        }

        // Create new record (POST)
        [HttpPost]
        public IActionResult Create(ClinicDb data)
        {
            if (ModelState.IsValid)
            {
                if (string.IsNullOrEmpty(data.appointmentId))
                    data.appointmentId  = GenerateNextId();

                _context.datas.Add(data);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(data);
        }

        // ✅ Function to generate next ID like BF00-1, BF00-2...
        private string GenerateNextId()
        {
            // Get the last ID in the database (if any)
            var lastRecord = _context.datas
                .OrderByDescending(x => x.appointmentId)
                .FirstOrDefault();

            int nextNumber = 1;

            if (lastRecord != null && !string.IsNullOrEmpty(lastRecord.appointmentId))
            {
                // lastRecord.Id is like "BF00-5"
                var parts = lastRecord.appointmentId.Split('-');
                if (parts.Length == 2 && int.TryParse(parts[1], out int lastNumber))
                {
                    nextNumber = lastNumber + 1;
                }
            }

            return $"BF00-{nextNumber}";
        }
    }
}
