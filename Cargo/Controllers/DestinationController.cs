using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cargo.Models;
using Cargo.Helper;

namespace Cargo.Controllers
{
    public class DestinationController : Controller
    {
        private CargoDBEntities db = new CargoDBEntities();
        // GET: Destination
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetAllDestinations()
        {
            var list = (from q in db.Destinations
                        select new
                        {
                            DestinationId = q.DestinationId,
                            DestinationName = q.DestinationName
                        });
            return Json(new { data = list.ToList() }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult Create([Bind(Include = "DestinationId,DestinationName")] Destination destination)
        {
            GenerateId generator = new GenerateId();
            destination.DestinationId = generator.generateID();
            db.Destinations.Add(destination);
            db.SaveChanges();

            var destino = new
            {
                DestinationId = destination.DestinationId,
                DestinationName = destination.DestinationName
            };

            return Json(new { data = destino }, JsonRequestBehavior.AllowGet);
        }
    }
}