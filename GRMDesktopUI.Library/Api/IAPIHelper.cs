
using GRMDesktopUI.Library.Models;
using System.Net.Http;
using System.Threading.Tasks;

namespace GRMDesktopUI.Library.Api
{
    public interface IAPIHelper
    {
        Task<AuthenticatesUserModel> Authenticate(string username, string password);

        Task GetLoggedInUserInfo(string token);

        HttpClient ApiClient { get; }

        void LogOffUser();
    }
}