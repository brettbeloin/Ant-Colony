using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Ant_Colony.Models
{
    public class BroodAnt : BaseAnt
    {
        public BroodAnt()
        {
            LARVAE_AMOUNT = 2;
            BASE_DEFENCE = 2;
            BASE_DAMAGE = 2;
        }

        public override string ToString()
        {
            return "Brood " +base.ToString();
        }
    }
}
