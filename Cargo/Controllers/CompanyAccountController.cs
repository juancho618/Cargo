using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cargo.Models;
using Cargo.Helper;

namespace Cargo.Controllers
{
    public class CompanyAccountController : Controller
    {
        private CargoDBEntities db = new CargoDBEntities();
        // GET: CompanyAccount
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public JsonResult Create([Bind(Include = "CompanyAccountID,CompanyName,Adress,City,State,ZipCode,Fk_CountryID,Email,Phone,Fax,Mobile,ContactName,Fk_Agent")] CompanyAccount CompanyAccount, String[] Classification, String[] Notification)
        {
            GenerateId generator = new GenerateId();
            CompanyAccount.CompanyAccountID = generator.generateID();
            db.CompanyAccounts.Add(CompanyAccount);
            db.SaveChanges();
            if (Classification != null) {

                ////Add classifications
                List<AccountClasificationRelation> classificationAccountList = new List<AccountClasificationRelation>();
                foreach (var item in Classification)
                {
                    var idClassification = db.AccountClasifications.Where(x => x.ClasificationName == item).Select(x => x.AccountClasificationID).SingleOrDefault();
                    AccountClasificationRelation classificacationItem = new AccountClasificationRelation();
                    classificacationItem.AccountClasificationID = generator.generateID();
                    classificacationItem.Fk_AccountID = CompanyAccount.CompanyAccountID;
                    classificacationItem.Fk_ClasificationID = idClassification;
                    classificationAccountList.Add(classificacationItem);
                }
                foreach (var item in classificationAccountList)
                {
                    db.AccountClasificationRelations.Add(item);
                }
            }

            if (Notification != null)
            {
                ////Add notifications
                List<NotificationAccountRelation> notificationAccountList = new List<NotificationAccountRelation>();
                foreach (var item in Notification)
                {
                    var idNotification = db.Notifications.Where(x => x.NotificationName == item).Select(x => x.NotificationID).SingleOrDefault();
                    NotificationAccountRelation notificationItem = new NotificationAccountRelation();
                    notificationItem.NotificationAccountRelation1 = generator.generateID();
                    notificationItem.Fk_Account = CompanyAccount.CompanyAccountID;
                    notificationItem.Fk_Notification = idNotification;
                    notificationAccountList.Add(notificationItem);
                }


                foreach (var item in notificationAccountList)
                {
                    db.NotificationAccountRelations.Add(item);
                }
            }

            var account = new
            {
                CompanyAccountID = CompanyAccount.CompanyAccountID,
                CompanyName = CompanyAccount.ContactName,
                Adress = CompanyAccount.Adress,
                City = CompanyAccount.City,
                State = CompanyAccount.State,
            };

            db.SaveChanges();

            

            return Json(new {data=account }, JsonRequestBehavior.AllowGet);
        }
        //public JsonResult Create(CompanyAccountViewModel CompanyAccount)
        //{
        //    GenerateId generator = new GenerateId();
        //    CompanyAccount.CompanyAccountID = generator.generateID();

        //    return Json(new { }, JsonRequestBehavior.AllowGet);
        //}

        [HttpPost]
        public JsonResult GetAllAccounts(string searchString)
        {
            var list = (from q in db.CompanyAccounts
                    select new
                    {
                        CompanyAccountID=q.CompanyAccountID,
                        CompanyName = q.CompanyName,
                        Adress = q.Adress,
                        City = q.City,
                        State = q.State,
                        Country = q.Country.CountryName
                    });
            if (string.IsNullOrEmpty(searchString) == false)
            {
                 
                list = (from q in db.CompanyAccounts
                            where q.CompanyName.Contains(searchString)
                            select new
                            {
                                CompanyAccountID = q.CompanyAccountID,
                                CompanyName = q.CompanyName,
                                Adress = q.Adress,
                                City = q.City,
                                State = q.State,
                                Country = q.Country.CountryName
                            });
            }
            
            return Json(new { data = list.ToList() }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetAllCompanyAccounts()
        {
            var list = (from q in db.CompanyAccounts
                        select new
                        {
                            CompanyAccountID = q.CompanyAccountID,
                            CompanyName = q.CompanyName,
                            Adress = q.Adress,
                            City = q.City,
                            State = q.State,
                            Country = q.Country.CountryName
                        });  

            return Json(new { data = list.ToList() }, JsonRequestBehavior.AllowGet);
        }
    }
}