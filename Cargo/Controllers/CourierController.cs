using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cargo.Helper;
using Cargo.Models;

namespace Cargo.Controllers
{
    public class CourierController : Controller
    {
        private CargoDBEntities db =new CargoDBEntities();
        // GET: Courier
        public ActionResult Create()
        {
            //var prueba = db.Warehouses.ToList();
            ViewBag.CodeNumber = db.CurrentWarehouseCodeNumbers.FirstOrDefault().WarehouseCodeNumber + 1;
            //ViewBag.CodeNumber = 1001;

            return View();
        }

        [HttpPost]
        public JsonResult checkTrackingNumber(string number)
        {
            bool exist = db.Couriers.Any(x => x.TrackingNumber == number);

            return Json(new { result=exist}, JsonRequestBehavior.AllowGet);
        }

      
    }
}