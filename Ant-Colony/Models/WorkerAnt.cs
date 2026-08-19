using System;
using System.Collections.Generic;
using System.Text;

namespace Ant_Colony.Models
{
    public class WorkerAnt : BaseAnt
    {
        public static new int FarmAmount { get; } = 1;
        public override int BaseDefence { get; } = 3;
    }
}
