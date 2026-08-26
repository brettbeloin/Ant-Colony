using System;
using System.Collections.Generic;
using System.Text;

namespace Ant_Colony.Models
{
    public class LeafCutterAnt : BaseAnt
    {
        public LeafCutterAnt()
        {
            GATHER_AMOUNT = 2;
            BASE_DAMAGE = 3;
        }

        public override string ToString()
        {
            return "Leaf Cutter " + base.ToString();
        }
    }
}
