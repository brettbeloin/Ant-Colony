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

        public static int MaxCapacity
        {
            get
            {
                if (AntManager.AntSwarm == null) return 0;
                return AntManager.AntSwarm.Count() * slotsPerAnt;
            }
        }

        private static Random rnd = new Random();
        private static int slotsPerAnt = 1;

 
        public static void ClearInventories()
        {
            GlobalInventory.Clear();
            DungeonInventory.Clear();
        }

        public static void CreateDungeonInventory(int capacity)
        {
            DungeonInventory = new List<BaseItem>(capacity); 
        }

        public static void InitializeCombatInventory()
        {
            CreateDungeonInventory(AntManager.AntSwarm.Count() * slotsPerAnt);           
        }
 

        public static bool TryAddItem(BaseItem itemName)
        {
            if (DungeonInventory.Count() < MaxCapacity)
            {
                DungeonInventory.Add(itemName);
                return true;
            }
            return false;
        }



        public static void CheckInventoryOverflow()
        {
            int currentMax = MaxCapacity;

            while (DungeonInventory.Count() > currentMax && DungeonInventory.Count() > 0)
            {
                int randomIndex = rnd.Next(0, DungeonInventory.Count());
                //BaseItem lostItem = DungeonInventory[randomIndex];

                DungeonInventory.RemoveAt(randomIndex);
            }
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
