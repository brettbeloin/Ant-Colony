using System;
using System.Collections.Generic;
using System.Text;

namespace Ant_Colony.Models
{
    public class LeafCutterAnt : BaseAnt
    {
        public static new int GatherAmount { get; } = 2;
        public static new int BaseDamage { get; } = 3;
    }
}
