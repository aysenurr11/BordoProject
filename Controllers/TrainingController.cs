using Microsoft.AspNetCore.Mvc;
using BordoProject.Data;
using BordoProject.Models;
using BordoProject.ViewModels;
using System.Linq;

namespace BordoProject.Controllers
{
    public class TrainingController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TrainingController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Route tanımlaması yapıldı
        //[HttpGet("Training/Index/{uid?}")]
        [HttpGet]
        public IActionResult Index(Guid? uid)
        {
            var model = new TrainingViewModel();

            if (uid.HasValue)
            {
                var employee = _context.Employees.FirstOrDefault(e => e.UniqueId == uid);
                if (employee != null)
                {
                    model.Name = employee.Name;
                    model.Email = employee.Email;
                }
            }

            return View(model);
        }

        [HttpPost]
        public IActionResult Index(TrainingViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var employee = _context.Employees.FirstOrDefault(x => x.Email == model.Email);

            if (employee == null)
            {
                employee = new Employee
                {
                    Email = model.Email,
                    Name = model.Name,
                    UniqueId = Guid.NewGuid()  // Yeni çalışan oluşturulduğunda UniqueId atama
                };

                _context.Employees.Add(employee);
                _context.SaveChanges();
            }

            // Formdan gelen verileri ekle
            foreach (var dayTime in model.DayTimes)
            {
                var answer = new Answer
                {
                    EmployeeId = employee.EmployeeId,
                    Day = dayTime.Day,
                    StartTime = dayTime.StartTime,
                    EndTime = dayTime.EndTime,
                    TotalHours = model.TotalHours,
                    Bolum1 = model.Bolum1,
                    Bolum2 = model.Bolum2,
                    Bolum3 = model.Bolum3,
                    Bolum4 = model.Bolum4,
                    NonWorkingDay = model.NonWorkingDay,
                    DateFilled = DateTime.Now
                };

                _context.Answers.Add(answer);
            }

            _context.SaveChanges();

            return RedirectToAction("Success"); // Başarılı form gönderimi sonrası yönlendirme
        }
    }
}