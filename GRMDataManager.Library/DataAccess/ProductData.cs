﻿using GRMDataManager.Library.Internal.DataAccess;
using GRMDataManager.Library.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRMDataManager.Library.DataAccess
{
    public class ProductData
    {
        private readonly IConfiguration _config;

        public ProductData()
        {

        }
        public ProductData(IConfiguration config)
        {
            _config = config;
        }

        public List<ProductModel> GetProducts()
        {
            SQLDataAccess sql = new SQLDataAccess(_config);

            var output = sql.LoadData<ProductModel, dynamic>("spProduct_GetAll", new { }, "GRMData");

            return output;
        }

        public ProductModel GetProductById(int productId)
        {
            SQLDataAccess sql = new SQLDataAccess(_config);

            var output = sql.LoadData<ProductModel, dynamic>("spProduct_GetById", new { Id = productId }, "GRMData").FirstOrDefault();

            return output;
        }
    }
}
