using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cargo.Models;
using Cargo.Helper;

namespace Cargo.Controllers
{
    public class DeliveryCompanyController : Controller
    {
        private CargoDBEntities db = new CargoDBEntities();
        // GET: DeliveryCompany
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult GetAllDeliveryCompany()
        {
            var List = (from q in db.DeliveryCompanies
                        where !q.Deleted
                        select new
                        {
                            Id = q.CompanyID,
                            CompanyName = q.CompanyName
                        });

            return Json(new { data = List.ToList() }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Create([Bind(Include = "CompanyID,CompanyName")] DeliveryCompany deliveryCompany)
        {
            GenerateId generator = new GenerateId();
            deliveryCompany.CompanyID = generator.generateID();
            db.DeliveryCompanies.Add(deliveryCompany);
            db.SaveChanges();

            var delivery = new
            {
                Id = deliveryCompany.CompanyID,
                CompanyName = deliveryCompany.CompanyName
            };

            return Json(new { data = delivery }, JsonRequestBehavior.AllowGet);
        }

    }
}