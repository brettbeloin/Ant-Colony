using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
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
            List<string> options = new List<string>{"Gather Leaves", "Tend Aphid Farm", "Nourish Larvae", "Enter The Dungeon" };
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
            //ClearScreen();
            //PrintLogo();
            Print("You are in the dungeon, Do you wish to Fight or leave?");
            string[] options = { "Fight", "Leave" };
            Print("Please select the options for combat", true, ConsoleColor.Blue);
            return CIO.PromptForMenuSelection(options, false);
        }
 

        public static void PrintCombatScreen(List<BaseAnt> ants, List<Enemies> enemies)
        {
            StringBuilder enemyNames = new StringBuilder();
            StringBuilder enemyBars = new StringBuilder();
            StringBuilder enemyStats = new StringBuilder();
            Print("Enemies", foregroundColor:ConsoleColor.Red);
            foreach (Enemies enemy in enemies) 
            {
                string[] enemyBar = PrintBar(enemy.Health, enemy.MaxHealth, Label: $"{enemy.Name}", shouldPrint: false);
                enemyNames.Append(enemyBar[0]);
                enemyBars.Append(enemyBar[1]);
                string battleStats = $"{enemy.Stats.atk} : {enemy.Stats.def}";
                AlignText(enemyBar[0], ref battleStats);
                enemyStats.Append(battleStats);
            }
            

            Print(enemyNames.ToString(),foregroundColor:ConsoleColor.Red);
            Print(enemyBars.ToString(),foregroundColor:ConsoleColor.Red);
            Print(enemyStats.ToString(),foregroundColor:ConsoleColor.Red);

            PrintBar(AntManager.AntSwarm.Count, 10, Label: "Ants Remaining:" , displayColor: ConsoleColor.Green);

            Print($"Reminder:\n\tattack : defence\n\tDamage taken will kill ants", foregroundColor: ConsoleColor.Yellow);
            

        }

        public static List<BaseAnt> SelectAttackingAnts(List<BaseAnt> ants)
        {

            if (ants.Count() <= 0) { return new List<BaseAnt>(); }
            List<BaseAnt> selectedAnts = new List<BaseAnt>();

            do
            {
                ClearScreen();
                PrintLogo();
                Print($"Current Attack : Defence\t{DungeonManager.GetAttack(selectedAnts)} : {DungeonManager.GetDefence(selectedAnts)}");
                Print("Select which ants you would like to attack", true, ConsoleColor.Blue);
                for (int i = 0; i < ants.Count(); i++)
                { 
                    Print($"{i + 1}: {ants[i]}  ", false);
                    Print($"\t- {ants[i].GetAttackDamage()} : {ants[i].GetDefenceAmount()}", false, foregroundColor: ConsoleColor.Yellow);
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
            if (enemies.Count == 1) return enemies[0];
            ClearScreen();
            PrintLogo();
            Print("Please Select an enemy to attack", true, ConsoleColor.Blue);
            for(int i = 0; i < enemies.Count(); i++)
            {
                Print($"{i + 1}:");
                string[] bar = PrintBar(enemies[i].Health, enemies[i].MaxHealth, Label: enemies[i].Name, shouldPrint: false);
                string atkDefText = $"{enemies[i].Stats.atk} : {enemies[i].Stats.def}";
                AlignText(bar[1], ref atkDefText);
                Print("\t" + bar[0], foregroundColor: ConsoleColor.Red);
                Print("\t" + bar[1], foregroundColor: ConsoleColor.Red);
                Print("\t" + atkDefText, foregroundColor: ConsoleColor.Red);
            }
            Print($"0: Cancel Selection");
            int response = CIO.PromptForInt($"(0-{enemies.Count()})", 0, enemies.Count()+1);
            if (response == 0)
                return null;
            try
            { 
                return enemies[response - 1]; 
            }catch(ArgumentOutOfRangeException outRangeException)
            {
                return null;
            }
        }

        
        /// <summary>
        /// Prompts the player for an ant type
        /// </summary>
        /// <param name="prompt">Changes the default prompt</param>
        /// <returns>returns an int for the type of ant, ranging from 0-2</returns>
        public static int SelectAntType(string prompt = "Please Select an ant type", bool AllowQuit = false)
        {
            ClearScreen();
            PrintLogo();
            Print(prompt, true, ConsoleColor.Blue);
            string[] antTypes = { "Worker Ant", "Leaf Cutter Ant", "Brood Ant" };
            return CIO.PromptForMenuSelection(antTypes, AllowQuit);
        }

        /// <summary>
        /// Prints a bar like:"[========(x/y)===|----]"
        /// </summary>
        /// <param name="value">the filled proportion of the bar</param>
        /// <param name="total">the total of the bar</param>
        /// <param name="length">the length of the bar</param>
        /// <param name="Label">an optional label over the bar when it prints</param>
        /// <param name="showValues">shows the '(x/y)' of the bar in the center</param>
        /// <param name="displayColor">the color the bar is printed in</param>
        /// <returns>Returns an array of length 2, the first value is the label, if null it is "", the second is the bar itself</returns>
        public static string[] PrintBar(int value, int total, int length = 20, string? Label = null, bool showValues = true, ConsoleColor displayColor = ConsoleColor.White, bool shouldPrint = true)
        {
            // [========(x/y)===|----]
            length = Math.Max(length, 10);
            StringBuilder bar = new StringBuilder();
            int filledBarProportion = (int)(((float)value / total) * length);
            for(int i = 0; i < length; i++)
            { 
                if (i > filledBarProportion)
                    bar.Append("-"); 
                else if (i == filledBarProportion)
                    bar.Append("|"); 
                else if (i < filledBarProportion)
                    bar.Append("=");
            }
            if (showValues)
            { 
                int middleIndex = length / 2;
                string visibleNumbers = $"({value}/{total})";
                bar.Remove(middleIndex-(visibleNumbers.Length/2), visibleNumbers.Length); 
                bar.Insert(middleIndex-(visibleNumbers.Length/2), visibleNumbers);
            }
            bar.Insert(0, "[");
            bar.Append("]");


            string barText = bar.ToString();
            if (!String.IsNullOrEmpty(Label)) 
            {
                AlignText(a: barText, b: ref Label);
                if(shouldPrint)
                    Print(Label, true, foregroundColor: displayColor);
            }
            if(shouldPrint)
                Print(bar.ToString(), foregroundColor: displayColor);
            string[] returnValue = { Label!=null ? Label : "", barText }; 
            return returnValue;
        }
        public static void AlignText(string a, ref string b)
        {
            if (a.Length < b.Length)
            {
                throw new ArgumentException("reference to string a cannot be larger than refernce to string b");
            }
            StringBuilder text = new StringBuilder();
            //string smallerString = a.Length < b.Length ? a : b;
            //string largerString = a.Length >= b.Length ? a : b;
            int paddingAmount = (a.Length / 2) - (b.Length / 2);

            for(int padding = 0; padding < paddingAmount; padding++)
            {
                text.Append(" ");
            }
            text.Append(b);
            for (int length = text.Length; length < a.Length; length++) 
            {
                text.Append(" ");
            }
            b = text.ToString();
        }
        
        public static void PrintTutorial()
        {
            // TODO: ADD TUTORIAL HERE
            ClearScreen();
            PrintLogo();
            WorkerAnt tempWorker = new WorkerAnt();
            LeafCutterAnt tempLeaf = new LeafCutterAnt();
            BroodAnt tempBrood = new BroodAnt();
            Print($"""
                Ant Colony is a game split into 2 main gameplay loops
                The Resource Managment and the Dungeon Crawler parts.

                The Resource Management is centered around getting as many ants as possible
                    You need to spend ants to do get leaves and tend aphid farms, 
                    then you can spend ants tending to the larvae to grow into more ants later
                    
                The Dungeon Crawler is equally important. Each ant levels up as the dungeon progresses
                It is important to have a powerful battle squadron because in a few in game days
                your colony will be invaded.

                Resource Management:
                    * The amount of each resource you get is determined by the type of ant you send to get the resource and amount of ants sent.
                    * when you run out of ants to command the day ends.
                    * ants are refilled at the end of day.
                    * at the end of day larvae grow.
                    
                Combat:
                    * When you enter the dungeon, you will be asked to send what ants you want.
                        -> You may loose these ants permanently if they die.
                        -> You can have a max of 10 ants in the dungeon at any given point
                    * Your health bar for combat is the amount of ants you have.
                    * Getting hit permanently kills an ant.
                    * You choose attacking ants, the rest will be blocking.
                    * blocked damage does not kill ants.
                    * The amount of turns you get per combat is decided by the amount of ants you have.

                Ant Stats:
                    (base damage : base defence)
                    Worker ants:
                        {tempWorker.BASE_DAMAGE} : {tempWorker.BASE_DEFENCE}
                        Worker ant is better with the aphid farms 
                    Leaf Cutter ants:
                        {tempLeaf.BASE_DAMAGE} : {tempLeaf.BASE_DEFENCE}
                        Leaf Cutter ants are better at gathering leaves 
                    Brood ants:
                        {tempBrood.BASE_DAMAGE} : {tempBrood.BASE_DEFENCE}
                        Brood ants are better at tending to larvae
                """);
            bool isReady = VerifyAction("Are you ready to play?");
            if (!isReady)
                PrintTutorial();
        }

    } 
}
