using System;
using System.Collections.Generic;
using System.Text;
using Ant_Colony.Models;

namespace Ant_Colony.Controllers
{
    public static class ItemManager
    {
        public static List<BaseItem> GlobalInventory = new List<BaseItem>();
        public static List<BaseItem> DungeonInventory = new List<BaseItem>();

        public static void CreateDungeonInventory(int capacity)
        {
            DungeonInventory = new List<BaseItem>(capacity); 
        }

        public static void ClearInventories()
        {
            GlobalInventory.Clear();
            DungeonInventory.Clear();
        }

        public static void MoveDungeonInventoryToGlobalInventory()
        {
            foreach (BaseItem item in DungeonInventory) 
            {
                GlobalInventory.Append(item);
            }
            DungeonInventory.Clear();
        }
    }
}
