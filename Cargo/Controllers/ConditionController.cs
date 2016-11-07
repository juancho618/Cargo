using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cargo.Models;
using Cargo.Helper;

namespace Cargo.Controllers
{
    public class ConditionController : Controller
    {
        private CargoDBEntities db = new CargoDBEntities();
        // GET: Condition
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetAllConditions()
        {
            var list = (from q in db.Conditions
                        select new
                        {
                            ConditionID = q.ConditionID,
                            ConditionName = q.ConditionName
                        });
            return Json(new { data = list.ToList() }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Create([Bind(Include = "ConditionID,ConditionName")] Condition condition)
        {
            GenerateId generator = new GenerateId();
            condition.ConditionID = generator.generateID();
            db.Conditions.Add(condition);
            db.SaveChanges();

            var condicion = new
            {
                ConditionID = condition.ConditionID,
                ConditionName = condition.ConditionName
            };

            return Json(new { data = condicion }, JsonRequestBehavior.AllowGet);
        }
    }
}