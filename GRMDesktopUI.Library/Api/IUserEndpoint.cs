using GRMDesktopUI.Library.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GRMDesktopUI.Library.Api
{
    public interface IUserEndpoint
    {
        Task<List<UserModel>> GetAll();

        Task<Dictionary<string, string>> GetAllRoles();

        Task AddUserToRole(string userId, string roleName);

        Task RemoveUserToRole(string userId, string roleName);
    }
}