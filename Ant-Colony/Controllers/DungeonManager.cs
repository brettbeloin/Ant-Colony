using Ant_Colony.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Ant_Colony.Controllers
{
    public class DungeonManager
    {
        List<BaseAnt> ants;
        List<Enemies> enemies;
        int expForLevelUp = 0;
        int totalExp = 0;
        //DO NOT MAKE STATIC
        public void RunDungeon()
        {
            SetupDungeon();
            bool enemiesToFight = enemies.Count != 0;
            do
            {
                // Handle CombatManager things here

                enemiesToFight = enemies.Count != 0;
            } while (enemiesToFight);
        }

        public void SetupDungeon()
        {
            int eventNum = EventManager.DungeonEventGetter();

            switch(eventNum){
                case 0:
                    EnemySetup(eventNum);
                    break;
                case 1:
                    break;
                default:
                    break;
            }
        }


        public void EnemySetup(int eventNum)
        {
            switch (eventNum)
            {
                case 0: 
                    enemies.Add(new Beetle(new Stats() { atk=5, def=5, spd=5}, "Beetle", 1, 20, 500, false));
                    enemies.Add(new Beetle(new Stats() { atk = 3, def = 3, spd = 3 }, "Beetle", 1, 20, 500, false));
                    break;
            }
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

        public void IncreaseExp(Enemies enemy)
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
