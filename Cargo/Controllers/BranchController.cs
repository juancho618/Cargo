using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cargo.Models;
using Cargo.Helper;
using Cargo.Domain.Helpers;
using System.Data.Entity.Validation;
using AutoMapper;
using Cargo.Data.Repository.Parametrization;
using Cargo.Data.Entities;
using Cargo.Domain.ViewModels.Parametrizacion;

namespace Cargo.Controllers
{
    public class BranchController : Controller
    {
        BranchRepository _repository = new BranchRepository();

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
                response.Data = Mapper.Map<IEnumerable<Branch>, IEnumerable<BranchViewModel>>(data);
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
        public JsonResult Create([Bind(Include = "Id, Name")] BranchViewModel branch)
        {
            var response = new JsonResultBody();
            string id = string.Empty;

            try
            {
                var mapped = Mapper.Map<BranchViewModel, Branch>(branch);
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
        public ActionResult Edit([Bind(Include = "Id, Name")] BranchViewModel branch)
        {
            var response = new JsonResultBody();

            try
            {
                response.Data = _repository.Edit(Mapper.Map<BranchViewModel, Branch>(branch));
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
                Branch country = _repository.GetBranchById(id);
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
                Branch branch = _repository.GetBranchById(id);
                response.Data = _repository.Delete(branch);
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