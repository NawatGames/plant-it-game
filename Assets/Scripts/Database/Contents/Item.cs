using System;
using InventorySystem.NewInventorySystem;
using UnityEngine;

namespace Database.Contents
{
    [Serializable]
    public class Item 
    {
        public enum Categories
        {
            Other = 1,
            Tool = 2,
            Fertilizer = 3,
            Seed = 4,
            Product = 5
        }

        public enum Rarity
        {
            Common = 1,
            Uncommon = 2,
            Rare = 3,
            Epic = 4 ,
            Legendary = 5
        }
        
        // Database properties
        public string itemName;
        public Categories category;
        public Rarity itemRarity;
        // UI properties
        public Texture2D itemTexture;
        // Shop properties
        public int sellPrice;
        public int buyPrice;

        public Item(string line)
        {
            var segments = line.Split(",");
            // Database properties
            itemName = segments[0];
            int categoryInt = 1;
            int.TryParse(segments[1], out categoryInt);
            category = (Categories) categoryInt;
            int rarityInt = 1;
            int.TryParse(segments[3], out rarityInt);
            itemRarity = (Rarity) rarityInt;
            // 
            // ****** Missing itemTexture load *******
            //
            // Shop properties
            int.TryParse(segments[4], out sellPrice);
            int.TryParse(segments[5], out buyPrice);
        }
    }
}