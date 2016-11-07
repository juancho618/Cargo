using AutoMapper;
using Cargo.Data.Entities;
using Cargo.Data.Repository.Parametrization;
using Cargo.Domain.Helpers;
using Cargo.Domain.ViewModels.Parametrizacion;
using Cargo.Helper;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web.Mvc;

namespace Cargo.Controllers
{
    public class OriginController : Controller
    {
        OriginRepository _repository = new OriginRepository();

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
                response.Data = Mapper.Map<IEnumerable<Origin>, IEnumerable<OriginViewModel>>(data);
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
        [AjaxValidationAntiForgeryToken]
        public JsonResult Create([Bind(Include = "Id, Name")] OriginViewModel origin)
        {
            var response = new JsonResultBody();
            string id = string.Empty;

            try
            {
                var mapped = Mapper.Map<OriginViewModel, Origin>(origin);
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
        public ActionResult Edit([Bind(Include = "Id, Name")] OriginViewModel origin)
        {
            var response = new JsonResultBody();

            try
            {
                response.Data = _repository.Edit(Mapper.Map<OriginViewModel, Origin>(origin));
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

        [HttpPost]
        [AjaxValidationAntiForgeryToken]
        public ActionResult ToggleState(string id)
        {
            var response = new JsonResultBody();

            try
            {
                Origin origin = _repository.GetOriginById(id);
                response.Data = _repository.Delete(origin);
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

        [HttpPost]
        [AjaxValidationAntiForgeryToken]
        public ActionResult Delete(string id)
        {
            var response = new JsonResultBody();

            try
            {
                Origin origin = _repository.GetOriginById(id);
                response.Data = _repository.Delete(origin);
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