﻿using GRMDataManager.Library.DataAccess;
using GRMDataManager.Library.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Security.Claims;

namespace GRMApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SaleController : ControllerBase
    {
        private readonly IConfiguration _config;

        public SaleController(IConfiguration config)
        {
            _config = config;
        }

        [Authorize(Roles = "Cashier")]
        public void Post(SaleModel sale)
        {
            SaleData data = new SaleData(_config);
            string userId = User.FindFirst(ClaimTypes.NameIdentifier).Value; //old way - RequestContext.Principal.Identity.GetUserId();

            data.SaveSale(sale, userId);
        }


        [Authorize(Roles = "Admin,Manager")]
        [Route("GetSalesReport")]
        public List<SaleReportModel> GetSalesReport()
        {
            SaleData data = new SaleData(_config);

            return data.GetSaleReport();
        }

        //public List<ProductModel> Get()
        //{

        //    ProductData data = new ProductData();

        //    return data.GetProducts();
        //}
    }
}
