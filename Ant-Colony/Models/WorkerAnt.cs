using System;
using System.Collections.Generic;
using System.Text;

namespace Ant_Colony.Models
{
    public class WorkerAnt : BaseAnt
    {
        public readonly new int FARM_AMOUNT = 1;
        public  readonly new int BASE_DEFENCE = 3;

        public override string ToString()
        {
            return "Worker " + base.ToString();
        }
    }
}
