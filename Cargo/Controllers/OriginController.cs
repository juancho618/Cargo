using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cargo.Models;
using Cargo.Helper;

namespace Cargo.Controllers
{
    public class OriginController : Controller
    {
        private CargoDBEntities db = new CargoDBEntities();
        // GET: Origin
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetAllOrigins()
        {
            var list = (from q in db.Origins
                        select new
                        {
                            OriginId = q.OriginId,
                            OriginName = q.OriginName
                        });
            return Json(new {data=list.ToList() }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Create([Bind(Include = "OriginId,OriginName")] Origin origin)
        {
            GenerateId generator = new GenerateId();
            origin.OriginId = generator.generateID();
            db.Origins.Add(origin);
            db.SaveChanges();

            var origen = new
            {
                OriginId = origin.OriginId,
                OriginName = origin.OriginName
            };

            return Json(new { data = origen }, JsonRequestBehavior.AllowGet);
        }
    }
}