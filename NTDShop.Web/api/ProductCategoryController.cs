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
        private IProductCategoryService _productCategoryService;

        public ProductCategoryController(IErrorService errorService, IProductCategoryService productCategoryService) : base(errorService)
        {
            this._productCategoryService = productCategoryService;
        }

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
                    _productCategoryService.Add(productCategory);
                    _productCategoryService.SavChanges();
                    var responseData = Mapper.Map<ProductCategory, ProductCategoryViewModel>(productCategory);
                    response = request.CreateResponse(HttpStatusCode.Created, responseData);
                    
                }
                return response;
            });
        }
    }
}