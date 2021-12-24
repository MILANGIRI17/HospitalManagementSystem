using Hospital.DAL;
using Hospital.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Controllers
{
    public class EmergencyServiceTypeController : Controller
    {
        private readonly HospitalDbContext db;

        public EmergencyServiceTypeController(HospitalDbContext _db)
        {
            db = _db;
        }
        // GET: EmergencyServiceTypeController
        public ActionResult Index()
        {
            var model = db.EmergencyServiceTypes.ToList();
            return View(model);
        }

        // GET: EmergencyServiceTypeController/Details/5
        public ActionResult Details(int id)
        {
            var model = db.EmergencyServiceTypes.Find(id);
            return View(model);
        }

        // GET: EmergencyServiceTypeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmergencyServiceTypeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EmergencyServiceType data)
        {
            try
            {
                db.Add(data);
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EmergencyServiceTypeController/Edit/5
        public ActionResult Edit(int id)
        {
            var model = db.EmergencyServiceTypes.Find(id);
            return View(model);
        }

        // POST: EmergencyServiceTypeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, EmergencyServiceType data)
        {
            try
            {

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EmergencyServiceTypeController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: EmergencyServiceTypeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
