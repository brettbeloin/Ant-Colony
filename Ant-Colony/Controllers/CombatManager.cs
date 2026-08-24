using Ant_Colony.Models;

namespace Ant_Colony.Controllers;

public static class CombatManager
{
    public static bool IsAlive { get; set; }

    static CombatManager()
    {
        throw new NotImplementedException();
    }

    

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

    public static int DetermineXp()
    {
        /*
         float x = healthLostRatio (0 to 1)
         int reward = 0;

         if x <= 0.20f:
             reward = base
         else:
             reward = 5 + (base - 5) * e^(-k * (x - 0.20))
       */
        throw new NotImplementedException();
    }
}