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
        // GET: Home
        public ActionResult Index()
        {
            var result = (from t in db.Type
                          join ct in db.CostType on t.TypeId equals ct.TypeId
                          join c in db.Cost on ct.CostId equals c.CostId
                          orderby c.Value descending
                          select t ).Take(3).ToList();

          


                        
            
            return View(result );
        }

        
    }
}