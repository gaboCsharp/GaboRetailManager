﻿using GRMDataManager.Library.Internal.DataAccess;
using GRMDataManager.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRMDataManager.Library.DataAccess
{
    public class SaleData
    {

        public void SaveSale(SaleModel saleInfo, string cashierId)
        {
            List<SaleDetailDBModel> details = new List<SaleDetailDBModel>();
            ProductData products = new ProductData();
            var taxRate = ConfigHelper.GetTaxRate()/100;

            foreach (var item in saleInfo.SaleDetails)
            {
                var detail = new SaleDetailDBModel
                {
                    ProductId = item.ProductId,
                    Quantity = item.Quantity
                };

               
                var productInfo = products.GetProductById(item.ProductId);
                if(productInfo == null)
                {
                    throw new Exception($"The product Id of { item.ProductId } could not be found in the database. ");
                }

                detail.PurchasePrice = (productInfo.RetailPrice * detail.Quantity);

                if(productInfo.isTaxable)
                {
                    detail.Tax = (detail.PurchasePrice * taxRate);
                }


                details.Add(detail);
            }

            SaleDBModel sale = new SaleDBModel
            {
                SubTotal = details.Sum(x => x.PurchasePrice),
                Tax = details.Sum(x => x.Tax),
                CashierId = cashierId
            };

            sale.Total = sale.SubTotal + sale.Tax;

            SQLDataAccess sql = new SQLDataAccess();
            sql.SaveData<SaleDBModel>("dbo.spSale_Insert", sale, "GRMData");

            sale.Id = sql.LoadData<int, dynamic>("dbo.spSale_Lookup", new { sale.CashierId, sale.SaleDate }, "GRMData").FirstOrDefault();

            foreach (var item in details)
            {
                item.SaleId = sale.Id;
                sql.SaveData("dbo.spSaleDetail_Insert", item, "GRMData");
            }




          



        }

        //public List<ProductModel> GetProducts()
        //{
        //    SQLDataAccess sql = new SQLDataAccess();

        //    var output = sql.LoadData<ProductModel, dynamic>("spProduct_GetAll", new { }, "GRMData");

        //    return output;
        //}
    }
}
