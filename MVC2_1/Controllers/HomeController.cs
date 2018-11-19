using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC2_1.Models;

namespace MVC2_1.Controllers
{
    public class HomeController : Controller
    {
        private Database2Entities db = new Database2Entities();
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var typeDelete = (from type in db.Type where type.TypeId == id select type).First();
            return View(typeDelete);
        }

        [HttpPost]
        public ActionResult Delete (int id, FormCollection collection)
        {
            var typeDelete = (from type in db.Type where type.TypeId == id select type).First();
            var costTypeDelete = (from costType in db.CostType where costType.TypeId == id select costType).First();
            var costDelete = (from cost in db.Cost where cost.CostId == costTypeDelete.CostId select cost).First();
        try
            {
                
                db.CostType.Remove(costTypeDelete);
                db.Cost.Remove(costDelete);
                db.Type.Remove(typeDelete);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(String.Empty, ex);
                return View(typeDelete);
            }

        }


        [HttpGet]
        public ActionResult Edit(int id)
        {
            var typeEdit = (from type in db.Type where type.TypeId == id select type).First();
            return View(typeEdit);
        }
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
          var typeEdit = (from type in db.Type where type.TypeId == id select type).First();
            try
            {
                UpdateModel(typeEdit);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            catch (Exception ex)
            {
                ModelState.AddModelError(String.Empty, ex);
            }

            return View(typeEdit);


        }
        [HttpGet]
        public ActionResult Create()
        {
            
            Models.Type tp = new Models.Type();
            return View(tp); 
        }

        [HttpPost]
        public ActionResult Create (Models.Type tp)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Type.Add(tp);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(String.Empty, ex);
            }

            return View(tp);
        }

        
        // GET: Home
        public ActionResult Index()
        {
            var result = (from t in db.Type select t);

            
            return View(result );
        }

        
    }
}