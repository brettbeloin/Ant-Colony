using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Ant_Colony.Controllers;
using Ant_Colony.Models;
using CSC160_ConsoleMenu;

namespace Ant_Colony.View
{
    internal static class Menu
    {


        public static void ClearScreen()
        {
            Console.Clear();
        }

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

        /// <summary>
        /// prints a bar :
        /// -------------
        /// </summary>
        /// <param name="length">The length of the bar</param>
        /// <param name="color">The color of the bar, Defaults to white</param>
        public static void PrintBar(uint length = 10, ConsoleColor color = ConsoleColor.White)
        {
            
            string bar = "";
            for (int i = 0; i < length; i++)
            {
                bar += "-";
            }
            Print(bar, true, color);
        }

        /// <summary>
        /// Use this to print out a multitude of stats,
        /// You may be wondering why this isnt 'PrintResourceManagerStats' and just grabs things from the static classes.
        /// The reason it is not like that is to maintain class independence, It is hard to keep things distinct for a game,
        /// but I would like for as many pieces to be independent as possible so that we can reuse pieces and keep things clean.
        /// </summary>
        /// <param name="stats">an array of strings that will be printed as stats, I recomend using string interpolation for nice formating</param>
        /// <param name="color">The color that the stats will be printed in, will be Yellow by default, Yellow will be my 'information' color</param>
        public static void PrintStats(string[] stats, ConsoleColor color = ConsoleColor.Yellow)
        {
            PrintBar(20, color);
            foreach (string stat in stats)
            {
                Print(stat, true, color);
            }
            PrintBar(20, color);
        }

        /// <summary>
        /// This is the main menu option select for the resource manager
        /// This prompts the player to Gather leaves, tend aphid farms, nourish larvae, or enter the dungeon + your extra options
        /// </summary>
        /// <param name="extraOptions">Null by default, extra options asks the player for more</param>
        /// <returns>returns an int from 1 to the amount of options avaliable</returns>
        public static int MainMenu(string[]? extraOptions = null )
        {
            Print("Please choose an action", true, ConsoleColor.Blue);
            List<string> options = new List<string>{"Gather Leaves", "Tend Aphid Farm", "Nourish Larvae", "Enter The Dungeon", "Use Item"};
            if (extraOptions != null)
            {
                foreach(string option in extraOptions)
                { 
                    options.Add(option);
                }
            }
            return CIO.PromptForMenuSelection(options, false);
        }
        
        public static bool VerifyAction(string prompt = "Are you sure?")
        {
            return CIO.PromptForBool(prompt, "yes", "no");
        }


        /// <summary>
        /// Prompts the player for an ant type and the amount of ants 
        /// </summary>
        /// <param name="max">the max number of ants that the use can ask for</param>
        /// <returns>returns an array of length 2 that holds an ant type as an int in the first slot, and the amount in the second</returns>
        public static int[] SelectAntTypeAndAmount(int max)
        {
            int antType = SelectAntType("Please select an ant type to allocate")-1;

            int amount = SelectAmount(max);
            return [antType, amount];
        }

        public static int SelectAmount(int max)
        {
            if (max == 0)
            {
                throw new ArgumentException("Max cannot be 0");
            }
            return CIO.PromptForInt($"Type the amount of ants: (0 - {max})\n", 0, max);
        }

        public static int SelectCombatOptions() 
        { 
            string[] options = { "Fight", "Use Item", "Leave" };
            Print("Please select the options for this combat", true, ConsoleColor.Blue);
            return CIO.PromptForMenuSelection(options, false);
        }

        public static void PrintItems(List<BaseItem> itemList)
        {
            throw new NotImplementedException();
        }

        public static int SelectItem(List<BaseItem> itemList)
        {
            throw new NotImplementedException();
        }
 
        public static void PrintCombatScreen(List<BaseAnt> ants, List<Enemies> enemies)
        {
            throw new NotImplementedException();
        }

        public static List<BaseAnt> SelectAttackingAnts(List<BaseAnt> ants)
        {

            if (ants.Count() <= 0) { return new List<BaseAnt>(); }
            List<BaseAnt> selectedAnts = new List<BaseAnt>();

            do
            { 
                ClearScreen();
                Print("Select which ants you would like to attack", true, ConsoleColor.Blue);
                for (int i = 0; i < ants.Count(); i++)
                { 
                    Print($"{i + 1}: {ants[i]}", false);
                    if (selectedAnts.Contains(ants[i]))
                    {
                        Print(" - Selected", false, ConsoleColor.Green);
                    } 
                    Print("");
                }
                Print("\n0: End Selection");

                int response = CIO.PromptForInt($"(0-{ants.Count() + 1})\n",0, ants.Count()+1);
                if (response == 0)
                {
                    break;
                }
                if (selectedAnts.Contains(ants[response - 1]))
                {
                    selectedAnts.Remove(ants[response -1]);
                }else
                { 
                    selectedAnts.Add(ants[response - 1]);
                }
            } while (true);

            return selectedAnts;
        }

        public static Enemies SelectEnemy(List<Enemies> enemies) 
        {
            Print("Please Select an enemy to attack", true, ConsoleColor.Blue);
            for(int i = 0; i < enemies.Count(); i++)
            {
                Print($"{i + 1}: {enemies}"); 
            }
            Print($"0: Cancel Selection");
            int response = CIO.PromptForInt($"(0-{enemies.Count()})", 0, enemies.Count()+1);
            if (response == 0)
                return null;
            return enemies[response - 1]; 
        }

        
        /// <summary>
        /// Prompts the player for an ant type
        /// </summary>
        /// <param name="prompt">Changes the default prompt</param>
        /// <returns>returns an int for the type of ant, ranging from 0-2</returns>
        public static int SelectAntType(string prompt = "Please Select an ant type", bool AllowQuit = false)
        {
            Print(prompt, true, ConsoleColor.Blue);
            string[] antTypes = { "Worker Ant", "Leaf Cutter Ant", "Brood Ant" };
            return CIO.PromptForMenuSelection(antTypes, AllowQuit);
        }

        public static void PrintBar(int value, int total, int length = 20)
        {
            // [========(x/y)===|----]
            length = Math.Max(length, 10);
            string bar = "";
            int filledBarProportion = (value / total) * length;
            for(int i = 0; i < length; i++)
            { 
                if (i > filledBarProportion)
                    bar += "-"; 
                else if (i == filledBarProportion)
                    bar += "|"; 
                else if (i < filledBarProportion)
                    bar += "=";
            }
            int middleIndex = length / 2;
            bar.Insert(middleIndex, $"({value}/{total})");
            bar.Insert(0, "[");
            bar += "]";
            Print(bar);
        }
        
        public static void PrintTutorial()
        {
            // TODO: ADD TUTORIAL HERE
            Print("Play the game and figure it out");
        }

    } 
}
