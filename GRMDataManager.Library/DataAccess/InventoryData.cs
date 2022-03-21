using GRMDataManager.Library.Internal.DataAccess;
using GRMDataManager.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRMDataManager.Library.DataAccess
{
    public class InventoryData
    {
        public List<InventoryModel> Getinventory()
        {
            SQLDataAccess sql = new SQLDataAccess();

            var output = sql.LoadData<InventoryModel, dynamic>("dbo.spInventory_GetAll", new { }, "GRMData");

            return output;
        }

        public void SaveInventoryRecord(InventoryModel item)
        {
            SQLDataAccess sql = new SQLDataAccess();

            sql.SaveData("dbo.spInventory_Insert", item, "GRMData");
        }
    }
}
