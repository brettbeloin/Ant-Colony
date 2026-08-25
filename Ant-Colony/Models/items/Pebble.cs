using Ant_Colony.Controllers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ant_Colony.Models.items
{
    public class Pebble : BaseItem
    {
        public Pebble() : base("Pebble", "A small grey rock, It inspires the ants to work harder", 1) { }
        public override void Use()
        {
            AntManager.GlobalWorkBonus += 1;
        }
    }
}
