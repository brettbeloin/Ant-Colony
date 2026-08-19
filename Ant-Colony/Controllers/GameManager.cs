using Ant_Colony.Models;
using Ant_Colony.View;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ant_Colony.Controllers
{
    public static class GameManager
    {
        public static void Run()
        {
            Menu.Print("Welcome To");
            do
            {
                Console.Clear();
                Menu.PrintLogo();
                DisplayStats();
                int response = Menu.MainMenu();
                HandleMainMenuResponse(response); 
            } while (true);
        }
        public static void DisplayStats()
        {
            string[] stats =
            [
                "Resources :",
                $"\tLeaves : {ResourceManager.Leaves}",
                $"\tFood : {ResourceManager.Food}",
                "Ants :",
                $"\tTotal Worker Ants : {AntManager.VirtWorkerAntAmount}",
                $"\tUsed Worker Ants : {AntManager.UsedVirtWorkerAnt}",
                $"\tTotal Leaf Cutter Ants : {AntManager.VirtLeafCutterAntAmount}",
                $"\tUsed Leaf Cutter Ants : {AntManager.UsedVirtLeafCutterAnt}",
                $"\tTotal Brood Ants : {AntManager.VirtBroodAntAmount}",
                $"\tUsed Broot Ants : {AntManager.UsedVirtBroodAnt}",
                $"\tLarvae : {AntManager.Larvae}",
            ];
            Menu.PrintStats(stats);
        }
        public static void HandleMainMenuResponse(int response) 
        {
            switch (response) 
            {
                case 1:
                    GatherLeaves();
                    break;
                case 2:
                    TendFarm(); 
                    break;
                case 3:
                    FeedLarvae();
                    break;
                case 4:
                    EnterDungeon();
                    break;
                default: return;
            }
        }

        public static void GatherLeaves()
        {
            int[] allocation = Menu.SelectAntTypeAndAmount(AntManager.CountAnts());
            int antCount = allocation[1];
            int antTypeInt = allocation[0];

            int effeciency = 1;
            //BaseAnt antType = AntManager.GetAntTypeFromInt(antTypeInt);
            //effeciency = ((BaseAnt)antType).GatherAmount();
            
            ResourceManager.GatherLeaves(antCount, effeciency);
        } 

        public static void TendFarm()
        {

            int[] allocation = Menu.SelectAntTypeAndAmount(AntManager.CountAnts());
            int antCount = allocation[1];
            int antTypeInt = allocation[0];

            int effeciency = 1;
            ResourceManager.GatherFood(antCount, effeciency);
        }

        public static void FeedLarvae()
        { 
            int[] allocation = Menu.SelectAntTypeAndAmount(AntManager.CountAnts());
            int antCount = allocation[1];
            int antTypeInt = allocation[0];

            int effeciency = 1;
            AntManager.TendLarvae(antCount, effeciency);
        }

        public static void EnterDungeon()
        {
            Menu.Print("Unfortunantly, this Has not been completed yet", true, ConsoleColor.Red); 
        }
    }
}
