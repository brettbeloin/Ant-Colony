using Ant_Colony.Controllers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ant_Colony.Models.items
{
    public class DivineNectar : BaseItem
    {
        public DivineNectar(string? name, string? description, int uses = -1) : base("Divine Nectar", "The nectar of the gods nourishes the young", 1) { }
        public override void Use()
        {
            AntManager.Larvae += 5;
        }
    }
}
