using System;
using UnityEngine;

namespace Database.Contents
{
    [Serializable]
    public class Seed
    {
        public enum Rarity
        {
            Common = 1,
            Uncommon = 2,
            Rare = 3,
            Epic = 4 ,
            Legendary = 5
        }   
        // Database properties
        public string seedName;
        public Rarity seedRarity;
        // Growth properties
        public int growthTime;
        public bool growsOnWinter;
        public bool growsOnSpring;
        public bool growsOnSummer;
        public bool growsOnFall;
        // Drops
        public int avgYield;
        public int yieldVariation;
        // Plant Consumption
        public int waterConsumption;
        public int nitrogenConsumption;
        public int potassiumConsumption;
        public int phosphorusConsumption;
        public int ironConsumption;
        public int zincConsumption;
        public int magnesiumConsumption;
        // Needed Nutrients
        public bool needsWater;
        public bool needsNitrogen;
        public bool needsPotassium;
        public bool needsPhosphorus;
        public bool needsIron;
        public bool needsZinc;
        public bool needsMagnesium;

        public Seed(string line)
        {
            // Database properties
            var segments = line.Split(",");
            seedName = segments[0];
            int rarityInt = 1;
            int.TryParse(segments[1], out rarityInt);
            seedRarity = (Rarity) rarityInt;
            // Growth properties
            int.TryParse(segments[2], out growthTime);
            bool.TryParse(segments[3], out growsOnWinter);
            bool.TryParse(segments[4], out growsOnSummer);
            bool.TryParse(segments[5], out growsOnSpring);
            bool.TryParse(segments[6], out growsOnFall);
            // Drops
            int.TryParse(segments[7], out avgYield);
            int.TryParse(segments[8], out yieldVariation);
            // Plant Consumption
            int.TryParse(segments[9], out waterConsumption);
            int.TryParse(segments[10], out nitrogenConsumption);
            int.TryParse(segments[11], out potassiumConsumption);
            int.TryParse(segments[12], out phosphorusConsumption);
            int.TryParse(segments[13], out ironConsumption);
            int.TryParse(segments[14], out zincConsumption);
            int.TryParse(segments[15], out magnesiumConsumption);
            // Needed Nutrients
            bool.TryParse(segments[16], out needsWater);
            bool.TryParse(segments[17], out needsNitrogen);
            bool.TryParse(segments[18], out needsPotassium);
            bool.TryParse(segments[19], out needsPhosphorus);
            bool.TryParse(segments[20], out needsIron);
            bool.TryParse(segments[21], out needsZinc);
            bool.TryParse(segments[22], out needsMagnesium);
        }
    }
}