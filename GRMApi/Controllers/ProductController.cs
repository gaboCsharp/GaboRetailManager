using GRMDataManager.Library.DataAccess;
using GRMDataManager.Library.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace GRMApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Cashier")]
    //[Authorize]
    public class ProductController : ControllerBase
    {
        private readonly IConfiguration _config;

        public ProductController(IConfiguration config)
        {
            _config = config;
        }

        // GET api/<controller>
        [HttpGet]
        public List<ProductModel> Get()
        {

            ProductData data = new ProductData(_config);

            return data.GetProducts();
        }
    }
}
