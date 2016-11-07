using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cargo.Models;
using Cargo.Helper;

namespace Cargo.Controllers
{
    public class ClassificationAccountController : Controller
    {
        private CargoDBEntities db = new CargoDBEntities();

        // GET: ClacssificationAccount
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetAllClassification()
        {
            var list = (from q in db.AccountClasifications
                        select new
                        {
                            Id=q.AccountClasificationID,
                            Classification= q.ClasificationName
                        });
            return Json(new {data=list.ToList() }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult Create([Bind(Include = "AccountClasificationID,ClasificationName")] AccountClasification classification)
        {
            GenerateId generator = new GenerateId();
            classification.AccountClasificationID = generator.generateID();
            db.AccountClasifications.Add(classification);
            db.SaveChanges();

            var clasificacion = new
            {
                Id = classification.AccountClasificationID,
                Classification = classification.ClasificationName
            };

            return Json(new { data = clasificacion }, JsonRequestBehavior.AllowGet);
        }
    }
}