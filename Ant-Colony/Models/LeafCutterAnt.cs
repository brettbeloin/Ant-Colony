using System;
using System.Collections.Generic;
using System.Text;

namespace Ant_Colony.Models
{
    public class LeafCutterAnt : BaseAnt
    {
        public static new int GatherAmount { get; } = 2;
        public override int BaseDamage { get; } = 3;
    }
}
