using System;
using System.Collections.Generic;
using System.Text;

namespace Ant_Colony.Models
{
    public class LeafCutterAnt : BaseAnt
    {
        public readonly new int GATHER_AMOUNT = 2;

        public readonly new int BASE_DAMAGE = 3;

        public override string ToString()
        {
            return "Leaf Cutter " + base.ToString();
        }
    }
}
