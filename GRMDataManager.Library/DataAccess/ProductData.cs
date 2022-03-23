using GRMDataManager.Library.Internal.DataAccess;
using GRMDataManager.Library.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRMDataManager.Library.DataAccess
{
    public class ProductData : IProductData
    {
        private readonly ISQLDataAccess _sql;

        public ProductData()
        {

        }
        public ProductData(ISQLDataAccess sql)
        {
            _sql = sql;
        }

        public List<ProductModel> GetProducts()
        {
          var output = _sql.LoadData<ProductModel, dynamic>("spProduct_GetAll", new { }, "GRMData");

            return output;
        }

        public ProductModel GetProductById(int productId)
        {
            var output = _sql.LoadData<ProductModel, dynamic>("spProduct_GetById", new { Id = productId }, "GRMData").FirstOrDefault();

            return output;
        }
    }
}
