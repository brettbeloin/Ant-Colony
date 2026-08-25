using Ant_Colony.Models;
using Ant_Colony.View;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ant_Colony.Controllers
{
    public static class AntManager
    { 
        public enum AntTypes
        {
            WORKER,
            LEAF_CUTTER,
            BROOD,
        }
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
            set 
            {
                field = Math.Max(0, value); 
            } 
        } = 0;

 
        public static int GlobalWorkBonus
        {
            get {
                int currentBonus = field;
                field = Math.Max(0, field - 1);
                return currentBonus; 
            }
            set { field = Math.Max(0, value); }
        } = 0;

        public static List<BaseAnt> AntSwarm { get; private set; } = new List<BaseAnt>();

        public static void CreateAntSwarm()
        {   
            List<BaseAnt> swarm = new List<BaseAnt>();
            while (swarm.Count < 10)
            {
                int[] antTypeAndAmount = Menu.SelectAntTypeAndAmount(10);
                for(int i = 0; i < antTypeAndAmount[1]; i++)
                {
                    swarm.Add(InstantiateAnt(antTypeAndAmount[0]));
                }
            }
        }

        public static int CountAnts(bool totalAnts = false)
        {
            int count = 0;
            count += VirtWorkerAntAmount;
            count += VirtLeafCutterAntAmount;
            count += VirtBroodAntAmount;

            if (totalAnts) return count;

            count -= UsedVirtWorkerAnt;
            count -= UsedVirtLeafCutterAnt;
            count -= UsedVirtBroodAnt;

            return count;
        }


        public static void PopRandomAnt(int amountOfAnts = 1)
        {
            Random rng = new Random();
            for(int i = 0; i < amountOfAnts; i++)
            {
                int randIndex = rng.Next(amountOfAnts);
                AntSwarm.RemoveAt(randIndex); 
            }
        } 

        public static BaseAnt InstantiateAnt(int antType)
        {
            switch (antType) {
                case (int)AntTypes.WORKER: return new WorkerAnt();
                case (int)AntTypes.LEAF_CUTTER: return new LeafCutterAnt();
                case (int)AntTypes.BROOD: return new BroodAnt();
                default: return new BaseAnt();
            }
        }

        public static Type GetAntTypeFromInt(int antType = -1)
        {
            switch (antType)
            {
                case (int)AntTypes.WORKER: return typeof(WorkerAnt);
                case (int)AntTypes.LEAF_CUTTER: return typeof(LeafCutterAnt);
                case (int)AntTypes.BROOD:return typeof(BroodAnt);
                default: return typeof(BaseAnt);
            }
        }

        /// <summary>
        /// Askes for an ant type and then only lets you allocate a valid amount of ants to it
        /// </summary>
        /// <returns>returns an array of length 2, where the first number is the ant type, and the second is,
        /// if the use quits, it returns [0, 0]</returns>
        public static int[] AllocateAnts()
        {

            bool reallocate = false;
            int antType = 0;
            int allocation = 0;

            int leafCuttersAllocated = 0;
            int broodsAllocated = 0;
            int leafCuttersAllocates = 0;
            do
            {
                reallocate = false;
                antType = Menu.SelectAntType(AllowQuit:true)-1;
                leafCuttersAllocated = 0;
                broodsAllocated = 0;
                leafCuttersAllocates = 0;
                try
                { 
                    switch (antType)
                    {
                        case -1:
                            return [0, 0];
                        case (int)AntTypes.LEAF_CUTTER:
                            allocation = Menu.SelectAmount(VirtLeafCutterAntAmount - UsedVirtLeafCutterAnt);
                            leafCuttersAllocates = allocation;
                            break;
                        case (int)AntTypes.BROOD:
                            allocation = Menu.SelectAmount(VirtBroodAntAmount - UsedVirtBroodAnt);
                            broodsAllocated = allocation;
                            break;
                        default: 
                            allocation = Menu.SelectAmount(VirtWorkerAntAmount - UsedVirtWorkerAnt);
                            leafCuttersAllocated = allocation;
                            break;
                    }
                    if (allocation <= 0)
                    {
                        reallocate = !Menu.VerifyAction("Are you sure you do not want to allocate any ants?");
                    }
                }
                catch (ArgumentException ae)
                {
                    Menu.Print("You have used all of the ants of this type already, please pick a different kind", true, ConsoleColor.Red);
                    reallocate = true;
                    continue;
                }


            } while(reallocate);
            UsedVirtWorkerAnt += leafCuttersAllocated;
            UsedVirtLeafCutterAnt += leafCuttersAllocated;
            UsedVirtBroodAnt += broodsAllocated;

            return [antType, allocation];
        }
        public static void DeallocateAnts()
        {
            UsedVirtBroodAnt = 0;
            UsedVirtLeafCutterAnt = 0;
            UsedVirtWorkerAnt = 0; 
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
            ResourceManager.EatFood(foodSpent);
            Larvae += foodSpent * LarvaePerAnt + GlobalWorkBonus;
        }

        
        public static void GrowLarvae()
        {
            while (Larvae > 0)
            {
                Menu.Print("It is time to for the larvae to grow into ants.\nPlease choose what type and amount of ant they should grow into.");
                int[] promptResults = Menu.SelectAntTypeAndAmount(Larvae);
                int antType = promptResults[0];
                int antAmount = promptResults[1];

                switch (antType) 
                {
                    case (int)AntTypes.WORKER:
                        VirtWorkerAntAmount += antAmount;
                        Larvae-= antAmount;
                        break;

                    case (int)AntTypes.LEAF_CUTTER:
                        VirtLeafCutterAntAmount += antAmount;
                        Larvae-= antAmount;
                        break;

                    case (int)AntTypes.BROOD:
                        VirtBroodAntAmount += antAmount;
                        Larvae-= antAmount;
                        break;
                    default: break;
                }
            }
        }

    }
}
