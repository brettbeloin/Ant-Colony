namespace Ant_Colony.Models;

public class Spider : Enemies
{
    public Spider(Stats stats, string name, int lvl, int health, int exp, bool isBoss) : base(stats, name, lvl, health, exp,  isBoss)
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