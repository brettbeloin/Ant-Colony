using System;
using System.Collections.Generic;
using System.Text;

namespace Ant_Colony.Models
{
    public class BaseItem
    {
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

        public bool IsConsumable { get { return (Uses != -1); } }
    }
}
