using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using EktacoTestTask.Entities;
using EktacoTestTask.Services;
using Newtonsoft.Json.Linq;

namespace EktacoTestTask.Controllers
{
    public class ProductController : ApiController
    {
        private IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        // GET api/products
        [HttpGet]
        public HttpResponseMessage Get()
        {
            var products = _productService.GetProducts();
            if (products != null)
            {
                var jsonproducts = JObject.FromObject(products);
                return Request.CreateResponse(HttpStatusCode.OK, jsonproducts.ToString());
            }
            return Request.CreateResponse(HttpStatusCode.NotFound);
        }

        // GET api/products/5
        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            var product = _productService.GetProduct(id);
            if (product != null)
            {
                var jsonproduct = JObject.FromObject(product);
                return Request.CreateResponse(HttpStatusCode.OK, jsonproduct.ToString());
            }
            return Request.CreateResponse(HttpStatusCode.NotFound);
        }

        // POST api/values
        [HttpPost]
        public HttpResponseMessage Post([FromBody]Product item)
        {
            if (_productService.ProductIsValid(item))
            {
                _productService.AddProduct(item);
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            return new HttpResponseMessage(HttpStatusCode.BadRequest);
        }
    }
}
