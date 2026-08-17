namespace Ant_Colony.Models;

public class Beetle : Enemies
{
    public Beetle(Stats stats, string name, int lvl, int health, int exp, bool isBoss) : base(stats, name, lvl, health, exp, isBoss)
    {
    }
    
    public override int Attack()
    {
        throw new NotImplementedException();
    }

    public override int Defend()
    {
        throw new NotImplementedException();
    }
}