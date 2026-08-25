using Ant_Colony.View;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ant_Colony.Models
{
    public class BaseItem
    {
        public BaseItem(string? name, string? description, int uses = -1)
        {
            if (name != null) Name = name;
            
            if (description != null) Description = description;
            
            Uses = uses;
        }
        public int Uses { get;
            set
            {
                if (field == -1)
                {
                    field = -1;
                    return;
                }
                field = Math.Max(value, 0);
            }
        } = -1; 

        public string Name
        {
            get;
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    field = "Item";
                    return;
                }
                field = value;
            }
        } = "Item";
 
        public string Description 
        {
            get;
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    field = "This is an item";
                    return;
                }
                field = value;
            }
        } = "This is an Item"; 
        public bool IsConsumable { get { return (Uses != -1); } }


        public virtual void Use()
        {
            Menu.Print("I am being Used!");
        }

        public override string ToString()
        {
            if (IsConsumable)
            {
                return $"{Name} - Uses:{Uses}"; 
            }
            return $"{Name}"; 
        }
    }


}
