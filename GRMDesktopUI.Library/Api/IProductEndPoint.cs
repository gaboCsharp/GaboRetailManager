using GRMDesktopUI.Library.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GRMDesktopUI.Library.Api
{
    public interface IProductEndPoint
    {
        Task<List<ProductModel>> GetAll();
    }
}