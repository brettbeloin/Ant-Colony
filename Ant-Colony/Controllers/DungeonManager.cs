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
        List<Enemies> enemies = new List<Enemies>();
        List<Enemies> enemyListForExp = new List<Enemies>();

        int expForLevelUp = 0;
        int totalExp = 0;
        //DO NOT MAKE STATIC
        public void RunDungeon()
        {
            bool playerIsAlive = true;
            bool playerWantsToContinue = true;
            do
            {
                playerIsAlive = SimulateDungeon();
                if (playerIsAlive)
                {
                    playerWantsToContinue = Menu.VerifyAction("Would you like to delve deeper into the Dungeon?");
                }
            }while (playerIsAlive && playerWantsToContinue);

        }

        public bool SimulateDungeon()
        {
            SetupDungeon();
            bool enemiesToFight = enemies.Count != 0;
            int playerHealth = ants.Count();
            int playerMoves = ants.Count();

            do
            {
                Menu.PrintCombatScreen(ants, enemies);
                // Handle CombatManager things here
                int combatSelection = Menu.SelectCombatOptions();
                switch (combatSelection)
                {
                    case 1:
                        // Get Player Atk and Def Stats
                        List<BaseAnt> attackAnts = Menu.SelectAttackingAnts(ants);
                        int atkTotal = 0;
                        int defTotal = 0;
                        if (attackAnts.Count != 0)
                        {
                            atkTotal = GetAttack(attackAnts);
                            defTotal = GetDefence(attackAnts);
                        }

                        // Attack Enemies
                        Enemies enemyBeingAttacked = Menu.SelectEnemy(enemies);
                        CombatManager.AttackEnemy(atkTotal, enemyBeingAttacked);
                        Menu.Print($"{enemyBeingAttacked.Name} took {atkTotal} damage!", true, ConsoleColor.Green);

                        //Remove enemy if dead
                        CombatManager.PopDeadEnemies(enemies);

                        // Attack Player
                        int enemyAtk = GetEnemyAtkTotal(enemies);
                        int damageDelt = CombatManager.AttackPlayer(defTotal, enemyAtk);

                        // Remove random ants depending on damageDelt
                        AntManager.PopRandomAnt(damageDelt);
                        if (damageDelt != 0)
                        {
                            Menu.Print($"{Math.Clamp(damageDelt, 0, 10)} ants were lost!", true, ConsoleColor.Red);
                            playerHealth = ants.Count();
                        }else
                        {
                            Menu.Print("Your block was successful!", true, ConsoleColor.Green);
                        }
                        playerMoves--;

                        break;
                }

                enemiesToFight = enemies.Count != 0;
            } while (enemiesToFight && playerHealth != 0 && playerMoves != 0);
            if (!enemiesToFight)
            {
                int expEarned = 0;
                foreach(Enemies enemy in enemyListForExp)
                {
                    expEarned += CombatManager.DetermineExp(enemy);
                }
                Menu.Print($"You earned {expEarned} exp");
                IncreaseExp(expEarned);
                CheckForLevelUp();

                return true;
            }
            else if(playerHealth != 0)
            {
                Menu.Print($"All your ants have been squashed!", true, ConsoleColor.Red);
                return false;
            }
            else
            {
                Menu.Print("You've run out of moves and have to sacrifice an ant to live.");
                AntManager.PopRandomAnt();
            }
            return false;
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

        public static int GetDefence(List<BaseAnt> attackAnts)
        {
            int defence = 0;
            bool antIsAtk = false;
            List <BaseAnt> defAnts = new List<BaseAnt>();

            foreach (BaseAnt ant in AntManager.AntSwarm)
            {
                antIsAtk = false;
                foreach (BaseAnt atkAnt in attackAnts)
                {
                    if(ant.AntID == atkAnt.AntID)
                    {
                        antIsAtk = true;
                        break;
                    }
                }
                if (!antIsAtk)
                {
                    defAnts.Add(ant);
                }
            }

            foreach(BaseAnt ant in defAnts)
            {
                defence += ant.BASE_DEFENCE;
            }


            return defence;
        }

        public static int GetAttack(List<BaseAnt> attackAnts)
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
            enemyListForExp = enemies.ToList();
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
