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
    public class InventoryData : IInventoryData
    {
        private readonly IConfiguration _config;
        private readonly ISQLDataAccess _sql;

        public InventoryData()
        {

        }
        public InventoryData(IConfiguration _config, ISQLDataAccess sql)
        {
            this._config = _config;
            _sql = sql;
        }

        public List<InventoryModel> Getinventory()
        {
            var output = _sql.LoadData<InventoryModel, dynamic>("dbo.spInventory_GetAll", new { }, "GRMData");

            return output;
        }

        public void SaveInventoryRecord(InventoryModel item)
        {
            _sql.SaveData("dbo.spInventory_Insert", item, "GRMData");
        }
    }
}
