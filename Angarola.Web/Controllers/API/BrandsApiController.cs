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
    [RoutePrefix("api/brands")]
    public class BrandsApiController : ApiController
    {
        [Route][HttpPost]
        public HttpResponseMessage Insert(BrandsRequestModel model)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
            }
            try
            {
                BrandService.Insert(model);
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
                Brand model = BrandService.GetById(id);
                ItemResponse<Brand> response = new ItemResponse<Brand>();
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
                List<Brand> brands = BrandService.GetAll();
                ItemsResponse<Brand> response = new ItemsResponse<Brand>();
                response.Items = brands;
                return Request.CreateResponse(response);
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        [Route("{id:int}")][HttpPut]
        public HttpResponseMessage Update(BrandsUpdateRequest model, int id)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
            }
            try
            {
                model.Id = id;
                BrandService.Update(model);
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
                BrandService.Delete(id);
                return Request.CreateResponse(new SuccessResponse());
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }
    }
}