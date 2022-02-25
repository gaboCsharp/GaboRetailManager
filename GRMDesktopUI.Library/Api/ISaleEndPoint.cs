using GRMDesktopUI.Library.Models;
using System.Threading.Tasks;

namespace GRMDesktopUI.Library.Api
{
    public interface ISaleEndPoint
    {
        Task PostSale(SaleModel sale);
    }
}