using System;
using System.Collections.Generic;
using System.Text;

namespace Ant_Colony.Controllers
{
    internal static class AntManager
    {
        public static int VirtWorkerAntAmount { get; private set; } = 10;
        public static int UsedVirtWorkerAnt { get; private set; } = 0;

        public static int VirtBulletAntAmount { get; private set; } = 0;
        public static int UsedVirtBulletAnt { get; private set; } = 0;


        public static int VirtLeafCutterAntAmount { get; private set; } = 0;
        public static int UsedVirtLeafCutterAnt { get; private set; } = 0;


        public static int VirtBroodAntAmount { get; private set; } = 0;
        public static int UsedVirtBroodAnt { get; private set; } = 0;

        public static int Larve {  get; private set; } = 0;
        
        public static void AllocateAnts()
        {
            throw new NotImplementedException();
        }

        public static void TendLarve(int AmountOfAnts, int LarvePerAnt = 1)
        {
            int foodSpent = ResourceManager.EatFood(AmountOfAnts);
            Larve += foodSpent * LarvePerAnt;
        }

    }
}
