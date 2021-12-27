using Hospital.DAL;
using Hospital.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Hospital.Controllers
{
    public class ServicesController : Controller
    {
        private readonly HospitalDbContext db;

        public ServicesController(HospitalDbContext _db)
        {
            db = _db;
        }
        // GET: ServicesController
        public ActionResult Index()
        {
            var model = db.Services.Include(s => s.Treatment);

            return View(model);
        }

        // GET: ServicesController/Details/5
        public ActionResult Details(int id)
        {
            var model = db.Services.Include(s => s.Treatment).FirstOrDefault(s=>s.Id==id);
            return View(model);
        }

        // GET: ServicesController/Create
        public ActionResult Create()
        {
            ViewData["treatments"] = db.Treatments.ToList();
            return View();
        }

        // POST: ServicesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Service data)
        {
            try
            {
                db.Services.Add(data);
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ServicesController/Edit/5
        public ActionResult Edit(int id)
        {
            var model = db.Services.Include(s=>s.Treatment).FirstOrDefault(s=>s.Id==id);
            ViewData["treatments"] = db.Treatments.ToList();
           
           
            return View(model);
        }

        // POST: ServicesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int? id, Service data)
        {
            try
            {
                if (id!=null)
                {
                    db.Services.Update(data);
                    db.SaveChanges();
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // get: servicescontroller/delete/5
        public ActionResult Delete(int id)
        {
            var model = db.Services.Include(s => s.Treatment).FirstOrDefault(wh => wh.Id == id);
            return View(model);
        }

        // post: servicescontroller/delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id,Service data)
        {
            try
            {
                var model = db.Services.Find(id);
                db.Services.Remove(model);
                db.SaveChanges();
                return RedirectToAction(nameof(Index));

            }
            catch
            {
                return RedirectToAction(nameof(Index));
            }
        }
    }
}
