using Hospital.DAL;
using Hospital.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Controllers
{
    public class HealthPackageController : Controller
    {

        private readonly HospitalDbContext db;

        public HealthPackageController(HospitalDbContext _db)
        {
            db = _db;
        }
        // GET: HealthPackageController
        public ActionResult Index()
        {
            var model = db.HealthPackages.ToList();
            return View(model);
        }

        // GET: HealthPackageController/Details/5
        public ActionResult Details(int id)
        {
            var model = db.HealthPackages.Find(id);
            return View(model);
        }

        // GET: HealthPackageController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HealthPackageController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(HealthPackages data)
        {
            try
            {
                db.HealthPackages.Add(data);
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: HealthPackageController/Edit/5
        public ActionResult Edit(int id)
        {
            var model = db.HealthPackages.Find(id);
            return View(model);
        }

        // POST: HealthPackageController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, HealthPackages data)
        {
            try
            {
                var model = db.HealthPackages.Find(id);
                model.Name = data.Name;
                db.HealthPackages.Update(model);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: HealthPackageController/Delete/5
        public ActionResult Delete(int id)
        {
            var model = db.HealthPackages.Find(id);
            return View(model);
        }

        // POST: HealthPackageController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, HealthPackages data)
        {
            try
            {
                var model = db.HealthPackages.Find(id);
                db.HealthPackages.Remove(model);
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
