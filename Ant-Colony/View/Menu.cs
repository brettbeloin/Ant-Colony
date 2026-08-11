using System;
using System.Collections.Generic;
using System.Text;
using CSC160_ConsoleMenu;

namespace Ant_Colony.View
{
    internal static class Menu
    {
        public static void WelcomePlayer()
        {
            Console.WriteLine("Welcome to:");
            PrintLogo();
        }

        public static void PrintLogo()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(""""""""" 
                       db                                   ,ad8888ba,                88                                         
                      d88b                      ,d         d8"'    `"8b               88                                         
                     d8'`8b                     88        d8'                         88                                         
                    d8'  `8b      8b,dPPYba,  MM88MMM     88              ,adPPYba,   88   ,adPPYba,   8b,dPPYba,   8b       d8  
                   d8YaaaaY8b     88P'   `"8a   88        88             a8"     "8a  88  a8"     "8a  88P'   `"8a  `8b     d8'  
                  d8""""""""8b    88       88   88        Y8,            8b       d8  88  8b       d8  88       88   `8b   d8'   
                 d8'        `8b   88       88   88,        Y8a.    .a8P  "8a,   ,a8"  88  "8a,   ,a8"  88       88    `8b,d8'    
                d8'          `8b  88       88   "Y888       `"Y8888Y"'    `"YbbdP"'   88   `"YbbdP"'   88       88      Y88'     
                                                                                                                        d8'      
                                                                                                                       d8'        
                """"""""");
            Console.ResetColor();
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

        public static void PrintItems(List<String> itemList)
        {
            //TODO: replace the string with items once the class is implemented
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
