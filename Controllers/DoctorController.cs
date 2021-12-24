using Hospital.DAL;
using Hospital.Models;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Controllers
{
    public class DoctorController : Controller
    {
        private readonly HospitalDbContext db;

        public DoctorController(HospitalDbContext _db)
        {
            db = _db;
        }
        public IActionResult Index()
        {
            var model = db.Doctors.ToList();
            return View(model);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Doctor data)
        {
            if (ModelState.IsValid)
            {
                var model = new Doctor();
                model.Name = data.Name;
                model.Experience = data.Experience;
                model.Speciality = data.Speciality;
                model.SurgerySuccessRate = data.SurgerySuccessRate;
                model.Availability = data.Availability;
                model.Education = data.Education;

                db.Doctors.Add(model);
                db.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var model = db.Doctors.Find(id);
            return View(model);
        }

        public IActionResult Edit(int id)
        {
            var model = db.Doctors.Find(id);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Doctor data)
        {
            try
            {
                var model = db.Doctors.Find(id);
                model.Name = data.Name;
                model.Experience = data.Experience;
                model.Speciality = data.Speciality;
                model.SurgerySuccessRate = data.SurgerySuccessRate;
                model.Availability = data.Availability;
                model.Education = data.Education;
                db.Doctors.Update(model);
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

      public ActionResult Delete(int id)
        {
            var model = db.Doctors.Find(id);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Doctor data)
        {
            try
            {
                var model = db.Doctors.Find(id);
                db.Doctors.Remove(model);
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
            
        }
    }
}
