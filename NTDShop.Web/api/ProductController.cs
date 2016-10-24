using AutoMapper;
using NTDShop.Model.Models;
using NTDShop.Service;
using NTDShop.Web.Infrastructure.Core;
using NTDShop.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Script.Serialization;
using NTDShop.Web.Infrastructure;
using NTDShop.Web.Infrastructure.Extensions;

namespace NTDShop.Web.api
{
    [RoutePrefix("api/product")]
    public class ProductController : ApiControllerBase
    {
        #region initialize
        private IProductService _productService;

        public ProductController(IErrorService errorService, IProductService productService) : base(errorService)
        {
            this._productService = productService;
        }
        #endregion


        [Route("getall")]
        [HttpGet]
        public HttpResponseMessage Get(HttpRequestMessage request, string keyWord, int page, int pageSize = 20)
        {
            return CreateHttpReponse(request, () =>
            {
                int totalRow = 0;

                var model = _productService.GetAll(keyWord);

                totalRow = model.Count();

                var query = model.OrderByDescending(x => x.CreatedDate).Skip(page * pageSize).Take(pageSize);

                var reponseData = Mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(query);
                var paginationSet = new PaginationSet<ProductViewModel>()
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
                var model = _productService.GetAll();

                var reponseData = Mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(model);

                var reponse = request.CreateResponse(HttpStatusCode.OK, reponseData);
                return reponse;
            });
        }

        [Route("getByID/{id:int}")]
        [HttpGet]
        public HttpResponseMessage GetByID(HttpRequestMessage request, int id)
        {
            return CreateHttpReponse(request, () =>
            {
                var model = _productService.GetByID(id);

                var reponseData = Mapper.Map<Product, ProductViewModel>(model);

                var reponse = request.CreateResponse(HttpStatusCode.OK, reponseData);
                return reponse;
            });
        }

        [Route("Create")]
        [HttpPost]
        public HttpResponseMessage Create(HttpRequestMessage request, ProductViewModel ProductVm)
        {
            return CreateHttpReponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (!ModelState.IsValid)
                {
                    response = request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    Product Product = new Product();
                    Product.UpdateProduct(ProductVm);
                    Product.CreatedDate = DateTime.Now;
                    _productService.Add(Product);
                    _productService.SavChanges();
                    var responseData = Mapper.Map<Product, ProductViewModel>(Product);
                    response = request.CreateResponse(HttpStatusCode.Created, responseData);

                }
                return response;
            });
        }

        [Route("Update")]
        [HttpPut]
        public HttpResponseMessage Update(HttpRequestMessage request, ProductViewModel ProductVm)
        {
            return CreateHttpReponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (!ModelState.IsValid)
                {
                    response = request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    Product dbProduct = _productService.GetByID(ProductVm.ID);
                    dbProduct.UpdateProduct(ProductVm);
                    dbProduct.UpdatedDate = DateTime.Now;
                    _productService.UpDate(dbProduct);
                    _productService.SavChanges();
                    var responseData = Mapper.Map<Product, ProductViewModel>(dbProduct);
                    response = request.CreateResponse(HttpStatusCode.Created, responseData);

                }
                return response;
            });
        }
        [Route("delete")]
        [HttpDelete]
        public HttpResponseMessage delete(HttpRequestMessage request, int id)
        {
            return CreateHttpReponse(request, () =>
            {
                HttpResponseMessage response = null;

                Product oldProduct = _productService.Delete(id);
                _productService.SavChanges();
                var responseData = Mapper.Map<Product, ProductViewModel>(oldProduct);
                response = request.CreateResponse(HttpStatusCode.OK, responseData);

                return response;
            });
        }
        [Route("deleteMulti")]
        [HttpDelete]
        public HttpResponseMessage deleteMulti(HttpRequestMessage request, string listIDs)
        {
            return CreateHttpReponse(request, () =>
            {
                HttpResponseMessage response = null;
                var ids = new JavaScriptSerializer().Deserialize<List<int>>(listIDs);
                foreach (var id in ids)
                {
                    Product oldProduct = _productService.Delete(id);

                }
                _productService.SavChanges();
                response = request.CreateResponse(HttpStatusCode.OK, ids.Count);

                return response;
            });
        }

    }
}