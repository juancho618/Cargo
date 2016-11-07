using System;
using System.Linq;
using System.Web.Mvc;
using Cargo.Helper;
using System.Data.Entity.Validation;
using Cargo.Data.Repository.Parametrization;
using AutoMapper;
using Cargo.Data.Entities;
using Cargo.Domain.ViewModels.Parametrizacion;
using System.Collections.Generic;
using Cargo.Domain.Helpers;

namespace Cargo.Controllers
{
    public class UnitTypeController : Controller
    {
        UnitTypeRepository _repository = new UnitTypeRepository();

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
                response.Data = Mapper.Map<IEnumerable<UnitType>, IEnumerable<UnitTypeViewModel>>(data);
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

        //public JsonResult GetAllUnitType()
        //{
        //    var list = (from q in db.UnitTypes
        //                select new
        //                {
        //                    Id = q.UnitTypeId,
        //                    Unit = q.UnitName
        //                });
        //    return Json(new { data = list.ToList() }, JsonRequestBehavior.AllowGet);
        //}

        [HttpPost]
        [AjaxValidationAntiForgeryToken]
        public JsonResult Create([Bind(Include = "Id, Name")] UnitTypeViewModel unitType)
        {
            var response = new JsonResultBody();
            string id = string.Empty;

            try
            {
                var mapped = Mapper.Map<UnitTypeViewModel, UnitType>(unitType);
                id = _repository.Save(mapped);
            }
            catch (DbEntityValidationException ex)
            {
                response.Status = System.Net.HttpStatusCode.InternalServerError;
                foreach (DbEntityValidationResult result in ex.EntityValidationErrors)
                {
                    response.Errors = (from ve in result.ValidationErrors select ve.ErrorMessage).ToList();
                }
            }
            catch (Exception exAplicacion)
            {
                response.Status = System.Net.HttpStatusCode.InternalServerError;
                response.Errors.Add(exAplicacion.Message);
            }

            response.Data = new { Id = id };

            return Json(response);
        }

        [HttpPost]
        [AjaxValidationAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id, Name")] UnitTypeViewModel unitType)
        {
            var response = new JsonResultBody();

            try
            {
                response.Data = _repository.Edit(Mapper.Map<UnitTypeViewModel, UnitType>(unitType));
            }
            catch (DbEntityValidationException ex)
            {
                response.Status = System.Net.HttpStatusCode.InternalServerError;
                foreach (DbEntityValidationResult result in ex.EntityValidationErrors)
                {
                    response.Errors = (from ve in result.ValidationErrors select ve.ErrorMessage).ToList();
                }
            }
            catch (Exception exApp)
            {
                response.Status = System.Net.HttpStatusCode.InternalServerError;
                response.Errors.Add(exApp.Message);
            }

            return Json(response);
        }


    }
}