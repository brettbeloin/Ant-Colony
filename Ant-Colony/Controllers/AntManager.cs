using System;
using System.Collections.Generic;
using System.Text;

namespace Ant_Colony.Controllers
{
    public static class AntManager
    {
        public static int VirtWorkerAntAmount { get; 
            private set
            {
                field = Math.Max(0, value);
            } } = 10;
        public static int UsedVirtWorkerAnt { get;
            private set 
            {
                field = Math.Clamp(value, 0, VirtWorkerAntAmount);
            }
        } = 0;

        public static int VirtBulletAntAmount { get; 
            private set { field = Math.Max(value, 0); }
        } = 0;
        public static int UsedVirtBulletAnt { get; 
            private set 
            {
                field = Math.Clamp(value, 0, VirtBulletAntAmount);
            } 
        } = 0;


        public static int VirtLeafCutterAntAmount { get; 
            private set
            {
                field = Math.Max(0, value);
            }
        } = 0;
        public static int UsedVirtLeafCutterAnt { get; 
            private set
            {
                field = Math.Clamp(value, 0, VirtLeafCutterAntAmount);
            } 
        } = 0;


        public static int VirtBroodAntAmount { get; 
            private set
            {
                field = Math.Max(0, value);
            } 
        } = 0;
        public static int UsedVirtBroodAnt { get; 
            private set
            {
                field = Math.Clamp(value, 0, VirtBroodAntAmount);
            }
        } = 0;

        public static int Larvae {  get; 
            private set 
            {
                field = Math.Max(0, value); 
            } 
        } = 0;
        
        public static void AllocateAnts()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Call this Function to increase the amount of larva you have,
        /// remember to call the GrowLarvae() function to turn the larvae into ants
        /// This is limited by the amount of food avaliable
        /// </summary>
        /// <param name="AmountOfAnts">The amount of ants tending the eggs, creating larvae</param>
        /// <param name="LarvaePerAnt">The amount of eggs an ant can tend, thus creating more larvae</param>
        public static void TendLarvae(int AmountOfAnts, int LarvaePerAnt = 1)
        {
            int foodSpent = ResourceManager.EatFood(AmountOfAnts);
            Larvae += foodSpent * LarvaePerAnt;
        }

        public static void GrowLarvae()
        {
            throw new NotImplementedException();
        }

    }
}
