using Ant_Colony.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ant_Colony.Controllers
{
    public static class EventManager
    {
        public static int DungeonEventGetter()
        {
            Random rnd = new Random();
            Array dunEvents = Enum.GetValues(typeof(DungeonEvents));

            return rnd.Next(dunEvents.Length);
        }
    }
}
