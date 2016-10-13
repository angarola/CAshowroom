using Angarola.Web.Domain;
using Angarola.Web.Models.Requests;
using Angarola.Web.Models.Responses;
using Angarola.Web.Services;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Angarola.Web.Controllers.API
{
    [RoutePrefix("api/calendar")]
    public class CalendarApiController : ApiController
    {
        [Route][HttpPost]
        public HttpResponseMessage Insert(CalendarRequest model)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
            }
            try
            {
                CalendarService.Insert(model);
                return Request.CreateResponse(new SuccessResponse());
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
        }

        [Route("{id:int}")][HttpGet]
        public HttpResponseMessage GetById(int id)
        {
            try
            {
                Calendar model = CalendarService.GetById(id);
                ItemResponse<Calendar> response = new ItemResponse<Calendar>();
                response.Item = model;
                return Request.CreateResponse(response);
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        [Route][HttpGet]
        public HttpResponseMessage GetAll()
        {
            try
            {
                List<Calendar> calendar = CalendarService.GetAll();
                ItemsResponse<Calendar> response = new ItemsResponse<Calendar>();
                response.Items = calendar;
                return Request.CreateResponse(response);
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        [Route("{id:int}")][HttpPut]
        public HttpResponseMessage Update(CalendarUpdateRequest model, int id)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
            }
            try
            {
                model.Id = id;
                CalendarService.Update(model);
                return Request.CreateResponse(new SuccessResponse());
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        [Route("{id:int}")][HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                CalendarService.Delete(id);
                return Request.CreateResponse(new SuccessResponse());
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }
    }
}