using NTDShop.Model.Models;
using NTDShop.Service;
using NTDShop.Web.Infrastructure.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace NTDShop.Web.api
{
    [RoutePrefix("api/postcategory")]
    public class PostCategoryController : ApiControllerBase
    {
        // GET api/<controller>
        IPostCategoryService _ipostCategoryService;
        public PostCategoryController(IErrorService errorService,IPostCategoryService ipostCategoryService)
            : base(errorService)
        {
            this._ipostCategoryService = ipostCategoryService;
        }
        [Route("getall")]
        public HttpResponseMessage Get(HttpRequestMessage request)
        {
            return CreateHttpReponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (!ModelState.IsValid)
                {
                    return request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }
                {
                    var listCategory = _ipostCategoryService.GetAll();
                    
                    response = request.CreateResponse(HttpStatusCode.OK, listCategory);
                }
                return response;
            });
        }
        public HttpResponseMessage Post(HttpRequestMessage request,PostCategory postCategory)
        {
            return CreateHttpReponse(request, () =>
            {
                HttpResponseMessage response = null;
                if(!ModelState.IsValid)
                {
                    return request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }
                {
                   var category = _ipostCategoryService.Add(postCategory);
                   _ipostCategoryService.SavChanges();

                   response = request.CreateResponse(HttpStatusCode.Created, category);
                }
                return response;
            });
        }
        public HttpResponseMessage Put(HttpRequestMessage request, PostCategory postCategory)
        {
            return CreateHttpReponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (!ModelState.IsValid)
                {
                    return request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }
                {
                     _ipostCategoryService.UpDate(postCategory);
                    _ipostCategoryService.SavChanges();

                    response = request.CreateResponse(HttpStatusCode.OK);
                }
                return response;
            });
        }
        public HttpResponseMessage Delete(HttpRequestMessage request, int id)
        {
            return CreateHttpReponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (!ModelState.IsValid)
                {
                    return request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }
                {
                    _ipostCategoryService.Delete(id);
                    _ipostCategoryService.SavChanges();

                    response = request.CreateResponse(HttpStatusCode.OK);
                }
                return response;
            });
        }
    }
}