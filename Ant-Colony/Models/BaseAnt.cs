using System;
using System.Collections.Generic;
using System.Text;

namespace Ant_Colony.Models
{
    public class BaseAnt
    {
        public static int GatherAmount { get; } = 1;
        public static int FarmAmount { get; } = 1;
        public static int LarveAmount { get; } = 1;

        public int Level { get; private set { field = Math.Max(0, value); } } = 1;

        public void LevelUp(int levels = 1)
        {
            Level += levels;
        }

        public virtual int BaseDamage { get; } = 1;
        public virtual int BaseDefence { get; } = 1;

        public int GetAttackDamage()
        {
            return this.BaseDamage * Level;
        }

        public int GetDefenceAmount()
        {
            return this.BaseDefence * Level;
        }
    }
}
