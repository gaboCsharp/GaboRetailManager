using GRMDataManager.Library.Models;
using System.Collections.Generic;

namespace GRMDataManager.Library.DataAccess
{
    public interface IProductData
    {
        ProductModel GetProductById(int productId);
        List<ProductModel> GetProducts();
    }
}