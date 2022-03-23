using GRMDataManager.Library.Models;
using System.Collections.Generic;

namespace GRMDataManager.Library.DataAccess
{
    public interface IInventoryData
    {
        List<InventoryModel> Getinventory();
        void SaveInventoryRecord(InventoryModel item);
    }
}