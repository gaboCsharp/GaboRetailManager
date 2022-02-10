using GRMDesktopUI.Models;
using System.Threading.Tasks;

namespace GRMDesktopUI.Helpers
{
    public interface IAPIHelper
    {
        Task<AuthenticatesUserModel> Authenticate(string username, string password);
    }
}