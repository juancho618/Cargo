using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cargo.Models;
using Cargo.Helper;
using Cargo.Domain.ViewModels.Parametrizacion;
using Cargo.Data.Repository.Parametrization;
using Cargo.Data.Entities;
using AutoMapper;
using Cargo.Domain.Helpers;
using System.Data.Entity.Validation;

namespace Cargo.Controllers
{
    public class NotificationController : Controller
    {
        NotificationRepository _repository = new NotificationRepository();

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
                response.Data = Mapper.Map<IEnumerable<Notification>, IEnumerable<NotificationViewModel>>(data);
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
        public JsonResult Create([Bind(Include = "Id, Name")] NotificationViewModel notification)
        {
            var response = new JsonResultBody();
            string id = string.Empty;

            try
            {
                var mapped = Mapper.Map<NotificationViewModel, Notification>(notification);
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
        public ActionResult Edit([Bind(Include = "Id, Name")] NotificationViewModel notification)
        {
            var response = new JsonResultBody();

            try
            {
                response.Data = _repository.Edit(Mapper.Map<NotificationViewModel, Notification>(notification));
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
                Notification notification = _repository.GetNotificationById(id);
                response.Data = _repository.Delete(notification);
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
                Notification notification = _repository.GetNotificationById(id);
                response.Data = _repository.Delete(notification);
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