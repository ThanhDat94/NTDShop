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
        public HttpResponseMessage Get(HttpRequestMessage request, int page, int pageSize = 20)
        {
            return CreateHttpReponse(request, () =>
            {
                int totalRow = 0;

                var model = _productCategoryService.GetAll();

                totalRow = model.Count();

                var query = model.OrderByDescending(x => x.CreatedDate).Skip(page * pageSize).Take(pageSize);

                var reponseData = Mapper.Map<IEnumerable<ProductCategory>, IEnumerable<ProductCategoryViewModel>>(query);
                var paginationSet = new PaginationSet<ProductCategoryViewModel>()
                {
                    Items = reponseData,
                    Page = page,
                    ToTalCount = totalRow,
                    TotalPages = (int)Math.Ceiling((decimal)(totalRow / pageSize))
                };

                var reponse = request.CreateResponse(HttpStatusCode.OK, paginationSet);
                return reponse;
            });
        }
    }
}