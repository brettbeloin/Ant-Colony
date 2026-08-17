using System;
using System.Collections.Generic;
using System.Text;

namespace Ant_Colony.Models
{
    public class BroodAnt : BaseAnt
    {
        public static new int LarveAmount { get; } = 2;
        public static new int BaseDamage { get; } = 2;
        public static new int BaseDefence { get; } = 2;
    }
}
