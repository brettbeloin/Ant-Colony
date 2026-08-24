using Ant_Colony.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ant_Colony.Controllers
{
    public static class EventManager
    {
        private static Random rnd = new Random();

        public static int DungeonEventGetter()
        {
            //Dictionary<DungeonEvents, int> dungeonEvents = new Dictionary<DungeonEvents, int>();

            Array dunEvents = Enum.GetValues(typeof(DungeonEvents));
            return rnd.Next(dunEvents.Length);
        }

        public static int OverworldEventSetter()
        {
            Array overworldEvents = Enum.GetValues(typeof(OverworldEvents));
            return rnd.Next(overworldEvents.Length); 
        }
    }
}
