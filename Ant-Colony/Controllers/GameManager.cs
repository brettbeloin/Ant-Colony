using Ant_Colony.Models;
using Ant_Colony.View;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Ant_Colony.Controllers
{
    public static class GameManager
    {

        private static int daysUntilFinalBoss = 7;

        private static OverworldEvents currentEvent = OverworldEvents.NO_EVENT;
        public static void Run() 
        {
            Menu.PrintBar(3, 7, 30, Label: "stinyPoppy");
            string[]? extraOptions = { "Set Demo Stats", "Tutorial"};
            Menu.Print("Welcome To");
            do
            {
                if (currentEvent != OverworldEvents.NO_EVENT)
                {
                    extraOptions = [ "Event" ];
                }
                Menu.PrintLogo();
                DisplayStats();
                int response = Menu.MainMenu(extraOptions);
                HandleMainMenuResponse(response);
                if (AntManager.CountAnts() == 0)
                {
                    SetMenuScreen();
                    EndDay();
                }
                extraOptions = null;
            } while (true);
        }
        
        public static void EndDay()
        {
            daysUntilFinalBoss--;
            AntManager.GrowLarvae();
            AntManager.DeallocateAnts();
        }

        public static void DisplayStats()
        {
            string[] stats =
            [
                $"Days Remaining : {daysUntilFinalBoss}",
                "Resources :",
                $"\tLeaves : {ResourceManager.Leaves}",
                $"\tFood : {ResourceManager.Food}",
                "Ants :",
                $"\tBattle Swarm : {AntManager.AntSwarm.Count}",
                $"\tWorker Ants : {AntManager.VirtWorkerAntAmount-AntManager.UsedVirtWorkerAnt}/{AntManager.VirtWorkerAntAmount}",
                $"\tLeaf Cutter Ants : {AntManager.VirtLeafCutterAntAmount-AntManager.UsedVirtLeafCutterAnt}/{AntManager.VirtLeafCutterAntAmount}",
                $"\tBrood Ants : {AntManager.VirtBroodAntAmount-AntManager.UsedVirtBroodAnt}/{AntManager.VirtBroodAntAmount}",
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
                case 5:
                    AntManager.SetDemoConfig();
                    break;
                default: return;
            }
        }

        public static void RunFinalBoss()
        {

        }

        public static void SetMenuScreen()
        {
            Menu.ClearScreen();
            Menu.PrintLogo();
            DisplayStats();
        }


        public static void GatherLeaves()
        {
            SetMenuScreen();
            int[] allocation = AntManager.AllocateAnts();
            int antCount = allocation[1];
            int antTypeInt = allocation[0];

            int effeciency = 1;
            effeciency = AntManager.InstantiateAnt(antTypeInt).GATHER_AMOUNT;
            
            ResourceManager.GatherLeaves(antCount, effeciency);
        } 

        public static void TendFarm()
        {
            SetMenuScreen();
            int[] allocation = AntManager.AllocateAnts();
            int antCount = allocation[1];
            int antTypeInt = allocation[0];

            int effeciency = 1;
            ResourceManager.GatherFood(antCount, effeciency);
        }
 
        public static void FeedLarvae()
        {
            SetMenuScreen();
            int[] allocation = AntManager.AllocateAnts();
            int antCount = allocation[1];
            int antTypeInt = allocation[0];

            int effeciency = 1;
            AntManager.TendLarvae(antCount, effeciency);
        }

        public static void EnterDungeon()
        {
            new DungeonManager().RunDungeon();
        }
    }
}
