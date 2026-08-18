using Ant_Colony.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ant_Colony.Controllers
{
    public class DungeonManager
    {
        List<BaseAnt> ants;
        int expForLevelUp = 0;
        int totalExp = 0;
        //DO NOT MAKE STATIC
        public void RunDungeon()
        {
            throw new NotImplementedException();
        }

        public void SetupDungeon()
        {
            throw new NotImplementedException();
        }


        public List<Enemies> EnemySetup()
        {
            throw new NotImplementedException();
        }

        public void SetXpForLevelUp()
        {
            if(expForLevelUp == 0)
            {
                expForLevelUp = 500;
            }
            else
            {
                expForLevelUp += 500;
            }
        }

        public void IncreaseXp(Enemies enemy)
        {
            totalExp += enemy.Exp;
        }

        public void CheckForLevelUp()
        {
            bool AnotherLevelUpNeeded = true;
            do
            {
                if (totalExp >= expForLevelUp)
                {
                    totalExp -= expForLevelUp;
                    SetXpForLevelUp();
                    foreach (BaseAnt ant in ants)
                    {
                        ant.LevelUp();
                    }
                }
                AnotherLevelUpNeeded = totalExp >= expForLevelUp;
            } while (AnotherLevelUpNeeded);
        }
    }
}
