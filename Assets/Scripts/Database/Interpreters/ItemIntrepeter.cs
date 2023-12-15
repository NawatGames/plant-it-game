using System;
using System.Collections.Generic;
using System.Linq;
using Database.Contents;
using UnityEngine;

namespace Database.Interpreters
{
    public class ItemIntrepeter
    {
        public TextAsset itemDatabase;
        [SerializeField] private List<Item> items = new List<Item>();
        public ItemIntrepeter()
        {
            var text = itemDatabase.text;
            
            // Splits the CSV into lines
            var lines = text.Split('\n').ToList();
            
            // Removes invalid lines
            lines.RemoveAt(0);
            lines.RemoveAt(lines.Count - 1);
            
            // Creates an item for each line
            foreach (var line in lines)
            {
                Debug.Log(line);
                Item item = new Item(line);
                items.Add(item);
            }
        }
        
        public Item GetItem(string itemName)
        {
            return items.FirstOrDefault(item => item.itemName == itemName);
        }
    }
}