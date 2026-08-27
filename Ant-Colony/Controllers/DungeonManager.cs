using Ant_Colony.Models;
using Ant_Colony.View;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;

namespace Ant_Colony.Controllers
{
    public class DungeonManager
    {
        List<BaseAnt> ants = AntManager.AntSwarm;
        List<Enemies> enemies;
        int expForLevelUp = 0;
        int totalExp = 0;
        //DO NOT MAKE STATIC
        public void RunDungeon()
        {
            bool playerIsAlive = true;
            do
            {
                playerIsAlive = SimulateDungeon();
            }while (playerIsAlive);

        }

        public bool SimulateDungeon()
        {
            SetupDungeon();
            bool enemiesToFight = enemies.Count != 0;
            int playerHealth = ants.Count();

            do
            {
                // Handle CombatManager things here
                int combatSelection = Menu.SelectCombatOptions();
                switch (combatSelection)
                {
                    case 1:
                        // Get Player Atk and Def Stats
                        List<BaseAnt> attackAnts = Menu.SelectAttackingAnts(ants);
                        int atkTotal = GetAttack(attackAnts);
                        int defTotal = GetDefence(attackAnts);

                        // Attack Enemies
                        Enemies enemyBeingAttacked = Menu.SelectEnemy(enemies);
                        CombatManager.AttackEnemy(atkTotal, enemyBeingAttacked);
                        Menu.Print($"{enemyBeingAttacked} took {atkTotal} damage!", true, ConsoleColor.Green);

                        //Remove enemy if dead and level up
                        CombatManager.PopDeadEnemies(enemies);
                        //if(exp > 0)
                        //{
                        //    IncreaseExp(exp);
                        //    CheckForLevelUp();
                        //}

                        // Attack Player
                        int enemyAtk = GetEnemyAtkTotal(enemies);
                        int damageDelt = CombatManager.AttackPlayer(defTotal, enemyAtk);

                        // Remove random ants depending on damageDelt
                        AntManager.PopRandomAnt(damageDelt);
                        if (damageDelt != 0)
                        {
                            Menu.Print($"{damageDelt} ants were lost!", true, ConsoleColor.Red);
                            playerHealth = ants.Count();
                        }

                        break;
                }

                enemiesToFight = enemies.Count != 0;
            } while (enemiesToFight || playerHealth == 0);
            if (!enemiesToFight)
            {
                int expEarned = CombatManager.DetermineXp();
                Menu.Print($"You earned {expEarned} exp");
                IncreaseExp(expEarned);
                CheckForLevelUp();

                return true;
            }
            else
            {
                Menu.Print($"All your ants have been squashed!", true, ConsoleColor.Red);
                return false;
            }
        }

        public int GetEnemyAtkTotal(List<Enemies> enemies)
        {
            int enemyAtk = 0;
            foreach( Enemies enemy in enemies)
            {
                enemyAtk += enemy.Stats.atk;
            }

            return enemyAtk;
        }

        public int GetDefence(List<BaseAnt> attackAnts)
        {
            int defence = 0;

            foreach (BaseAnt atkAnt in attackAnts)
            {
                foreach (BaseAnt ant in ants)
                {
                    defence += (atkAnt.AntID == ant.AntID) ? atkAnt.BASE_DEFENCE : 0;
                }
            }

            return defence;
        }

        public int GetAttack(List<BaseAnt> attackAnts)
        {
            int attackTotal = 0;
            foreach(BaseAnt ant in attackAnts)
            {
                attackTotal += ant.BASE_DAMAGE;
            }
            return attackTotal;
        }

        public void SetupDungeon()
        {
            int eventNum = EventManager.DungeonEventGetter();

            switch(eventNum){
                case 0:
                    EnemySetup(1);
                    break;
                case 1:
                    EnemySetup(2);
                    break;
                case 2:
                    EnemySetup(3);
                    break;
                case 3:
                    EnemySetup(4);
                    break;
                case 4:
                    EnemySetup(5);
                    break;
                case 5:
                    EnemySetup(6);
                    break;
                case 6:
                    EnemySetup(7);
                    break;
                case 7:
                    EnemySetup(8);
                    break;
                case 8:
                    EnemySetup(9);
                    break;
                default:
                    break;
            }
        }


