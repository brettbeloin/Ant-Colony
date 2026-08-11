using System;
using System.Collections.Generic;
using System.Text;

namespace Ant_Colony.Controllers
{
    internal static class ResourceManager
    {
        public static int Food { get; private set; }

        public static int Leaves { get; private set; }

        public static void GatherLeaves(int AmountOfAnts, int AmountPerAnt)
        {
            Leaves += AmountOfAnts * AmountPerAnt;
        }
 
        public static void GatherFood(int AmountOfAnts, int AmountPerAnt)
        {
            Leaves -= AmountOfAnts;
            Food += AmountOfAnts * AmountPerAnt;
        }

        /// <summary>
        /// Function called to eat food, handles reducing the food stores and validates the amount of food needed.
        /// </summary>
        /// <param name="amount">The amount of food you are trying to eat</param>
        /// <returns>Returns the amount of food eaten, if the amount attempted to eat is more than the food avaliable, all the food will be eaten</returns>
        public static int EatFood(int amount)
        { 
            int foodLeft = Food - amount;
            if (foodLeft < 0 )
            {
                amount = Food;
                Food = 0;
            } 
            return amount;
        }
    
    }
}
