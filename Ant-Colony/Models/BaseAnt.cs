using System;
using System.Collections.Generic;
using System.Text;

namespace Ant_Colony.Models
{
    public class BaseAnt
    {
        private static int nextID = 0;

        public readonly int GATHER_AMOUNT = 1; 
        public readonly int FARM_AMOUNT = 1;
        public readonly int LARVAE_AMOUNT = 1;
        public int Level { get; private set { field = Math.Max(0, value); } } = 1;

        public int AntID { get; } = nextID++;

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

        public override string ToString()
        {
            return $"Ant (Level-{Level})"; 
        }

        public static bool operator ==(BaseAnt ant1,  BaseAnt ant2)
        {
            return ant1.AntID == ant2.AntID;
        }
        
        public static bool operator !=(BaseAnt ant1,  BaseAnt ant2)
        {
            return ant1.AntID != ant2.AntID;
        }

    }
}
