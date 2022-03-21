using GRMDataManager.Library.DataAccess;
using GRMDataManager.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace GRMDataManager.Controllers
{
    [Authorize]
    public class InventoryController : ApiController
    {
        public List<InventoryModel> Get()
        {
            InventoryData data = new InventoryData();

            return data.Getinventory();
        }

        public void Post(InventoryModel item)
        {
            InventoryData data = new InventoryData();
            data.SaveInventoryRecord(item);

        }
    }
}