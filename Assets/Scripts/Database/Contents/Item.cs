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
        
        public string itemName;
        public Categories category;
        public Texture2D itemTexture;
        public Rarity itemRarity = Rarity.Common;
        public int sellPrice = -1;
        public int buyPrice = -1;

        public Item(string line)
        {
            var segments = line.Split(",");
            itemName = segments[0];
            int rarityInt = 1;
            int categoryInt = 1;
            int.TryParse(segments[1], out categoryInt);
            category = (Categories) categoryInt;
            int.TryParse(segments[3], out rarityInt);
            itemRarity = (Rarity) rarityInt;
            int.TryParse(segments[4], out sellPrice);
            int.TryParse(segments[5], out buyPrice);
        }
    }
}