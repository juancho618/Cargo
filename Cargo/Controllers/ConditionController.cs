using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cargo.Models;
using Cargo.Helper;
using Cargo.Data.Repository.Parametrization;
using Cargo.Domain.Helpers;

namespace Cargo.Controllers
{
    public class ConditionController : Controller
    {
        ConditionRepository _repository = new ConditionRepository();

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetAll()
        {
            var response = new JsonResultBody();
            response.Status = System.Net.HttpStatusCode.OK;

            try
            {
                var data = _repository.GetAll();
                response.Data = Mapper.Map<IEnumerable<Country>, IEnumerable<CountryViewModel>>(data);
            }
            catch (DbEntityValidationException ex)
            {
                response.Status = System.Net.HttpStatusCode.InternalServerError;

                foreach (DbEntityValidationResult result in ex.EntityValidationErrors)
                {
                    response.Errors = (from ve in result.ValidationErrors select ve.ErrorMessage).ToList();
                }
            }
            catch (Exception ex)
            {
                response.Status = System.Net.HttpStatusCode.InternalServerError;
                response.Errors.Add(ex.Message);
            }

            return Json(response, JsonRequestBehavior.AllowGet);
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