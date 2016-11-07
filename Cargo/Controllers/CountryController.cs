using System.Linq;
using System.Web.Mvc;
using Cargo.Data.Repository.Parametrization;
using Cargo.Domain.Helpers;
using System.Collections.Generic;
using AutoMapper;
using System.Data.Entity.Validation;
using Cargo.Data.Entities;
using Cargo.Domain.ViewModels.Parametrizacion;
using System;
using Cargo.Helper;

namespace Cargo.Controllers
{
    public class CountryController : Controller
    {
        CountryRepository _repository = new CountryRepository();

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
        [AjaxValidationAntiForgeryToken]
        public JsonResult Create([Bind(Include = "Id, Name")] CountryViewModel country)
        {
            var response = new JsonResultBody();
            string id = string.Empty;

            try
            {
                var mapped = Mapper.Map<CountryViewModel, Country>(country);
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
        public ActionResult Edit([Bind(Include = "Id, Name")] CountryViewModel country)
        {
            var response = new JsonResultBody();

            try
            {
                response.Data = _repository.Edit(Mapper.Map<CountryViewModel, Country>(country));
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
                Country country = _repository.GetCountryById(id);
                response.Data = _repository.Delete(country);
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
                Country country = _repository.GetCountryById(id);
                response.Data = _repository.Delete(country);
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