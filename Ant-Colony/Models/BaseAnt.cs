using System;
using System.Collections.Generic;
using System.Text;

namespace Ant_Colony.Models
{
    public class BaseAnt
    {
        public readonly int GATHER_AMOUNT = 1; 
        public readonly int FARM_AMOUNT = 1;
        public readonly int LARVAE_AMOUNT = 1;

        public int Level { get; private set { field = Math.Max(0, value); } } = 1;

        public void LevelUp(int levels = 1)
        {
            Level += levels;
        }

        public readonly int BASE_DAMAGE = 1;
        public readonly int BASE_DEFENCE = 1;

        public int GetAttackDamage()
        {
            return this.BASE_DAMAGE * Level;
        }

        public int GetDefenceAmount()
        {
            return this.BASE_DEFENCE * Level;
        }
    }
}
