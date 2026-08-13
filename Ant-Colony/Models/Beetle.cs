namespace Ant_Colony.Models;

public class Beetle : Enemies
{
    public Beetle(Stats stats, string name, int lvl, int health, int exp, bool isBoss) : base(stats, name, lvl, health, exp, isBoss)
    {
    }
    
    public override bool Attack()
    {
        throw new NotImplementedException();
    }

    public override bool Defend()
    {
        throw new NotImplementedException();
    }
}