using System;
using System.Collections.Generic;
using System.Text;

namespace Ant_Colony.Models
{
    public struct Stats
    {
        public  int atk { get; set; }
        public int def  { get; set; }
        public int spd { get; set; };
    }
    
    public abstract class Enemies
    {
        public Stats stats  { get; set; }
        public string name { get; set; }
        public int lvl { get; set; }
        public int health { get; set; }

        public Enemies()
        {
            stats = new Stats {atk =5, def = 5, spd = 5};
            name = "Stinky";
            lvl = 1;   
            health = 10;
        }

        public Enemies(Stats stats, string name, int lvl, int health)
        {
            this.stats = stats;
            this.name = name;
            this.lvl = lvl;
            this.health = health;
        }

        public abstract bool Attack();
        
        public abstract bool Defend();

        public override string ToString()
        {
            throw new NotImplementedException("Not implemented");
        }
    }
}
