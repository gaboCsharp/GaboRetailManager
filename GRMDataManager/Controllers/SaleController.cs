using GRMDataManager.Library.DataAccess;
using GRMDataManager.Library.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace GRMDataManager.Controllers
{
    [Authorize]
    public class SaleController : ApiController
    {
    
        public void Post(SaleModel sale)
        {
            SaleData data = new SaleData();
            string userId = RequestContext.Principal.Identity.GetUserId();

            data.SaveSale(sale, userId);
        }


        //public List<ProductModel> Get()
        //{

        //    ProductData data = new ProductData();

        //    return data.GetProducts();
        //}
    }
}