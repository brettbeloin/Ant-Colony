using System;
using System.Collections.Generic;
using System.Text;
using Ant_Colony.Controllers;
using CSC160_ConsoleMenu;

namespace Ant_Colony.View
{
    internal static class Menu
    {
        /// <summary>
        /// Use this to print messages outside of full menu functions
        /// </summary>
        /// <param name="message">The message shown to the player</param>
        /// <param name="withLinebreak">If true adds a new line at the end of the message</param>
        /// <param name="foregroundColor">The color the text is</param>
        /// <param name="backgroundColor">The color the text is highlighted with</param>
        public static void Print(string message, bool withLinebreak = true, ConsoleColor foregroundColor = ConsoleColor.White, ConsoleColor backgroundColor = ConsoleColor.Black)
        {
            Console.ForegroundColor = foregroundColor;
            Console.BackgroundColor = backgroundColor;
            Console.Write(message);
            if (withLinebreak)
            {
                Console.Write("\n");
            }
            Console.ResetColor();
        }
        public static void WelcomePlayer()
        {
            Console.WriteLine("Welcome to:");
            PrintLogo();
        }

        public static void PrintLogo()
        {
            Print(""""""""" 
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
                """"""""", true, ConsoleColor.Red);
        }

        public static void PrintResourceManagementStats()
        {
            throw new NotImplementedException();
        }

        public static int MainMenu(bool hasEvent = false)
        {
            //TODO: ask event manager for event if hasEvent is true
            string[] options = { "Gather Leaves", "Tend Aphid Farm", "Nourish Larvae", "Enter The Dungeon" };
            return CIO.PromptForMenuSelection(options, false);
        } 

        /// <summary>
        /// Prompts the player for an ant type and the amount of ants 
        /// </summary>
        /// <param name="max">the max number of ants that the use can ask for</param>
        /// <returns>returns an array of length 2 that holds an ant type as an int in the first slot, and the amount in the second</returns>
        public static int[] SelectAntTypeAndAmount(int max)
        {
            int antType = SelectAntType("Please select an ant type to allocate");
            int amount = CIO.PromptForInt("Type the amount of ants:", 0, max);
            return [antType, amount];
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
        
        public static int SelectAntType(string prompt = "Please Select an ant type")
        {
            Print(prompt, true, ConsoleColor.Blue);
            string[] antTypes = { "Worker Ant", "Leaf Cutter Ant", "Brood Ant" };
            return CIO.PromptForMenuSelection(antTypes, false);
        }
        
    } 
}
