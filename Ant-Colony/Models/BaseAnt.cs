using System;
using System.Collections.Generic;
using System.Net.Security;
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

        public static int BaseDamage { get; } = 1;
        public static int BaseDefence { get; } = 1;

        public int GetAttackDamage()
        {
            return BaseDamage * Level;
        }

        public int GetDefenceAmount()
        {
            return BaseDefence * Level;
        }
    }
}
