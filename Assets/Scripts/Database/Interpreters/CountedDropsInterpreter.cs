using System;
using System.Collections.Generic;
using System.Linq;
using Database.Contents;
using UnityEngine;

namespace Database.Interpreters
{
    public class CountedDropsInterpreter
    {
        public TextAsset countedDropsDatabase;
        [SerializeField] private List<CountedDrops> items = new List<CountedDrops>();
        public CountedDropsInterpreter()
        {
            var text = countedDropsDatabase.text;
            
            // Splits the CSV into lines
            var lines = text.Split('\n').ToList();
            
            // Removes invalid lines
            lines.RemoveAt(0);
            lines.RemoveAt(lines.Count - 1);
            
            // Creates a fertilizer item for each line
            foreach (var line in lines)
            {
                Debug.Log(line);
                CountedDrops item = new CountedDrops(line);
                items.Add(item);
            }
        }
        
        public CountedDrops GetItem(int id)
        {
            return items.FirstOrDefault(countedDrops => countedDrops.id == id);
        }
    }
}