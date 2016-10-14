using AutoMapper;
using NTDShop.Model.Models;
using NTDShop.Service;
using NTDShop.Web.Infrastructure.Core;
using NTDShop.Web.Infrastructure.Extensions;
using NTDShop.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace NTDShop.Web.api
{
    [RoutePrefix("api/productCategory")]
    public class ProductCategoryController : ApiControllerBase
    {
        #region initialize
        private IProductCategoryService _productCategoryService;

        public ProductCategoryController(IErrorService errorService, IProductCategoryService productCategoryService) : base(errorService)
        {
            this._productCategoryService = productCategoryService;
        }
        #endregion


        [Route("getall")]
        [HttpGet]
        public HttpResponseMessage Get(HttpRequestMessage request, string keyWord, int page, int pageSize = 20)
        {
            return CreateHttpReponse(request, () =>
            {
                int totalRow = 0;

                var model = _productCategoryService.GetAll(keyWord);

                totalRow = model.Count();

                var query = model.OrderByDescending(x => x.CreatedDate).Skip(page * pageSize).Take(pageSize);

                var reponseData = Mapper.Map<IEnumerable<ProductCategory>, IEnumerable<ProductCategoryViewModel>>(query);
                var paginationSet = new PaginationSet<ProductCategoryViewModel>()
                {
                    Items = reponseData,
                    Page = page,
                    TotalCount = totalRow,
                    TotalPages = (int)Math.Ceiling((decimal)(totalRow / pageSize))
                };

                var reponse = request.CreateResponse(HttpStatusCode.OK, paginationSet);
                return reponse;
            });
        }
        [Route("getallParents")]
        [HttpGet]
        public HttpResponseMessage Get(HttpRequestMessage request)
        {
            return CreateHttpReponse(request, () =>
            {
                var model = _productCategoryService.GetAll();

                var reponseData = Mapper.Map<IEnumerable<ProductCategory>, IEnumerable<ProductCategoryViewModel>>(model);
               
                var reponse = request.CreateResponse(HttpStatusCode.OK, reponseData);
                return reponse;
            });
        }

        [Route("getByID/{id:int}")]
        [HttpGet]
        public HttpResponseMessage GetByID(HttpRequestMessage request,int id)
        {
            return CreateHttpReponse(request, () =>
            {
                var model = _productCategoryService.GetByID(id);

                var reponseData = Mapper.Map<ProductCategory,ProductCategoryViewModel>(model);

                var reponse = request.CreateResponse(HttpStatusCode.OK, reponseData);
                return reponse;
            });
        }

        [Route("Create")]
        [HttpPost]
        public HttpResponseMessage Create(HttpRequestMessage request,ProductCategoryViewModel ProductCategoryVm)
        {
            return CreateHttpReponse(request, () => {
                HttpResponseMessage response = null;
                if(! ModelState.IsValid)
                {
                  response=  request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    ProductCategory productCategory = new ProductCategory();
                    productCategory.UpdateProductCategory(ProductCategoryVm);
                    productCategory.CreatedDate = DateTime.Now;
                    _productCategoryService.Add(productCategory);
                    _productCategoryService.SavChanges();
                    var responseData = Mapper.Map<ProductCategory, ProductCategoryViewModel>(productCategory);
                    response = request.CreateResponse(HttpStatusCode.Created, responseData);
                    
                }
                return response;
            });
        }

        [Route("Update")]
        [HttpPut]
        public HttpResponseMessage Update(HttpRequestMessage request, ProductCategoryViewModel ProductCategoryVm)
        {
            return CreateHttpReponse(request, () => {
                HttpResponseMessage response = null;
                if (!ModelState.IsValid)
                {
                    response = request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    ProductCategory dbProductCategory = _productCategoryService.GetByID(ProductCategoryVm.ID);
                    dbProductCategory.UpdateProductCategory(ProductCategoryVm);
                    dbProductCategory.UpdatedDate = DateTime.Now;
                    _productCategoryService.UpDate(dbProductCategory);
                    _productCategoryService.SavChanges();
                    var responseData = Mapper.Map<ProductCategory, ProductCategoryViewModel>(dbProductCategory);
                    response = request.CreateResponse(HttpStatusCode.Created, responseData);

                }
                return response;
            });
        }

    }
}