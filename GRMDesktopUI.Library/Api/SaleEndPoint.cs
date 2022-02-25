using GRMDesktopUI.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace GRMDesktopUI.Library.Api
{
    public class SaleEndPoint : ISaleEndPoint
    {
        private IAPIHelper _apiHelper;
        public SaleEndPoint(IAPIHelper apiHelper)
        {
            _apiHelper = apiHelper;
        }


        public async Task PostSale(SaleModel sale)
        {
            using (HttpResponseMessage responde = await _apiHelper.ApiClient.PostAsJsonAsync("api/Sale", sale))
            {
                if (responde.IsSuccessStatusCode)
                {
                    //log successful call?
                }
                else
                {
                    throw new Exception(responde.ReasonPhrase);
                }
            }
        }
    }
}

