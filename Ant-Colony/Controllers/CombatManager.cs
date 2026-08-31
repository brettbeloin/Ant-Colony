using Ant_Colony.Models;
using Ant_Colony.View;

namespace Ant_Colony.Controllers;

public static class CombatManager
{
    public static bool IsAlive { get; set; }

    public static void AttackEnemy(int playerDamage, Enemies enemy)
    {
        enemy.Health -= playerDamage;
    }

    public static int AttackPlayer(int playerDefence, int enemyDamage)
    {
        if(playerDefence - enemyDamage < 0)
        {
            return enemyDamage - playerDefence;
        } else
        {
            return 0;
        }
    }

    public static void PopDeadEnemies(List<Enemies> enemies)
    {
        //int totalExp = 0;
        
        List<Enemies> deadenemies = new List<Enemies>();
        List<Enemies> copyOfEnemies = enemies;
        foreach(Enemies enemy in enemies)
        {
            if (enemy.Health <= 0)
            {
                deadenemies.Add(enemy);
                //int exp = DetermineXp();
                Menu.Print($"{enemy.Name} has been defeated!");
                //totalExp += exp;
            }
        }
        for (int i = 0; i < copyOfEnemies.Count-1; i++)
        {
            if (copyOfEnemies[i].Health <= 0)
            {
                enemies.Remove(copyOfEnemies[i]);
            }
        }

        //return totalExp;
    }

    private static float HealthLossRatio()
    {

        return float.PositiveInfinity;
    }

    /// <summary>
    /// decays the amount if XP that is earned based on how much health was lost.
    /// </summary>
    /// <param name="enemies">The current ennemy that is being fought.</param>
    /// <returns> The modified XP value.</returns>
    public static int DetermineExp(Enemies enemies)
    {
        float healthLoss = HealthLossRatio();
        int rateOfDecay = (enemies.IsBoss) ? 5 : 3;
        int reward = 0;

        if (healthLoss <= .20f)
        {
            reward = enemies.Exp;
        }
        else
        {
            reward = Double.ConvertToInteger<Int32>(5 + enemies.Exp * Math.Pow(Math.E, -rateOfDecay * (healthLoss - .20f)));
        }

        return reward;
    }
}