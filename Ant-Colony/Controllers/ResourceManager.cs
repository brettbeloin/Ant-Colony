using System;
using System.Collections.Generic;
using System.Text;

namespace Ant_Colony.Controllers
{
    public static class ResourceManager
    {
        public static int Food { get;
            private set { field = Math.Max(0, value); }
        } = 0;

        public static int Leaves { get;
            private set { field = Math.Max(0, value); }
        } = 0; 

        /// <summary>
        /// Call this to increase the amount of leaves stored
        /// </summary>
        /// <param name="AmountOfAnts">The amount of ants you spend to get leaves</param>
        /// <param name="AmountPerAnt">The effeciency of the ants getting leaves</param>
        public static void GatherLeaves(int AmountOfAnts, int AmountPerAnt = 1)
        {
            Leaves += (AmountOfAnts * AmountPerAnt) + AntManager.GlobalWorkBonus;
        }
 
        /// <summary>
        /// Call this to increase the amount of food used by the player. 
        /// This costs leaves and gains food, the amount of food gained is limited by the amount of leaves consumed and Amount per Leaf.
        /// The amout of leaves consumed is limited by the amount of leaves held and the amount of ants used  
        /// </summary>
        /// <param name="AmountOfAnts">Every ant tries to grab a leaf, then spend all the leaves that the ants get to turn into food</param>
        /// <param name="AmountPerLeaf">The effeciency of the leaves turning into food</param>
        public static void GatherFood(int AmountOfAnts, int AmountPerLeaf = 1)
        {
            int leavesConsumed = Math.Min(AmountOfAnts, Leaves);
            Leaves -= leavesConsumed;
            Food += (leavesConsumed * AmountPerLeaf) + AntManager.GlobalWorkBonus;
        }

        /// <summary>
        /// Function called to eat food, handles reducing the food stores and validates the amount of food needed.
        /// </summary>
        /// <param name="amount">The amount of food you are trying to eat</param>
        /// <returns>Returns the amount of food eaten, if the amount attempted to eat is more than the food avaliable, all the food will be eaten</returns>
        public static int EatFood(int amount)
        { 
            int foodConsumed = Math.Min(amount, Food);
            Food -= foodConsumed;
            return foodConsumed;
        }
        
        /// <summary>
        /// Resets the food and leaves to 0
        /// </summary>
        public static void ResetResources()
        {
            Food = 0;
            Leaves = 0;
        }

        public static void SetDemoResourceAmounts()
        {
            Food = 20;
            Leaves = 20;
        }
    }
}
