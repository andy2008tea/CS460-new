using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Hw8.Models;
using PagedList;

namespace Hw8.Controllers
{
    public class PiratesController : Controller
    {
        private Hw8Context db = new Hw8Context();

        // GET: Pirates
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;
            var pirates = from s in db.Pirates
                           select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                pirates = pirates.Where(s => s.Name.Contains(searchString)
                                       );
            }
            switch (sortOrder)
            {
                case "name_desc":
                    pirates = pirates.OrderByDescending(s => s.Name);
                    break;
                case "Date":
                    pirates = pirates.OrderBy(s => s.Conscripted);
                    break;
                case "date_desc":
                    pirates = pirates.OrderByDescending(s => s.Conscripted);
                    break;
                default:
                    pirates = pirates.OrderBy(s => s.Name);
                    break;
            }
            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return View(pirates.ToPagedList(pageNumber, pageSize));

            return View(pirates.ToList());
        }
        // GET: Pirates/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pirates pirates = db.Pirates.Find(id);
            if (pirates == null)
            {
                return HttpNotFound();
            }
            return View(pirates);
        }

        // GET: Pirates/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pirates/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Conscripted")] Pirates pirates)
        {
            if (ModelState.IsValid)
            {
                db.Pirates.Add(pirates);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pirates);
        }

        // GET: Pirates/Edit/5
        public ActionResult Edit(int? id)
        {
            
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Pirates pirates = db.Pirates.Find(id);
            if (pirates == null)
            {
                return HttpNotFound();
            }
            return View(pirates);
        }

        // POST: Pirates/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Conscripted")] Pirates pirates)
        {
            if (ModelState.IsValid)
            {
                if (pirates.Conscripted > DateTime.Now)
                {
                    return Content("Cant future");
                }
                db.Entry(pirates).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pirates);
        }

        // GET: Pirates/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pirates pirates = db.Pirates.Find(id);
            if (pirates == null)
            {
                return HttpNotFound();
            }
            return View(pirates);
        }

        // POST: Pirates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pirates pirates = db.Pirates.Find(id);
            db.Pirates.Remove(pirates);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
