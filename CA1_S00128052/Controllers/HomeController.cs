using CA1_S00128052.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CA1_S00128052.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            using (CampDb db = new CampDb())
            {
                var camps = db.Camps.Include("CampChildren").OrderByDescending(cmp => cmp.CampStartDate).ToList();
                if (camps == null)
                {
                    return View();
                }
                else
                    return View(camps);
            }
        }

        //
        // GET: /Home/Details/5

        public ActionResult Details(int id)
        {
            using (CampDb db = new CampDb())
            {
                var Camp = db.Camps.Include("CampChildren").SingleOrDefault(cmp => cmp.CampId == id);
                if (Camp != null)
                {
                    return View(Camp);
                }
                else
                    return View();
            }
        }

        //
        // GET: /Home/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Home/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Home/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Home/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Home/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Home/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
