using System;
using System.Collections.Generic;
using System.Text;
using CSC160_ConsoleMenu;

namespace Ant_Colony.View
{
    internal static class Menu
    {
        public static void PrintLogo()
        {
            //TODO: get a fancy ascii ant farm text to put here
            Console.WriteLine("ant-farm");
        }

        public static void PrintResourceManagementStats()
        {
            throw new NotImplementedException();
        }

        public static int MainMenu(bool hasEvent = false)
        { 
            //TODO: ask event manager for event if hasEvent is true
            throw new NotImplementedException();
        } 

        public static int SelectAntAllocationAmounts()
        {
            throw new NotImplementedException();
        }

        public static int SelectCombatOptions()
        {
            throw new NotImplementedException();
        }

        public static void PrintItemsInInventory()
        {
            throw new NotImplementedException();
        }

        public static int SelectItem(List<String> itemList)
        {
            //TODO: make the inputed list of items of the item class when that is implemented
            throw new NotImplementedException();
        }

        
        public static void PrintCombatScreen()
        {
            throw new NotImplementedException();
        }

        
    } 
}
