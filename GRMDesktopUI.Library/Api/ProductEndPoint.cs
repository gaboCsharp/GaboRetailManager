using GRMDesktopUI.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace GRMDesktopUI.Library.Api
{
    public class ProductEndPoint : IProductEndPoint
    {
        private IAPIHelper _apiHelper;
        public ProductEndPoint(IAPIHelper apiHelper)
        {
            _apiHelper = apiHelper;
        }

        public async Task<List<ProductModel>> GetAll()
        {
            using (HttpResponseMessage responde = await _apiHelper.ApiClient.GetAsync("api/Product"))
            {
                if (responde.IsSuccessStatusCode)
                {
                    var result = await responde.Content.ReadAsAsync<List<ProductModel>>();
                    return result;
                }
                else
                {
                    throw new Exception(responde.ReasonPhrase);
                }
            }
        }
    }
}
