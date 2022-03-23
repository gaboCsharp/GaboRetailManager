
using GRMDataManager.Library.Internal.DataAccess;
using GRMDataManager.Library.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRMDataManager.Library.DataAccess
{
    public class UserData : IUserData
    {
        private readonly ISQLDataAccess _sql;

        public UserData()
        {

        }
        public UserData(ISQLDataAccess sql)
        {
            _sql = sql;
        }
        public List<UserModel> GetUserById(string Id)
        {  
            var output = _sql.LoadData<UserModel, dynamic>("spUserLooup", new { Id }, "GRMData");

            return output;
        }
    }
}
