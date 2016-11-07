using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cargo.Models;
using Cargo.Helper;

namespace Cargo.Controllers
{
    public class NotificationController : Controller
    {
        private CargoDBEntities db = new CargoDBEntities();
        // GET: Notification
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult GetAllNotifications()
        {
            var list = (from q in db.Notifications
                        select new
                        {
                            Id = q.NotificationID,
                            Notification=q.NotificationName
                        });
            return Json(new { data = list.ToList() }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Create([Bind(Include = "NotificationID,NotificationName")] Notification notification)
        {
            GenerateId generator = new GenerateId();
            notification.NotificationID = generator.generateID();
            db.Notifications.Add(notification);
            db.SaveChanges();

            var notificacion = new
            {
                Id = notification.NotificationID,
                Notification = notification.NotificationName
            };

            return Json(new { data = notificacion }, JsonRequestBehavior.AllowGet);
        }
    }
}