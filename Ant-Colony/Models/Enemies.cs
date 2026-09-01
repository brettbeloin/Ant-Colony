using System;
using System.Collections.Generic;
using System.Text;
using Ant_Colony.Controllers;

namespace Ant_Colony.Models
{
    public struct Stats
    {
        public  int atk { get; set; }
        public int def  { get; set; }
    }
    
    public class Enemies
    {
        public Stats Stats  { get; set; }
        public string Name { get; set; }
        public int Lvl { get; set; }
        public int Health { get; set { field = Math.Clamp(value, 0, MaxHealth); } }

        public int MaxHealth { get; set { field = Math.Max(0, value); } }

        public int Exp { get; set; }
        public bool IsBoss { get; set; }
        
        public Enemies()
        {
            Stats = new Stats {atk =5, def = 5};
            Name = "Stinky";
            Lvl = 1;
            Health = 10;
            MaxHealth = Health;
            Exp = 5;
            IsBoss = false;
        }

        public Enemies(Stats stats, string name, int lvl, int health, int exp, bool isBoss)
        {
            Stats = stats;
            Name = name;
            Lvl = lvl;
            Health = health;
            MaxHealth = health;
            Exp = exp;
            IsBoss  = isBoss;
        }

        public int DetermineLevel()
        {
            
            return Lvl;
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
