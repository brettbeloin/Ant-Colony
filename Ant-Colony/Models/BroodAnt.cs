using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Ant_Colony.Models
{
    public class BroodAnt : BaseAnt
    {
        public readonly new int LARVAE_AMOUNT = 2;
        public readonly new int BASE_DAMAGE  = 2;
        public readonly new int BASE_DEFENCE = 2;
    }
}
