using Ant_Colony.Models;
namespace Ant_Colony.Controllers;

public static class CombatManager
{
    public static bool IsAlive { get; set; }

    static CombatManager()
    {
        throw new NotImplementedException();
    }

    public static float HealthLostRatio()
    {
        return float.MaxValue;
    }

    public static int DetermineXp(int k, int e, Enemies enemies)
    {
        
        float x = HealthLostRatio();
           int reward = 0;

           if (x <= 0.20f)
           {
               reward = enemies.Exp;
           }
           else
           {
               reward = 5 + (enemies.Exp - 5) * Convert.ToInt32(Math.Pow(e, (-k * (x - 0.20))));
           }
           
           return reward;
    }
}