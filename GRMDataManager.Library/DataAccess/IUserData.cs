using GRMDataManager.Library.Models;
using System.Collections.Generic;

namespace GRMDataManager.Library.DataAccess
{
    public interface IUserData
    {
        List<UserModel> GetUserById(string Id);
    }
}