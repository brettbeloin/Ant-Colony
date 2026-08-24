using System;
using System.Collections.Generic;
using System.Text;

namespace Ant_Colony.Models
{
    public struct Stats
    {
        public  int atk { get; set; }
        public int def  { get; set; }
    }
    
    public abstract class Enemies
    {
        public Stats Stats  { get; set; }
        public string Name { get; set; }
        public int Lvl { get; set; }
        public int Health { get; set; }
        public int Exp { get; set; }
        public bool IsBoss { get; set; }
        
        //TODO: talk with jermy and get items

        public Enemies()
        {
            Stats = new Stats {atk =5, def = 5};
            Name = "Stinky";
            Lvl = 1;
            Health = 10;
            Exp = 5;
            IsBoss = false;
        }

        public Enemies(Stats stats, string name, int lvl, int health, int exp, bool isBoss)
        {
            Stats = stats;
            Name = name;
            Lvl = lvl;
            Health = health;
            Exp = exp;
            IsBoss  = isBoss;
        }

        public abstract bool Attack();
        
        public abstract bool Defend();

        public int DetermineLevel()
        {
            throw new NotImplementedException(); 
        }

        public bool DetermineBoss()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return $"Name: {Name}, Level: {Lvl}, Health: {Health}";
        }
    }
}
