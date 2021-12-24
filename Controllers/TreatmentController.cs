using Hospital.DAL;
using Hospital.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Controllers
{
    public class TreatmentController : Controller
    {
        private readonly HospitalDbContext db;

        public TreatmentController(HospitalDbContext _db)
        {
            db = _db;
        }
        // GET: TreatmentController
        public ActionResult Index()
        {
            var model = db.Treatments.ToList();
            return View(model);
        }

        // GET: TreatmentController/Details/5
        public ActionResult Details(int id)
        {
            var model = db.Treatments.Find(id);
            return View(model);
        }

        // GET: TreatmentController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TreatmentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Treatments data)
        {
            try
            {
                db.Treatments.Add(data);
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TreatmentController/Edit/5
        public ActionResult Edit(int id)
        {
            var model = db.Treatments.Find(id);
            return View(model);
        }

        // POST: TreatmentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Treatments data)
        {
            try
            {
                var model = new Treatments();
                model.Name = data.Name;
                db.Treatments.Update(model);
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TreatmentController/Delete/5
        public ActionResult Delete(int id)
        {
            var model = db.Treatments.Find(id);
            return View(model);
        }

        // POST: TreatmentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Treatments data)
        {
            try
            {
                var model = db.Treatments.Find(id);
                db.Treatments.Remove(model);
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
