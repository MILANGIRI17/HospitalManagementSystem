using Hospital.DAL;
using Hospital.Models;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly HospitalDbContext db;

        public DepartmentController(HospitalDbContext _hospitalContext)
        {
            db = _hospitalContext;
        }
        // GET: DepartmentController
        public ActionResult Index()
        {
            var model = db.Departments.ToList();
            return View(model);
        }

        // GET: DepartmentController/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var model = db.Departments.Find(id);
            return View(model);
        }

        // GET: DepartmentController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DepartmentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Department data)
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

        // GET: DepartmentController/Edit/5
        public ActionResult Edit(int id)
        {
            var model = db.Departments.Find(id);
            return View(model);
        }

        // POST: DepartmentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Department data)
        {
            try
            {
                var model = db.Departments.Find(id);
                model.DepartmentName = data.DepartmentName;
                db.Departments.Update(model);
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DepartmentController/Delete/5
        public ActionResult Delete(int id)
        {
            var model = db.Departments.Find(id);
            
            return View(model);
        }

        // POST: DepartmentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                var model = db.Departments.Find(id);
                db.Departments.Remove(model);
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