        public void EnemySetup(int eventNum)
        {
            switch (eventNum)
            {
                case 1: 
                    enemies.Add(new Beetle(new Stats() { atk=5, def=5}, "Beetle", 1, 20, 500, false));
                    enemies.Add(new Beetle(new Stats() { atk=3, def=3}, "Beetle", 1, 20, 500, false));
                    break;
                case 2: 
                    enemies.Add(new Beetle(new Stats() { atk=5, def=5}, "Beetle", 1, 20, 500, false));
                    enemies.Add(new Beetle(new Stats() { atk=3, def=3}, "Beetle", 1, 20, 500, false));
                    enemies.Add(new Beetle(new Stats() { atk=3, def=3}, "Beetle", 1, 20, 500, false));
                    break;
                case 3: 
                    enemies.Add(new Beetle(new Stats() { atk=5, def=5}, "Beetle", 1, 20, 500, false));
                    enemies.Add(new Beetle(new Stats() { atk=6, def=6}, "Beetle", 1, 20, 500, false));
                    enemies.Add(new Beetle(new Stats() { atk=5, def=5}, "Beetle", 1, 20, 500, false));
                    break;
                case 4: 
                    enemies.Add(new Spider(new Stats() { atk=5, def=5}, "Spider", 1, 20, 500, false));
                    enemies.Add(new Spider(new Stats() { atk=3, def=3}, "Spider", 1, 20, 500, false));
                    break;
                case 5: 
                    enemies.Add(new Spider(new Stats() { atk=5, def=5}, "Spider", 1, 20, 500, false));
                    enemies.Add(new Spider(new Stats() { atk=3, def=3}, "Spider", 1, 20, 500, false));
                    enemies.Add(new Spider(new Stats() { atk=3, def=3}, "Spider", 1, 20, 500, false));
                    break;
                case 6: 
                    enemies.Add(new Spider(new Stats() { atk=5, def=5}, "Spider", 1, 20, 500, false));
                    enemies.Add(new Spider(new Stats() { atk=6, def=6}, "Spider", 1, 20, 500, false));
                    enemies.Add(new Spider(new Stats() { atk=5, def=5}, "Spider", 1, 20, 500, false));
                    break;
                case 7: 
                    enemies.Add(new Beetle(new Stats() { atk=4, def=4}, "Beetle", 1, 20, 500, false));
                    enemies.Add(new Spider(new Stats() { atk=4, def=4}, "Spider", 1, 20, 500, false));
                    break;
                case 8: 
                    enemies.Add(new Beetle(new Stats() { atk=6, def=6}, "Beetle", 1, 20, 500, false));
                    enemies.Add(new Spider(new Stats() { atk=6, def=6}, "Spider", 1, 20, 500, false));
                    break;
                case 9: 
                    enemies.Add(new Beetle(new Stats() { atk=5, def=5}, "Beetle", 1, 20, 500, false));
                    enemies.Add(new Beetle(new Stats() { atk=5, def=5}, "Beetle", 1, 20, 500, false));
                    enemies.Add(new Spider(new Stats() { atk=5, def=5}, "Spider", 1, 20, 500, false));
                    enemies.Add(new Spider(new Stats() { atk=5, def=5}, "Spider", 1, 20, 500, false));
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

        public void IncreaseExp(int exp)
        {
            totalExp += exp;
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
                    LevelUpAnts();
                    Menu.Print("Your ants have leveled up!", true, ConsoleColor.Green);
                }
                AnotherLevelUpNeeded = totalExp >= expForLevelUp;
            } while (AnotherLevelUpNeeded);
        }

        public void LevelUpAnts()
        {
            foreach (BaseAnt ant in ants)
            {
                ant.LevelUp();
            }
        }
    }
}
