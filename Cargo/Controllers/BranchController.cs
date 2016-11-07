using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cargo.Models;
using Cargo.Helper;

namespace Cargo.Controllers
{
    public class BranchController : Controller
    {
        private CargoDBEntities db = new CargoDBEntities();
        // GET: Branch
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetAllBranches()
        {
            var list = (from q in db.Branches
                        select new
                        {
                            BranchID = q.BranchID,
                            BranchName = q.BranchName
                        });
            return Json(new { data = list.ToList() }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Create([Bind(Include = "BranchID,BranchName")] Branch branch)
        {
            GenerateId generator = new GenerateId();
            branch.BranchID = generator.generateID();
            db.Branches.Add(branch);
            db.SaveChanges();

            var branchObj = new
            {
                BranchID = branch.BranchID,
                BranchName = branch.BranchName
            };

            return Json(new { data = branchObj }, JsonRequestBehavior.AllowGet);
        }
    }
}