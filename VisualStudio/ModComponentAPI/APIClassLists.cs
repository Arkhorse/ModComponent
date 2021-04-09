﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModComponentAPI
{
    public static class APIClassLists
    {
        public static readonly string[] Behaviours = new string[]
        {
            "ModAccelerantComponent",
            "ModFireStarterComponent",
            "ModBurnableComponent",
            "ModEvolveComponent",
            "ModHarvestableComponent",
            "ModMillableComponent",
            "ModRepairableComponent",
            "ModScentComponent",
            "ModSharpenableComponent",
            "ModStackableComponent"
        };
        public static readonly string[] Components = new string[]
        {
            "ModGenericComponent",
            "ModBedComponent",
            "ModBodyHarvestComponent",
            "ModClothingComponent",
            "ModCookableComponent",
            "ModCookingPotComponent",
            "ModExplosiveComponent",
            "ModFirstAidComponent",
            "ModFoodComponent",
            "ModLiquidComponent",
            "ModPowderComponent",
            "ModRifleComponent",
            "ModToolComponent"
        };
        public static bool IsBehaviour(string className) => Behaviours.Contains<string>(className);
        public static bool IsComponent(string className) => Components.Contains<string>(className);
        public static int GetNumberOfBehaviours(string[] classList)
        {
            int count = 0;
            foreach(string className in classList)
            {
                if (IsBehaviour(className)) count++;
            }
            return count;
        }
        public static int GetNumberOfComponents(string[] classList)
        {
            int count = 0;
            foreach (string className in classList)
            {
                if (IsComponent(className)) count++;
            }
            return count;
        }
        public static bool ContainsBehaviour(string[] classList)
        {
            foreach (string className in classList)
            {
                if (IsBehaviour(className)) return true;
            }
            return false;
        }
        public static bool ContainsComponent(string[] classList)
        {
            foreach (string className in classList)
            {
                if (IsComponent(className)) return true;
            }
            return false;
        }
    }
}
