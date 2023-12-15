using System;
using System.Collections.Generic;
using System.Linq;
using Database.Contents;
using UnityEngine;

namespace Database.Interpreters
{
    public class GuaranteedDropsInterpreter
    {
        public TextAsset guaranteedDropsDatabase;
        [SerializeField] private List<GuaranteedDrops> items = new List<GuaranteedDrops>();
        public GuaranteedDropsInterpreter()
        {
            var text = guaranteedDropsDatabase.text;
            
            // Splits the CSV into lines
            var lines = text.Split('\n').ToList();
            
            // Removes invalid lines
            lines.RemoveAt(0);
            lines.RemoveAt(lines.Count - 1);
            
            // Creates a fertilizer item for each line
            foreach (var line in lines)
            {
                Debug.Log(line);
                GuaranteedDrops item = new GuaranteedDrops(line);
                items.Add(item);
            }
        }
        
        public GuaranteedDrops GetItem(int id)
        {
            return items.FirstOrDefault(guaranteedDrops => guaranteedDrops.id == id);
        }
    }
}