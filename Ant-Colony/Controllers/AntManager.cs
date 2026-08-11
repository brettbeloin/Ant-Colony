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
        public static int UsedVirtLeafCutterAn { get; private set; } = 0;



        public static void AllocateAnts()
        {
            throw new NotImplementedException();
        }

    }
}
