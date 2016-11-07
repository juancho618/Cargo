using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cargo.Models;
using Cargo.Helper;

namespace Cargo.Controllers
{    
    public class WarehouseTypeController : Controller
    {
        private CargoDBEntities db = new CargoDBEntities();
        // GET: WarehouseType
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetAllWarehouseType()
        {
            var list = (from q in db.WarehouseTypes
                        select new
                        {
                            TypeId= q.TypeId,
                            TypeName=q.TypeName
                        });

            return Json(new { data=list.ToList()}, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Create([Bind(Include = "TypeId,TypeName")] WarehouseType warehouseClassification)
        {
            GenerateId generator = new GenerateId();
            warehouseClassification.TypeId = generator.generateID();
            db.WarehouseTypes.Add(warehouseClassification);
            db.SaveChanges();

            var tipo = new
            {
                TypeId = warehouseClassification.TypeId,
                TypeName = warehouseClassification.TypeName
            };

            return Json(new { data = tipo }, JsonRequestBehavior.AllowGet);
        }
    }
}