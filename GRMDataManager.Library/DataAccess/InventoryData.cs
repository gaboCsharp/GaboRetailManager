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
    public class InventoryData
    {
        private readonly IConfiguration _config;

        public InventoryData()
        {

        }
        public InventoryData(IConfiguration _config)
        {
            this._config = _config;
        }

        public List<InventoryModel> Getinventory()
        {
            SQLDataAccess sql = new SQLDataAccess(_config);

            var output = sql.LoadData<InventoryModel, dynamic>("dbo.spInventory_GetAll", new { }, "GRMData");

            return output;
        }

        public void SaveInventoryRecord(InventoryModel item)
        {
            SQLDataAccess sql = new SQLDataAccess(_config);

            sql.SaveData("dbo.spInventory_Insert", item, "GRMData");
        }
    }
}
