using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inventory.IBL;
using Inventory.DAL;

namespace Inventory.BAL
{
    public class InventoryRepository : IInventoryRepository
    {
        InventoryEntities entity;
        public InventoryRepository()
        {
            entity = new InventoryEntities();
        }

        public void AddInventory(DAL.Inventory inventory)
        {
            entity.Inventories.Add(inventory);
            entity.SaveChanges();
        }

        public void DeleteInventory(int Id)
        {
            DAL.Inventory inventory = entity.Inventories.Where(inv => inv.Id == Id).FirstOrDefault();

            if (inventory != null)
            {
                entity.Inventories.Remove(inventory);
                entity.SaveChanges();
            }

        }

        public List<DAL.Inventory> GetAllInventory()
        {
            return entity.Inventories.ToList();
        }

        public DAL.Inventory GetInventoryById(int id)
        {
            return entity.Inventories.Where(inv => inv.Id == id).FirstOrDefault();
        }

        public int UpdateInventory(DAL.Inventory inventory)
        {
            DAL.Inventory sampleInv = entity.Inventories.Find(inventory.Id);
            if (sampleInv != null)
            {
                entity.Entry(sampleInv).CurrentValues.SetValues(inventory);
                entity.SaveChanges();
                return inventory.Id;
            }
            return 0;
            
        }
    }
}
