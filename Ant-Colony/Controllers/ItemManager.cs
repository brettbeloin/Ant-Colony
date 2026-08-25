using System;
using System.Collections.Generic;
using System.Text;

namespace Ant_Colony.Controllers
{
    public static class ItemManager
    {
        private static List<string> combatInventory = new List<string>();
        private static Random rnd = new Random();
        private static int slotsPerAnt = 1;

        private static List<BaseAnt> activeAnts;

        public static List<string> CombatInventory => combatInventory;

        public static void InitializeCombatInventory(List<BaseAnt> liveAntList)
        {
            activeAnts = liveAntList;
        }

        public static void ResetCombatInventory()
        {
            combatInventory.Clear();
        }

        public static int MaxCapacity
        {
            get
            {
                if (activeAnts == null) return 0;
                return activeAnts.Count * slotsPerAnt;
            }
        }

        public static bool TryAddItem(string itemName)
        {
            if (combatInventory.Count < MaxCapacity)
            {
                combatInventory.Add(itemName);
                return true;
            }
            return false;
        }

        public static void CheckInventoryOverflow()
        {
            int currentMax = MaxCapacity;

            while (combatInventory.Count > currentMax && combatInventory.Count > 0)
            {
                int randomIndex = rnd.Next(0, combatInventory.Count);
                string lostItem = combatInventory[randomIndex];

                combatInventory.RemoveAt(randomIndex);
            }
        }
    }
}
