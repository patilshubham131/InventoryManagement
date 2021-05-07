using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using INV = Inventory.DAL;

namespace Inventory.IBL
{
    public interface IInventoryRepository
    {
        List<INV.Inventory> GetAllInventory();
        void AddInventory(INV.Inventory inventory);
        void DeleteInventory(int Id);
        INV.Inventory GetInventoryById(int id);

        int UpdateInventory(INV.Inventory inventory);
    }
}
